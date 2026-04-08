[CmdletBinding()]
param(
    [string]$GiteaBaseUrl = 'https://gitea.syncfusion.com',

    [string]$Owner = 'essential-studio',

    [string]$ControlName,

    [Parameter(Mandatory = $true)]
    [ValidateSet('lookup', 'info', 'list')]
    [string]$Operation,

    [int]$Top = 50
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-Json {
    param([Parameter(Mandatory = $true)]$Object)
    $Object | ConvertTo-Json -Depth 20
}

function Get-GiteaHeaders {
    $token = $env:GITEA_TOKEN
    if ([string]::IsNullOrWhiteSpace($token)) {
        throw 'GITEA_TOKEN is not set. Set it as an environment variable before running.'
    }
    return @{
        Authorization = "token $token"
        Accept        = 'application/json'
    }
}

function Invoke-Gitea {
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('GET', 'POST')]
        [string]$Method,

        [Parameter(Mandatory = $true)]
        [string]$Uri
    )

    $headers = Get-GiteaHeaders
    $request = @{
        Method  = $Method
        Uri     = $Uri
        Headers = $headers
    }
    Invoke-RestMethod @request
}

function Resolve-Context {
    $resolvedBaseUrl = $GiteaBaseUrl
    $resolvedOwner = $Owner

    if ([string]::IsNullOrWhiteSpace($resolvedBaseUrl)) {
        $resolvedBaseUrl = $env:GITEA_BASE_URL
    }
    if ([string]::IsNullOrWhiteSpace($resolvedOwner)) {
        $resolvedOwner = $env:GITEA_OWNER
    }
    if ([string]::IsNullOrWhiteSpace($resolvedBaseUrl) -or [string]::IsNullOrWhiteSpace($resolvedOwner)) {
        throw 'Base URL and Owner are required. Provide params or set GITEA_BASE_URL and GITEA_OWNER.'
    }
    $resolvedBaseUrl = $resolvedBaseUrl.TrimEnd('/')
    return @{
        BaseUrl = $resolvedBaseUrl
        Owner   = $resolvedOwner
    }
}

# ─── Map control name to test repo name ───────────────────────────────────────
function Get-TestRepoName {
    param([string]$Control)
    # Direct mapping: SfTabView -> SfTabView-MAUI-tests
    return "$Control-MAUI-tests"
}

# ─── Map control repo name to test repo name ──────────────────────────────────
function Get-TestRepoFromControlRepo {
    param([string]$ControlRepo)
    # maui-tabview -> SfTabView-MAUI-tests
    $parts = $ControlRepo -replace '^maui-', '' -split '-'
    $pascalName = ($parts | ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1).ToLower() }) -join ''
    return "Sf$pascalName-MAUI-tests"
}

# ─── Resolve context ──────────────────────────────────────────────────────────
$ctx = Resolve-Context
$baseApi = "$($ctx.BaseUrl)/api/v1"

switch ($Operation) {

    'lookup' {
        if ([string]::IsNullOrWhiteSpace($ControlName)) {
            throw "ControlName is required for 'lookup' operation."
        }

        $repoName = Get-TestRepoName -Control $ControlName
        $uri = "$baseApi/repos/$($ctx.Owner)/$repoName"

        try {
            $repo = Invoke-Gitea -Method GET -Uri $uri
            Write-Json @{
                operation  = 'lookup'
                found      = $true
                repoName   = $repoName
                fullName   = $repo.full_name
                cloneUrl   = $repo.clone_url
                htmlUrl    = $repo.html_url
                defaultBranch = $repo.default_branch
                description   = $repo.description
                updatedAt     = $repo.updated_at
            }
        }
        catch {
            $statusCode = $_.Exception.Response.StatusCode.value__
            if ($statusCode -eq 404) {
                Write-Json @{
                    operation = 'lookup'
                    found     = $false
                    repoName  = $repoName
                    message   = "Test repository '$repoName' does not exist under '$($ctx.Owner)'."
                    suggestion = "Use the appium-project-creation skill to scaffold a new test project."
                }
            }
            else {
                throw
            }
        }
    }

    'info' {
        if ([string]::IsNullOrWhiteSpace($ControlName)) {
            throw "ControlName is required for 'info' operation."
        }

        $repoName = Get-TestRepoName -Control $ControlName
        $repoUri = "$baseApi/repos/$($ctx.Owner)/$repoName"
        $branchesUri = "$baseApi/repos/$($ctx.Owner)/$repoName/branches?limit=20"

        try {
            $repo = Invoke-Gitea -Method GET -Uri $repoUri
            $branches = Invoke-Gitea -Method GET -Uri $branchesUri

            $branchNames = @($branches | ForEach-Object { $_.name })

            Write-Json @{
                operation      = 'info'
                repoName       = $repoName
                fullName       = $repo.full_name
                cloneUrl       = $repo.clone_url
                htmlUrl        = $repo.html_url
                defaultBranch  = $repo.default_branch
                description    = $repo.description
                stars          = $repo.stars_count
                forks          = $repo.forks_count
                openIssues     = $repo.open_issues_count
                openPRs        = $repo.open_pr_counter
                size           = $repo.size
                createdAt      = $repo.created_at
                updatedAt      = $repo.updated_at
                branches       = $branchNames
            }
        }
        catch {
            $statusCode = $_.Exception.Response.StatusCode.value__
            if ($statusCode -eq 404) {
                Write-Json @{
                    operation = 'info'
                    found     = $false
                    repoName  = $repoName
                    message   = "Test repository '$repoName' does not exist."
                }
            }
            else {
                throw
            }
        }
    }

    'list' {
        $uri = "$baseApi/orgs/$($ctx.Owner)/repos?limit=$Top&type=sources"

        try {
            $repos = Invoke-Gitea -Method GET -Uri $uri
            $testRepos = @($repos | Where-Object { $_.name -like '*-MAUI-tests' })

            Write-Json @{
                operation  = 'list'
                totalRepos = @($repos).Count
                testRepos  = @($testRepos | ForEach-Object {
                    @{
                        name          = $_.name
                        htmlUrl       = $_.html_url
                        cloneUrl      = $_.clone_url
                        defaultBranch = $_.default_branch
                        updatedAt     = $_.updated_at
                    }
                })
                testRepoCount = @($testRepos).Count
            }
        }
        catch {
            # If org endpoint fails, try user repos
            $uri2 = "$baseApi/users/$($ctx.Owner)/repos?limit=$Top"
            $repos = Invoke-Gitea -Method GET -Uri $uri2
            $testRepos = @($repos | Where-Object { $_.name -like '*-MAUI-tests' })

            Write-Json @{
                operation  = 'list'
                totalRepos = @($repos).Count
                testRepos  = @($testRepos | ForEach-Object {
                    @{
                        name          = $_.name
                        htmlUrl       = $_.html_url
                        cloneUrl      = $_.clone_url
                        defaultBranch = $_.default_branch
                        updatedAt     = $_.updated_at
                    }
                })
                testRepoCount = @($testRepos).Count
            }
        }
    }
}

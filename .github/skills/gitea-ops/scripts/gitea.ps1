[CmdletBinding()]
param(
    [string]$GiteaBaseUrl = 'https://gitea.syncfusion.com',

    [string]$Owner = 'essential-studio',

    [string]$Repository = 'maui-tabview',

    [Parameter(Mandatory = $true)]
    [ValidateSet('list', 'get', 'create', 'update', 'close', 'delete', 'get-pr', 'list-pr-files', 'pr-diff', 'create-pr', 'create-review-comment', 'post-pr-comment')]
    [string]$Operation,

    [ValidateRange(1, 1000)]
    [int]$Top = 50,

    [int]$IssueNumber,

    [int]$PullNumber,

    [string]$Title,

    [string]$Body,

    [ValidateSet('open', 'closed')]
    [string]$State,

    [string]$FilePath,

    [int]$Line,

    [ValidateSet('APPROVED', 'REQUEST_CHANGES', 'COMMENT')]
    [string]$ReviewAction,

    [string]$HeadBranch,

    [string]$BaseBranch = 'development'
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
        Accept = 'application/json'
    }
}

function Require-Value {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,
        [Parameter(Mandatory = $true)]
        [AllowNull()]
        [AllowEmptyString()]
        [object]$Value
    )

    if ($null -eq $Value -or [string]::IsNullOrWhiteSpace([string]$Value)) {
        throw "$Name is required for operation '$Operation'."
    }
}

function Require-PositiveInt {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Name,
        [Parameter(Mandatory = $true)]
        [int]$Value
    )

    if ($Value -le 0) {
        throw "$Name must be a positive integer for operation '$Operation'."
    }
}

function Resolve-GiteaContext {
    $resolvedBaseUrl = $GiteaBaseUrl
    $resolvedOwner = $Owner
    $resolvedRepository = $Repository

    if ([string]::IsNullOrWhiteSpace($resolvedBaseUrl)) {
        $resolvedBaseUrl = $env:GITEA_BASE_URL
    }

    if ([string]::IsNullOrWhiteSpace($resolvedOwner)) {
        $resolvedOwner = $env:GITEA_OWNER
    }

    if ([string]::IsNullOrWhiteSpace($resolvedRepository)) {
        $resolvedRepository = $env:GITEA_REPO
    }

    if ([string]::IsNullOrWhiteSpace($resolvedBaseUrl) -or [string]::IsNullOrWhiteSpace($resolvedOwner) -or [string]::IsNullOrWhiteSpace($resolvedRepository)) {
        throw 'Base URL, Owner, and Repository are required. Provide params or set GITEA_BASE_URL, GITEA_OWNER, and GITEA_REPO.'
    }

    $resolvedBaseUrl = $resolvedBaseUrl.TrimEnd('/')

    return @{
        BaseUrl    = $resolvedBaseUrl
        Owner      = $resolvedOwner
        Repository = $resolvedRepository
    }
}

function Invoke-Gitea {
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('GET', 'POST', 'PATCH', 'DELETE')]
        [string]$Method,

        [Parameter(Mandatory = $true)]
        [string]$Uri,

        [object]$Body
    )

    $headers = Get-GiteaHeaders

    $request = @{
        Method  = $Method
        Uri     = $Uri
        Headers = $headers
    }

    if ($PSBoundParameters.ContainsKey('Body')) {
        $request.Body = if ($Body -is [string]) { $Body } else { $Body | ConvertTo-Json -Depth 20 }
        $request.ContentType = 'application/json'
    }

    Invoke-RestMethod @request
}

$context = Resolve-GiteaContext
$GiteaBaseUrl = $context.BaseUrl
$Owner = $context.Owner
$Repository = $context.Repository

$issuesBase = "$GiteaBaseUrl/api/v1/repos/$Owner/$Repository/issues"
$pullsBase = "$GiteaBaseUrl/api/v1/repos/$Owner/$Repository/pulls"

switch ($Operation) {
    'list' {
        $uri = "$issuesBase?limit=$Top&state=all"
        $result = Invoke-Gitea -Method GET -Uri $uri

        Write-Json @{
            operation = 'list'
            count     = @($result).Count
            items     = $result
        }
    }

    'get' {
        Require-PositiveInt -Name 'IssueNumber' -Value $IssueNumber

        $uri = "$issuesBase/$IssueNumber"
        $result = Invoke-Gitea -Method GET -Uri $uri

        Write-Json @{
            operation = 'get'
            item      = $result
        }
    }

    'create' {
        Require-Value -Name 'Title' -Value $Title

        $payload = @{ title = $Title }
        if (-not [string]::IsNullOrWhiteSpace($Body)) {
            $payload.body = $Body
        }

        $result = Invoke-Gitea -Method POST -Uri $issuesBase -Body $payload

        Write-Json @{
            operation = 'create'
            item      = $result
        }
    }

    'update' {
        Require-PositiveInt -Name 'IssueNumber' -Value $IssueNumber

        if ([string]::IsNullOrWhiteSpace($Title) -and [string]::IsNullOrWhiteSpace($Body) -and [string]::IsNullOrWhiteSpace($State)) {
            throw 'For update, provide at least one of: Title, Body, State.'
        }

        $payload = @{}

        if (-not [string]::IsNullOrWhiteSpace($Title)) {
            $payload.title = $Title
        }

        if (-not [string]::IsNullOrWhiteSpace($Body)) {
            $payload.body = $Body
        }

        if (-not [string]::IsNullOrWhiteSpace($State)) {
            $payload.state = $State
        }

        $uri = "$issuesBase/$IssueNumber"
        $result = Invoke-Gitea -Method PATCH -Uri $uri -Body $payload

        Write-Json @{
            operation = 'update'
            item      = $result
        }
    }

    'close' {
        Require-PositiveInt -Name 'IssueNumber' -Value $IssueNumber

        $uri = "$issuesBase/$IssueNumber"
        $payload = @{ state = 'closed' }
        $result = Invoke-Gitea -Method PATCH -Uri $uri -Body $payload

        Write-Json @{
            operation = 'close'
            item      = $result
        }
    }

    'delete' {
        Require-PositiveInt -Name 'IssueNumber' -Value $IssueNumber

        $uri = "$issuesBase/$IssueNumber"
        $null = Invoke-Gitea -Method DELETE -Uri $uri

        Write-Json @{
            operation   = 'delete'
            issueNumber = $IssueNumber
            deleted     = $true
        }
    }

    'get-pr' {
        Require-PositiveInt -Name 'PullNumber' -Value $PullNumber

        $uri = "$pullsBase/$PullNumber"
        $result = Invoke-Gitea -Method GET -Uri $uri

        Write-Json @{
            operation = 'get-pr'
            item      = $result
        }
    }

    'list-pr-files' {
        Require-PositiveInt -Name 'PullNumber' -Value $PullNumber

        $uri = "$pullsBase/$PullNumber/files?limit=$Top"
        $result = Invoke-Gitea -Method GET -Uri $uri

        Write-Json @{
            operation = 'list-pr-files'
            count     = @($result).Count
            items     = $result
        }
    }

    'pr-diff' {
        Require-PositiveInt -Name 'PullNumber' -Value $PullNumber

        $headers = Get-GiteaHeaders
        $headers.Accept = 'text/plain'
        $uri = "$pullsBase/$PullNumber.diff"
        $result = Invoke-RestMethod -Method GET -Uri $uri -Headers $headers

        # Output raw diff text (not JSON)
        $result
    }

    'create-review-comment' {
        Require-PositiveInt -Name 'PullNumber' -Value $PullNumber
        Require-Value -Name 'Body' -Value $Body

        $payload = @{ body = $Body }

        if (-not [string]::IsNullOrWhiteSpace($FilePath)) {
            $payload.path = $FilePath
        }

        if ($Line -gt 0) {
            $payload.new_position = $Line
        }

        $uri = "$pullsBase/$PullNumber/reviews"

        # Create a single-comment review
        $reviewPayload = @{
            body = $Body
            event = if (-not [string]::IsNullOrWhiteSpace($ReviewAction)) { $ReviewAction } else { 'COMMENT' }
        }

        if (-not [string]::IsNullOrWhiteSpace($FilePath)) {
            $reviewPayload.comments = @(
                @{
                    path         = $FilePath
                    body         = $Body
                    new_position = if ($Line -gt 0) { $Line } else { 1 }
                }
            )
        }

        $result = Invoke-Gitea -Method POST -Uri $uri -Body $reviewPayload

        Write-Json @{
            operation = 'create-review-comment'
            item      = $result
        }
    }

    'post-pr-comment' {
        Require-PositiveInt -Name 'PullNumber' -Value $PullNumber
        Require-Value -Name 'Body' -Value $Body

        # Post a general comment on the PR (uses the issues comment endpoint since PRs are issues in Gitea)
        $uri = "$issuesBase/$PullNumber/comments"
        $payload = @{ body = $Body }
        $result = Invoke-Gitea -Method POST -Uri $uri -Body $payload

        Write-Json @{
            operation = 'post-pr-comment'
            item      = $result
        }
    }

    'create-pr' {
        Require-Value -Name 'Title' -Value $Title
        Require-Value -Name 'HeadBranch' -Value $HeadBranch

        $payload = @{
            title = $Title
            head  = $HeadBranch
            base  = $BaseBranch
        }

        if (-not [string]::IsNullOrWhiteSpace($Body)) {
            $payload.body = $Body
        }

        $result = Invoke-Gitea -Method POST -Uri $pullsBase -Body $payload

        Write-Json @{
            operation = 'create-pr'
            item      = $result
        }
    }
}

[CmdletBinding()]
param(
    [string]$Organization = 'EssentialStudio',

    [string]$Project = 'Mobile and Desktop',

    [string]$OrganizationUrl,

    [Parameter(Mandatory = $true)]
    [ValidateSet('list', 'get', 'create', 'update', 'delete')]
    [string]$Operation,

    [ValidateRange(1, 1000)]
    [int]$Top = 50,

    [int]$WorkItemId,

    [string]$WorkItemType = 'Bug',

    [string]$Title,

    [string]$Description,

    [string]$AreaPath,

    [string]$State,

    [switch]$Destroy
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-Json {
    param([Parameter(Mandatory = $true)]$Object)
    $Object | ConvertTo-Json -Depth 20
}

function Get-AdoHeaders {
    $pat = $env:AZDO_PAT
    if ([string]::IsNullOrWhiteSpace($pat)) {
        throw 'AZDO_PAT is not set. Set it as an environment variable before running.'
    }

    $token = [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(":" + $pat))
    return @{
        Authorization = "Basic $token"
        Accept = 'application/json'
    }
}

function Resolve-AdoContext {
    $resolvedOrganization = $Organization
    $resolvedProject = $Project

    if ([string]::IsNullOrWhiteSpace($resolvedOrganization)) {
        $resolvedOrganization = $env:AZDO_ORGANIZATION
    }

    if ([string]::IsNullOrWhiteSpace($resolvedProject)) {
        $resolvedProject = $env:AZDO_PROJECT
    }

    if (-not [string]::IsNullOrWhiteSpace($OrganizationUrl)) {
        $uri = [Uri]$OrganizationUrl

        if ([string]::IsNullOrWhiteSpace($resolvedOrganization)) {
            if ($uri.Host -ieq 'dev.azure.com') {
                $segments = @($uri.AbsolutePath.Trim('/') -split '/')
                if ($segments.Count -ge 1 -and -not [string]::IsNullOrWhiteSpace($segments[0])) {
                    $resolvedOrganization = $segments[0]
                }
            } elseif ($uri.Host -like '*.visualstudio.com') {
                $resolvedOrganization = $uri.Host.Split('.')[0]
            }
        }

        if ([string]::IsNullOrWhiteSpace($resolvedProject)) {
            $segments = @($uri.AbsolutePath.Trim('/') -split '/')
            if ($uri.Host -ieq 'dev.azure.com' -and $segments.Count -ge 2 -and -not [string]::IsNullOrWhiteSpace($segments[1])) {
                $resolvedProject = $segments[1]
            }
        }
    }

    if ([string]::IsNullOrWhiteSpace($resolvedOrganization) -or [string]::IsNullOrWhiteSpace($resolvedProject)) {
        throw 'Organization and Project are required. Provide -Organization and -Project, or use -OrganizationUrl with project in the URL, or set AZDO_ORGANIZATION and AZDO_PROJECT.'
    }

    return @{
        Organization = $resolvedOrganization
        Project      = $resolvedProject
    }
}

function Invoke-Ado {
    param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('GET', 'POST', 'PATCH', 'DELETE')]
        [string]$Method,

        [Parameter(Mandatory = $true)]
        [string]$Uri,

        [object]$Body,

        [switch]$JsonPatch
    )

    $headers = Get-AdoHeaders

    $request = @{
        Method  = $Method
        Uri     = $Uri
        Headers = $headers
    }

    if ($PSBoundParameters.ContainsKey('Body')) {
        $request.Body = if ($Body -is [string]) { $Body } else { $Body | ConvertTo-Json -Depth 20 }
    }

    if ($JsonPatch) {
        $request.ContentType = 'application/json-patch+json'
    } elseif ($PSBoundParameters.ContainsKey('Body')) {
        $request.ContentType = 'application/json'
    }

    Invoke-RestMethod @request
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

$context = Resolve-AdoContext
$Organization = $context.Organization
$Project = $context.Project
$base = "https://dev.azure.com/$Organization/$Project/_apis"

switch ($Operation) {
    'list' {
        $wiqlUri = "$base/wit/wiql?api-version=7.1-preview.2"

        $conditions = @()
        if (-not [string]::IsNullOrWhiteSpace($WorkItemType)) {
            $conditions += "[System.WorkItemType] = '$WorkItemType'"
        }
        if (-not [string]::IsNullOrWhiteSpace($AreaPath)) {
            $conditions += "[System.AreaPath] UNDER '$AreaPath'"
        }
        if (-not [string]::IsNullOrWhiteSpace($State)) {
            $conditions += "[System.State] = '$State'"
        }

        $wiql = 'Select [System.Id] From WorkItems'
        if ($conditions.Count -gt 0) {
            $wiql += ' Where ' + ($conditions -join ' AND ')
        }
        $wiql += ' Order By [System.ChangedDate] Desc'

        $query = @{
            query = $wiql
        }

        $wiqlResult = Invoke-Ado -Method POST -Uri $wiqlUri -Body $query
        $ids = @($wiqlResult.workItems | Select-Object -ExpandProperty id -First $Top)

        if ($ids.Count -eq 0) {
            Write-Json @{ operation = 'list'; count = 0; items = @() }
            break
        }

        $idParam = ($ids -join ',')
        $workItemsUri = "$base/wit/workitems?ids=$idParam&`$expand=Relations&api-version=7.1-preview.3"
        $workItems = Invoke-Ado -Method GET -Uri $workItemsUri

        Write-Json @{
            operation = 'list'
            count     = @($workItems.value).Count
            items     = $workItems.value
        }
    }

    'get' {
        Require-PositiveInt -Name 'WorkItemId' -Value $WorkItemId

        $uri = "$base/wit/workitems/$WorkItemId?`$expand=Relations&api-version=7.1-preview.3"
        $result = Invoke-Ado -Method GET -Uri $uri

        Write-Json @{
            operation = 'get'
            item      = $result
        }
    }

    'create' {
        Require-Value -Name 'Title' -Value $Title

        $uri = "$base/wit/workitems/`$$WorkItemType?api-version=7.1-preview.3"
        $ops = @(
            @{ op = 'add'; path = '/fields/System.Title'; value = $Title }
        )

        if (-not [string]::IsNullOrWhiteSpace($Description)) {
            $ops += @{ op = 'add'; path = '/fields/System.Description'; value = $Description }
        }

        $result = Invoke-Ado -Method PATCH -Uri $uri -Body $ops -JsonPatch

        Write-Json @{
            operation = 'create'
            item      = $result
        }
    }

    'update' {
        Require-PositiveInt -Name 'WorkItemId' -Value $WorkItemId

        if ([string]::IsNullOrWhiteSpace($Title) -and [string]::IsNullOrWhiteSpace($Description)) {
            throw 'For update, provide at least one of: Title, Description.'
        }

        $uri = "$base/wit/workitems/$WorkItemId?api-version=7.1-preview.3"
        $ops = @()

        if (-not [string]::IsNullOrWhiteSpace($Title)) {
            $ops += @{ op = 'add'; path = '/fields/System.Title'; value = $Title }
        }

        if (-not [string]::IsNullOrWhiteSpace($Description)) {
            $ops += @{ op = 'add'; path = '/fields/System.Description'; value = $Description }
        }

        $result = Invoke-Ado -Method PATCH -Uri $uri -Body $ops -JsonPatch

        Write-Json @{
            operation = 'update'
            item      = $result
        }
    }

    'delete' {
        Require-PositiveInt -Name 'WorkItemId' -Value $WorkItemId

        $destroyParam = if ($Destroy) { 'true' } else { 'false' }
        $uri = "$base/wit/workitems/$WorkItemId`?destroy=$destroyParam&api-version=7.1-preview.3"
        $null = Invoke-Ado -Method DELETE -Uri $uri

        Write-Json @{
            operation  = 'delete'
            workItemId = $WorkItemId
            destroyed  = [bool]$Destroy
            deleted    = $true
        }
    }
}

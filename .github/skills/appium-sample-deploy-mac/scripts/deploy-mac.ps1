[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$AppPath,

    [Parameter(Mandatory = $true)]
    [string]$MacAppId,

    [string]$Framework = 'net9.0-maccatalyst',

    [string]$Configuration = 'Debug',

    [switch]$SkipBuild
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-Status {
    param([string]$Message, [string]$Type = 'INFO')
    $symbol = switch ($Type) {
        'OK'    { '✅' }
        'WARN'  { '⚠️' }
        'ERR'   { '❌' }
        'WAIT'  { '⏳' }
        default { 'ℹ️' }
    }
    Write-Host "$symbol $Message"
}

function Write-Json {
    param([Parameter(Mandatory = $true)]$Object)
    $Object | ConvertTo-Json -Depth 10
}

# ─── Check platform ───────────────────────────────────────────────────────────
if (-not $IsMacOS) {
    Write-Status "macOS (Mac Catalyst) deployment requires macOS." -Type ERR
    exit 1
}

# ─── Validate inputs ──────────────────────────────────────────────────────────
if (-not (Test-Path $AppPath)) {
    Write-Status "App path not found: $AppPath" -Type ERR
    exit 1
}

$csprojFiles = Get-ChildItem -Path $AppPath -Filter '*.csproj' -File
if ($csprojFiles.Count -eq 0) {
    Write-Status "No .csproj file found in $AppPath" -Type ERR
    exit 1
}

# ─── Check Xcode tools ────────────────────────────────────────────────────────
$xcodeSelect = Get-Command 'xcode-select' -ErrorAction SilentlyContinue
if (-not $xcodeSelect) {
    Write-Status "Xcode Command Line Tools not found. Run: xcode-select --install" -Type ERR
    exit 1
}

# ─── Determine architecture ───────────────────────────────────────────────────
$arch = & uname -m 2>&1
if ($arch -match 'arm64') {
    $runtimeArch = 'maccatalyst-arm64'
} else {
    $runtimeArch = 'maccatalyst-x64'
}

Write-Status "Detected architecture: $arch → $runtimeArch" -Type INFO

# ─── Build ─────────────────────────────────────────────────────────────────────
$appBundlePath = Join-Path $AppPath "bin/$Configuration/$Framework/$runtimeArch/$MacAppId.app"

if (-not $SkipBuild) {
    Write-Status "Building Mac Catalyst app ($Configuration)..." -Type WAIT

    $buildCmd = "dotnet build -f $Framework -c $Configuration"

    Push-Location $AppPath
    try {
        Invoke-Expression $buildCmd
        if ($LASTEXITCODE -ne 0) {
            Write-Status "Build failed with exit code $LASTEXITCODE" -Type ERR
            exit $LASTEXITCODE
        }
    }
    finally {
        Pop-Location
    }

    Write-Status "Build completed successfully." -Type OK
} else {
    Write-Status "Skipping build (SkipBuild flag set)." -Type INFO
}

# ─── Verify .app bundle ───────────────────────────────────────────────────────
# Check both arm64 and x64 paths
$appBundlePathArm = Join-Path $AppPath "bin/$Configuration/$Framework/maccatalyst-arm64/$MacAppId.app"
$appBundlePathX64 = Join-Path $AppPath "bin/$Configuration/$Framework/maccatalyst-x64/$MacAppId.app"

if (Test-Path $appBundlePath) {
    Write-Status ".app bundle found: $appBundlePath" -Type OK
} elseif (Test-Path $appBundlePathArm) {
    $appBundlePath = $appBundlePathArm
    Write-Status ".app bundle found (arm64): $appBundlePath" -Type OK
} elseif (Test-Path $appBundlePathX64) {
    $appBundlePath = $appBundlePathX64
    Write-Status ".app bundle found (x64): $appBundlePath" -Type OK
} else {
    Write-Status ".app bundle not found at expected paths:" -Type ERR
    Write-Host "  arm64: $appBundlePathArm"
    Write-Host "  x64:   $appBundlePathX64"
    exit 1
}

# ─── Remove quarantine attribute ──────────────────────────────────────────────
Write-Status "Removing quarantine attribute..." -Type WAIT
& xattr -cr $appBundlePath 2>&1 | Out-Null
Write-Status "Quarantine attribute removed." -Type OK

# ─── Output summary ───────────────────────────────────────────────────────────
$summary = @{
    status        = 'success'
    platform      = 'maccatalyst'
    macAppId      = $MacAppId
    appBundlePath = $appBundlePath
    architecture  = $runtimeArch
    appPath       = $AppPath
}

Write-Host ""
Write-Json $summary

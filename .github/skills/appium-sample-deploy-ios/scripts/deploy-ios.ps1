[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$AppPath,

    [Parameter(Mandatory = $true)]
    [string]$ApplicationId,

    [string]$DeviceId = 'A345178C-6D96-4B7E-83BD-266E3B81B0F7'

    [string]$Framework = 'net9.0-ios',

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

# ─── Resolve Device ID ────────────────────────────────────────────────────────
if ([string]::IsNullOrWhiteSpace($DeviceId)) {
    $DeviceId = $env:SIMID
}

if ([string]::IsNullOrWhiteSpace($DeviceId)) {
    Write-Status "No DeviceId provided and SIMID environment variable is not set." -Type ERR
    Write-Host ""
    Write-Host "  Provide -DeviceId parameter or set the SIMID environment variable:"
    Write-Host "    export SIMID=<simulator-udid>"
    Write-Host ""
    Write-Host "  To list available simulators:"
    Write-Host "    xcrun simctl list devices available"
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

# ─── Check xcrun availability ─────────────────────────────────────────────────
$xcrunPath = Get-Command xcrun -ErrorAction SilentlyContinue
if (-not $xcrunPath) {
    Write-Status "xcrun not found. Install Xcode Command Line Tools: xcode-select --install" -Type ERR
    exit 1
}

# ─── Check if macOS ───────────────────────────────────────────────────────────
if (-not $IsMacOS) {
    Write-Status "iOS Simulator deployment requires macOS." -Type ERR
    exit 1
}

# ─── Boot Simulator ───────────────────────────────────────────────────────────
Write-Status "Checking simulator status for device $DeviceId..." -Type WAIT

$deviceStatus = & xcrun simctl list devices 2>&1 | Select-String -Pattern $DeviceId
if (-not $deviceStatus) {
    Write-Status "Device $DeviceId not found in simulator list." -Type ERR
    Write-Host "  Run 'xcrun simctl list devices available' to see available devices."
    exit 1
}

if ($deviceStatus -match 'Booted') {
    Write-Status "Simulator $DeviceId is already booted." -Type OK
} else {
    Write-Status "Booting simulator $DeviceId..." -Type WAIT
    & xcrun simctl boot $DeviceId 2>&1 | Out-Null
    & open -a Simulator 2>&1 | Out-Null

    # Wait for boot
    $maxWait = 60
    $elapsed = 0
    while ($elapsed -lt $maxWait) {
        $status = & xcrun simctl list devices 2>&1 | Select-String -Pattern $DeviceId
        if ($status -match 'Booted') {
            break
        }
        Start-Sleep -Seconds 5
        $elapsed += 5
        Write-Status "Waiting for simulator to boot... ($elapsed s)" -Type WAIT
    }

    if ($elapsed -ge $maxWait) {
        Write-Status "Simulator did not boot within $maxWait seconds." -Type ERR
        exit 1
    }

    Write-Status "Simulator booted successfully." -Type OK
}

# ─── Build ─────────────────────────────────────────────────────────────────────
$appBundlePath = Join-Path $AppPath "bin/$Configuration/$Framework/iossimulator-x64/$ApplicationId.app"

if (-not $SkipBuild) {
    Write-Status "Building iOS app ($Configuration)..." -Type WAIT

    $buildCmd = "dotnet build -f $Framework -p:_DeviceName=:v2:udid=$DeviceId"

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

# ─── Verify .app bundle exists ────────────────────────────────────────────────
# Also check arm64 path for Apple Silicon
$appBundlePathArm = Join-Path $AppPath "bin/$Configuration/$Framework/iossimulator-arm64/$ApplicationId.app"

if (Test-Path $appBundlePath) {
    Write-Status ".app bundle found: $appBundlePath" -Type OK
} elseif (Test-Path $appBundlePathArm) {
    Write-Status ".app bundle found (arm64): $appBundlePathArm" -Type OK
    $appBundlePath = $appBundlePathArm
} else {
    Write-Status ".app bundle not found at expected paths:" -Type ERR
    Write-Host "  x64:   $appBundlePath"
    Write-Host "  arm64: $appBundlePathArm"
    exit 1
}

# ─── Install on Simulator ─────────────────────────────────────────────────────
Write-Status "Installing app on simulator $DeviceId..." -Type WAIT

$installResult = & xcrun simctl install $DeviceId $appBundlePath 2>&1
$installOutput = $installResult -join "`n"

if ($LASTEXITCODE -ne 0) {
    Write-Status "Install failed: $installOutput" -Type ERR
    exit 1
}

Write-Status "App installed successfully." -Type OK

# ─── Output summary ───────────────────────────────────────────────────────────
$summary = @{
    status        = 'success'
    platform      = 'ios'
    applicationId = $ApplicationId
    deviceId      = $DeviceId
    appBundlePath = $appBundlePath
    appPath       = $AppPath
}

Write-Host ""
Write-Json $summary

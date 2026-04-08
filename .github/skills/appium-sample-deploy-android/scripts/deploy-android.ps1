[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$AppPath,

    [Parameter(Mandatory = $true)]
    [string]$AppId,

    [string]$KeyStore = 'key.keystore',

    [string]$KeyAlias = 'MauiAlias',

    [string]$KeyPass = 'kanna007',

    [string]$StorePass = 'kanna007',

    [string]$Framework = 'net9.0-android',

    [string]$Configuration = 'Release',

    [switch]$SkipBuild,

    [switch]$Replace
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

# ─── Check adb availability ───────────────────────────────────────────────────
$adbPath = Get-Command adb -ErrorAction SilentlyContinue
if (-not $adbPath) {
    Write-Status "adb not found on PATH. Install Android SDK platform-tools." -Type ERR
    exit 1
}

# ─── Check emulator/device connectivity ───────────────────────────────────────
Write-Status "Checking connected Android devices..." -Type WAIT
$devices = & adb devices 2>&1
$connectedDevices = ($devices -split "`n" | Where-Object { $_ -match '\t(device|emulator)$' })

if ($connectedDevices.Count -eq 0) {
    Write-Status "No Android devices/emulators connected. Start an emulator or connect a device." -Type ERR
    Write-Host ""
    Write-Host "  To list available AVDs:  emulator -list-avds"
    Write-Host "  To start an AVD:         emulator -avd <avd_name> &"
    exit 1
}

Write-Status "Found $($connectedDevices.Count) connected device(s)." -Type OK

# ─── Build ─────────────────────────────────────────────────────────────────────
$apkPath = Join-Path $AppPath "bin/$Configuration/$Framework/publish/$AppId-Signed.apk"

if (-not $SkipBuild) {
    Write-Status "Building Android APK ($Configuration)..." -Type WAIT

    $buildCmd = "dotnet publish -f $Framework -c $Configuration" +
                " -p:AndroidKeyStore=true" +
                " -p:AndroidSigningKeyStore=$KeyStore" +
                " -p:AndroidSigningKeyAlias=$KeyAlias" +
                " -p:AndroidSigningKeyPass=$KeyPass" +
                " -p:AndroidSigningStorePass=$StorePass"

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

# ─── Verify APK exists ────────────────────────────────────────────────────────
if (-not (Test-Path $apkPath)) {
    Write-Status "Signed APK not found at: $apkPath" -Type ERR
    Write-Host "  Check your AppId and build output."
    exit 1
}

Write-Status "APK found: $apkPath" -Type OK

# ─── Install APK ──────────────────────────────────────────────────────────────
Write-Status "Installing APK on device..." -Type WAIT

$installArgs = @('install')
if ($Replace) {
    $installArgs += '-r'
}
$installArgs += $apkPath

$installResult = & adb @installArgs 2>&1
$installOutput = $installResult -join "`n"

if ($installOutput -match 'Success') {
    Write-Status "APK installed successfully." -Type OK
} elseif ($installOutput -match 'INSTALL_FAILED_ALREADY_EXISTS') {
    Write-Status "App already installed. Retrying with -r (replace) flag..." -Type WARN
    $installResult = & adb install -r $apkPath 2>&1
    $installOutput = $installResult -join "`n"
    if ($installOutput -match 'Success') {
        Write-Status "APK replaced successfully." -Type OK
    } else {
        Write-Status "Install failed: $installOutput" -Type ERR
        exit 1
    }
} else {
    Write-Status "Install failed: $installOutput" -Type ERR
    exit 1
}

# ─── Verify installation ──────────────────────────────────────────────────────
Write-Status "Verifying installation..." -Type WAIT
$pkgCheck = & adb shell pm list packages 2>&1
if ($pkgCheck -match [regex]::Escape($AppId)) {
    Write-Status "Package '$AppId' is installed on the device." -Type OK
} else {
    Write-Status "Package '$AppId' not found on device after install." -Type WARN
}

# ─── Output summary ───────────────────────────────────────────────────────────
$summary = @{
    status   = 'success'
    platform = 'android'
    appId    = $AppId
    apkPath  = $apkPath
    appPath  = $AppPath
}

Write-Host ""
Write-Json $summary

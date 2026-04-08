[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$AppPath,

    [Parameter(Mandatory = $true)]
    [string]$AppName,

    [string]$Framework = 'net9.0-windows10.0.19041.0',

    [string]$Configuration = 'Release',

    [switch]$Packaged,

    [switch]$SkipBuild
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-Status {
    param([string]$Message, [string]$Type = 'INFO')
    $symbol = switch ($Type) {
        'OK'    { [char]0x2705 }
        'WARN'  { [char]0x26A0 }
        'ERR'   { [char]0x274C }
        'WAIT'  { [char]0x23F3 }
        default { [char]0x2139 }
    }
    Write-Host "$symbol $Message"
}

function Write-Json {
    param([Parameter(Mandatory = $true)]$Object)
    $Object | ConvertTo-Json -Depth 10
}

# ─── Check platform ───────────────────────────────────────────────────────────
if (-not $IsWindows) {
    Write-Status "Windows deployment requires Windows OS." -Type ERR
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

# ─── Determine build mode ─────────────────────────────────────────────────────
$packageType = if ($Packaged) { '' } else { '-p:WindowsPackageType=None' }
$outputDir = Join-Path $AppPath "bin/$Configuration/$Framework/win10-x64"

# ─── Build ─────────────────────────────────────────────────────────────────────
if (-not $SkipBuild) {
    if ($Packaged) {
        Write-Status "Building Windows MSIX package ($Configuration)..." -Type WAIT
        $buildCmd = "dotnet publish -f $Framework -c $Configuration"
    } else {
        Write-Status "Building Windows unpackaged app ($Configuration)..." -Type WAIT
        $buildCmd = "dotnet build -f $Framework -c $Configuration $packageType"
    }

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

# ─── Verify build output ──────────────────────────────────────────────────────
if ($Packaged) {
    # Look for MSIX in AppPackages
    $appPackagesDir = Join-Path $outputDir 'AppPackages'
    if (Test-Path $appPackagesDir) {
        $msixFile = Get-ChildItem -Path $appPackagesDir -Filter '*.msix' -Recurse | Select-Object -First 1
        if ($msixFile) {
            Write-Status "MSIX package found: $($msixFile.FullName)" -Type OK

            # Install MSIX
            Write-Status "Installing MSIX package..." -Type WAIT
            try {
                Add-AppPackage -Path $msixFile.FullName -AllowUnsigned
                Write-Status "MSIX package installed." -Type OK
            } catch {
                Write-Status "MSIX install failed: $_" -Type ERR
                Write-Host "  Ensure Developer Mode is enabled in Windows Settings."
                exit 1
            }

            $summary = @{
                status      = 'success'
                platform    = 'windows'
                mode        = 'packaged'
                appName     = $AppName
                msixPath    = $msixFile.FullName
                appPath     = $AppPath
            }
        } else {
            Write-Status "No .msix file found in $appPackagesDir" -Type ERR
            exit 1
        }
    } else {
        Write-Status "AppPackages directory not found at $appPackagesDir" -Type ERR
        exit 1
    }
} else {
    # Unpackaged — look for .exe
    $exePath = Join-Path $outputDir "$AppName.exe"

    if (-not (Test-Path $exePath)) {
        # Try without win10-x64 subfolder
        $altOutputDir = Join-Path $AppPath "bin/$Configuration/$Framework"
        $exePath = Join-Path $altOutputDir "$AppName.exe"
    }

    if (Test-Path $exePath) {
        Write-Status "Executable found: $exePath" -Type OK
    } else {
        Write-Status "Executable not found: $AppName.exe" -Type ERR
        Write-Host "  Searched in: $outputDir"
        Write-Host "  Ensure AppName matches the project assembly name."
        exit 1
    }

    $summary = @{
        status      = 'success'
        platform    = 'windows'
        mode        = 'unpackaged'
        appName     = $AppName
        exePath     = $exePath
        appPath     = $AppPath
    }
}

# ─── Output summary ───────────────────────────────────────────────────────────
Write-Host ""
Write-Json $summary

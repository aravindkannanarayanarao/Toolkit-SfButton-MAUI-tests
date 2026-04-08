````skill
---
name: appium-sample-deploy-windows
description: Builds and deploys a MAUI sample app on Windows for Appium UI testing. Handles dotnet build targeting WinUI (net9.0-windows10.0.19041.0), MSIX package registration, and app launch verification. Use when you need to deploy a MAUI app on Windows before running Appium tests.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 9+, Windows 10/11, and Windows App SDK.
---

# Appium Sample Deploy — Windows

This skill builds a .NET MAUI app for Windows (WinUI 3), publishes an unpackaged or MSIX build, and prepares it for Appium UI testing on Windows.

## What This Skill Does

1. **Validates prerequisites** — Checks for Windows environment, .NET SDK, and project path
2. **Builds the app** — Runs `dotnet build` or `dotnet publish` targeting Windows
3. **Registers/installs the app** — Handles MSIX sideloading or unpackaged deployment
4. **Verifies the build output** — Confirms the executable exists and is launchable

## Prerequisites

| Requirement | Details |
|-------------|---------|
| Windows | Windows 10 (build 19041+) or Windows 11 |
| .NET SDK | 9.0 or later with MAUI workload installed |
| Windows App SDK | Installed (ships with Visual Studio or MAUI workload) |
| Developer Mode | Enabled in Windows Settings (for sideloading MSIX) |

## Inputs Required

| Input | Required | Default | Description |
|-------|----------|---------|-------------|
| AppPath | Yes | — | Absolute path to the MAUI project directory (contains `.csproj`) |
| AppName | Yes | — | Windows process/app name (e.g., `AccordionTestBed`) — used for Appium WinAppDriver |
| Framework | No | `net9.0-windows10.0.19041.0` | Target framework moniker |
| Configuration | No | `Release` | Build configuration (`Debug` or `Release`) |
| Unpackaged | No | `false` | If true, builds as unpackaged (no MSIX) |

## Step-by-Step Execution

### Step 1: Verify Windows Environment

Ensure developer mode is enabled for sideloading:

```powershell
# Check developer mode
reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\AppModelUnlock" /v AllowDevelopmentWithoutDevLicense
# Value should be 0x1
```

### Step 2: Build the App for Windows

#### Option A: Unpackaged Build (Simpler for Testing)

```powershell
cd {AppPath}
dotnet build -f net9.0-windows10.0.19041.0 -c Release -p:WindowsPackageType=None
```

Output executable:
```
{AppPath}\bin\Release\net9.0-windows10.0.19041.0\win10-x64\{AppName}.exe
```

#### Option B: MSIX Packaged Build

```powershell
cd {AppPath}
dotnet publish -f net9.0-windows10.0.19041.0 -c Release
```

Output MSIX:
```
{AppPath}\bin\Release\net9.0-windows10.0.19041.0\win10-x64\AppPackages\
```

### Build Parameters Explained

| Parameter | Purpose |
|-----------|---------|
| `-f net9.0-windows10.0.19041.0` | Target WinUI framework (minimum Windows 10 build 19041) |
| `-c Release` | Build configuration |
| `-p:WindowsPackageType=None` | Unpackaged mode — produces an `.exe` directly |

### Step 3: Register/Install the App

#### Unpackaged (exe)
No installation needed — the `.exe` can be launched directly:

```powershell
Start-Process "{AppPath}\bin\Release\net9.0-windows10.0.19041.0\win10-x64\{AppName}.exe"
```

#### MSIX Packaged
Install the MSIX package:

```powershell
# Find the generated msix/msixbundle
$msixPath = Get-ChildItem -Path "{AppPath}\bin\Release\net9.0-windows10.0.19041.0\win10-x64\AppPackages" -Filter "*.msix" -Recurse | Select-Object -First 1

# Install
Add-AppPackage -Path $msixPath.FullName -AllowUnsigned
```

### Step 4: Verify the Build Output

```powershell
# Unpackaged — check exe exists
Test-Path "{AppPath}\bin\Release\net9.0-windows10.0.19041.0\win10-x64\{AppName}.exe"

# MSIX — check package is registered
Get-AppxPackage | Where-Object { $_.Name -like "*{AppName}*" }
```

### Step 5: Launch the App (Optional)

```powershell
# Unpackaged
Start-Process "{AppPath}\bin\Release\net9.0-windows10.0.19041.0\win10-x64\{AppName}.exe"

# MSIX — launch via protocol or Start menu
```

## Using the Deploy Script

A PowerShell script is provided for automated deployment:

```powershell
# Full build + launch verification (unpackaged)
pwsh .github/skills/appium-sample-deploy-windows/scripts/deploy-windows.ps1 `
  -AppPath C:\Projects\MauiProject `
  -AppName AccordionTestBed

# MSIX packaged build
pwsh .github/skills/appium-sample-deploy-windows/scripts/deploy-windows.ps1 `
  -AppPath C:\Projects\MauiProject `
  -AppName AccordionTestBed `
  -Packaged

# Skip build, just verify existing output
pwsh .github/skills/appium-sample-deploy-windows/scripts/deploy-windows.ps1 `
  -AppPath C:\Projects\MauiProject `
  -AppName AccordionTestBed `
  -SkipBuild
```

## Troubleshooting

| Issue | Resolution |
|-------|------------|
| `Developer Mode not enabled` | Settings → Update & Security → For developers → Enable Developer Mode |
| `BUILD FAILED` on Windows TFM | Run `dotnet workload install maui-windows` |
| `.exe` not found after build | Check `bin\Release\net9.0-windows10.0.19041.0\win10-x64\` folder |
| WinAppDriver cannot find app | Ensure `AppName` matches the process name (without `.exe`) |
| MSIX install fails | Enable Developer Mode or sign the package with a trusted certificate |
| `Platform not supported` | This skill requires Windows — use `appium-sample-deploy-mac` for macOS |

## Appium WinAppDriver Configuration

For Appium tests on Windows, the `BaseTest.cs` uses the `AppName` property:

```csharp
if (_testDevice == TestDevice.Windows)
{
    config.SetProperty("AppName", "{AppName}");
}
```

WinAppDriver uses this to attach to the running process.

## Integration with Other Skills

| Skill | Integration Point |
|-------|-------------------|
| **appium-project-creation** | Creates the test project that runs against the deployed app |
| **bugsample-creation** | Generates the bug reproduction pages inside the MAUI app |
| **appium-sample-deploy-android** | Android counterpart of this skill |
| **appium-sample-deploy-ios** | iOS counterpart of this skill |
| **appium-sample-deploy-mac** | macOS counterpart of this skill |

## Notes

- WinAppDriver must be running for Appium tests: `"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe"`
- For CI pipelines, use unpackaged builds to avoid MSIX signing complexity.
- The script path from the repo root is `.github/skills/appium-sample-deploy-windows/scripts/deploy-windows.ps1`.
````

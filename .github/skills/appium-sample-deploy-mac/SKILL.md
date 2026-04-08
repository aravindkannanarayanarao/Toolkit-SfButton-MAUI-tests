````skill
---
name: appium-sample-deploy-mac
description: Builds and deploys a MAUI sample app on macOS (Mac Catalyst) for Appium UI testing. Handles dotnet build targeting net9.0-maccatalyst, app bundle generation, and launch verification. Use when you need to deploy a MAUI app on macOS before running Appium tests.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 9+, macOS 13+, and Xcode Command Line Tools.
---

# Appium Sample Deploy — macOS (Mac Catalyst)

This skill builds a .NET MAUI app for macOS via Mac Catalyst, produces the `.app` bundle, and prepares it for Appium UI testing on macOS.

## What This Skill Does

1. **Validates prerequisites** — Checks for macOS environment, .NET SDK, Xcode tools, and project path
2. **Builds the app** — Runs `dotnet build` targeting `net9.0-maccatalyst`
3. **Verifies the build output** — Confirms the `.app` bundle exists
4. **Launches the app** — Optionally opens the app for Appium to connect

## Prerequisites

| Requirement | Details |
|-------------|---------|
| macOS | 13 (Ventura) or later |
| .NET SDK | 9.0 or later with MAUI workload installed |
| Xcode | Installed with Command Line Tools |
| Security | May need to allow unsigned apps in System Preferences → Privacy & Security |

## Inputs Required

| Input | Required | Default | Description |
|-------|----------|---------|-------------|
| AppPath | Yes | — | Absolute path to the MAUI project directory (contains `.csproj`) |
| MacAppId | Yes | — | macOS bundle identifier (e.g., `com.companyname.accordiontestbed`) |
| Framework | No | `net9.0-maccatalyst` | Target framework moniker |
| Configuration | No | `Debug` | Build configuration (`Debug` or `Release`) |

## Step-by-Step Execution

### Step 1: Verify macOS Environment

```bash
# Verify Xcode tools
xcode-select -p
# Should return a path like /Applications/Xcode.app/Contents/Developer

# Verify .NET MAUI workload
dotnet workload list
# Should include maui-maccatalyst
```

### Step 2: Build the App for Mac Catalyst

Navigate to the MAUI project directory and build:

```bash
cd {AppPath} && dotnet build -f net9.0-maccatalyst -c Debug
```

#### Build Parameters Explained

| Parameter | Purpose |
|-----------|---------|
| `-f net9.0-maccatalyst` | Target Mac Catalyst framework |
| `-c Debug` | Debug configuration (or `Release` for production builds) |

The `.app` bundle will be produced at:
```
{AppPath}/bin/Debug/net9.0-maccatalyst/maccatalyst-arm64/{MacAppId}.app
```

On Intel Macs:
```
{AppPath}/bin/Debug/net9.0-maccatalyst/maccatalyst-x64/{MacAppId}.app
```

### Step 3: Grant Execution Permission (if needed)

macOS may quarantine unsigned apps. Remove the quarantine attribute:

```bash
xattr -cr {AppPath}/bin/Debug/net9.0-maccatalyst/maccatalyst-arm64/{MacAppId}.app
```

### Step 4: Launch the App

```bash
open {AppPath}/bin/Debug/net9.0-maccatalyst/maccatalyst-arm64/{MacAppId}.app
```

Or launch via bundle ID:

```bash
open -b {MacAppId}
```

### Step 5: Verify the App is Running

```bash
pgrep -f {MacAppId}
```

Or check running processes:

```bash
ps aux | grep {MacAppId}
```

## Using the Deploy Script

A PowerShell script is provided for automated deployment:

```bash
# Full build + launch
pwsh .github/skills/appium-sample-deploy-mac/scripts/deploy-mac.ps1 \
  -AppPath /path/to/MauiProject \
  -MacAppId com.companyname.accordiontestbed

# Release build
pwsh .github/skills/appium-sample-deploy-mac/scripts/deploy-mac.ps1 \
  -AppPath /path/to/MauiProject \
  -MacAppId com.companyname.accordiontestbed \
  -Configuration Release

# Skip build, just verify existing output
pwsh .github/skills/appium-sample-deploy-mac/scripts/deploy-mac.ps1 \
  -AppPath /path/to/MauiProject \
  -MacAppId com.companyname.accordiontestbed \
  -SkipBuild
```

## Troubleshooting

| Issue | Resolution |
|-------|------------|
| `BUILD FAILED` on maccatalyst | Run `dotnet workload install maui-maccatalyst` |
| `.app` bundle not found | Check `bin/Debug/net9.0-maccatalyst/maccatalyst-arm64/` (or `maccatalyst-x64` on Intel) |
| `App is damaged and can't be opened` | Run `xattr -cr` on the `.app` bundle to clear quarantine |
| App crashes on launch | Check Console.app for crash logs; ensure all entitlements are correct |
| `xcrun: error` | Install Xcode Command Line Tools: `xcode-select --install` |
| `Platform not supported` | This skill requires macOS — use `appium-sample-deploy-windows` for Windows |

## Appium Mac2 Driver Configuration

For Appium tests on macOS, the `BaseTest.cs` uses the `MacApp` property:

```csharp
if (_testDevice == TestDevice.Mac)
{
    config.SetProperty("MacApp", "{MacAppId}");
}
```

The Appium Mac2 driver uses the bundle ID to connect to the running app.

## Integration with Other Skills

| Skill | Integration Point |
|-------|-------------------|
| **appium-project-creation** | Creates the test project that runs against the deployed app |
| **bugsample-creation** | Generates the bug reproduction pages inside the MAUI app |
| **appium-sample-deploy-android** | Android counterpart of this skill |
| **appium-sample-deploy-ios** | iOS counterpart of this skill |
| **appium-sample-deploy-windows** | Windows counterpart of this skill |

## Notes

- Mac Catalyst apps run as native macOS apps built from iOS code — they use `UIKit` under the hood.
- On Apple Silicon Macs, the output architecture is `maccatalyst-arm64`. On Intel, it is `maccatalyst-x64`.
- For Appium testing, use the Mac2 driver which connects via the bundle ID.
- The `EnterFullScreen()` / `ExitFullScreen()` helpers in test `[SetUp]` / `[TearDown]` are important for consistent macOS screenshots.
- The script path from the repo root is `.github/skills/appium-sample-deploy-mac/scripts/deploy-mac.ps1`.
````

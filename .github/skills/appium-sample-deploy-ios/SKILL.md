````skill
---
name: appium-sample-deploy-ios
description: Builds and deploys a MAUI sample app to an iOS Simulator for Appium UI testing. Handles dotnet build targeting iOS simulator, app installation via xcrun simctl, and simulator readiness checks. Use when you need to deploy a MAUI app on iOS before running Appium tests.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 9+, Xcode with iOS Simulator, xcrun, and macOS.
---

# Appium Sample Deploy — iOS

This skill builds a .NET MAUI app for iOS Simulator, installs the `.app` bundle via `xcrun simctl`, and verifies it is ready for Appium UI testing.

## What This Skill Does

1. **Validates prerequisites** — Checks for Xcode, iOS Simulator availability, and project path
2. **Boots the simulator** — Ensures the target simulator device is booted and accessible
3. **Builds the app** — Runs `dotnet build` targeting `net9.0-ios` for the simulator device
4. **Installs the app** — Uses `xcrun simctl install` to deploy the `.app` bundle
5. **Verifies installation** — Confirms the app is installed on the simulator

## Prerequisites

| Requirement | Details |
|-------------|---------|
| macOS | Required (iOS Simulator only runs on macOS) |
| .NET SDK | 9.0 or later with MAUI workload installed |
| Xcode | Installed with iOS Simulator runtimes |
| xcrun | Available on PATH (ships with Xcode Command Line Tools) |
| Simulator | A valid iOS Simulator device (e.g., iPhone 16) |

## Inputs Required

| Input | Required | Default | Description |
|-------|----------|---------|-------------|
| AppPath | Yes | — | Absolute path to the MAUI project directory (contains `.csproj`) |
| ApplicationId | Yes | — | iOS bundle identifier (e.g., `com.companyname.accordiontestbed`) |
| DeviceId | Yes | — | Simulator UDID (e.g., from `xcrun simctl list devices`) |
| Framework | No | `net9.0-ios` | Target framework moniker |

## Step-by-Step Execution

### Step 1: Identify the Target Simulator Device

List available iOS Simulator devices to find the UDID:

```bash
xcrun simctl list devices --json
```

Or for a quick human-readable list:

```bash
xcrun simctl list devices available
```

Pick the desired device and note its UDID. You can also use the `SIMID` environment variable:

```bash
export SIMID=<device-udid>
```

### Step 2: Boot the Simulator

If the simulator is not already booted:

```bash
xcrun simctl boot {DeviceId}
open -a Simulator
```

Wait for the simulator to fully boot:

```bash
# Check boot status
xcrun simctl list devices | grep {DeviceId}
# Should show "(Booted)"
```

If the simulator is already booted, this step can be skipped.

### Step 3: Build the App for iOS Simulator

Navigate to the MAUI project directory and build:

```bash
cd {AppPath} && dotnet build -f net9.0-ios -p:_DeviceName=:v2:udid={DeviceId}
```

#### Build Parameters Explained

| Parameter | Purpose |
|-----------|---------|
| `-f net9.0-ios` | Target framework for iOS |
| `-p:_DeviceName=:v2:udid={DeviceId}` | Targets the specific simulator device by UDID |

The `.app` bundle will be produced at:
```
{AppPath}/bin/Debug/net9.0-ios/iossimulator-x64/{ApplicationId}.app
```

### Step 4: Install the App on the Simulator

```bash
xcrun simctl install {DeviceId} {AppPath}/bin/Debug/net9.0-ios/iossimulator-x64/{ApplicationId}.app
```

### Step 5: Verify Installation

```bash
xcrun simctl listapps {DeviceId} | grep {ApplicationId}
```

### Step 6: Launch the App (Optional)

```bash
xcrun simctl launch {DeviceId} {ApplicationId}
```

## Using the Deploy Script

A PowerShell script is provided for automated deployment:

```bash
# Full build + install
pwsh .github/skills/appium-sample-deploy-ios/scripts/deploy-ios.ps1 \
  -AppPath /path/to/MauiProject \
  -ApplicationId com.companyname.accordiontestbed \
  -DeviceId <simulator-udid>

# Install only (skip build)
pwsh .github/skills/appium-sample-deploy-ios/scripts/deploy-ios.ps1 \
  -AppPath /path/to/MauiProject \
  -ApplicationId com.companyname.accordiontestbed \
  -DeviceId <simulator-udid> \
  -SkipBuild

# Use SIMID environment variable for device ID
export SIMID=<simulator-udid>
pwsh .github/skills/appium-sample-deploy-ios/scripts/deploy-ios.ps1 \
  -AppPath /path/to/MauiProject \
  -ApplicationId com.companyname.accordiontestbed
```

## Troubleshooting

| Issue | Resolution |
|-------|------------|
| `Unable to boot device in current state: Booted` | Simulator is already running — safe to ignore |
| `No matching device found` | Verify UDID with `xcrun simctl list devices` |
| `BUILD FAILED` | Ensure MAUI iOS workload is installed: `dotnet workload install maui-ios` |
| `.app` bundle not found | Check `bin/Debug/net9.0-ios/iossimulator-x64/` for the `.app` directory |
| `xcrun: error: unable to find utility` | Install Xcode Command Line Tools: `xcode-select --install` |
| Simulator never boots | Try `xcrun simctl shutdown {DeviceId}` then re-boot |

## Integration with Other Skills

| Skill | Integration Point |
|-------|-------------------|
| **appium-project-creation** | Creates the test project that runs against the deployed app |
| **bugsample-creation** | Generates the bug reproduction pages inside the MAUI app |
| **appium-sample-deploy-android** | Android counterpart of this skill |
| **appium-sample-deploy-windows** | Windows counterpart of this skill |
| **appium-sample-deploy-mac** | macOS counterpart of this skill |

## Notes

- iOS builds target the **iossimulator-x64** architecture by default for Intel-based simulators. For Apple Silicon Macs using native simulator, the path may be `iossimulator-arm64`.
- The `SIMID` environment variable is used by `BaseTest.cs` to configure the Appium iOS driver — set it before running tests.
- The script path from the repo root is `.github/skills/appium-sample-deploy-ios/scripts/deploy-ios.ps1`.
````

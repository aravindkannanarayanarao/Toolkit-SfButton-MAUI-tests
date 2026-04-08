````skill
---
name: appium-sample-deploy-android
description: Builds and deploys a MAUI sample app to an Android emulator for Appium UI testing. Handles dotnet publish with Android signing, APK installation via adb, and emulator readiness checks. Use when you need to deploy a MAUI app on Android before running Appium tests.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 9+, Android SDK, adb, and a running Android emulator.
---

# Appium Sample Deploy — Android

This skill builds a .NET MAUI app for Android, produces a signed APK via `dotnet publish`, and installs it on a running Android emulator using `adb`. Use it before executing Appium UI tests on Android.

## What This Skill Does

1. **Validates prerequisites** — Checks for Android emulator, adb connectivity, and project path
2. **Builds a signed APK** — Runs `dotnet publish` with Android keystore signing parameters
3. **Installs the APK** — Uses `adb install` to deploy the signed APK to the emulator
4. **Verifies installation** — Confirms the app package is listed on the device

## Prerequisites

| Requirement | Details |
|-------------|---------|
| .NET SDK | 9.0 or later with MAUI workload installed |
| Android SDK | Installed and configured (via Visual Studio or standalone) |
| Android Emulator | A running emulator instance (or physical device with USB debugging) |
| adb | Available on PATH |
| Keystore | `key.keystore` file present in the MAUI project root |

## Inputs Required

| Input | Required | Default | Description |
|-------|----------|---------|-------------|
| AppPath | Yes | — | Absolute path to the MAUI project directory (contains `.csproj`) |
| AppId | Yes | — | Android application ID / package name (e.g., `com.companyname.accordiontestbed`) |
| KeyStore | No | `key.keystore` | Path to the Android keystore file (relative to project or absolute) |
| KeyAlias | No | `MauiAlias` | Keystore alias name |
| KeyPass | No | `kanna007` | Keystore key password |
| StorePass | No | `kanna007` | Keystore store password |

## Step-by-Step Execution

### Step 1: Verify Android Emulator is Running

Before building, confirm an emulator is booted and reachable via adb:

```bash
# List connected devices
adb devices

# Expected output should show at least one "device" (not "offline" or "unauthorized"):
# emulator-5554   device
```

If no emulator is running, start one:

```bash
# List available AVDs
emulator -list-avds

# Boot an AVD
emulator -avd <avd_name> &
```

Wait until the emulator is fully booted:

```bash
adb wait-for-device
adb shell getprop sys.boot_completed
# Should return "1"
```

### Step 2: Build the Signed APK

Navigate to the MAUI project directory and run `dotnet publish` targeting Android:

```bash
cd {AppPath} && dotnet publish -f net9.0-android -c Release \
  -p:AndroidKeyStore=true \
  -p:AndroidSigningKeyStore=key.keystore \
  -p:AndroidSigningKeyAlias=MauiAlias \
  -p:AndroidSigningKeyPass=kanna007 \
  -p:AndroidSigningStorePass=kanna007
```

#### Build Parameters Explained

| Parameter | Purpose |
|-----------|---------|
| `-f net9.0-android` | Target framework for Android |
| `-c Release` | Release configuration (required for signing) |
| `-p:AndroidKeyStore=true` | Enable keystore-based signing |
| `-p:AndroidSigningKeyStore` | Path to the `.keystore` file |
| `-p:AndroidSigningKeyAlias` | Alias inside the keystore |
| `-p:AndroidSigningKeyPass` | Password for the key |
| `-p:AndroidSigningStorePass` | Password for the keystore |

The signed APK will be produced at:
```
{AppPath}/bin/Release/net9.0-android/publish/{AppId}-Signed.apk
```

### Step 3: Install the APK on the Emulator

```bash
adb install {AppPath}/bin/Release/net9.0-android/publish/{AppId}-Signed.apk
```

If the app is already installed and you want to replace it:

```bash
adb install -r {AppPath}/bin/Release/net9.0-android/publish/{AppId}-Signed.apk
```

### Step 4: Verify Installation

```bash
adb shell pm list packages | grep {AppId}
```

Expected output:
```
package:{AppId}
```

### Step 5: Launch the App (Optional)

```bash
adb shell monkey -p {AppId} -c android.intent.category.LAUNCHER 1
```

## Using the Deploy Script

A PowerShell script is provided for automated deployment:

```bash
# Full build + install
pwsh .github/skills/appium-sample-deploy-android/scripts/deploy-android.ps1 \
  -AppPath /path/to/MauiProject \
  -AppId com.companyname.accordiontestbed

# Install only (skip build, use existing APK)
pwsh .github/skills/appium-sample-deploy-android/scripts/deploy-android.ps1 \
  -AppPath /path/to/MauiProject \
  -AppId com.companyname.accordiontestbed \
  -SkipBuild

# Custom keystore settings
pwsh .github/skills/appium-sample-deploy-android/scripts/deploy-android.ps1 \
  -AppPath /path/to/MauiProject \
  -AppId com.companyname.accordiontestbed \
  -KeyStore my.keystore \
  -KeyAlias MyAlias \
  -KeyPass mypassword \
  -StorePass mypassword
```

## Troubleshooting

| Issue | Resolution |
|-------|------------|
| `adb: no devices/emulators found` | Start an Android emulator or connect USB device with debugging enabled |
| `INSTALL_FAILED_ALREADY_EXISTS` | Use `adb install -r` to replace, or `adb uninstall {AppId}` first |
| `BUILD FAILED` with signing error | Ensure `key.keystore` exists in the project root and passwords are correct |
| `dotnet publish` fails on SDK | Run `dotnet workload install maui-android` to install the workload |
| APK not found after build | Check `bin/Release/net9.0-android/publish/` for the `-Signed.apk` file |

## Integration with Other Skills

| Skill | Integration Point |
|-------|-------------------|
| **appium-project-creation** | Creates the test project that runs against the deployed app |
| **bugsample-creation** | Generates the bug reproduction pages inside the MAUI app |
| **appium-sample-deploy-ios** | iOS counterpart of this skill |
| **appium-sample-deploy-windows** | Windows counterpart of this skill |
| **appium-sample-deploy-mac** | macOS counterpart of this skill |

## Notes

- The keystore defaults (`key.keystore`, `MauiAlias`, `kanna007`) are for development/testing only — never use these in production.
- If you need a new keystore, generate one with: `keytool -genkey -v -keystore key.keystore -alias MauiAlias -keyalg RSA -keysize 2048 -validity 10000`
- The script path from the repo root is `.github/skills/appium-sample-deploy-android/scripts/deploy-android.ps1`.
````

# Parallel Appium Testing on Dual Android Emulators

## Overview

This document describes the architecture for running Appium UI tests in parallel across two Android emulators (`emulator-5554` and `emulator-5556`), each with its own Appium server instance, Appium session, and dedicated test fixtures.

---

## Architecture

```
┌─────────────────────────────────────┐
│         NUnit Test Runner           │
│    (NumberOfTestWorkers = 2)        │
├──────────────┬──────────────────────┤
│   Thread 1   │      Thread 2       │
│  (Device A)  │     (Device B)      │
├──────────────┼──────────────────────┤
│ Accordion_   │ Accordion_          │
│ Device5554   │ Device5556          │
│    then      │    then             │
│ Testhub_     │ Testhub_            │
│ Device5554   │ Device5556          │
├──────────────┼──────────────────────┤
│ Appium Port  │ Appium Port         │
│    4723      │    4724             │
├──────────────┼──────────────────────┤
│ emulator-    │ emulator-           │
│   5554       │   5556              │
└──────────────┴──────────────────────┘
```

---

## Files Modified

### Infrastructure (Appium Helpers)

| File | Change |
|------|--------|
| `src/Syncfusion.UITestHelpers.Appium/AppiumServerContext.cs` | Dual Appium servers (ports 4723, 4724), UDID-to-port mapping, per-device semaphore locking |
| `src/Syncfusion.UITestHelpers.Appium/AppiumApp.cs` | Passes `udid` as Appium capability in `SetGeneralAppiumOptions` |
| `src/Syncfusion.UITestHelpers.Appium/AppiumUIClientContext.cs` | Releases device semaphore lock on `Dispose()` |
| `src/Syncfusion.UITestHelpers.NUnit/UITestContextBase.cs` | `[ThreadStatic]` on `_uiTestContext` for thread-safe parallel fixture isolation |

### Test Project

| File | Change |
|------|--------|
| `UITests.Shared/AssemblyTestFixture.cs` | Starts both Appium servers on initialization (ports 4723 and 4724) |
| `UITests.Shared/BaseTest.cs` | Per-device `AppMain` mapping, `EnsureCorrectDeviceSession` setup method, `_currentSessionUdid` tracking |
| `UITests.Shared/Attributes.cs` | `[TargetDevice]` attribute (class or method level) |
| `UITests.Shared/Features_Device5554.cs` | Even-numbered test cases bound to emulator-5554 |
| `UITests.Shared/Features_Device5556.cs` | Odd-numbered test cases bound to emulator-5556 |
| `UITests.Shared/TestHubMigration_Device5554.cs` | Testhub migration tests for emulator-5554 |
| `UITests.Shared/TestHubMigration_Device5556.cs` | Testhub migration tests for emulator-5556 |
| `UITests.Android/test.runsettings` | `NumberOfTestWorkers` set to `2` |
| `UITests.Android/UITests.Android.csproj` | `RunSettingsFilePath` auto-loads `.runsettings` |

### Files Removed

| File | Reason |
|------|--------|
| `UITests.Shared/Features.cs` | Replaced by `Features_Device5554.cs` + `Features_Device5556.cs` |
| `UITests.Shared/TestHubMigration.cs` | Replaced by `TestHubMigration_Device5554.cs` + `TestHubMigration_Device5556.cs` |

---

## Key Design Decisions

### 1. Dual Appium Servers

Each emulator gets its own Appium server on a separate port. This prevents Appium from routing commands to the wrong device.

```
emulator-5554 → Appium server on port 4723
emulator-5556 → Appium server on port 4724
```

Configured in `AppiumServerContext.cs`:
```csharp
static readonly Dictionary<string, int> _devicePortMap = new()
{
    { "emulator-5554", Port },   // 4723
    { "emulator-5556", Port2 }   // 4724
};
```

### 2. UDID Capability

The `udid` is passed as an Appium capability so the Appium session explicitly targets the correct emulator:

```csharp
// In AppiumApp.SetGeneralAppiumOptions()
var udid = config.GetProperty<string>("Udid");
if (!string.IsNullOrEmpty(udid))
    appiumOptions.AddAdditionalAppiumOption("udid", udid);
```

### 3. ThreadStatic Session Isolation

`_uiTestContext` in `UITestContextBase` is marked `[ThreadStatic]` so each parallel NUnit worker thread gets its own Appium session. Without this, parallel fixtures overwrite each other's session.

```csharp
[ThreadStatic]
static IUIClientContext? _uiTestContext;
```

### 4. Per-Device Semaphore Locking

A `SemaphoreSlim(1,1)` per device UDID prevents two fixtures from creating concurrent sessions on the same emulator. The semaphore is acquired in `CreateUIClientContext` and released in `AppiumUIClientContext.Dispose()`.

```csharp
// Acquire before session creation
acquiredSemaphore = _deviceLocks.GetOrAdd(udid, _ => new SemaphoreSlim(1, 1));
acquiredSemaphore.Wait();

// Release on dispose
AppiumServerContext.ReleaseContextDeviceLock(this);
```

### 5. Class-Level TargetDevice

Each fixture class is bound to exactly one device via `[TargetDevice("emulator-XXXX")]` at class level. This eliminates mid-fixture device switching.

```csharp
[TargetDevice("emulator-5554")]
internal class Accordion_Device5554 : BaseTest { ... }

[TargetDevice("emulator-5556")]
internal class Accordion_Device5556 : BaseTest { ... }
```

### 6. NumberOfTestWorkers = 2

With 2 devices, only 2 NUnit worker threads run simultaneously. Each thread picks one fixture, runs all its tests, then picks the next fixture for the same device.

```xml
<!-- test.runsettings -->
<NUnit>
    <NumberOfTestWorkers>2</NumberOfTestWorkers>
</NUnit>
```

### 7. Per-Device MainActivity CRC

Each emulator can have a different `AppMain` (MainActivity CRC hash). Configured in `BaseTest.GetTestConfig()`:

```csharp
var deviceAppMainMap = new Dictionary<string, string>
{
    { "emulator-5554", "crc64ccbe8b2f819dfe3f" },
    { "emulator-5556", "crc64ccbe8b2f819dfe3f" }
};
```

---

## How to Run

```bash
cd UITests.Android
dotnet test
```

The `.runsettings` file is automatically loaded via `<RunSettingsFilePath>` in the `.csproj`. To explicitly specify:

```bash
dotnet test --settings test.runsettings
```

---

## Execution Flow

1. **Assembly Setup** (`AssemblyTestFixture.cs`)
   - Starts Appium server on port 4723
   - Starts Appium server on port 4724

2. **NUnit spawns 2 worker threads**

3. **Thread 1** picks `Accordion_Device5554` (or `AccordionTesthubMigration_Device5554`)
   - `OneTimeSetup` → `InitialSetup` → `CreateUIClientContext`
   - Reads `[TargetDevice("emulator-5554")]` → sets `Udid` in config
   - Maps to port 4723, acquires device semaphore for `emulator-5554`
   - Creates `AndroidDriver` with `udid=emulator-5554`
   - Runs all tests sequentially within the fixture
   - `OneTimeTearDown` → `Reset()` → disposes session → releases semaphore

4. **Thread 2** picks `Accordion_Device5556` (or `AccordionTesthubMigration_Device5556`)
   - Same flow but targeting `emulator-5556` on port 4724

5. When a fixture completes on Thread 1, the next 5554-targeted fixture starts. Same for Thread 2 with 5556 fixtures.

6. **Assembly Teardown** disposes both Appium servers.

---

## Adding a New Test

1. Decide which emulator the test should run on
2. Add the test method to the appropriate file:
   - `Features_Device5554.cs` or `TestHubMigration_Device5554.cs` for emulator-5554
   - `Features_Device5556.cs` or `TestHubMigration_Device5556.cs` for emulator-5556
3. No per-method `[TargetDevice]` attribute needed — the class-level attribute handles it

---

## Adding a Third Emulator

1. Start a third emulator (e.g., `emulator-5558`)
2. In `AppiumServerContext.cs`:
   - Add `const int Port3 = 4725;`
   - Add `AppiumLocalService? _server3;`
   - Add `{ "emulator-5558", Port3 }` to `_devicePortMap`
   - Handle `Port3` in `CreateAndStartServer` and `Dispose`
3. In `AssemblyTestFixture.cs`:
   - Add `_appiumServerContext.CreateAndStartServer(4725);`
4. Create new fixture files (e.g., `Features_Device5558.cs`)
5. In `BaseTest.cs`, add to `deviceAppMainMap`
6. Update `test.runsettings`: `NumberOfTestWorkers` to `3`

---

## Troubleshooting

| Symptom | Cause | Fix |
|---------|-------|-----|
| `instrumentation process is not running` | Two sessions created on same emulator simultaneously | Verify `NumberOfTestWorkers=2` is loaded (check `RunSettingsFilePath` in `.csproj`) |
| Tests running sequentially (not parallel) | `.runsettings` not loaded | Run with `--settings test.runsettings` or ensure `RunSettingsFilePath` is in `.csproj` |
| All 4 fixtures start simultaneously | `NumberOfTestWorkers` too high | Set to `2` (one per device) |
| Deadlock / test hangs | Semaphore not released | Check `AppiumUIClientContext.Dispose()` calls `ReleaseContextDeviceLock` |
| Wrong emulator receives commands | `udid` capability missing | Verify `SetGeneralAppiumOptions` passes `udid` |
| `EnsureCorrectDeviceSession` calls Reset on first test | `_currentSessionUdid` null check missing | Only call `Reset()` when `_currentSessionUdid != null && != requiredUdid` |

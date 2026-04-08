````skill
---
name: appium-test-run
description: Runs NUnit Appium UI test cases for a specific MAUI sample project on a selected platform (Android, iOS, Windows, macOS). Executes dotnet test against the platform-specific test project, generates TRX test result logs, and collects screenshots and report output. Use after deploying the app to run and capture test results.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 10+, NUnit 4.1+, Appium.WebDriver 5.0.0, and the sample app deployed on the target platform.
---

# Appium Test Run Skill

This skill runs NUnit-based Appium UI tests for a MAUI sample application on a selected platform. It executes `dotnet test` against the platform-specific test `.csproj`, captures TRX result files, and collects screenshots, report artifacts, and diff images for validation.

## What This Skill Does

1. **Resolves the test project** — Maps the platform to the correct `UITests.{Platform}` project
2. **Runs dotnet test** — Executes the test suite with TRX logger output
3. **Collects results** — Gathers TRX files, screenshots (expected/output/diff), and report HTML
4. **Summarizes outcomes** — Parses TRX XML for pass/fail/skip counts per test method

## Prerequisites

| Requirement | Details |
|-------------|---------|
| App Deployed | The MAUI sample must already be built and deployed on the target platform |
| Appium Server | Running for the target platform (WinAppDriver for Windows, Appium for mobile/Mac) |
| .NET SDK | 10.0+ with test SDK packages |
| Platform Device/Emulator | Running and accessible |

## Inputs Required

| Input | Required | Default | Description |
|-------|----------|---------|-------------|
| SamplePath | Yes | — | Path to the sample root (e.g., `UITest/Appium/AccordionTestBedSample`) |
| SampleName | Yes | — | Name of the sample (e.g., `AccordionTestBedSample`) |
| ControlName | No | `SfAccordion` | Name of the control being tested (used for TRX file naming) |
| Platform | Yes | — | Target platform: `Android`, `iOS`, `Windows`, `macOS` |

## Platform-to-Project Mapping

| Platform | Test Project Directory | csproj File |
|----------|----------------------|-------------|
| Android | `UITests.Android` | `UITests.Android/UITests.Android.csproj` |
| iOS | `UITests.iOS` | `UITests.iOS/UITests.iOS.csproj` |
| Windows | `UITests.Windows` | `UITests.Windows/UITests.Windows.csproj` |
| macOS | `UITests.macOS` | `UITests.macOS/UITests.macOS.csproj` |

## Step-by-Step Execution

### Step 1: Resolve Test Project Path

```bash
# The test project csproj lives at:
{SamplePath}/UITests.{Platform}/UITests.{Platform}.csproj
```

Verify it exists:
```bash
ls {SamplePath}/UITests.{Platform}/UITests.{Platform}.csproj
```

### Step 2: Run the Tests

Execute `dotnet test` with the TRX logger:

```bash
dotnet test {SamplePath}/UITests.{Platform}/UITests.{Platform}.csproj \
  --logger "trx;LogFileName={ControlName}_{SampleName}_TestResult.xml"
```

#### Optional: Filter by Test Name

To run specific test methods:
```bash
dotnet test {SamplePath}/UITests.{Platform}/UITests.{Platform}.csproj \
  --filter "FullyQualifiedName~Bug_1014072" \
  --logger "trx;LogFileName={ControlName}_{SampleName}_TestResult.xml"
```

#### Optional: Run with Verbose Output

```bash
dotnet test {SamplePath}/UITests.{Platform}/UITests.{Platform}.csproj \
  --logger "trx;LogFileName={ControlName}_{SampleName}_TestResult.xml" \
  --verbosity normal
```

### Step 3: Locate Test Results

After test execution, the TRX file is generated at:
```
{SamplePath}/UITests.{Platform}/TestResults/{ControlName}_{SampleName}_TestResult.xml
```

### Step 4: Locate Screenshot & Report Artifacts

Screenshots and diff images are produced in the platform test project's `Images` folder:

```
{SamplePath}/UITests.{Platform}/Images/
├── snapshots/           ← Expected baseline screenshots
├── snapshots-output/    ← Actual screenshots from this run
└── snapshots-diff/      ← Visual diff images (expected vs actual)
```

Report HTML files (if configured):
```
{SamplePath}/UITests.{Platform}/report/
├── dashboard.html
├── home.html
└── updateStats.js
```

### Step 5: Parse TRX Results

The TRX file is XML with this structure:

```xml
<TestRun>
  <Results>
    <UnitTestResult testName="Bug_1014072_1" outcome="Passed" />
    <UnitTestResult testName="Bug_1014072_2" outcome="Failed">
      <Output>
        <ErrorInfo>
          <Message>Assert.AreEqual failed...</Message>
          <StackTrace>at Bug_1014072Tests.Bug_1014072_2()...</StackTrace>
        </ErrorInfo>
      </Output>
    </UnitTestResult>
  </Results>
  <ResultSummary outcome="Failed">
    <Counters total="5" passed="3" failed="1" error="1" />
  </ResultSummary>
</TestRun>
```

Extract per-test results:
| Field | XPath |
|-------|-------|
| Test Name | `//UnitTestResult/@testName` |
| Outcome | `//UnitTestResult/@outcome` (Passed, Failed, NotExecuted) |
| Error Message | `//UnitTestResult/Output/ErrorInfo/Message` |
| Stack Trace | `//UnitTestResult/Output/ErrorInfo/StackTrace` |
| Duration | `//UnitTestResult/@duration` |
| Total/Passed/Failed | `//ResultSummary/Counters/@total/@passed/@failed` |

## Using the Deploy Script

A PowerShell script is provided for automated test execution:

```bash
# Run all tests for a sample on Android
pwsh .github/skills/appium-test-run/scripts/run-tests.ps1 \
  -SamplePath UITest/Appium/AccordionTestBedSample \
  -SampleName AccordionTestBedSample \
  -Platform Android

# Run filtered tests on iOS
pwsh .github/skills/appium-test-run/scripts/run-tests.ps1 \
  -SamplePath UITest/Appium/AccordionCRBugsTestBed \
  -SampleName AccordionCRBugsTestBed \
  -ControlName SfAccordion \
  -Platform iOS \
  -Filter "Bug_1014072"

# Run on Windows
pwsh .github/skills/appium-test-run/scripts/run-tests.ps1 \
  -SamplePath UITest/Appium/AccordionTestBedSample \
  -SampleName AccordionTestBedSample \
  -Platform Windows
```

## Test Result Summary Format

After execution, the script outputs a JSON summary:

```json
{
  "status": "completed",
  "platform": "Android",
  "sampleName": "AccordionTestBedSample",
  "trxPath": "UITests.Android/TestResults/SfAccordion_AccordionTestBedSample_TestResult.xml",
  "total": 10,
  "passed": 8,
  "failed": 1,
  "skipped": 1,
  "results": [
    { "testName": "Bug_1014072_1", "outcome": "Passed", "duration": "00:00:12.345" },
    { "testName": "Bug_1014072_2", "outcome": "Failed", "error": "Assert.AreEqual failed..." }
  ]
}
```

## Troubleshooting

| Issue | Resolution |
|-------|------------|
| `No test matches the given test filter` | Check the filter string matches test names — use `--list-tests` to see available tests |
| `App not found / driver error` | Ensure the app is deployed and Appium/WinAppDriver is running |
| `Screenshots not generated` | Check `TakeAndCompareScreenshot()` calls in test code; verify `Images/snapshots/` exists |
| `TRX file not found` | Check `TestResults/` directory; ensure `--logger trx` is set |
| `Tests timeout` | Increase `Thread.Sleep()` waits or add explicit `WaitForElement()` calls |
| Build errors in test project | Run `dotnet restore` first; check NuGet package versions |

## Integration with Other Skills

| Skill | Integration Point |
|-------|-------------------|
| **appium-sample-deploy-android** | Deploys the app before tests run on Android |
| **appium-sample-deploy-ios** | Deploys the app before tests run on iOS |
| **appium-sample-deploy-windows** | Deploys the app before tests run on Windows |
| **appium-sample-deploy-mac** | Deploys the app before tests run on macOS |
| **appium-project-creation** | Creates the test project structure |
| **appium-helper-extensions** | Documents the test helper methods used in test classes |

## Notes

- Always deploy the app before running tests — use the platform-specific deploy skill.
- The TRX logger name pattern `{ControlName}_{SampleName}_TestResult.xml` is required for downstream report parsing.
- First-run tests without baseline screenshots will always fail visual comparison — this is expected. Run twice: first to generate baselines, second to validate.
- The script path from the repo root is `.github/skills/appium-test-run/scripts/run-tests.ps1`.
````

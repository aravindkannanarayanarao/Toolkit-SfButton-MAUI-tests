---
name: appium_run
description: End-to-end Appium UI test runner agent. Builds and deploys MAUI sample apps on a user-selected platform (Android, iOS, Windows, macOS), runs NUnit Appium tests, parses results, validates each test case, and produces a final issue summary report. Use when you need to build, deploy, run, and validate Appium UI tests for one or more samples.
argument-hint: "Sample names to test and the target platform, e.g., 'AccordionTestBedSample on Android'"
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'web', 'todo']
---

# Appium Run Agent

This agent automates the complete Appium UI test lifecycle:
1. Collects sample names and target platform from the user
2. Scans test methods and builds a validation table
3. Builds and deploys the sample app on the chosen platform
4. Runs the Appium tests and collects TRX results + screenshots
5. Parses results into the validation table
6. Validates each failure and categorizes the issue root cause
7. Generates a final issue summary report

> **Important**: This agent runs inside the `maui-accordion-tests` repository. The current working directory IS the test repo.

## When to Use This Agent

- When you need to build, deploy, and run Appium tests for one or more samples
- When you want automated validation of test results with categorized failure analysis
- When a comprehensive summary report of control issues vs sample/platform issues is needed

## When NOT to Use This Agent

- When you only need to create test cases (use `pr_automation` agent instead)
- When you only need to deploy without running tests (use deploy skills directly)
- When the sample project does not exist yet (use `appium-project-creation` skill first)

---

## Critical Rules

1. **Always read the skill file** before executing its steps — use `read_file` on the SKILL.md path
2. **Never skip phases** — each phase depends on the output of the previous phase
3. **Always ask the user for sample names and platform** before starting
4. **Use platform-specific deploy skills** — do not hard-code build commands
5. **Parse every test result** — never summarize without reading TRX and screenshots
6. **Categorize every failure** — distinguish between control bugs, platform issues, pixel diffs, sample exceptions, and Appium method failures
7. **Create the validation table early** (Phase 1.2) and update it incrementally through Phases 4 and 5
8. **Generate a final report** even if all tests pass — include the validation table and summary
9. **Handle multiple samples** — loop through each sample independently, creating separate validation tables and reports per sample
10. **The control is SfAccordion** — source repo is `essential-studio/maui-expander`, test repo is the current directory

---

## Directory Structure Reference

```
{CurrentDirectory}/
└── UITest/Appium/
    └── {SampleName}/                          ← Sample root
        ├── {SampleName}/                      ← MAUI app project (contains .csproj)
        ├── {SampleName}.sln                   ← Solution file
        ├── UITests.Shared/                    ← Shared test code (.cs files with [Test] methods)
        │   ├── BaseTest.cs
        │   ├── *.cs                           ← Test class files
        │   └── UITests.Shared.csproj
        ├── UITests.Android/
        │   ├── UITests.Android.csproj
        │   ├── Images/
        │   │   ├── snapshots/                 ← Expected baseline screenshots
        │   │   ├── snapshots-output/          ← Actual screenshots from run
        │   │   └── snapshots-diff/            ← Diff images
        │   ├── report/                        ← HTML reports
        │   └── TestResults/                   ← TRX files after test run
        ├── UITests.iOS/
        ├── UITests.Windows/
        └── UITests.macOS/
```

---

## Skills Reference

| # | Skill | File | Purpose |
|---|-------|------|---------|
| 1 | **appium-sample-deploy-android** | `.github/skills/appium-sample-deploy-android/SKILL.md` | Build & deploy MAUI app on Android emulator |
| 2 | **appium-sample-deploy-ios** | `.github/skills/appium-sample-deploy-ios/SKILL.md` | Build & deploy MAUI app on iOS Simulator |
| 3 | **appium-sample-deploy-windows** | `.github/skills/appium-sample-deploy-windows/SKILL.md` | Build & deploy MAUI app on Windows |
| 4 | **appium-sample-deploy-mac** | `.github/skills/appium-sample-deploy-mac/SKILL.md` | Build & deploy MAUI app on macOS (Mac Catalyst) |
| 5 | **appium-test-run** | `.github/skills/appium-test-run/SKILL.md` | Run NUnit tests and collect TRX results |
| 6 | **appium-helper-extensions** | `.github/skills/appium-helper-extensions/SKILL.md` | Reference for HelperExtensions methods |

> **How to use a skill**: Read the skill file with `read_file`, then follow its steps within the corresponding phase.

---

## Workflow Overview

```
Phase 1:   Collect Samples & Build Validation Table
Phase 1.2: Scan [Test] methods and create per-sample validation table
     ↓
Phase 2:   Build & Deploy sample on selected platform (deploy skill)
     ↓
Phase 3:   Run Appium tests (test-run skill)
     ↓
Phase 4:   Parse TRX + screenshots → fill validation table
     ↓
Phase 5:   Validate each failure → categorize & set status
     ↓
Phase 6:   Generate final issue summary report as MD file
```

---

## Phase 1: Collect Sample Names from User

### Step 1.1: Ask User for Samples and Platform

Prompt the user for:
1. **Sample names** — one or more sample folder names from `UITest/Appium/` (e.g., `AccordionTestBedSample`, `AccordionCRBugsTestBed`)
2. **Target platform** — `Android`, `iOS`, `Windows`, or `macOS`

### Step 1.2: Validate Sample Paths Exist

For each sample name provided, verify the sample directory exists:

```bash
ls UITest/Appium/{SampleName}/
```

Expected contents:
- `{SampleName}/` directory (MAUI app project)
- `{SampleName}.sln` file
- `UITests.Shared/` directory
- `UITests.{Platform}/` directory

If any sample does not exist, inform the user and skip that sample.

### Step 1.3: Create Per-Sample Document

For each valid sample, create a validation document at:
```
doc/{SampleName}_validation.md
```

Initial content:
```markdown
# Validation Report: {SampleName}

**Platform**: {Platform}
**Date**: {CurrentDate}
**Sample Path**: UITest/Appium/{SampleName}

## Test Execution Status

(Populated in Phase 1.2)
```

---

## Phase 1.2: Scan Test Methods and Build Validation Table

For each sample, scan all `.cs` files in `UITests.Shared/` that contain `[Test]` attributes.

### Step 1.2.1: Find All Test Methods

Read every `.cs` file in the `UITests.Shared/` directory:

```bash
# List all .cs files in UITests.Shared
ls UITest/Appium/{SampleName}/UITests.Shared/*.cs
```

For each `.cs` file, parse and extract:
- Methods decorated with `[Test]` attribute
- The method name (this is the test name)
- The `[Description("...")]` if present
- The `[Category("...")]` if present

### Step 1.2.2: Build the Validation Table

Create a table in the per-sample validation document:

```markdown
## Validation Table

| S.No | Test Name | Description | Validation Exception or Results | Status |
|------|-----------|-------------|--------------------------------|--------|
| 1 | {TestMethodName1} | {Description or ''} | | |
| 2 | {TestMethodName2} | {Description or ''} | | |
| ... | ... | ... | | |
```

**Rules**:
- `S.No` — Sequential number starting from 1
- `Test Name` — The exact method name that has the `[Test]` attribute
- `Description` — From `[Description("...")]` tag if present, empty otherwise
- `Validation Exception or Results` — Leave **empty** until Phase 4
- `Status` — Leave **empty** until Phase 5

### Phase 1 Output

- Validated sample paths exist
- Per-sample validation document created at `doc/{SampleName}_validation.md`
- Validation table populated with all `[Test]` method names, with results and status columns empty

---

## Phase 2: Build and Deploy Sample on Selected Platform

**Skills used**: `appium-sample-deploy-android`, `appium-sample-deploy-ios`, `appium-sample-deploy-windows`, `appium-sample-deploy-mac`

### Step 2.1: Read the Platform Deploy Skill

Based on user-selected platform, read the corresponding skill:

| Platform | Skill File |
|----------|-----------|
| Android | `.github/skills/appium-sample-deploy-android/SKILL.md` |
| iOS | `.github/skills/appium-sample-deploy-ios/SKILL.md` |
| Windows | `.github/skills/appium-sample-deploy-windows/SKILL.md` |
| macOS | `.github/skills/appium-sample-deploy-mac/SKILL.md` |

```
read_file .github/skills/appium-sample-deploy-{platform}/SKILL.md
```

### Step 2.2: Extract App Identifiers from BaseTest.cs

Read `UITest/Appium/{SampleName}/UITests.Shared/BaseTest.cs` to extract:
- `AppId` — Android/iOS bundle identifier
- `AppName` — Windows process name  
- `MacApp` — macOS bundle identifier
- `iOSAppName` — iOS app name
- `AppMain` — Android main activity CRC

These values are in the `GetTestConfig()` method.

### Step 2.3: Build the MAUI App

The MAUI app project is at:
```
UITest/Appium/{SampleName}/{SampleName}/
```

Execute the deploy skill steps:

#### Android:
```bash
cd UITest/Appium/{SampleName}/{SampleName} && \
dotnet publish -f net9.0-android -c Release \
  -p:AndroidKeyStore=true \
  -p:AndroidSigningKeyStore=key.keystore \
  -p:AndroidSigningKeyAlias=MauiAlias \
  -p:AndroidSigningKeyPass=kanna007 \
  -p:AndroidSigningStorePass=kanna007
```

Then install:
```bash
adb install UITest/Appium/{SampleName}/{SampleName}/bin/Release/net9.0-android/publish/{AppId}-Signed.apk
```

#### iOS:
```bash
cd UITest/Appium/{SampleName}/{SampleName} && \
dotnet build -f net9.0-ios -p:_DeviceName=:v2:udid={DeviceId}
```

Then install:
```bash
xcrun simctl install {DeviceId} UITest/Appium/{SampleName}/{SampleName}/bin/Debug/net9.0-ios/iossimulator-x64/{ApplicationId}.app
```

#### Windows:
```bash
cd UITest/Appium/{SampleName}/{SampleName} && \
dotnet build -f net9.0-windows10.0.19041.0 -c Release -p:WindowsPackageType=None
```

#### macOS:
```bash
cd UITest/Appium/{SampleName}/{SampleName} && \
dotnet build -f net9.0-maccatalyst -c Debug
```

### Step 2.4: Verify Deployment

Follow the verification steps in the platform deploy skill to confirm the app is installed and ready.

### Phase 2 Output

- MAUI app built for the selected platform
- App deployed to emulator/simulator/device
- Deployment verified (package listed or executable confirmed)

---

## Phase 3: Run Appium Tests

**Skills used**: `appium-test-run`

### Step 3.1: Read the Test Run Skill

```
read_file .github/skills/appium-test-run/SKILL.md
```

### Step 3.2: Execute Tests

Run the platform-specific test project:

```bash
dotnet test UITest/Appium/{SampleName}/UITests.{Platform}/UITests.{Platform}.csproj \
  --logger "trx;LogFileName=SfAccordion_{SampleName}_TestResult.xml"
```

Or use the script:

```bash
pwsh .github/skills/appium-test-run/scripts/run-tests.ps1 \
  -SamplePath UITest/Appium/{SampleName} \
  -SampleName {SampleName} \
  -ControlName SfAccordion \
  -Platform {Platform}
```

### Step 3.3: Wait for Completion

Tests may take several minutes depending on the number of test methods and platform. Let the command complete fully.

### Phase 3 Output

- Tests executed on the selected platform
- TRX result file generated at `UITests.{Platform}/TestResults/`
- Screenshots captured in `UITests.{Platform}/Images/`

---

## Phase 4: Parse Results into Validation Table

### Step 4.1: Locate and Read TRX File

Find the TRX result file:
```bash
ls UITest/Appium/{SampleName}/UITests.{Platform}/TestResults/*.xml
```

Read the TRX XML content and parse each `<UnitTestResult>` element.

### Step 4.2: Locate Report and Screenshot Directories

```bash
# Report directory
ls UITest/Appium/{SampleName}/UITests.{Platform}/report/

# Screenshot directories
ls UITest/Appium/{SampleName}/UITests.{Platform}/Images/snapshots/
ls UITest/Appium/{SampleName}/UITests.{Platform}/Images/snapshots-output/
ls UITest/Appium/{SampleName}/UITests.{Platform}/Images/snapshots-diff/
```

### Step 4.3: Update Validation Table — Fill "Validation Exception or Results" Column

For each test in the validation table, find the matching `<UnitTestResult>` from the TRX:

- **Passed tests**: Set `Validation Exception or Results` to `Passed — No errors`
- **Failed tests**: Set to the error message from `<ErrorInfo><Message>` + the exception type
- **Not executed**: Set to `Skipped — Not executed`

Also note any screenshot diff images corresponding to the test name:
```
Images/snapshots-diff/{TestName}.png
```

If a diff image exists, append to the results column:
```
Failed — Screenshot mismatch detected. Diff image: Images/snapshots-diff/{TestName}.png
```

### Step 4.4: Update the Validation Document

Update `doc/{SampleName}_validation.md` with the filled validation table:

```markdown
| S.No | Test Name | Description | Validation Exception or Results | Status |
|------|-----------|-------------|--------------------------------|--------|
| 1 | Bug_1014072_1 | Verify load | Passed — No errors | |
| 2 | Bug_1014072_2 | Verify grouping border | Failed — Assert.AreEqual: Expected border visible. Diff: Images/snapshots-diff/Bug_1014072_2.png | |
```

### Phase 4 Output

- TRX file parsed
- Validation table updated with results for every test method
- Screenshot artifacts cataloged

---

## Phase 5: Validate Each Failure and Set Status

### Step 5.1: For Each Failed Test, Analyze the Root Cause

For every test where `Validation Exception or Results` indicates a failure, perform this analysis:

#### 5.1.1: Read the Error Details

- Read the full error message and stack trace from TRX
- Check if there is an expected screenshot in `Images/snapshots/`
- Check if there is an output screenshot in `Images/snapshots-output/`
- Check if there is a diff screenshot in `Images/snapshots-diff/`

#### 5.1.2: Categorize the Issue

Classify each failure into one of these categories:

| Category | Description | Detection Criteria |
|----------|-------------|-------------------|
| **Control Issue** | Bug in the Syncfusion control rendering or behavior | Visual diff shows control element rendering differently; error in control namespace (`Syncfusion.Maui.*`); **or** screenshot diff exceeds 40,000% and image inspection reveals control rendering problems (see Step 5.1.4) |
| **Platform Issue** | Platform-specific rendering or behavior difference | Error mentions platform APIs; issue only on one platform; system dialog interference |
| **Pixel Issue** | Minor pixel-level screenshot difference (tolerance) | Diff image shows very small color/position changes; no functional difference; **diff percentage ≤ 40,000%** with no structural/layout changes visible |
| **Sample Exception** | Exception in the sample app code (not the control) | Stack trace points to sample namespace; `NullReferenceException` in sample code |
| **Appium Method Failure** | Appium helper method did not work as expected | Error in `HelperExtensions` or `OpenQA.Selenium`; element not found; timeout waiting for element |

> **Critical Threshold Rule**: Any screenshot mismatch with a difference percentage **greater than 40,000%** MUST NOT be auto-classified as a Pixel Issue. These require mandatory image inspection (Step 5.1.4) to determine if a control issue exists.

#### 5.1.3: Compare Screenshots

If expected, output, and diff screenshots exist:
1. Note the expected image path: `Images/snapshots/{TestName}.png`
2. Note the output image path: `Images/snapshots-output/{TestName}.png`
3. Note the diff image path: `Images/snapshots-diff/{TestName}.png`
4. Describe what the visual difference shows

#### 5.1.4: High-Diff Image Inspection (Diff > 40,000%)

When a test fails with a screenshot difference percentage **greater than 40,000%**, the failure is too large to be a minor pixel tolerance issue. Perform the following deep inspection:

##### Step A: Open and Examine All Three Images

For each high-diff test case, visually inspect these three images:
1. **Expected (baseline)**: `UITests.{Platform}/Images/snapshots/{TestName}.png`
2. **Output (actual)**: `UITests.{Platform}/Images/snapshots-output/{TestName}.png`
3. **Diff**: `UITests.{Platform}/Images/snapshots-diff/{TestName}.png`

##### Step B: Check for Control Rendering Issues

Compare the expected and output images and look for any of the following control-level problems:

| Check | What to Look For |
|-------|------------------|
| **Missing/extra rows or columns** | Row count changed, columns missing, headers absent |
| **Broken layout/alignment** | Cells misaligned, overlapping content, incorrect spacing |
| **Incorrect filtering/sorting results** | Data not filtered correctly, wrong rows displayed |
| **Rendering artifacts** | Black rectangles, blank areas, clipped content, corrupted text |
| **Style/theme regression** | Colors, fonts, borders drastically different from baseline |
| **Control element missing** | Filter row, header row, summary row, pager, or other SfAccordion elements not rendered |
| **Interactive state difference** | Expanded/collapsed groups wrong, selection state incorrect, checkbox state wrong |

##### Step C: Classify Based on Inspection

- If the output image shows **correct rendering** and the difference is only due to an outdated baseline (e.g., framework version upgrade, intentional style change), classify as:
  - **🔍 Pixel Issue** — with a note: `Baseline update needed — output renders correctly`
  - **Recommended Action**: Update baseline by copying output screenshot to snapshots folder

- If the output image shows **broken, incorrect, or degraded rendering** compared to the expected image, classify as:
  - **❌ Control Issue** — with a detailed description of what is visually wrong
  - Include specifics: which control element is affected, what changed, and how it impacts functionality

- If the output image shows **a platform dialog, system overlay, or keyboard obstructing the view**, classify as:
  - **⚠️ Platform Issue**

##### Step D: Document Findings

For every high-diff test case, add a note in the `Validation Exception or Results` column:
```
Failed — Images differ by {X}%. Diff: snapshots-diff/{TestName}.png.
High-diff inspection: {One-line summary of what the visual difference shows}
```

### Step 5.2: Set Status in Validation Table

Update the `Status` column for each test:

| Status Value | Meaning |
|-------------|---------|
| ✅ Passed | Test passed successfully |
| ❌ Control Issue | Syncfusion control bug detected — includes high-diff (>40,000%) failures where image inspection confirmed a rendering problem |
| ⚠️ Platform Issue | Platform-specific rendering/behavior problem |
| 🔍 Pixel Issue | Minor screenshot pixel difference (diff ≤ 40,000%) **or** high-diff where image inspection confirmed output renders correctly and baseline needs updating |
| 💥 Sample Exception | Exception in sample code |
| 🔧 Appium Failure | Appium method/driver issue |
| ⏭️ Skipped | Test was not executed |

> **Note**: For 🔍 Pixel Issue tests that were flagged via high-diff inspection (>40,000%) and confirmed as baseline-update-needed, append the recommended action: "Update baseline screenshots from snapshots-output to snapshots folder."

### Step 5.3: Update Validation Document

Final validation table example:

```markdown
| S.No | Test Name | Description | Validation Exception or Results | Status |
|------|-----------|-------------|--------------------------------|--------|
| 1 | Bug_1014072_1 | Verify load | Passed — No errors | ✅ Passed |
| 2 | Bug_1014072_2 | Verify grouping border | Failed — Assert.AreEqual: border not visible after grouping. Diff: snapshots-diff/Bug_1014072_2.png | ❌ Control Issue |
| 3 | Bug_1014072_3 | Verify expand/collapse | Failed — Element "expandBtn" not found within 30s | 🔧 Appium Failure |
| 4 | Bug_1014072_4 | Verify orientation | Failed — System.NullReferenceException in Bug_1014072.xaml.cs | 💥 Sample Exception |
```

### Phase 5 Output

- Every test case analyzed and categorized
- Status column filled in validation table
- Screenshot comparison notes added
- Validation document fully updated

---

## Phase 6: Generate Final Issue Summary Report

### Step 6.1: Create the Summary Report

Create a comprehensive issue summary at:
```
doc/{SampleName}_issue_summary.md
```

**If multiple samples were run**, create an aggregated report at:
```
doc/appium_run_summary.md
```

### Step 6.2: Report Format

For every test that is NOT `✅ Passed`, create an issue entry:

```markdown
# Appium Run — Issue Summary Report

**Date**: {CurrentDate}
**Platform**: {Platform}
**Samples Tested**: {SampleName1}, {SampleName2}, ...

---

## Issue #{IssueNumber}

**Control Name**: SfAccordion
**Sample Name**: {SampleName}
**Test Case Name**: {TestMethodName}
**Issue Title**: {Short descriptive title of the issue}
**Issue Description**: {Concise description understandable by the development team — include the error type, what went wrong, and the impact}

**Issue Replication Steps**:
1. Deploy {SampleName} on {Platform}
2. Launch the app
3. Navigate to {PageName} (tap "{AutomationId}")
4. {Step that triggers the issue}
5. Observe: {What goes wrong}

**Expected Behavior**: {What should happen based on the test assertion}

**Observed Behavior**: {What actually happened, including error message}

**Screenshots**:
- Expected: `UITests.{Platform}/Images/snapshots/{TestName}.png`
- Output: `UITests.{Platform}/Images/snapshots-output/{TestName}.png`
- Diff: `UITests.{Platform}/Images/snapshots-diff/{TestName}.png`

**Issue Category**: {Control Issue | Platform Issue | Pixel Issue | Sample Exception | Appium Failure}

---
```

### Step 6.3: Append Overall Summary Table

At the end of the report, add:

```markdown
## Overall Summary

| # | Sample | Total Tests | Passed | Failed | Control Issues | Platform Issues | Pixel Issues | Sample Exceptions | Appium Failures |
|---|--------|-------------|--------|--------|---------------|----------------|-------------|------------------|----------------|
| 1 | {SampleName1} | {N} | {N} | {N} | {N} | {N} | {N} | {N} | {N} |
| 2 | {SampleName2} | {N} | {N} | {N} | {N} | {N} | {N} | {N} | {N} |
```

### Step 6.4: Handle All-Pass Scenario

If all tests passed:

```markdown
# Appium Run — Summary Report

**Date**: {CurrentDate}
**Platform**: {Platform}
**Samples Tested**: {SampleName1}, {SampleName2}

## Result: ✅ All Tests Passed

All {TotalCount} test cases across {SampleCount} sample(s) passed successfully on {Platform}.

No control issues, platform issues, or regressions detected.

## Validation Tables

(Include the fully populated validation tables from each sample)
```

### Phase 6 Output

- Per-sample issue summary files created in `doc/`
- Aggregated summary report if multiple samples
- Every non-passing test has a detailed issue entry with screenshots
- Overall summary table with counts by category
- Report is ready for review by the development team

---

## Full Execution Checklist

| Phase | Action | Skill Used | Output |
|-------|--------|-----------|--------|
| 1 | Collect sample names from user | — | Sample list confirmed |
| 1.2 | Scan [Test] methods, build validation table | — | `doc/{SampleName}_validation.md` |
| 2 | Build & deploy sample on platform | `appium-sample-deploy-{platform}` | App deployed |
| 3 | Run Appium tests | `appium-test-run` | TRX + screenshots |
| 4 | Parse TRX → fill validation table | — | Results column filled |
| 5 | Validate failures → categorize & set status | — | Status column filled |
| 6 | Generate issue summary report | — | `doc/{SampleName}_issue_summary.md` |

## Repeat for Multiple Samples

If the user provides multiple sample names, execute Phases 2–6 for each sample sequentially:
1. Deploy sample A → run tests → parse → validate → report
2. Deploy sample B → run tests → parse → validate → report
3. Generate aggregated summary across all samples

---

## Notes

- The MAUI app project is always at `UITest/Appium/{SampleName}/{SampleName}/` (nested same name)
- Test projects share code via `<Compile Include="..\UITests.Shared\**\*.cs" />` in each platform csproj
- First-run screenshot comparisons will fail if no baseline exists — this is a **Pixel Issue**, not a control bug
- Screenshot diff percentages **above 40,000%** must trigger deep image inspection (Phase 5, Step 5.1.4) — do NOT auto-classify these as Pixel Issues without examining expected, output, and diff images to rule out control regressions
- The `Reset()` method in `[TearDown]` kills and restarts the app between tests
- Always check `BaseTest.cs` for the correct `AppId`, `AppName`, and `MacApp` values before deploying
- Report files go in the `doc/` directory at the repository root
# Automation Test Cases — PR Template

## Bug Fix Reference

| Field | Details |
|-------|---------|
| **Bug ID** | #{BugId} |
| **Control** | {SfControlName} |
| **Source PR** | [{ControlRepo}#{PRNumber}]({PRUrl}) |
| **Bug Description** | {BugDescription} |
| **Root Cause** | {RootCause} |
| **Solution** | {SolutionDescription} |
| **Affected Platforms** | {AffectedPlatforms} |
| **Is Breaking Issue?** | {Yes/No} |

---

## Bug Sample Created

| File | Description |
|------|-------------|
| `{AppFolder}/Bug_{BugId}.xaml` | XAML page reproducing the bug scenario |
| `{AppFolder}/Bug_{BugId}.xaml.cs` | Code-behind with event handlers and data bindings |
| `{AppFolder}/MainPage.xaml.cs` | Updated navigation switch-case for `Bug_{BugId}` |

### AutomationIds Added

| Element | AutomationId | Purpose |
|---------|-------------|---------|
| {Element1} | `{automationId1}` | {Purpose1} |
| {Element2} | `{automationId2}` | {Purpose2} |

---

## Test Cases Summary

### Total Test Cases: **{TotalTestCount}**

| # | Test Method | Category | Platforms | Description |
|---|------------|----------|-----------|-------------|
| 1 | `Bug_{BugId}_1` | Bug Fix Validation | Android, iOS, Windows, macOS | {TestDescription1} |
| 2 | `Bug_{BugId}_2` | Bug Fix Validation | Android, iOS, Windows, macOS | {TestDescription2} |
| 3 | `Bug_{BugId}_3` | Bug Fix Validation | Android, iOS, Windows, macOS | {TestDescription3} |

### Test Coverage by Platform

| Platform | Tests Applicable | Status |
|----------|-----------------|--------|
| Android | {N} | 🟡 Pending first run |
| iOS | {N} | 🟡 Pending first run |
| Windows | {N} | 🟡 Pending first run |
| macOS | {N} | 🟡 Pending first run |

### Screenshot Baselines

| Screenshot Name | Platform | Status |
|----------------|----------|--------|
| `Bug_{BugId}_1` | All | 🟡 Pending baseline capture |
| `Bug_{BugId}_2` | All | 🟡 Pending baseline capture |
| `Bug_{BugId}_3` | All | 🟡 Pending baseline capture |

---

## Files Changed

### New Files
- [ ] `{AppFolder}/Bug_{BugId}.xaml` — Bug reproduction sample page
- [ ] `{AppFolder}/Bug_{BugId}.xaml.cs` — Code-behind
- [ ] `UITests.Shared/Test/Bug_{BugId}Tests.cs` — Test class with {N} test methods

### Modified Files
- [ ] `{AppFolder}/MainPage.xaml.cs` — Added navigation case for `Bug_{BugId}`
- [ ] `{AppFolder}/MauiProgram.cs` — Added Syncfusion handler registration (if needed)

---

## HelperExtensions Methods Used

| Method | Category | Platform |
|--------|----------|----------|
| `app.Tap()` | Tap/Click | All |
| `app.EnterText()` | Text Input | All |
| `app.DismissKeyboard()` | Keyboard | Android |
| `app.SetOrientationLandscape()` | Orientation | Mobile |
| `app.SetOrientationPortrait()` | Orientation | Mobile |
| `app.WaitForElement()` | Wait | All |
| `TakeAndCompareScreenshot()` | Screenshot | All |

---

## Agent Usage Summary

### PR Automation Agent — Execution Report

| Metric | Value |
|--------|-------|
| **Agent** | PR Automation Agent v1.0 |
| **Execution Date** | {ExecutionDate} |
| **Source PRs Analyzed** | {SourcePRCount} |
| **Bug Fix PRs Identified** | {BugFixPRCount} |
| **PRs Skipped (non-bug)** | {SkippedPRCount} |
| **Bug Samples Created** | {BugSampleCount} |
| **Test Cases Generated** | {TotalTestCount} |
| **Test Classes Created** | {TestClassCount} |
| **Screenshots Configured** | {ScreenshotCount} |
| **Target Repository** | {ControlName}-MAUI-tests |
| **Feature Branch** | `automation/Bug_{BugId}` |
| **Base Branch** | `development` |

### Skills Invoked

| Skill | Invocations | Purpose |
|-------|------------|---------|
| `control-element-id-identifier` | {N} | Mapped control element IDs and element locators |
| `control-identifier` | {N} | Identified Syncfusion control from PR title/description |
| `bugsample-creation` | {N} | Generated XAML bug reproduction pages |
| `appium-project-creation` | {N} | Scaffolded/verified test project structure |
| `appium-helper-extensions` | {N} | Referenced helper methods for test implementation |
| `test-repo-identifier` | {N} | Located target test repository |
| `gitea-ops` | {N} | Retrieved PRs, created branches, submitted PR |
| `azure-devops-ops` | {N} | Linked work items (if applicable) |

### Phase Execution Timeline

| Phase | Status | Duration |
|-------|--------|----------|
| Phase 1: Data Gathering | ✅ Complete | {Duration} |
| Phase 2: Data Analysis | ✅ Complete | {Duration} |
| Phase 3: Repo Setup | ✅ Complete | {Duration} |
| Phase 4: Sample & Test Creation | ✅ Complete | {Duration} |
| Phase 5: Commit & PR | ✅ Complete | {Duration} |
| Phase 6: Summary | ✅ Complete | — |

---

## Verification Checklist

- [ ] Bug reproduction sample builds without errors
- [ ] All test methods compile and are discoverable by NUnit
- [ ] AutomationIds match between XAML and test code
- [ ] Platform guards (`#if ANDROID/IOS/WINDOWS/MACOS`) are correctly applied
- [ ] `[TearDown]` includes `Reset()` in all test classes
- [ ] `[SetUp]` includes `App.EnterFullScreen()` under `#if MACOS`
- [ ] Screenshot names follow convention: `Bug_{BugId}_{N}`
- [ ] Navigation entry added in `MainPage.xaml.cs`
- [ ] No secrets or tokens in committed code
- [ ] PR description follows this template

---

## How to Run Tests

```bash
# Android
dotnet test UITests.Android/UITests.Android.csproj --filter "FullyQualifiedName~Bug_{BugId}"

# iOS
dotnet test UITests.iOS/UITests.iOS.csproj --filter "FullyQualifiedName~Bug_{BugId}"

# Windows
dotnet test UITests.Windows/UITests.Windows.csproj --filter "FullyQualifiedName~Bug_{BugId}"

# macOS
dotnet test UITests.macOS/UITests.macOS.csproj --filter "FullyQualifiedName~Bug_{BugId}"
```

---

## Known Issues

| Issue | Severity | Workaround |
|-------|----------|------------|
| {KnownIssue1} | {Low/Medium/High} | {Workaround1} |

---

> Generated by **PR Automation Agent** on {ExecutionDate}

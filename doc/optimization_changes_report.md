# Optimization Changes Report

**Date**: 2026-04-02 14:10:17
**Mode**: APPLIED
**Samples processed**: 9
**Total changes**: 859
**Duration**: 2.1s

---

## Summary

| # | Sample | TearDown | Screenshot Wait | Parallel | Runsettings | Thread.Sleep Commented | Total |
|---|--------|----------|-----------------|----------|-------------|----------------------|-------|
| 1 | AccordionSample | 3 | 1 | 1 | 2 | 1 | 8 |
| 2 | AccordionSample1 | 2 | 1 | 1 | 2 | 1 | 7 |
| 3 | ApplicationCRBugs | 1 | 1 | 1 | 2 | 1 | 6 |
| 4 | BindableLayout | 1 | 1 | 1 | 2 | 1 | 6 |
| 5 | CRBugs | 1 | 1 | 1 | 2 | 1 | 6 |
| 6 | GlobalStylesCRBugs | 1 | 1 | 1 | 2 | 1 | 6 |
| 7 | MAUIExpander | 1 | 1 | 1 | 2 | 1 | 6 |
| 8 | MauiSfExpander | 1 | 1 | 1 | 2 | 1 | 6 |
| 9 | MemoryLeakTestSample | 1 | 1 | 1 | 2 | 1 | 6 |
| | **TOTAL** | **12** | **9** | **9** | **18** | **9** | **859** |

---

## Detailed Changes Per Sample

### AccordionSample

**Changes: 8**

**TearDown:**
- Added `NavigateToHome()` method to `BaseTest.cs`
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`
- Replaced `Reset()` with `NavigateToHome()` in `TestHubMigration.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 80 `Thread.Sleep()` call(s) in `Features.cs`

---

### AccordionSample1

**Changes: 7**

**TearDown:**
- Added `NavigateToHome()` method to `BaseTest.cs`
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 34 `Thread.Sleep()` call(s) in `Features.cs`

---

### ApplicationCRBugs

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 7 `Thread.Sleep()` call(s) in `Features.cs`

---

### BindableLayout

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 104 `Thread.Sleep()` call(s) in `Features.cs`

---

### CRBugs

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 50 `Thread.Sleep()` call(s) in `Features.cs`

---

### GlobalStylesCRBugs

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 9 `Thread.Sleep()` call(s) in `Features.cs`

---

### MAUIExpander

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 35 `Thread.Sleep()` call(s) in `Features.cs`

---

### MauiSfExpander

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Feature.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 63 `Thread.Sleep()` call(s) in `Feature.cs`

---

### MemoryLeakTestSample

**Changes: 6**

**TearDown:**
- Replaced `Reset()` with `NavigateToHome()` in `Features.cs`

**Screenshot Wait:**
- Added `Thread.Sleep(1500)` to `TakeAndCompareScreenshot()` in `BaseTest.cs`

**Parallel:**
- Added `[assembly: Parallelizable(ParallelScope.Fixtures)]` to `AssemblyTestFixture.cs`

**Runsettings:**
- Created `test.runsettings` in `UITests.Android/`
- Created `test.runsettings` in `UITests.iOS/`

**Thread.Sleep Commented:**
- Commented 9 `Thread.Sleep()` call(s) in `Features.cs`

---

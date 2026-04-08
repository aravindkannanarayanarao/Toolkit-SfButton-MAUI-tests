# Test Optimization Report — maui-accordion-tests

**Date**: 2026-04-02 14:10
**Samples Analyzed**: 9
**Total Tests**: 227

## Summary

| Category | Count |
|----------|-------|
| Convert (Assert) | 1 |
| Keep (Screenshot) | 226 |

## Thread.Sleep Analysis

| Metric | Value |
|--------|-------|
| Tests with Thread.Sleep | 207 |
| Total sleep time | 853500ms (853.5s) |

## Duplicate Groups

Found 3 cross-sample duplicate groups:
- AccordionSample/Features.cs::TestCase0, AccordionSample/Features.cs::TestCase1, AccordionSample/Features.cs::TestCase2, AccordionSample/Features.cs::TestCase3, AccordionSample/Features.cs::TestCase4, AccordionSample/Features.cs::TestCase5, AccordionSample/Features.cs::TestCase6, AccordionSample/Features.cs::TestCase7, AccordionSample/Features.cs::TestCase8, AccordionSample/Features.cs::TestCase9, AccordionSample/Features.cs::TestCase10, AccordionSample/Features.cs::TestCase11, AccordionSample/Features.cs::TestCase12, AccordionSample/Features.cs::TestCase13, AccordionSample/Features.cs::TestCase14, AccordionSample/Features.cs::TestCase15, AccordionSample/Features.cs::TestCase16, AccordionSample/Features.cs::TestCase17, AccordionSample/Features.cs::TestCase18, AccordionSample/Features.cs::TestCase19, AccordionSample/Features.cs::TestCase20, AccordionSample/Features.cs::TestCase21, AccordionSample/Features.cs::TestCase22, AccordionSample/Features.cs::TestCase23, AccordionSample/Features.cs::TestCase24, AccordionSample/Features.cs::TestCase25, AccordionSample/Features.cs::TestCase26, AccordionSample/Features.cs::TestCase27, AccordionSample/Features.cs::TestCase28, AccordionSample/Features.cs::TestCase29, AccordionSample/Features.cs::TestCase30, AccordionSample/Features.cs::TestCase31, AccordionSample/Features.cs::TestCase32, AccordionSample/Features.cs::TestCase33, AccordionSample/Features.cs::TestCase34, AccordionSample/Features.cs::TestCase35, AccordionSample/Features.cs::TestCase36, AccordionSample/Features.cs::TestCase37, AccordionSample/Features.cs::TestCase38, AccordionSample/Features.cs::TestCase39, AccordionSample/Features.cs::TestCase40, AccordionSample/Features.cs::TestCase41, AccordionSample/Features.cs::TestCase42, AccordionSample/Features.cs::TestCase43, AccordionSample/Features.cs::TestCase45, AccordionSample/Features.cs::TestCase46, AccordionSample/Features.cs::TestCase47, AccordionSample/Features.cs::TestCase48, AccordionSample/Features.cs::TestCase49, AccordionSample/Features.cs::TestCase50, AccordionSample/Features.cs::TestCase51, AccordionSample/Features.cs::TestCase52, AccordionSample/Features.cs::TestCase53, AccordionSample/Features.cs::TestCase54, AccordionSample1/Features.cs::TestCase49, AccordionSample1/Features.cs::TestCase50, AccordionSample1/Features.cs::TestCase51, AccordionSample1/Features.cs::TestCase52, AccordionSample1/Features.cs::TestCase55, AccordionSample1/Features.cs::TestCase59, AccordionSample1/Features.cs::TestCase60, AccordionSample1/Features.cs::TestCase61, AccordionSample1/Features.cs::TestCase62, AccordionSample1/Features.cs::TestCase63, ApplicationCRBugs/Features.cs::TestCase_1, BindableLayout/Features.cs::TestCase2, BindableLayout/Features.cs::TestCase3, BindableLayout/Features.cs::TestCase4, BindableLayout/Features.cs::TestCase5, BindableLayout/Features.cs::TestCase6, BindableLayout/Features.cs::TestCase7, BindableLayout/Features.cs::TestCase8, BindableLayout/Features.cs::TestCase9, BindableLayout/Features.cs::TestCase10, BindableLayout/Features.cs::Testcase11, BindableLayout/Features.cs::TestCase12, BindableLayout/Features.cs::TestCase13, BindableLayout/Features.cs::TestCase14, BindableLayout/Features.cs::TestCase15, BindableLayout/Features.cs::TestCase16, BindableLayout/Features.cs::TestCase17, BindableLayout/Features.cs::TestCase18, BindableLayout/Features.cs::TestCase19, BindableLayout/Features.cs::TestCase20, BindableLayout/Features.cs::TestCase21, BindableLayout/Features.cs::TestCase22, BindableLayout/Features.cs::TestCase23, BindableLayout/Features.cs::TestCase24, BindableLayout/Features.cs::TestCase25, BindableLayout/Features.cs::TestCase26, BindableLayout/Features.cs::TestCase27, BindableLayout/Features.cs::TestCase28, BindableLayout/Features.cs::TestCase29, BindableLayout/Features.cs::TestCase30, BindableLayout/Features.cs::TestCase31, BindableLayout/Features.cs::TestCase32, BindableLayout/Features.cs::TestCase33, BindableLayout/Features.cs::TestCase34, BindableLayout/Features.cs::TestCase35, BindableLayout/Features.cs::TestCase36, BindableLayout/Features.cs::TestCase37, BindableLayout/Features.cs::TestCase38, BindableLayout/Features.cs::TestCase39, BindableLayout/Features.cs::TestCase40, BindableLayout/Features.cs::TestCase41, BindableLayout/Features.cs::TestCase42, BindableLayout/Features.cs::TestCase43, BindableLayout/Features.cs::TestCase44, BindableLayout/Features.cs::TestCase45, BindableLayout/Features.cs::TestCase48, CRBugs/Features.cs::ImplicitStyle, CRBugs/Features.cs::ExplicitStyle, CRBugs/Features.cs::LoadedPage, CRBugs/Features.cs::ConstructorPage, CRBugs/Features.cs::OnAppearingPage, GlobalStylesCRBugs/Features.cs::TestCase_1, MAUIExpander/Features.cs::TestCase1, MAUIExpander/Features.cs::TestCase2, MAUIExpander/Features.cs::TestCase3, MAUIExpander/Features.cs::TestCase4, MAUIExpander/Features.cs::TestCase6, MAUIExpander/Features.cs::TestCase7, MAUIExpander/Features.cs::TestCase8, MAUIExpander/Features.cs::TestCase9, MAUIExpander/Features.cs::TestCase10, MAUIExpander/Features.cs::TestCase11, MAUIExpander/Features.cs::TestCase12, MAUIExpander/Features.cs::TestCase13, MAUIExpander/Features.cs::TestCase14, MAUIExpander/Features.cs::TestCase15, MAUIExpander/Features.cs::TestCase16, MAUIExpander/Features.cs::TestCase17, MAUIExpander/Features.cs::TestCase18, MAUIExpander/Features.cs::TestCase19, MAUIExpander/Features.cs::TestCase20, MauiSfExpander/Feature.cs::TestCase1, MauiSfExpander/Feature.cs::TestCase2, MauiSfExpander/Feature.cs::TestCase3, MauiSfExpander/Feature.cs::TestCase4, MauiSfExpander/Feature.cs::TestCase5, MauiSfExpander/Feature.cs::TestCase6, MauiSfExpander/Feature.cs::TestCase7, MauiSfExpander/Feature.cs::TestCase8, MauiSfExpander/Feature.cs::TestCase9, MauiSfExpander/Feature.cs::TestCase11, MauiSfExpander/Feature.cs::TestCase14, MauiSfExpander/Feature.cs::TestCase15, MauiSfExpander/Feature.cs::TestCase16, MauiSfExpander/Feature.cs::TestCase17, MauiSfExpander/Feature.cs::TestCase18, MauiSfExpander/Feature.cs::TestCase19, MauiSfExpander/Feature.cs::TestCase20, MauiSfExpander/Feature.cs::TestCase21, MauiSfExpander/Feature.cs::TestCase22, MauiSfExpander/Feature.cs::TestCase24, MauiSfExpander/Feature.cs::TestCase27, MauiSfExpander/Feature.cs::TestCase29, MauiSfExpander/Feature.cs::TestCase32, MauiSfExpander/Feature.cs::TestCase38, MauiSfExpander/Feature.cs::TestCase39, MemoryLeakTestSample/Features.cs::TestCase0, MemoryLeakTestSample/Features.cs::TestCase1, MemoryLeakTestSample/Features.cs::TestCase2
- AccordionSample1/Features.cs::TestCase53, AccordionSample1/Features.cs::TestCase58, BindableLayout/Features.cs::TestCase47
- MAUIExpander/Features.cs::TestCase5, MAUIExpander/Features.cs::TestCase22, MAUIExpander/Features.cs::TestCase23, MAUIExpander/Features.cs::TestCase24, MauiSfExpander/Feature.cs::TestCase28, MauiSfExpander/Feature.cs::TestCase30, MauiSfExpander/Feature.cs::TestCase31, MauiSfExpander/Feature.cs::TestCase33, MauiSfExpander/Feature.cs::TestCase34, MauiSfExpander/Feature.cs::TestCase35, MauiSfExpander/Feature.cs::TestCase36, MauiSfExpander/Feature.cs::TestCase37, MauiSfExpander/Feature.cs::TestCase40, MauiSfExpander/Feature.cs::TestCase41, MauiSfExpander/Feature.cs::TestCase42, MauiSfExpander/Feature.cs::TestCase43, MauiSfExpander/Feature.cs::TestCase44, MauiSfExpander/Feature.cs::TestCase45, MauiSfExpander/Feature.cs::TestCase46, MauiSfExpander/Feature.cs::TestCase47, MauiSfExpander/Feature.cs::TestCase48, MauiSfExpander/Feature.cs::TestCase49, MauiSfExpander/Feature.cs::TestCase50, MauiSfExpander/Feature.cs::TestCase51, MauiSfExpander/Feature.cs::TestCase52, MauiSfExpander/Feature.cs::TestCase53, MauiSfExpander/Feature.cs::TestCase54, MauiSfExpander/Feature.cs::TestCase55, MauiSfExpander/Feature.cs::TestCase56, MauiSfExpander/Feature.cs::TestCase57, MauiSfExpander/Feature.cs::TestCase58, MauiSfExpander/Feature.cs::TestCase59, MauiSfExpander/Feature.cs::TestCase60, MauiSfExpander/Feature.cs::TestCase61, MauiSfExpander/Feature.cs::TestCase62, MauiSfExpander/Feature.cs::TestCase63

## Data-Driven Consolidation Candidates

Found 1321 consolidation candidates:
- AccordionSample/Features.cs: TestCase0, TestCase1
- AccordionSample/Features.cs: TestCase0, TestCase2
- AccordionSample/Features.cs: TestCase0, TestCase3
- AccordionSample/Features.cs: TestCase0, TestCase6
- AccordionSample/Features.cs: TestCase0, TestCase8
- AccordionSample/Features.cs: TestCase0, TestCase9
- AccordionSample/Features.cs: TestCase0, TestCase10
- AccordionSample/Features.cs: TestCase0, TestCase11
- AccordionSample/Features.cs: TestCase0, TestCase12
- AccordionSample/Features.cs: TestCase0, TestCase13
- AccordionSample/Features.cs: TestCase0, TestCase14
- AccordionSample/Features.cs: TestCase0, TestCase15
- AccordionSample/Features.cs: TestCase0, TestCase16
- AccordionSample/Features.cs: TestCase0, TestCase23
- AccordionSample/Features.cs: TestCase0, TestCase24
- AccordionSample/Features.cs: TestCase0, TestCase32
- AccordionSample/Features.cs: TestCase0, TestCase35
- AccordionSample/Features.cs: TestCase0, TestCase36
- AccordionSample/Features.cs: TestCase0, TestCase37
- AccordionSample/Features.cs: TestCase0, TestCase42


---

## Thread.Sleep Optimization Changes (Applied 2026-04-06)

### Optimizations Applied

| Optimization | Description |
|-------------|-------------|
| Pre-screenshot sleep removal | Removed `Thread.Sleep` before `TakeAndCompareScreenshot` in all test methods (handled centrally in `BaseTest.cs`) |
| Thread.Sleep -> WaitForElement | Replaced `Thread.Sleep` with `App.WaitForElement` after navigation taps where AutomationId is available |
| BaseTest common method reduction | Reduced `Thread.Sleep` durations in common helper methods (`Basicsbutton`, `LoadSample`, `EditorIntract`, etc.) |
| TearDown optimization | Replaced `Reset()` with `NavigateToHome()` for faster test teardown |
| Parallelization config | Added `[Parallelizable(ParallelScope.Fixtures)]` and `.runsettings` |

### Current Thread.Sleep State (After Optimization)

| Metric | Value |
|--------|-------|
| Remaining Thread.Sleep calls | 277 |
| Remaining total sleep time | 337500ms (337.5s) |

### Per-Sample Thread.Sleep Breakdown

| Sample | Sleep Calls | Total Duration (ms) |
|--------|------------|--------------------|
| BindableLayout | 114 | 69000 |
| CRBugs | 56 | 59000 |
| AccordionSample1 | 25 | 40500 |
| AccordionSample | 20 | 91500 |
| MAUIExpander | 17 | 18500 |
| GlobalStylesCRBugs | 15 | 18000 |
| ApplicationCRBugs | 13 | 16000 |
| MemoryLeakTestSample | 11 | 16000 |
| MauiSfExpander | 6 | 9000 |

### Git Changes

```
15 files changed, 31 insertions(+), 279 deletions(-)
```

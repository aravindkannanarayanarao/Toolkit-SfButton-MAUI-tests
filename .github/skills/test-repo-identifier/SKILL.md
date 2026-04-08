````skill
---
name: test-repo-identifier
description: Identifies the correct Gitea test repository for a given Syncfusion MAUI control. Maps control names to their corresponding test repositories, branches, and folder structures. Use this skill to locate or create the appropriate test repo when automating bug fix validation. Optionally runs a script to query Gitea for repository metadata.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires network access to gitea.syncfusion.com and GITEA_TOKEN environment variable.
---

# Test Repo Identifier Skill

This skill maps Syncfusion MAUI controls to their corresponding Gitea test repositories, identifies the correct branches and folder structure, and provides scripts to query repository metadata. Use it to locate or create the proper test repository for a control's UI automation tests.

## What This Skill Does

- Maps Syncfusion control names to their Gitea test repository
- Identifies the correct branch for test code (typically `development` or `main`)
- Provides the repository URL, owner, and folder structure
- Queries Gitea API for repository existence and metadata via script
- Determines the naming convention for new test repositories

## Test Repository Naming Convention

Syncfusion MAUI control test repositories follow this pattern:

```
https://gitea.syncfusion.com/essential-studio/{ControlName}-MAUI-tests
```

### Repository Name Pattern
```
{ControlName}-MAUI-tests
```

Where `{ControlName}` is the Syncfusion package name prefix in PascalCase (e.g., `SfTabView`, `SfTextInputLayout`).

## Control-to-Repository Mapping

| Syncfusion Control | Repository Name | Gitea URL |
|-------------------|-----------------|-----------|
| SfTabView | `SfTabView-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfTabView-MAUI-tests` |
| SfTextInputLayout | `SfTextInputLayout-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfTextInputLayout-MAUI-tests` |
| SfAccordion | `SfAccordion-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfAccordion-MAUI-tests` |
| SfListView | `SfListView-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfListView-MAUI-tests` |
| SfComboBox | `SfComboBox-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfComboBox-MAUI-tests` |
| SfAutoComplete | `SfAutoComplete-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfAutoComplete-MAUI-tests` |
| SfNumericEntry | `SfNumericEntry-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfNumericEntry-MAUI-tests` |
| SfSlider | `SfSlider-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfSlider-MAUI-tests` |
| SfChip | `SfChip-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfChip-MAUI-tests` |
| SfBadgeView | `SfBadgeView-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfBadgeView-MAUI-tests` |
| SfSegmentedControl | `SfSegmentedControl-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfSegmentedControl-MAUI-tests` |
| SfCalendar | `SfCalendar-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfCalendar-MAUI-tests` |
| SfDatePicker | `SfDatePicker-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfDatePicker-MAUI-tests` |
| SfTimePicker | `SfTimePicker-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfTimePicker-MAUI-tests` |
| SfTreeView | `SfTreeView-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfTreeView-MAUI-tests` |
| SfNavigationDrawer | `SfNavigationDrawer-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfNavigationDrawer-MAUI-tests` |
| SfCartesianChart | `SfCartesianChart-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfCartesianChart-MAUI-tests` |
| SfCircularChart | `SfCircularChart-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfCircularChart-MAUI-tests` |
| SfFunnelChart | `SfFunnelChart-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfFunnelChart-MAUI-tests` |
| SfPyramidChart | `SfPyramidChart-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfPyramidChart-MAUI-tests` |
| SfPolarChart | `SfPolarChart-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfPolarChart-MAUI-tests` |
| SfScheduler | `SfScheduler-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfScheduler-MAUI-tests` |
| SfPopup | `SfPopup-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfPopup-MAUI-tests` |
| SfRangeSlider | `SfRangeSlider-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfRangeSlider-MAUI-tests` |
| SfMaskedEntry | `SfMaskedEntry-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfMaskedEntry-MAUI-tests` |
| SfRating | `SfRating-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfRating-MAUI-tests` |
| SfPullToRefresh | `SfPullToRefresh-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfPullToRefresh-MAUI-tests` |
| SfEffectsView | `SfEffectsView-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfEffectsView-MAUI-tests` |
| SfShimmer | `SfShimmer-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfShimmer-MAUI-tests` |
| SfAvatarView | `SfAvatarView-MAUI-tests` | `https://gitea.syncfusion.com/essential-studio/SfAvatarView-MAUI-tests` |

## Control Source Repository Mapping

The source code for a control lives in a separate "control repo":

| Repository Pattern | Example |
|-------------------|---------|
| `maui-{controlname}` (lowercase, hyphenated) | `maui-tabview`, `maui-expander` |
| Bug fix PRs are created in the **control repo** | `https://gitea.syncfusion.com/essential-studio/maui-tabview/pulls/606` |
| Test automation is committed to the **test repo** | `https://gitea.syncfusion.com/essential-studio/SfTabView-MAUI-tests` |

### Mapping Control Repo → Test Repo

| Control Repo | Test Repo |
|-------------|-----------|
| `maui-tabview` | `SfTabView-MAUI-tests` |
| `maui-textinputlayout` | `SfTextInputLayout-MAUI-tests` |
| `maui-expander` | `SfAccordion-MAUI-tests` |
| `maui-listview` | `SfListView-MAUI-tests` |
| `maui-combobox` | `SfComboBox-MAUI-tests` |
| `maui-calendar` | `SfCalendar-MAUI-tests` |
| `maui-charts` | `SfCartesianChart-MAUI-tests` (or specific chart type) |
| `maui-scheduler` | `SfScheduler-MAUI-tests` |

## Test Repository Structure

A typical test repository has this structure:

```
{ControlName}-MAUI-tests/
├── {ControlSampleApp}/                    (The MAUI app under test)
│   ├── {ControlSampleApp}.csproj
│   ├── App.xaml / App.xaml.cs
│   ├── AppShell.xaml / AppShell.xaml.cs
│   ├── MainPage.xaml / MainPage.xaml.cs
│   ├── MauiProgram.cs
│   ├── Bug_{BugId}.xaml                   (Bug reproduction pages)
│   └── Bug_{BugId}.xaml.cs
├── UITests.Shared/
│   ├── UITests.Shared.csproj
│   ├── BaseTest.cs
│   ├── VisualTestContext.cs
│   └── Test/
│       ├── BasicFunctionality.cs
│       ├── Orientation.cs                  (Orientation test cases)
│       ├── ThemeTests.cs
│       └── BugFixTests.cs
├── UITests.Android/
│   ├── UITests.Android.csproj
│   ├── Orientation.cs                      (Platform-specific overrides)
│   └── Images/snapshots/                   (Screenshot baselines)
├── UITests.iOS/
│   ├── UITests.iOS.csproj
│   └── Images/snapshots/
├── UITests.macOS/
│   ├── UITests.macOS.csproj
│   └── Images/
├── UITests.Windows/
│   ├── UITests.Windows.csproj
│   └── Images/
└── {ControlSampleApp}.sln
```

## Execution Steps

### Step 1: Identify the Control from PR

Extract the Syncfusion control name from the bug fix PR:
- Check the repository name (e.g., `maui-tabview` → `SfTabView`)
- Check changed files for control namespaces
- Check PR title/description for control mentions

### Step 2: Determine the Test Repository

```bash
# Use the script to check if the test repo exists
pwsh .github/skills/test-repo-identifier/scripts/test-repo-lookup.ps1 \
    -ControlName "SfTabView" \
    -Operation lookup
```

### Step 3: Clone or Create Repository

If the test repo exists:
```bash
git clone https://gitea.syncfusion.com/essential-studio/{ControlName}-MAUI-tests.git
cd {ControlName}-MAUI-tests
git checkout development
```

If the test repo does NOT exist, use the **appium-project-creation** skill to scaffold it from the template.

### Step 4: Create Feature Branch for Bug Fix Tests

```bash
git checkout -b automation/Bug_{BugId}
```

### Step 5: Add Test Cases and Commit

After creating bug samples and test cases using other skills:
```bash
git add .
git commit -m "Add automation test cases for Bug #{BugId}"
git push origin automation/Bug_{BugId}
```

### Step 6: Create Pull Request

Use the **gitea-ops** skill to create a PR:
```bash
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 \
    -Repository "{ControlName}-MAUI-tests" \
    -Operation create-pr \
    -Title "Automation: Bug #{BugId} test cases" \
    -Body "Automated test cases for bug fix #{BugId}" \
    -HeadBranch "automation/Bug_{BugId}" \
    -BaseBranch "development"
```

## Script Usage

The test repo lookup script can:
- **lookup**: Check if a test repo exists for a control
- **info**: Get metadata about an existing test repo (branches, last commit, etc.)
- **list**: List all test repos under `essential-studio`

```bash
# Lookup a repository
pwsh .github/skills/test-repo-identifier/scripts/test-repo-lookup.ps1 \
    -ControlName "SfTabView" -Operation lookup

# Get repo info
pwsh .github/skills/test-repo-identifier/scripts/test-repo-lookup.ps1 \
    -ControlName "SfTabView" -Operation info

# List all test repos
pwsh .github/skills/test-repo-identifier/scripts/test-repo-lookup.ps1 \
    -Operation list
```

## Integration with Other Skills

| Skill | How It Integrates |
|-------|-------------------|
| **control-element-id-identifier** | Maps control name to AutomationId patterns for tests |
| **bugsample-creation** | Creates bug reproduction pages inside the test repo's app |
| **appium-project-creation** | Scaffolds a new test repo if one doesn't exist |
| **appium-helper-extensions** | Provides the helper methods used in test classes |
| **gitea-ops** | Clones repos, creates branches, pushes code, creates PRs |
| **azure-devops-ops** | Links work items to the test repo PRs |

## Notes

- The Gitea organization is always `essential-studio`
- Test repo base URL: `https://gitea.syncfusion.com/essential-studio/`
- Default branch for test repos is `development`
- Test repos may also have `main`, `master`, or `release/*` branches
- Always create a feature branch for new test cases — never push directly to `development`

````

````skill
---
name: bugsample-creation
description: Creates MAUI C# bug reproduction samples based on PR bug fix data. Generates XAML pages and code-behind files that reproduce the original bug scenario and validate the fix. Use when creating automation test samples from analyzed bug fix PRs.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 10+ MAUI project with Syncfusion NuGet packages.
---

# Bug Sample Creation Skill

This skill creates MAUI C# bug reproduction sample pages based on information extracted from bug fix pull requests. It generates the XAML page, code-behind, and navigation entry required to reproduce and validate a bug fix through Appium UI automation.

## What This Skill Does

- Generates MAUI XAML pages that reproduce the bug scenario
- Creates code-behind files with required bindings and logic
- Adds navigation routes and AppShell entries for the sample
- Sets proper AutomationIds for Appium test discovery
- Creates platform-conditional code for multi-platform bugs
- Documents the bug ID and fix in the sample

## Inputs Required

| Input | Required | Description |
|-------|----------|-------------|
| BugId | Yes | The bug/work item ID (e.g., `864440`) |
| ControlName | Yes | The Syncfusion control name (e.g., `SfTextInputLayout`, `SfTabView`) |
| BugDescription | Yes | Short description of the bug being reproduced |
| SolutionDescription | Yes | Description of how the bug was fixed |
| AffectedPlatforms | Yes | Platforms affected: `Android`, `iOS`, `Windows`, `macOS` (comma-separated) |
| SampleProjectPath | Yes | Path to the MAUI sample project |
| Namespace | No | Default: `com.companyname.sampleproject` |

## Bug Sample Page Structure

A bug sample page consists of:
1. **XAML file** — UI layout reproducing the bug scenario
2. **Code-behind (.xaml.cs)** — Event handlers, bindings, initialization
3. **Navigation entry** — AppShell/MainPage route to access the sample
4. **AutomationIds** — Every interactive element must have an `AutomationId`

## Step-by-Step Execution

### Step 1: Identify Control and Bug Scenario

From the PR data, extract:
- The Syncfusion control involved
- The specific properties/configurations that trigger the bug
- The user interaction that reveals the bug
- Platform-specific behavior differences

### Step 2: Generate the XAML Sample Page

Template for a bug reproduction page:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:sf="clr-namespace:Syncfusion.Maui.{ControlNamespace};assembly=Syncfusion.Maui.{AssemblyName}"
             x:Class="SampleProject.Bug_{BugId}"
             Title="Bug_{BugId}">
    <VerticalStackLayout Padding="20" Spacing="10">
        
        <Label Text="Bug #{BugId}: {ShortDescription}"
               AutomationId="bugTitle"
               FontSize="16"
               FontAttributes="Bold" />

        <!-- Bug reproduction control setup -->
        <sf:{ControlType} AutomationId="{controlAutomationId}"
                          {PropertyThatTriggersTheBug}>
            <!-- Child elements as needed -->
        </sf:{ControlType}>

        <!-- Additional elements to validate the fix -->
        <Label AutomationId="statusLabel" Text="Status: Ready" />
        
    </VerticalStackLayout>
</ContentPage>
```

### Step 3: Generate Code-Behind

```csharp
namespace SampleProject;

/// <summary>
/// Bug #{BugId}: {BugDescription}
/// Root Cause: {RootCauseDescription}
/// Fix: {SolutionDescription}
/// </summary>
public partial class Bug_{BugId} : ContentPage
{
    public Bug_{BugId}()
    {
        InitializeComponent();
        // Setup any required data context or event handlers
    }

    // Event handlers for bug reproduction
}
```

### Step 4: Add Navigation Route

In AppShell.xaml or MainPage navigation:

```csharp
// In AppShell.xaml.cs constructor or Routing
Routing.RegisterRoute("Bug_{BugId}", typeof(Bug_{BugId}));

// Or in MainPage navigation (editor + button pattern)
case "Bug_{BugId}":
    await Navigation.PushAsync(new Bug_{BugId}());
    break;
```

For projects using the editor + button navigation pattern (like the sample project template):

```csharp
// In MainPage.xaml
<Entry AutomationId="editor" Placeholder="Enter sample name" />
<Button AutomationId="btn" Text="Go" Clicked="OnButtonClicked" />

// In MainPage.xaml.cs
private async void OnButtonClicked(object sender, EventArgs e)
{
    var sampleName = editor.Text;
    switch (sampleName)
    {
        case "Bug_{BugId}":
            await Navigation.PushAsync(new Bug_{BugId}());
            break;
        // ... other cases
    }
}
```

### Step 5: Set AutomationIds

Every element that needs to be verified or interacted with must have an `AutomationId`:

```xml
<!-- Required AutomationIds -->
<Entry AutomationId="editor" />          <!-- Navigation input -->
<Button AutomationId="btn" />            <!-- Navigation trigger -->
<sf:SfControl AutomationId="control" />  <!-- Target control -->
<Label AutomationId="statusLabel" />     <!-- Verification element -->
```

## Common Bug Reproduction Patterns

### Orientation Bug Pattern
```csharp
// Bug: Control doesn't render correctly after orientation change
App.Tap("btn");                              // Navigate to sample
Thread.Sleep(1000);
App.SetOrientationLandscape();               // Change orientation
Thread.Sleep(2000);
TakeAndCompareScreenshot("Bug_{BugId}_landscape");
App.SetOrientationPortrait();                // Return to portrait
Thread.Sleep(1000);
TakeAndCompareScreenshot("Bug_{BugId}_portrait");
```

### Data Binding Bug Pattern
```csharp
// Bug: Control crashes when bound data changes
App.Tap("btn");
Thread.Sleep(1000);
App.Tap("updateDataButton");                 // Trigger data change
Thread.Sleep(500);
App.WaitForElement("control");               // Verify no crash
TakeAndCompareScreenshot("Bug_{BugId}_afterUpdate");
```

### Theme Change Bug Pattern
```csharp
// Bug: Control doesn't adapt to dark theme
App.Tap("btn");
Thread.Sleep(1000);
App.SetDarkTheme();
Thread.Sleep(1000);
TakeAndCompareScreenshot("Bug_{BugId}_dark");
App.SetLightTheme();
Thread.Sleep(1000);
TakeAndCompareScreenshot("Bug_{BugId}_light");
```

### Keyboard Interaction Bug Pattern
```csharp
// Bug: Control behaves incorrectly when keyboard is shown
App.Tap("btn");
Thread.Sleep(1000);
App.Tap("editor");
App.EnterText("editor", "test input");
#if ANDROID
App.DismissKeyboard();
#elif IOS
App.Tap("Done");
#endif
Thread.Sleep(500);
TakeAndCompareScreenshot("Bug_{BugId}_afterInput");
```

### Scroll/Swipe Bug Pattern
```csharp
// Bug: Control state lost after scrolling
App.Tap("btn");
Thread.Sleep(1000);
App.ScrollDown("scrollView");
Thread.Sleep(500);
App.ScrollUp("scrollView");
Thread.Sleep(500);
App.WaitForElement("control");
TakeAndCompareScreenshot("Bug_{BugId}_afterScroll");
```

## Syncfusion Control NuGet References

When creating a bug sample, include the relevant Syncfusion NuGet package:

| Control | NuGet Package |
|---------|---------------|
| SfTextInputLayout | `Syncfusion.Maui.Core` |
| SfTabView | `Syncfusion.Maui.TabView` |
| SfAccordion | `Syncfusion.Maui.Expander` |
| SfListView | `Syncfusion.Maui.ListView` |
| SfComboBox | `Syncfusion.Maui.Inputs` |
| SfAutoComplete | `Syncfusion.Maui.Inputs` |
| SfNumericEntry | `Syncfusion.Maui.Inputs` |
| SfSlider | `Syncfusion.Maui.Sliders` |
| SfChip | `Syncfusion.Maui.Core` |
| SfCalendar | `Syncfusion.Maui.Calendar` |
| SfDatePicker | `Syncfusion.Maui.Picker` |
| SfTimePicker | `Syncfusion.Maui.Picker` |
| SfChart | `Syncfusion.Maui.Charts` |
| SfCartesianChart | `Syncfusion.Maui.Charts` |
| SfCircularChart | `Syncfusion.Maui.Charts` |
| SfTreeView | `Syncfusion.Maui.TreeView` |
| SfNavigationDrawer | `Syncfusion.Maui.NavigationDrawer` |
| SfBadgeView | `Syncfusion.Maui.Core` |
| SfSegmentedControl | `Syncfusion.Maui.Buttons` |

## MauiProgram.cs Registration

Add the Syncfusion handler in `MauiProgram.cs`:

```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .ConfigureSyncfusionCore()           // For core controls
        .ConfigureSyncfusionTabView()         // For TabView
        .ConfigureSyncfusionCore()        // For DataGrid
        // Add other Syncfusion configurations as needed
        ;
    return builder.Build();
}
```

## File Naming Convention

- **XAML Page**: `Bug_{BugId}.xaml` (e.g., `Bug_864440.xaml`)
- **Code-Behind**: `Bug_{BugId}.xaml.cs` (e.g., `Bug_864440.xaml.cs`)
- **Test Class**: `Bug_{BugId}Tests.cs` or placed in existing test class file
- **Screenshot Baseline**: `Bug_{BugId}_1.png`, `Bug_{BugId}_2.png`, etc.

## Notes

- Always include `Thread.Sleep()` after orientation changes and navigation to allow UI to settle
- Use `TakeAndCompareScreenshot()` for visual regression validation
- The sample should reproduce the bug with minimal code — avoid unnecessary complexity
- Document the bug ID, root cause, and fix in code comments
- Use `#if ANDROID / IOS / MACOS / WINDOWS` for platform-specific behavior

````

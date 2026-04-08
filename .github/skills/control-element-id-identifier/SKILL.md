````skill
---
name: control-element-id-identifier
description: Identifies MAUI Syncfusion control element IDs — AutomationIds, accessibility identifiers, class names, and platform-specific element locators. Use this skill to determine how to find and interact with UI elements in Appium tests across Android, iOS, macOS, and Windows platforms.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Works with Syncfusion.UITestHelpers.Appium framework targeting .NET 10+.
---

# Control Element ID Identifier Skill

This skill provides a comprehensive reference for identifying MAUI Syncfusion control element IDs in Appium UI automation tests. It documents the element-finding strategies, AutomationId conventions, platform-specific identifiers, and XPath patterns used to locate controls reliably across all supported platforms.

## What This Skill Does

- Maps MAUI control names to their platform-specific native class names
- Provides AutomationId and accessibility identifier naming conventions
- Documents XPath and query strategies per platform
- Offers platform-specific fallback strategies when primary locators fail
- Provides Syncfusion control-specific identifier patterns

## Platform-Specific Element Identifiers

### Android
| Attribute | Maps To | Appium Strategy |
|-----------|---------|-----------------|
| `AutomationId` | `content-desc` | `MobileBy.AccessibilityId()` |
| `Text` | `text` attribute | XPath: `//*[@text='...']` |
| `ResourceId` | `resource-id` | `MobileBy.Id()` |
| `ClassName` | `class` (e.g., `android.widget.Button`) | `MobileBy.ClassName()` |

### iOS
| Attribute | Maps To | Appium Strategy |
|-----------|---------|-----------------|
| `AutomationId` | `name` / `label` | `MobileBy.AccessibilityId()` |
| `Text` | `label` / `value` | XPath: `//*[@label='...']` |
| `AccessibilityId` | `accessibility-id` | `MobileBy.AccessibilityId()` |
| `ClassName` | `type` (e.g., `XCUIElementTypeButton`) | `MobileBy.ClassName()` |

### Windows (WinAppDriver)
| Attribute | Maps To | Appium Strategy |
|-----------|---------|-----------------|
| `AutomationId` | `AutomationId` | `MobileBy.AccessibilityId()` |
| `Name` | `Name` attribute | `MobileBy.Name()` |
| `ClassName` | `ClassName` | `MobileBy.ClassName()` |
| `HelpText` | `HelpText` | Custom XPath |

### macOS / Catalyst
| Attribute | Maps To | Appium Strategy |
|-----------|---------|-----------------|
| `AutomationId` | `identifier` | `MobileBy.AccessibilityId()` |
| `Text` | `title` / `value` | XPath: `//*[@title='...']` |
| `TagName` | Maps to AutomationId | Custom lookup |

## Element Finding Strategies (Priority Order)

### Strategy 1: By AutomationId (Recommended)
```csharp
// Cross-platform — fastest and most reliable
app.FindElement("MyControlAutomationId");
app.Tap("MyControlAutomationId");
app.WaitForElement("MyControlAutomationId");
```

### Strategy 2: By Text / Label
```csharp
// Cross-platform — finds element by visible text
app.FindElementByText("Submit");
app.TapByText("Submit");
app.FindVisibleElementByText("Submit", timeoutInSeconds: 5);
```

### Strategy 3: By Accessibility ID (Query)
```csharp
// Using AppiumQuery
var query = AppiumQuery.ByAccessibilityId("MyAccessibilityId");
app.FindElement(query);
app.Tap(query);
```

### Strategy 4: By XPath (Last Resort)
```csharp
// Platform-specific XPath — use when AutomationId is unavailable
app.XpathTap("//android.widget.EditText[@text='Enter name']");
app.XpathTap("//XCUIElementTypeButton[@name='Done']");
```

### Strategy 5: By Class Name
```csharp
var query = AppiumQuery.ByClass("android.widget.Button");
app.FindElements(query);
```

## Syncfusion Control AutomationId Conventions

| Control | Typical AutomationId Pattern | Example |
|---------|------------------------------|---------|
| SfTabView | `tabview`, `Tab_{tabname}` | `app.Tap("tabview")` |
| SfTextInputLayout | `textinputlayout`, `editor` | `app.EnterText("editor", "text")` |
| SfAccordion | `datagrid`, `Accordion_Cell_{row}_{col}` | `app.Tap("accordion")` |
| SfListView | `listview`, `Item_{index}` | `app.ScrollDownTo("Item_5", "listview")` |
| SfComboBox | `combobox` | `app.SelectFromComboBox("combobox")` |
| SfAutoComplete | `autocomplete` | `app.SelectFromAutoComplete("autocomplete", "value", x, y)` |
| SfNumericEntry | `numericentry` | `app.EnterText("numericentry", "42")` |
| SfSlider | `slider` | `app.SetSliderValue("slider", 0.5)` |
| SfChip / SfChipGroup | `chip`, `chipgroup` | `app.Tap("chip")` |
| SfBadgeView | `badgeview` | `app.Tap("badgeview")` |
| SfSegmentedControl | `segmented`, `Segment_{name}` | `app.Tap("Segment_Option1")` |
| SfTreeView | `treeview`, `Node_{name}` | `app.Tap("Node_root")` |
| SfCalendar | `calendar` | `app.Tap("calendar")` |
| SfDatePicker | `datepicker` | `app.Tap("datepicker")` |
| SfTimePicker | `timepicker` | `app.Tap("timepicker")` |
| SfNavigationDrawer | `navigationdrawer` | `app.Tap("navigationdrawer")` |
| SfChart | `chart` | `app.Tap("chart")` |
| SfCartesianChart | `cartesianchart` | `app.Tap("cartesianchart")` |
| SfCircularChart | `circularchart` | `app.Tap("circularchart")` |

## Setting AutomationId in MAUI XAML

```xml
<!-- In your MAUI page -->
<Entry AutomationId="editor" Placeholder="Enter text" />
<Button AutomationId="btn" Text="Submit" />
<sfInput:SfTextInputLayout AutomationId="textinputlayout">
    <Entry AutomationId="editor" />
</sfInput:SfTextInputLayout>
```

## Setting AutomationId in MAUI C# Code-Behind

```csharp
var entry = new Entry { AutomationId = "editor", Placeholder = "Enter text" };
var button = new Button { AutomationId = "btn", Text = "Submit" };
```

## Debugging Element Identifiers

### Print Page Source
```csharp
// Dump the full element tree to console for inspection
var source = app.GetNativePageSource();
Console.WriteLine(source);

// Or use the simpler helper
app.PrintTree();
```

### Check Element Existence
```csharp
bool exists = app.DoesElementExist("MyAutomationId");
```

### Dump Windows Text Input Fields
```csharp
// Windows-specific diagnostic — prints all text input fields with attributes
app.DumpWindowsTextInputs();
```

## Platform-Specific XPath Patterns

### Android
```xpath
//*[@resource-id='com.companyname.myapp:id/editor']
//*[@content-desc='MyAutomationId']
//*[@text='Submit']
//android.widget.Button[@text='OK']
//android.widget.EditText[@content-desc='editor']
//hierarchy/android.widget.FrameLayout/android.widget.LinearLayout
```

### iOS
```xpath
//*[@name='MyAutomationId']
//*[@label='Submit']
//XCUIElementTypeButton[@name='Done']
//XCUIElementTypeTextField[@name='editor']
//XCUIElementTypeStaticText[@label='Hello']
```

### Windows
```xpath
//*[@AutomationId='editor']
//*[@Name='Submit']
//Edit[@AutomationId='editor']
//Button[@Name='OK']
```

### macOS / Catalyst
```xpath
//*[@identifier='MyAutomationId']
//*[@title='Submit']
//XCUIElementTypeButton[@identifier='Done']
```

## Usage with Bug PR Analysis

When analyzing a bug fix PR, use this skill to:
1. Identify the Syncfusion control involved (e.g., `SfTabView`, `SfTextInputLayout`)
2. Determine the correct AutomationId pattern for that control
3. Map the bug scenario to element-finding strategies
4. Generate correct `app.FindElement()`, `app.Tap()`, `app.WaitForElement()` calls
5. Create platform-conditional identifiers using `#if ANDROID / IOS / WINDOWS / MACOS`

## Example: Identifying a Bug Fix Target Control

Given a PR description mentioning "TrailingView not shown in Landscape mode for TextInputLayout":

```csharp
// 1. Identify the control: SfTextInputLayout
// 2. Set AutomationId in sample: "textinputlayout"
// 3. Open the sample page
App.Tap("btn");                          // Navigate to bug reproduction page
Thread.Sleep(1000);

// 4. Interact with the control
App.SetOrientationLandscape();
Thread.Sleep(2000);

// 5. Verify the fix
App.WaitForElement("trailingView");      // Verify trailing view is visible
TakeAndCompareScreenshot("Bug_864440_landscape");
```

````

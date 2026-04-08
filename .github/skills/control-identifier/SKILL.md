````skill
---
name: control-identifier
description: Identifies which Syncfusion MAUI control is involved in a PR by analyzing the PR title and description against a known controls list. Once identified, uses the Syncfusion MCP server to collect control-specific documentation, properties, events, and platform behavior. Outputs a control details document for downstream skills.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Works with PR Automation Agent pipeline. Requires access to Gitea PRs and Syncfusion MCP server.
---

# Control Identifier Skill

This skill identifies the Syncfusion MAUI control referenced in a pull request by matching the PR title and description against a comprehensive controls list. Once the control is confirmed, it collects detailed control documentation using the Syncfusion MCP server and generates a control details document.

## What This Skill Does

1. **Parses PR title and description** to detect Syncfusion control names
2. **Matches against the full controls list** using exact names, aliases, and namespace patterns
3. **Confirms the identified control** with the agent before proceeding
4. **Collects control details** via the Syncfusion MCP server (properties, events, platform behavior)
5. **Generates a control details MD document** for use by downstream skills

## When to Use This Skill

- At the **beginning of Phase 2** of the PR Automation Agent workflow
- Before any element identification, test creation, or project scaffolding
- When you need to determine which Syncfusion control a bug fix targets
- When collecting control-specific documentation for test case creation

---

## Step 1: Parse PR Title and Description

Extract the PR title and body text (already gathered in Phase 1 via `gitea-ops`).

```
PR Title: "[Bug] SfTabView - Tab header not visible in RTL mode"
PR Body: "Fixed an issue where SfTabView tab headers were not rendering..."
```

### Matching Rules

1. **Exact match** — Check if any control name from the list appears in the title (case-insensitive)
2. **Partial match** — Check for control name without the `Sf` prefix (e.g., "TabView" → `SfTabView`)
3. **Namespace match** — Check changed file paths for `Syncfusion.Maui.{ControlArea}` namespaces
4. **Description match** — If not found in title, scan the PR body/description
5. **Repository name match** — Extract from the repo name (e.g., `maui-tabview` → `SfTabView`)

### Priority Order
```
1. PR Title (exact match)     → Highest confidence
2. PR Title (partial match)   → High confidence
3. Repository name            → High confidence
4. PR Description (exact)     → Medium confidence
5. Changed file namespaces    → Medium confidence
6. PR Description (partial)   → Low confidence — ask for confirmation
```

---

## Step 2: Controls List Reference

The following is the complete list of Syncfusion MAUI controls. Match PR content against these names and their aliases.

### Input Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfAutoComplete` | AutoComplete, Auto Complete, Autocomplete | `Syncfusion.Maui.Inputs` |
| `SfComboBox` | ComboBox, Combo Box, Dropdown | `Syncfusion.Maui.Inputs` |
| `SfMaskedEntry` | MaskedEntry, Masked Entry, MaskedTextBox | `Syncfusion.Maui.Inputs` |
| `SfNumericEntry` | NumericEntry, Numeric Entry, NumericTextBox | `Syncfusion.Maui.Inputs` |
| `SfNumericUpDown` | NumericUpDown, Numeric UpDown, Spinner | `Syncfusion.Maui.Inputs` |
| `SfTextInputLayout` | TextInputLayout, Text Input Layout, TIL | `Syncfusion.Maui.Core` |
| `SfRichTextEditor` | RichTextEditor, Rich Text Editor, RTE | `Syncfusion.Maui.RichTextEditor` |

### Button & Selection Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfButton` | Button, SfButton | `Syncfusion.Maui.Buttons` |
| `SfCheckBox` | CheckBox, Check Box | `Syncfusion.Maui.Buttons` |
| `SfChip` | Chip, Chips, ChipGroup, SfChipGroup | `Syncfusion.Maui.Buttons` |
| `SfRadioButton` | RadioButton, Radio Button | `Syncfusion.Maui.Buttons` |
| `SfSegmentedControl` | Segment, Segmented, SegmentedControl | `Syncfusion.Maui.Buttons` |
| `SfSwitch` | Switch, Toggle | `Syncfusion.Maui.Buttons` |

### Navigation & Layout Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfTabView` | TabView, Tab View, Tabs | `Syncfusion.Maui.TabView` |
| `SfNavigationDrawer` | NavigationDrawer, Navigation Drawer, Drawer | `Syncfusion.Maui.NavigationDrawer` |
| `SfBackdropPage` | BackdropPage, Backdrop Page, Backdrop | `Syncfusion.Maui.Backdrop` |
| `SfPopup` | Popup, Pop up, Dialog, Modal | `Syncfusion.Maui.Popup` |
| `SfExpander` | Expander, Expandable | `Syncfusion.Maui.Expander` |
| `SfAccordion` | Accordion | `Syncfusion.Maui.Accordion` |
| `SfDocklayout` | DockLayout, Dock Layout | `Syncfusion.Maui.DockLayout` |
| `SfToolBar` | ToolBar, Tool Bar, Toolbar | `Syncfusion.Maui.ToolBar` |
| `SfCarousel` | Carousel | `Syncfusion.Maui.Carousel` |

### Data Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfAccordion` | DataGrid, Data Grid, Grid | `Syncfusion.Maui.Expander` |
| `SfListView` | ListView, List View | `Syncfusion.Maui.ListView` |
| `SfTreeView` | TreeView, Tree View | `Syncfusion.Maui.TreeView` |
| `SfDataForms` | DataForms, Data Forms, DataForm | `Syncfusion.Maui.DataForm` |
| `SfKanban` | Kanban, Kanban Board | `Syncfusion.Maui.Kanban` |
| `SfPullToRefresh` | PullToRefresh, Pull To Refresh, PTR | `Syncfusion.Maui.PullToRefresh` |
| `SmartDataGrid` | Smart DataGrid, AI DataGrid | `Syncfusion.Maui.SmartComponents` |

### Chart Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfCartesianChart` | CartesianChart, Cartesian Chart, Charts, SfCharts | `Syncfusion.Maui.Charts` |
| `SfCircularChart` | CircularChart, Circular Chart, PieChart, DoughnutChart | `Syncfusion.Maui.Charts` |
| `SfFunnelChart` | FunnelChart, Funnel Chart | `Syncfusion.Maui.Charts` |
| `SfPyramidChart` | PyramidChart, Pyramid Chart | `Syncfusion.Maui.Charts` |
| `SfPolarChart` | PolarChart, Polar Chart, RadarChart | `Syncfusion.Maui.Charts` |

### Calendar & Scheduling Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfCalendar` | Calendar | `Syncfusion.Maui.Calendar` |
| `SfDatePicker` | DatePicker, Date Picker | `Syncfusion.Maui.Picker` |
| `SfTimePicker` | TimePicker, Time Picker | `Syncfusion.Maui.Picker` |
| `SfPicker` | Picker | `Syncfusion.Maui.Picker` |
| `SfScheduler` | Scheduler, Schedule, Calendar Scheduler | `Syncfusion.Maui.Scheduler` |
| `SmartScheduler` | Smart Scheduler, AI Scheduler | `Syncfusion.Maui.SmartComponents` |

### Gauge & Indicator Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfLinearGauge` | LinearGauge, Linear Gauge, SfGauge | `Syncfusion.Maui.Gauges` |
| `SfRadialGauge` | RadialGauge, Radial Gauge | `Syncfusion.Maui.Gauges` |
| `SfBusyIndicator` | BusyIndicator, Busy Indicator, Loading | `Syncfusion.Maui.Core` |
| `SfProgressBar` | ProgressBar, Progress Bar | `Syncfusion.Maui.ProgressBar` |
| `SfShimmer` | Shimmer, Skeleton | `Syncfusion.Maui.Shimmer` |
| `SfRating` | Rating, Star Rating | `Syncfusion.Maui.Inputs` |

### Visualization Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfMaps` | Maps, Map | `Syncfusion.Maui.Maps` |
| `SfTreeMap` | TreeMap, Tree Map | `Syncfusion.Maui.TreeMap` |
| `SfBarcodeGenerator` | BarcodeGenerator, Barcode Generator, QRCode, Barcode | `Syncfusion.Maui.Barcode` |
| `SfImageEditor` | ImageEditor, Image Editor | `Syncfusion.Maui.ImageEditor` |
| `SfSignaturePad` | SignaturePad, Signature Pad, Signature | `Syncfusion.Maui.SignaturePad` |

### Display & Decoration Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfAvatarView` | AvatarView, Avatar View, Avatar | `Syncfusion.Maui.Core` |
| `SfBadgeView` | BadgeView, Badge View, Badge | `Syncfusion.Maui.Core` |
| `SfCards` | Cards, Card View | `Syncfusion.Maui.Cards` |
| `SfEffectsView` | EffectsView, Effects View, Ripple | `Syncfusion.Maui.Core` |
| `SfRotator` | Rotator | `Syncfusion.Maui.Rotator` |

### Slider Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfSlider` | Slider | `Syncfusion.Maui.Sliders` |
| `SfRangeSlider` | RangeSlider, Range Slider | `Syncfusion.Maui.Sliders` |
| `SfDateTimeSlider` | DateTimeSlider, DateTime Slider | `Syncfusion.Maui.Sliders` |

### Communication & AI Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfAIAssistView` | AIAssist, AI Assist, AIAssistView, SfAIAssist | `Syncfusion.Maui.AIAssistView` |
| `SfChat` | Chat, ChatView | `Syncfusion.Maui.Chat` |
| `SfColorPicker` | ColorPicker, Color Picker | `Syncfusion.Maui.ColorPicker` |
| `SfMarkdownViewer` | MarkdownViewer, Markdown Viewer, Markdown | `Syncfusion.Maui.MarkdownViewer` |
| `SmartTextEditor` | Smart Text Editor, AI Text Editor | `Syncfusion.Maui.SmartComponents` |

### Menu Controls

| Control Name | Aliases / Keywords | Namespace Pattern |
|-------------|-------------------|-------------------|
| `SfRadialMenu` | RadialMenu, Radial Menu | `Syncfusion.Maui.RadialMenu` |

---

## Step 3: Identification Algorithm

```
FUNCTION IdentifyControl(prTitle, prBody, repoName, changedFiles):

    // 1. Exact match in title
    FOR EACH control IN controlsList:
        IF prTitle CONTAINS control.name (case-insensitive):
            RETURN { control: control.name, source: "PR Title", confidence: "High" }
        FOR EACH alias IN control.aliases:
            IF prTitle CONTAINS alias (case-insensitive):
                RETURN { control: control.name, source: "PR Title (alias)", confidence: "High" }

    // 2. Repository name match
    controlFromRepo = MapRepoToControl(repoName)
    IF controlFromRepo:
        RETURN { control: controlFromRepo, source: "Repository", confidence: "High" }

    // 3. Exact match in description
    FOR EACH control IN controlsList:
        IF prBody CONTAINS control.name (case-insensitive):
            RETURN { control: control.name, source: "PR Description", confidence: "Medium" }
        FOR EACH alias IN control.aliases:
            IF prBody CONTAINS alias (case-insensitive):
                RETURN { control: control.name, source: "PR Description (alias)", confidence: "Medium" }

    // 4. Namespace match in changed files
    FOR EACH file IN changedFiles:
        FOR EACH control IN controlsList:
            IF file.path CONTAINS control.namespace:
                RETURN { control: control.name, source: "Changed Files", confidence: "Medium" }

    // 5. No match found
    RETURN { control: null, source: null, confidence: "None" }
    // → Ask user to specify the control manually
```

### Repository-to-Control Mapping

| Repository Name Pattern | Control | Test Repository |
|------------------------|---------|-----------------|
| `maui-autocomplete` | `SfAutoComplete` | `SfAutocomplete-MAUI-tests` |
| `maui-avatarview` | `SfAvatarView` | `SfAvatarView-MAUI-tests` |
| `maui-backdrop` | `SfBackdropPage` | `maui-backdrop-tests` |
| `maui-badgeview` | `SfBadgeView` | `SfBadgeView-MAUI-tests` |
| `maui-barcode` | `SfBarcodeGenerator` | `maui-barcode-tests` |
| `maui-busyindicator` | `SfBusyIndicator` | `BusyIndicator-MAUI-tests` |
| `maui-buttons` | `SfButton` | `SfButton-MAUI-tests` |
| `maui-calendar` | `SfCalendar` | `maui-calendar-tests` |
| `maui-cards` | `SfCards` | `maui-cards-tests` |
| `maui-carousel` | `SfCarousel` | `SfCarousel-MAUI-tests` |
| `maui-charts` | `SfCartesianChart` / `SfCircularChart` | `maui-charts-tests` |
| `maui-checkbox` | `SfCheckBox` | `Maui-SfCheckBox-test` |
| `maui-chips` | `SfChip` | `SfChip-MAUI-tests` |
| `maui-combobox` | `SfComboBox` | `SfComboBox-MAUI-tests` |
| `maui-dataforms` | `SfDataForms` | `maui-dataform-tests` |
| `maui-expander` | `SfAccordion` | `maui-accordion-tests` |
| `maui-effectsview` | `SfEffectsView` | `SfEffectsView-MAUI-tests` |
| `maui-expander` | `SfExpander` / `SfAccordion` | `maui-accordion-tests` |
| `maui-gauges` | `SfLinearGauge` / `SfRadialGauge` | `maui-gauges-tests` |
| `maui-imageeditor` | `SfImageEditor` | `maui-image-editor-tests` |
| `maui-inputs` | `SfTextInputLayout` / `SfNumericEntry` / `SfMaskedEntry` | `SfTextInputLayout-MAUI-tests` |
| `maui-kanban` | `SfKanban` | `maui-kanban-tests` |
| `maui-listview` | `SfListView` | `maui-listview-tests` |
| `maui-maps` | `SfMaps` | `maui-maps-tests` |
| `maui-navigationdrawer` | `SfNavigationDrawer` | `SfNavigationDrawer-MAUI-tests` |
| `maui-picker` | `SfPicker` / `SfDatePicker` / `SfTimePicker` | `maui-picker-tests` |
| `maui-popup` | `SfPopup` | `maui-popup-tests` |
| `maui-progressbar` | `SfProgressBar` | `maui-progressbar-tests` |
| `maui-pulltorefresh` | `SfPullToRefresh` | `maui-pulltorefresh-tests` |
| `maui-radialmenu` | `SfRadialMenu` | `SfRadialMenu-MAUI-tests` |
| `maui-radiobutton` | `SfRadioButton` | `Maui-SfRadioButton-test` |
| `maui-rating` | `SfRating` | `SfRating-MAUI-tests` |
| `maui-richtexteditor` | `SfRichTextEditor` | `maui-sfrichtexteditor-test` |
| `maui-rotator` | `SfRotator` | `SfRotator-MAUI-tests` |
| `maui-scheduler` | `SfScheduler` | `maui-scheduler-tests` |
| `maui-segmented` | `SfSegmentedControl` | `maui-segmentcontrol-test` |
| `maui-shimmer` | `SfShimmer` | `maui-shimmer-test` |
| `maui-signaturepad` | `SfSignaturePad` | `SfSignaturePad-MAUI-tests` |
| `maui-sliders` | `SfSlider` / `SfRangeSlider` | `maui-sliders-tests` |
| `maui-switch` | `SfSwitch` | `SfSwitch-MAUI-tests` |
| `maui-tabview` | `SfTabView` | `maui-tabview-tests` |
| `maui-textinputlayout` | `SfTextInputLayout` | `SfTextInputLayout-MAUI-tests` |
| `maui-treeview` | `SfTreeView` | `maui-treeview-tests` |
| `maui-treemap` | `SfTreeMap` | `maui-treemap-test` |
| `maui-aiassistview` | `SfAIAssistView` | `aiassist-maui-test` |
| `maui-chat` | `SfChat` | `maui-chat-tests` |
| `maui-colorpicker` | `SfColorPicker` | `maui-sfcolorpicker-test` |
| `maui-docklayout` | `SfDocklayout` | `maui-SfDockLayout-test` |
| `maui-markdownviewer` | `SfMarkdownViewer` | `maui-markdownviewer-tests` |
| `maui-signaturepad` | `SfSignaturePad` | `SfSignaturePad-MAUI-tests` |
| `maui-toolbar` | `SfToolBar` | `maui-toolbar-tests` |
| `maui-smartdatagrid` | `SmartDataGrid` | `maui-SmartDataGrid-tests` |
| `maui-smartscheduler` | `SmartScheduler` | `maui-SmartScheduler-tests` |
| `maui-smarttexteditor` | `SmartTextEditor` | `maui-SmartTextEditor-tests` |

---

## Step 4: Confirm Identified Control

Once a control is identified, the agent MUST confirm before proceeding:

```
✅ Control Identified: SfTabView
   Source: PR Title ("[Bug] SfTabView - Tab header not visible in RTL mode")
   Confidence: High
   Namespace: Syncfusion.Maui.TabView

   Proceeding with SfTabView for automation...
```

If confidence is **Low** or **None**, ask the user:
```
⚠️ Could not confidently identify the Syncfusion control.
   Best guess: SfTextInputLayout (from PR description mention of "input layout")
   
   Please confirm the control name or specify manually.
```

---

## Step 5: Collect Control Details via Syncfusion MCP Server

After the control is confirmed, use the **Syncfusion MCP server** to gather control-specific documentation.

### What to Collect

| Data Category | Description |
|---------------|-------------|
| **Control Overview** | What the control does, primary use cases |
| **Key Properties** | Bindable properties, their types, and defaults |
| **Key Events** | Events fired by the control with event args |
| **Platform Behavior** | Platform-specific rendering differences |
| **Known Limitations** | Any platform-specific limitations or workarounds |
| **XAML Usage** | Typical XAML declaration with common properties |
| **C# Usage** | Programmatic instantiation pattern |
| **NuGet Package** | Required NuGet package name |
| **Namespace** | Full namespace for XAML `xmlns` and C# `using` |
| **Dependencies** | Any dependent controls or additional packages needed |

### MCP Server Query Examples

```
Query: "SfTabView MAUI control documentation, properties, events"
Query: "SfAccordion MAUI control features, column types, selection modes"
Query: "SfTextInputLayout MAUI control input types, validation, floating label"
```

### Output: Control Details Document

Generate a structured Markdown document with the collected information:

```markdown
# {ControlName} — Control Details

## Overview
{Brief description of what the control does}

## NuGet Package
`{PackageName}` (version: latest)

## Namespace
- XAML: `xmlns:sf="clr-namespace:{Namespace};assembly={Assembly}"`
- C#: `using {Namespace};`

## Key Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| {Prop1} | {Type} | {Default} | {Description} |

## Key Events
| Event | EventArgs | Description |
|-------|-----------|-------------|
| {Event1} | {Args} | {Description} |

## Platform Behavior
| Platform | Behavior |
|----------|----------|
| Android | {behavior} |
| iOS | {behavior} |
| Windows | {behavior} |
| macOS | {behavior} |

## XAML Usage
```xml
<sf:{ControlName} AutomationId="{id}" {CommonProperties} />
```

## Known Limitations
- {limitation1}
- {limitation2}
```

---

## Step 6: Pass Results to Downstream Skills

After identification and data collection, the following information is passed to the next phases:

| Output | Used By |
|--------|---------|
| Control name (e.g., `SfTabView`) | `control-element-id-identifier`, `test-repo-identifier`, `bugsample-creation` |
| Namespace | `bugsample-creation` (XAML xmlns declarations) |
| NuGet package | `appium-project-creation` (csproj references) |
| Properties and events | `bugsample-creation` (setting up reproduction scenario) |
| Platform behavior | `appium-helper-extensions` (choosing platform-specific methods) |
| Control details document | Stored as reference for test case creation |

---

## Integration with Other Skills

| Skill | How This Skill Feeds Into It |
|-------|------------------------------|
| **control-element-id-identifier** | Provides the control name → skill maps it to AutomationId patterns |
| **bugsample-creation** | Provides namespace, properties, events → skill creates XAML reproduction page |
| **appium-project-creation** | Provides NuGet package → skill adds it to csproj |
| **test-repo-identifier** | Provides control name → skill maps to test repository |
| **appium-helper-extensions** | Provides platform behavior → skill selects correct helper methods |

---

## Example: Full Identification Flow

### Input
```
PR Title: "[Bug] SfTextInputLayout - TrailingView not shown in Landscape mode"
PR Body: "Fixed an issue where SfTextInputLayout trailing view was not visible when the device was rotated to landscape orientation. The issue was in the layout calculation..."
Repository: essential-studio/maui-inputs
Changed Files: src/Syncfusion.Maui.Core/TextInputLayout/SfTextInputLayout.cs
```

### Step-by-Step Execution

1. **Parse title** → Found "SfTextInputLayout" → Exact match → High confidence
2. **Confirm**: `✅ Control Identified: SfTextInputLayout (from PR Title, High confidence)`
3. **Query MCP server** for SfTextInputLayout documentation
4. **Generate control details document**:
   ```markdown
   # SfTextInputLayout — Control Details
   
   ## Overview
   A container that decorates input controls with floating labels, helper text,
   error messages, leading/trailing views, and character counters.
   
   ## NuGet Package
   `Syncfusion.Maui.Core`
   
   ## Namespace
   - XAML: `xmlns:sfInput="clr-namespace:Syncfusion.Maui.Core;assembly=Syncfusion.Maui.Core"`
   - C#: `using Syncfusion.Maui.Core;`
   
   ## Key Properties
   | Property | Type | Default | Description |
   |----------|------|---------|-------------|
   | Hint | string | "" | Floating label text |
   | ContainerType | ContainerType | Outlined | Border style |
   | TrailingView | View | null | Trailing icon/view |
   | LeadingView | View | null | Leading icon/view |
   | IsHintAlwaysFloated | bool | false | Keep label floating |
   
   ## Key Events
   | Event | EventArgs | Description |
   |-------|-----------|-------------|
   | Focused | FocusEventArgs | Input control received focus |
   | Unfocused | FocusEventArgs | Input control lost focus |
   ```

5. **Pass to downstream skills**:
   - `control-element-id-identifier`: Map `SfTextInputLayout` → AutomationId patterns
   - `test-repo-identifier`: Map `SfTextInputLayout` → `SfTextInputLayout-MAUI-tests`
   - `bugsample-creation`: Use namespace, properties for XAML reproduction

---

## Notes

- This skill should ALWAYS run before `control-element-id-identifier`
- If multiple controls are mentioned in a single PR, identify the PRIMARY control (the one being fixed)
- The Syncfusion MCP server provides the most accurate and up-to-date documentation
- Control details documents can be cached per control to avoid repeated MCP queries
- When in doubt about the control, always ask the user rather than guessing wrong
````

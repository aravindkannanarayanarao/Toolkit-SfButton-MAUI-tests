---
name: maui-user-documentation
description: Writes comprehensive user documentation for .NET MAUI custom UI controls and libraries. Use when writing user guides, creating usage examples, or preparing documentation for developers.
compatibility: Requires access to the control source code and public API surface. Documentation is written in Markdown.
---

# User Documentation Skill

Writes comprehensive, example-driven user documentation for .NET MAUI custom UI controls and libraries. Produces structured documentation with mandatory Overview and Getting Started pages, plus categorized feature pages — each with working XAML and C# examples, not just API name and one-line descriptions.

## When to Use

- Writing user guides for controls
- Creating usage examples and tutorials
- Preparing documentation for developers consuming the control/library
- Documenting public API surface (properties, methods, events)
- Generating getting started guides with NuGet setup instructions

## Core Principles

1. **Research first** - Before writing documentation, search the repository for existing docs, README files, API guidelines, and spec documents. Understand what exists and follow established documentation patterns
2. **Example-driven** - Every documented feature, property, method, and event MUST include a working example with both XAML and C# code. Never just list an API name with a one-line description
3. **Mandatory pages** - Every control MUST have an **Overview** page and a **Getting Started** page. These are non-negotiable
4. **Categorized documentation** - Group related APIs into logical category pages (Customization, Data Binding, Events, Styling, etc.) rather than dumping everything into one page
5. **Complete API coverage** - All public properties, methods, events, and commands must be documented somewhere in the documentation set. Nothing should be undocumented
6. **Practical, not theoretical** - Show real-world usage scenarios with business objects, view models, and realistic data — not abstract `Foo`/`Bar` examples
7. **Confirm structure before writing** - Present the planned documentation structure (page list, categories) to the user for confirmation before writing content
8. **Never skip silently** - If any step cannot be performed or any rule needs to be bypassed (e.g., missing API reference, undocumented feature, incomplete examples), do NOT silently skip it. Stop and ask the user for confirmation on how to proceed before continuing

## Repository Documentation Discovery

**MANDATORY: Before writing documentation, search the repository for existing content and conventions.**

### What to Look For

| Document Type | Common Locations | Purpose |
|--------------|------------------|---------|
| **Existing docs** | `docs/`, `documentation/`, `wiki/` | Existing documentation to extend or update |
| **README files** | `README.md`, `src/*/README.md` | Existing usage guides, API descriptions |
| **Source code** | Control `.cs` files | XML doc comments, public API surface |
| **Spec docs** | `docs/specs/`, `specs/`, `requirements/` | Feature specifications, acceptance criteria |
| **Sample projects** | `samples/`, `demo/`, `examples/` | Working examples to reference |
| **Changelog** | `CHANGELOG.md`, `RELEASE_NOTES.md` | Feature history, version info |
| **NuGet config** | `*.csproj`, `*.nuspec`, `Directory.Build.props` | Package name, version, dependencies |

### How to Search

```bash
# Find existing documentation
find . -name "*.md" -not -path "*/bin/*" -not -path "*/obj/*" | head -50

# Find the control's public API surface
grep -rn "public.*class\|public.*interface\|public.*enum" --include="*.cs" src/ | head -30

# Find all public properties
grep -rn "public.*BindableProperty\|public.*Property\b" --include="*.cs" src/ | head -30

# Find all public events
grep -rn "public.*event " --include="*.cs" src/ | head -20

# Find all public methods
grep -rn "public.*void\|public.*Task\|public.*bool\|public.*string\|public.*int\|public.*double" --include="*.cs" src/ | grep -v "get;\|set;" | head -30

# Find NuGet package info
grep -rn "PackageId\|Version\|PackageVersion" --include="*.csproj" | head -10

# Find sample/demo projects
find . -path "*/samples/*" -o -path "*/demo/*" -o -path "*/examples/*" | head -20
```

### What to Extract

- **Package name and version** — for NuGet install instructions
- **Namespace** — for xmlns declarations
- **All public properties** — with types, defaults, and binding modes
- **All public events** — with event args types
- **All public methods** — with parameters and return types
- **Enums** — all enum values used by properties
- **Dependencies** — required packages, platform SDK versions
- **Registration** — how to register handlers/services in `MauiProgram.cs`

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| Control/library to document | Yes | The control or library to create documentation for |
| Target audience | Optional | Skill level of target readers (beginner, intermediate, advanced) |
| Existing docs | Optional | Any existing documentation to extend or update |
| Platform support | Optional | Which platforms are supported |
| NuGet details | Optional | Package name, version, feed URL |

## Outputs

| Field | Description |
|-------|-------------|
| `pages_created` | List of documentation pages created |
| `api_coverage` | Percentage of public API documented |
| `result` | `Complete`, `Partial`, or `Blocked` |

## Mandatory Documentation Structure

Every control MUST have at minimum these pages. Additional pages are added based on the control's feature set.

### Required Pages

```
docs/
├── [control-name]/
│   ├── overview.md              # MANDATORY — What the control is, key features, screenshot
│   ├── getting-started.md       # MANDATORY — Prerequisites, NuGet install, minimal working example
│   ├── data-binding.md          # If control supports data binding
│   ├── customization.md         # Configurable properties grouped logically
│   ├── events.md                # All events with examples
│   ├── methods.md               # All public methods with examples  
│   ├── commands.md              # If control has ICommand properties
│   ├── styling.md               # Visual customization, colors, fonts, templates
│   ├── templates.md             # If control supports DataTemplate/ControlTemplate
│   └── [feature-name].md        # Separate page for complex features needing detailed docs
```

### When to Create a Separate Feature Page

Create a dedicated page for a feature when:
- It has multiple configuration options or modes (e.g., "Suggest Mode" with Suggest, Append, SuggestAppend)
- It requires a detailed explanation with multiple examples
- It involves complex setup (e.g., Remote Search, Custom Filtering)
- It's a key selling point of the control that deserves prominence

## Page Templates

### Template 1: Overview Page (MANDATORY)

```markdown
---
title: [Control Name] Overview
slug: [control-name]-overview
---

# .NET MAUI [Control Name] Overview

[2-3 sentence description of what the control does and its primary use case.]

![Control Name Overview](images/[control-name]-overview.png)

## Key Features

The .NET MAUI [Control Name] provides the following key features:

- **[Feature 1 Name]** — [Brief description of what this feature does and why 
  it's useful, with link to dedicated page]
- **[Feature 2 Name]** — [Brief description]
- **[Feature 3 Name]** — [Brief description]
- **[Feature N Name]** — [Brief description]

## Supported Platforms

| Platform | Supported |
|----------|-----------|
| Android | ✅ |
| iOS | ✅ |
| Windows | ✅ |
| macOS | ✅ |

## Next Steps

- [Getting Started with [Control Name]](getting-started.md)
- [Customization](customization.md)
- [Data Binding](data-binding.md)

## See Also

- [Events](events.md)
- [Methods](methods.md)
- [Styling](styling.md)
```

### Template 2: Getting Started Page (MANDATORY)

```markdown
---
title: Getting Started with [Control Name]
slug: [control-name]-getting-started
---

# Getting Started with the .NET MAUI [Control Name]

This guide provides the information you need to start using the [Control Name]
by adding the control to your project.

At the end, you will achieve the following result:

![Control Name Getting Started](images/[control-name]-getting-started.png)

## Prerequisites

Before adding the [Control Name], you need to:

1. Set up your .NET MAUI application.
2. Install the required NuGet package.

### Install the NuGet Package

Install the `[PackageName]` NuGet package:

**Package Manager Console:**
```
Install-Package [PackageName] -Version [x.x.x]
```

**.NET CLI:**
```
dotnet add package [PackageName] --version [x.x.x]
```

**Or add directly to your `.csproj`:**
```xml
<PackageReference Include="[PackageName]" Version="[x.x.x]" />
```

## Register the Control

Register the control handlers in your `MauiProgram.cs`:

```csharp
using [Namespace];

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMyControls()  // Register control handlers
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        return builder.Build();
    }
}
```

## Add the Namespace

Add the XML namespace to your XAML page:

```xml
xmlns:controls="clr-namespace:[Namespace];assembly=[AssemblyName]"
```

## Define the Control

**XAML:**
```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:controls="clr-namespace:[Namespace];assembly=[AssemblyName]"
             x:Class="MyApp.MainPage">

    <controls:[ControlName] [MinimalProperties]="[Values]" />

</ContentPage>
```

**C#:**
```csharp
var control = new [ControlName]
{
    [MinimalProperty1] = [value1],
    [MinimalProperty2] = [value2]
};
```

This is the result:

![Getting Started Result](images/[control-name]-getting-started-result.png)

## Next Steps

- [Customization](customization.md) — Configure the control appearance and behavior
- [Data Binding](data-binding.md) — Bind data to the control
- [Events](events.md) — Handle control events

## See Also

- [[Control Name] Overview](overview.md)
- [Styling](styling.md)
```

### Template 3: Feature Category Page

```markdown
---
title: [Category Name]
slug: [control-name]-[category]
---

# [Category Name] in .NET MAUI [Control Name]

[2-3 sentence overview of this category — what it covers and why it matters.]

## [Feature/Property Group 1]

[Description of what this feature does, when to use it, and how it affects 
the control. NOT just "Gets or sets the value." — explain the behavior.]

The `[PropertyName]` property (`[Type]`) controls [what it does]. 
The default value is `[default]`.

The available options are:

| Value | Description |
|-------|-------------|
| `Option1` | [What this option does and when to use it] |
| `Option2` | [What this option does and when to use it] |
| `Option3` | [What this option does and when to use it] |

### Example

Create a data model:

```csharp
public class ItemModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}
```

Create a ViewModel:

```csharp
public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ItemModel> Items { get; set; }
    
    public MainViewModel()
    {
        Items = new ObservableCollection<ItemModel>
        {
            new ItemModel { Name = "Item 1", Description = "First item" },
            new ItemModel { Name = "Item 2", Description = "Second item" },
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
```

Use in XAML:

```xml
<controls:[ControlName] [PropertyName]="Option1"
                        ItemsSource="{Binding Items}"
                        DisplayMemberPath="Name" />
```

Result with `[PropertyName]="Option1"`:

![Feature Option1](images/[control-name]-[feature]-option1.png)

Result with `[PropertyName]="Option2"`:

![Feature Option2](images/[control-name]-[feature]-option2.png)

## [Feature/Property Group 2]

[Same pattern — description, options table, full example...]

## See Also

- [Related Page 1](related-page-1.md)
- [Related Page 2](related-page-2.md)
```

### Template 4: Events Page

```markdown
---
title: Events
slug: [control-name]-events
---

# Events in .NET MAUI [Control Name]

The [Control Name] exposes the following events for handling user interaction 
and state changes.

## [EventName]

The `[EventName]` event fires when [describe exactly when this event fires 
and why you would handle it]. The event provides a `[EventArgsType]` object 
with the following properties:

| Property | Type | Description |
|----------|------|-------------|
| `[Prop1]` | `[Type]` | [What this property contains] |
| `[Prop2]` | `[Type]` | [What this property contains] |

### Example

```xml
<controls:[ControlName] [EventName]="OnEventFired" />
```

```csharp
private void OnEventFired(object sender, [EventArgsType] e)
{
    // Access event data
    var value = e.[Prop1];
    
    // Example: Update UI based on event
    statusLabel.Text = $"Event fired with value: {value}";
}
```

**Common use case:** [Describe a real-world scenario where you'd use this event, 
e.g., "Use ValueChanged to update a summary label as the user adjusts a slider."]

## [NextEventName]

[Same pattern...]

## See Also

- [Commands](commands.md)
- [Data Binding](data-binding.md)
```

### Template 5: Methods Page

```markdown
---
title: Methods
slug: [control-name]-methods
---

# Methods in .NET MAUI [Control Name]

The [Control Name] provides the following public methods.

## [MethodName]

```csharp
public [ReturnType] [MethodName]([ParameterType] [paramName])
```

[Describe what this method does, when to call it, and what happens when you do. 
NOT just "Calls the method." — explain the behavior and side effects.]

| Parameter | Type | Description |
|-----------|------|-------------|
| `[paramName]` | `[Type]` | [What this parameter controls] |

**Returns:** `[ReturnType]` — [What the return value represents]

### Example

```csharp
var control = new [ControlName]();

// [Describe the scenario]
var result = control.[MethodName](paramValue);

// [Show what to do with the result]
```

**When to use:** [Describe a practical scenario for calling this method.]

## See Also

- [Events](events.md)
- [Customization](customization.md)
```

## Workflow

### Step 1: Research the Repository

**MANDATORY: Do this before writing any documentation.**

1. **Search for existing documentation** that may need updating rather than creating from scratch
2. **Extract the complete public API surface** from source code:
   - List all public properties with types, defaults, and XML doc comments
   - List all public events with event arg types
   - List all public methods with signatures
   - List all public enums with values
3. **Find NuGet package details** — package name, version, dependencies
4. **Find namespace and registration** — how the control is registered in `MauiProgram.cs`
5. **Check for sample projects** — existing working examples to reference

### Step 2: Plan the Documentation Structure

1. **Categorize all public API members:**

   | API Member | Category/Page |
   |-----------|---------------|
   | Properties controlling appearance | `customization.md` or `styling.md` |
   | Properties controlling behavior | `customization.md` or dedicated feature page |
   | Properties for data | `data-binding.md` |
   | Events | `events.md` |
   | Methods | `methods.md` |
   | Commands | `commands.md` |
   | Template-related | `templates.md` |
   | Complex features with multiple options | Dedicated `[feature-name].md` page |

2. **Determine which features need dedicated pages:**
   - Features with multiple modes or options
   - Features requiring detailed setup or configuration
   - Features that are key selling points of the control

3. **Create the page list:**
   - ✅ `overview.md` (MANDATORY)
   - ✅ `getting-started.md` (MANDATORY)
   - Plus categorized pages based on the API surface

### 🚫 STOP — Get User Confirmation Before Proceeding

**MANDATORY: Present the documentation structure to the user and wait for confirmation before writing content.**

Present:
1. **Complete page list** — all planned documentation pages with brief description of what each covers
2. **API-to-page mapping** — which properties, events, methods go on which page
3. **Dedicated feature pages** — which features get their own page and why
4. **Any gaps** — API members that are unclear or need clarification

Only proceed to Step 3 after user confirms the documentation plan.

### Step 3: Write the Overview Page

Follow Template 1. Include:
- Clear control description (what it does, primary use case)
- Screenshot/image placeholder
- Key features list with links to dedicated pages
- Platform support table
- Navigation to next steps

### Step 4: Write the Getting Started Page

Follow Template 2. Include:
- Prerequisites
- NuGet package installation (Package Manager, .NET CLI, `.csproj`)
- Handler registration in `MauiProgram.cs`
- XML namespace declaration
- Minimal working example in both XAML and C#
- Screenshot of the result
- Links to next steps

**The Getting Started page should get the user from zero to a working control in under 5 minutes.**

### Step 5: Write Category Pages

For each category page:

1. **Group related properties/features logically** — don't just alphabetically list everything
2. **For each feature/property group:**
   - Explain what it does and when to use it (not just "Gets or sets X")
   - Show available options/values in a table if applicable
   - Provide a complete, working example including:
     - Data model class (if needed)
     - ViewModel class (if needed)
     - XAML usage
     - C# alternative
     - Screenshot placeholder showing the result
3. **Show multiple configurations** when a property has enum values — show examples for each value with result screenshots

### Step 6: Write Events and Methods Pages

For events:
- Describe *when* the event fires (not just "fires when the event occurs")
- Document the EventArgs properties in a table
- Provide a working event handler example
- Describe a real-world use case

For methods:
- Describe *what* the method does and *when* to call it
- Document parameters in a table
- Show return value and what it represents
- Provide a practical example with scenario description

### Step 7: Write Dedicated Feature Pages

For complex features:
- Follow Template 3
- Show each mode/option with its own example and screenshot
- Include the data model and ViewModel setup
- Show XAML for each configuration variant
- Provide comparison between options

### Step 8: Review and Cross-Link

1. **Verify complete API coverage:**

   | API Member | Documented In | Has Example |
   |-----------|---------------|-------------|
   | Property1 | customization.md | ✅ |
   | Property2 | data-binding.md | ✅ |
   | Event1 | events.md | ✅ |
   | Method1 | methods.md | ✅ |

2. **Add "See Also" sections** to every page linking to related pages
3. **Verify all examples are complete** — every example must include all necessary code (model, ViewModel, XAML/C#), not just a snippet
4. **Verify consistency** — same control name, namespace, and conventions used throughout

## Documentation Quality Rules

### ❌ DO NOT

```markdown
## Value Property

Gets or sets the value.

`public double Value { get; set; }`
```

This is BAD documentation. It tells the developer nothing they can't already see from IntelliSense.

### ✅ DO

```markdown
## Value

The `Value` property (`double`) controls the current progress of the control, 
expressed as a number between `Minimum` and `Maximum`. When set, the control 
visually updates to reflect the new progress. If a value outside the range is 
provided, it is automatically coerced to the nearest bound.

The default value is `0.0`. The property supports two-way data binding.

### Example

Track download progress by binding `Value` to a ViewModel property:

**ViewModel:**
```csharp
public class DownloadViewModel : INotifyPropertyChanged
{
    private double _progress;
    public double Progress
    {
        get => _progress;
        set
        {
            _progress = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public async Task StartDownload()
    {
        for (int i = 0; i <= 100; i += 10)
        {
            Progress = i;
            await Task.Delay(200);
        }
    }
}
```

**XAML:**
```xml
<controls:ProgressRing Value="{Binding Progress}"
                       Minimum="0"
                       Maximum="100"
                       TrackColor="LightGray"
                       ProgressColor="Blue" />

<Label Text="{Binding Progress, StringFormat='{0}% Complete'}" />
```
```

This is GOOD documentation. It explains behavior, shows coercion, and provides a real-world scenario.

### Documentation Writing Rules

| Rule | Description |
|------|-------------|
| **Every property must have an example** | Show XAML usage and/or C# for every property |
| **Every event must have a handler example** | Show the event handler method with event args usage |
| **Every method must have a usage example** | Show when and how to call it with actual scenario |
| **Enum properties must show all values** | Table of enum values + example for each major value |
| **Use realistic data** | Business objects like `Client`, `Product`, `Order` — not `Foo`, `Bar` |
| **Show both XAML and C#** | Getting Started must show both; other pages at minimum show XAML |
| **Include ViewModel when binding** | Complete ViewModel with `INotifyPropertyChanged` |
| **Screenshot placeholders** | Mark where screenshots should go: `![Description](images/filename.png)` |
| **Cross-link related pages** | Every page has a "See Also" section |
| **Group logically, not alphabetically** | Related properties together, not A-Z |

## Common Mistakes to Avoid

| Mistake | Why It's Wrong | Correct Approach |
|---------|----------------|------------------|
| ❌ One-line property descriptions | Developer learns nothing beyond IntelliSense | ✅ Describe behavior, defaults, coercion, binding mode |
| ❌ No examples | Developer can't understand usage | ✅ Working example for every feature |
| ❌ Abstract examples (`Foo`, `Bar`) | Not relatable, hard to understand | ✅ Realistic data models and scenarios |
| ❌ XAML-only examples | C#-only developers excluded | ✅ Show both XAML and C# (at least in Getting Started) |
| ❌ Missing NuGet/setup instructions | Developer can't get started | ✅ Complete Getting Started with install, register, use |
| ❌ Missing event args documentation | Developer can't use event data | ✅ Table of EventArgs properties |
| ❌ All APIs on one giant page | Overwhelming, hard to find things | ✅ Categorized pages with logical grouping |
| ❌ No "See Also" cross-links | Developer can't discover related features | ✅ Every page links to related pages |
| ❌ Skipping repo research | Miss existing docs, package info | ✅ Always search repo first |
| ❌ Writing docs before confirming structure | May need to restructure later | ✅ Get user confirmation on page plan first |

## Completion Criteria

The skill is complete when:
- [ ] Repository has been searched for existing docs, API surface, package info
- [ ] Documentation structure has been confirmed with the user
- [ ] **Overview page** is written with key features and platform support
- [ ] **Getting Started page** is written with prerequisites, NuGet install, registration, and minimal working example
- [ ] All public **properties** are documented with behavior description and examples
- [ ] All public **events** are documented with firing conditions, EventArgs table, and handler examples
- [ ] All public **methods** are documented with parameters, return values, and usage examples
- [ ] All public **commands** are documented (if applicable)
- [ ] All **enum values** used by properties are listed and explained
- [ ] Complex features have **dedicated pages** with multi-option examples
- [ ] Every documentation page has **working code examples** (not just descriptions)
- [ ] Every page has a **"See Also"** section with cross-links
- [ ] Documentation uses **realistic data models** and scenarios
- [ ] No property, event, or method is left undocumented

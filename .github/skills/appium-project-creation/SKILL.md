````skill
---
name: appium-project-creation
description: Creates a complete MAUI C# Appium UI test project from the project template. Scaffolds the solution structure with platform-specific test projects (Android, iOS, macOS, Windows), shared test code, NuGet references, and baseline configuration. Use when a new Appium automation test project is needed for a Syncfusion control.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires .NET 10+, NUnit 4.1+, Appium.WebDriver 5.0.0, Syncfusion.UITestHelpers packages.
---

# Appium Project Creation Skill

This skill scaffolds a complete MAUI C# Appium UI test project from the standard project template. It creates the entire solution structure including shared test code, per-platform test projects, NuGet package references, and baseline configuration files.

## What This Skill Does

- Creates the full test solution from the project template at `.github/projecttemplate/SampleProject/`
- Customizes project names, namespaces, app identifiers, and control references
- Configures per-platform `DefineConstants` (ANDROID, IOS, MACOS, WINDOWS)
- Sets up `BaseTest`, `VisualTestContext`, and test fixture infrastructure
- Adds Syncfusion UITestHelpers NuGet package references
- Creates report output directories and screenshot diff folders

## Project Template Location

```
.github/projecttemplate/SampleProject/
├── SampleProject.sln
├── SampleProject/                    (The MAUI app under test)
│   ├── App.xaml / App.xaml.cs
│   ├── AppShell.xaml / AppShell.cs
│   ├── MainPage.xaml / MainPage.xaml.cs
│   ├── MauiProgram.cs
│   └── SampleProject.csproj
├── UITests.Shared/                   (Shared test code — NoTargets SDK)
│   ├── UITests.Shared.csproj
│   ├── BaseTest.cs
│   ├── VisualTestContext.cs
│   └── Test/                         (Test classes go here)
├── UITests.Android/
│   ├── UITests.Android.csproj
│   └── Images/snapshots/
├── UITests.iOS/
│   ├── UITests.iOS.csproj
│   └── Images/snapshots/
├── UITests.macOS/
│   ├── UITests.macOS.csproj
│   └── Images/
└── UITests.Windows/
    ├── UITests.Windows.csproj
    └── Images/
```

## Inputs Required

| Input | Required | Description |
|-------|----------|-------------|
| ControlName | Yes | Syncfusion control name (e.g., `SfTabView`, `SfTextInputLayout`) |
| ProjectName | Yes | Name of the test project (e.g., `SfTabView-MAUI-tests`) |
| AppId | Yes | Bundle/package ID of the MAUI app (e.g., `com.companyname.tabviewsample`) |
| AppName | Yes | Windows process name of the app (e.g., `TabViewSample`) |
| MacAppId | No | macOS bundle ID if different from AppId |
| iOSAppName | No | iOS app name if different from AppId |
| TargetRepo | No | Gitea repo where the project will be pushed |
| GiteaOwner | No | Default: `essential-studio` |

## Step-by-Step Project Creation

### Step 1: Copy the Template

Copy the entire project template from `.github/projecttemplate/SampleProject/` to the target location:

```bash
# Create the target directory
mkdir -p /path/to/{ProjectName}

# Copy the template
cp -r .github/projecttemplate/SampleProject/* /path/to/{ProjectName}/
```

### Step 2: Rename Solution and Projects

Rename files and update references:

```bash
# Rename .sln file
mv SampleProject.sln {ProjectName}.sln

# Rename the MAUI app project folder and .csproj
mv SampleProject/ {ControlAppName}/
mv {ControlAppName}/SampleProject.csproj {ControlAppName}/{ControlAppName}.csproj
```

Update the `.sln` file to reference the new project names.

### Step 3: Customize BaseTest.cs

Update the `BaseTest.cs` with correct app identifiers:

```csharp
public override IConfig GetTestConfig()
{
    reportpath();
    var config = new Config();

    // Update these values for each project
    config.SetProperty("AppId", "{AppId}");              // e.g., "com.companyname.tabviewsample"
    config.SetProperty("AppMain", "{AppMainActivity}");  // Android main activity CRC
    
    if (_testDevice == TestDevice.Windows)
    {
        config.SetProperty("AppName", "{AppName}");      // e.g., "TabViewSample"
    }

    if (_testDevice == TestDevice.Mac)
    {
        config.SetProperty("MacApp", "{MacAppId}");      // e.g., "com.companyname.tabviewsample"
    }

    if (_testDevice == TestDevice.iOS)
    {
        config.SetProperty("iOSAppName", "{iOSAppName}");
        // Simulator config
        if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SIMID")))
        {
            config.SetProperty("Udid", Environment.GetEnvironmentVariable("SIMID"));
        }
        else
        {
            config.SetProperty("DeviceName", "iPhone 16");
            config.SetProperty("PlatformVersion", "18.0");
        }
    }
    
    return config;
}
```

### Step 4: Create Test Class Files

Create test classes in `UITests.Shared/Test/` directory:

```csharp
using NUnit.Framework;
using Syncfusion.UITestHelpers.Appium;
using Syncfusion.UITestHelpers.Core;
using UITests.Shared;

namespace SfControlNameScripts  // e.g., SfTabViewScripts
{
    public class BasicFunctionality : BaseTest
    {
        public BasicFunctionality(TestDevice testDevice) : base(testDevice)
        {
        }

        [SetUp]
        public void Setup()
        {
#if MACOS
            App.EnterFullScreen();
#endif
        }

        [TearDown]
        public void TearDown()
        {
#if MACOS
            App.ExitFullScreen();
#endif
            Reset();  // Reset App after each test
        }

        [Test]
        [Category("Basic Functionality")]
        [WrittenBy("Agent")]
        public void Test_BasicRender()
        {
            // Navigate to sample
            Basicsbutton("BasicSample");
            Thread.Sleep(2000);
            TakeAndCompareScreenshot("BasicRender");
        }
    }
}
```

### Step 5: Platform-Specific csproj Configuration

Each platform csproj follows this pattern:

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
        <IsTestProject>true</IsTestProject>
        <RootNamespace>UITests</RootNamespace>
    </PropertyGroup>

    <PropertyGroup Condition="'$(Configuration)' == 'Debug'">
        <DefineConstants>$(DefineConstants);{PLATFORM_CONSTANT}</DefineConstants>
    </PropertyGroup>

    <!-- NuGet Packages -->
    <ItemGroup>
        <PackageReference Include="Appium.WebDriver" Version="5.0.0" />
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.9.0" />
        <PackageReference Include="NUnit" Version="4.1.0" />
        <PackageReference Include="NUnit.Console" Version="3.19.2" />
        <PackageReference Include="NUnit.ConsoleRunner" Version="3.19.2" />
        <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
        <PackageReference Include="VisualTestUtils" Version="0.9.46-beta" />
        <PackageReference Include="VisualTestUtils.MagickNet" Version="0.9.46-beta" />
    </ItemGroup>

    <!-- Shared test code -->
    <ItemGroup>
        <Compile Include="..\UITests.Shared\**\*.cs" LinkBase="Shared" Visible="false" />
    </ItemGroup>

    <!-- Syncfusion UITestHelpers -->
    <ItemGroup>
        <PackageReference Include="Syncfusion.UITestHelpers.Appium" Version="*" />
        <PackageReference Include="Syncfusion.UITestHelpers.Core" Version="*" />
        <PackageReference Include="Syncfusion.UITestHelpers.NUnit" Version="*" />
        <PackageReference Include="Syncfusion.UITestHelpers.ExtendReport" Version="*" />
        <PackageReference Include="Syncfusion.UITestHelpers.Screenshot" Version="*" />
    </ItemGroup>
</Project>
```

Platform constants:
- **Android**: `ANDROID`
- **iOS**: `IOS`
- **macOS**: `MACOS`
- **Windows**: `WINDOWS`

### Step 6: Create Report Directory Structure

```bash
# Per-platform report and snapshot directories
mkdir -p UITests.Android/Images/snapshots
mkdir -p UITests.Android/Images/snapshots-diff
mkdir -p UITests.Android/Images/snapshots-output
mkdir -p UITests.Android/report

mkdir -p UITests.iOS/Images/snapshots

mkdir -p UITests.macOS/Images

mkdir -p UITests.Windows/Images
```

### Step 7: Create Report HTML Files

Copy the report template files:
- `report/dashboard.html`
- `report/home.html`
- `report/updateStats.js`

### Step 8: Create UITests.Shared.csproj

```xml
<Project Sdk="Microsoft.Build.NoTargets/3.7.0">
    <PropertyGroup>
        <TargetFrameworks>net10.0</TargetFrameworks>
        <GenerateAssemblyInfo>False</GenerateAssemblyInfo>
        <GenerateMSBuildEditorConfigFile>False</GenerateMSBuildEditorConfigFile>
        <RootNamespace>UITests</RootNamespace>
    </PropertyGroup>
    <ItemGroup>
        <Content Include="**\*.cs" />
    </ItemGroup>
</Project>
```

## Running Tests

```bash
# Build and run Android tests
dotnet test UITests.Android/UITests.Android.csproj --configuration Debug

# Build and run iOS tests
dotnet test UITests.iOS/UITests.iOS.csproj --configuration Debug

# Build and run Windows tests
dotnet test UITests.Windows/UITests.Windows.csproj --configuration Debug

# Build and run macOS tests
dotnet test UITests.macOS/UITests.macOS.csproj --configuration Debug
```

## Getting the Android AppMain CRC

To obtain the `AppMain` CRC hash needed for Android configuration:

1. Build and deploy the MAUI app in Debug mode on an Android emulator
2. Run: `adb shell dumpsys activity activities | grep -i "crc"` 
3. Look for the main activity class like `crc641182c9129960376f.MainActivity`
4. Use the `crc...` prefix as the `AppMain` value

## Integration with Other Skills

| Skill | Integration Point |
|-------|-------------------|
| **control-element-id-identifier** | Provides AutomationId patterns for the target control |
| **bugsample-creation** | Generates bug reproduction pages placed in the MAUI app |
| **appium-helper-extensions** | Documents the helper methods used in test classes |
| **test-repo-identifier** | Locates the correct test repository for the control |
| **gitea-ops** | Pushes the created project and creates PRs |

## Notes

- The project template is located at `.github/projecttemplate/SampleProject/`
- Always use the latest Syncfusion.UITestHelpers NuGet packages with wildcard version `*`
- Test classes should inherit from `BaseTest` which extends `UITestData` → `UITestBase` → `UITestContextBase`
- The `Reset()` method in `[TearDown]` kills the app process between tests
- Visual regression uses `VisualTestUtils` + `VisualTestUtils.MagickNet` for screenshot comparison

````

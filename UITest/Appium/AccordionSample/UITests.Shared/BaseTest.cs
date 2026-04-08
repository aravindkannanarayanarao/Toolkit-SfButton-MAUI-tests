using NUnit.Framework;
using Syncfusion.UITestHelpers.Appium;  
using Syncfusion.UITestHelpers.Core;
using Syncfusion.UITestHelpers.Screenshot;
using System.Diagnostics;
using VisualTestUtils;
using VisualTestUtils.MagickNet;
using System.Reflection;
using OpenQA.Selenium.Appium;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.ExtendReport;
using System.Drawing.Imaging;
using System.Drawing;
using AccordionScripts1;

namespace UITests.Shared;

#if ANDROID
[TestFixture(TestDevice.Android)]
#elif IOS
[TestFixture(TestDevice.iOS)]
#elif MACOS
[TestFixture(TestDevice.Mac)]
#elif WINDOWS
[TestFixture(TestDevice.Windows)]
#endif
public abstract class BaseTest : UITestData
{
    [ThreadStatic] static string? _currentSessionUdid;

    public BaseTest(TestDevice testDevice) : base(testDevice)
    {
    }

    public override IConfig GetTestConfig()
    {
        reportpath();
        var config = new Config();

        var appIdentifierKey = "AppId";

        // Note: an app with this ID has to be deployed to the emulator/device you want to run it on
        var appIdentifier = "com.companyname.accordionsample";
        var AppMain1 = "AppMain";
        var defaultAppMain = "crc64ccbe8b2f819dfe3f";

        // Per-device MainActivity CRC hash mapping
        // Each emulator gets its own AppMain so they can be configured independently
        var deviceAppMainMap = new Dictionary<string, string>
        {
            { "emulator-5554", "crc64ccbe8b2f819dfe3f" },
            { "emulator-5556", "crc64ccbe8b2f819dfe3f" }
        };

        config.SetProperty(appIdentifierKey, appIdentifier);

        if (_testDevice == TestDevice.Android)
        {
            // Priority 1: Read UDID from TargetDevice attribute on the current test method
            var testMethodName = TestContext.CurrentContext.Test.MethodName;
            var methodAttr = testMethodName != null
                ? GetType().GetMethod(testMethodName)?.GetCustomAttribute<TargetDevice>()
                : null;

            if (methodAttr != null)
            {
                config.SetProperty("Udid", methodAttr.Udid);
            }
            // Priority 2: Read UDID from TargetDevice attribute on the test class
            else
            {
                var classAttr = GetType().GetCustomAttribute<TargetDevice>();
                if (classAttr != null)
                {
                    config.SetProperty("Udid", classAttr.Udid);
                }
                // Priority 3: Fallback to ANDROID_UDID environment variable
                else if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ANDROID_UDID")))
                {
                    config.SetProperty("Udid", Environment.GetEnvironmentVariable("ANDROID_UDID"));
                }
            }

            // Set the AppMain (MainActivity CRC hash) based on the target device
            var udid = config.GetProperty<string>("Udid");
            if (!string.IsNullOrEmpty(udid) && deviceAppMainMap.TryGetValue(udid, out var deviceAppMain))
            {
                config.SetProperty(AppMain1, deviceAppMain);
            }
            else
            {
                config.SetProperty(AppMain1, defaultAppMain);
            }
        }
        else
        {
            config.SetProperty(AppMain1, defaultAppMain);
        }

        if (_testDevice == TestDevice.Windows)
        {
            var appIdentifierKey11 = "AppName";

            // Note: a release build has to be done and the path to this .exe file should exist. Tweak this path if necessary
            var appIdentifier1 = "AccordionSample";

            config.SetProperty(appIdentifierKey11, appIdentifier1);
        }

        // If the app ID is provided through an environment variable, like through CI, use that instead
        if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("APPID")))
        {
            appIdentifier = Environment.GetEnvironmentVariable("APPID");
        }

        //config.SetProperty(appIdentifierKey, appIdentifier);

        if (_testDevice == TestDevice.Mac)
        {
            var Macappname = "MacApp";
            var MacappnameID = "com.companyname.accordionsample";
            config.SetProperty(Macappname, MacappnameID);
        }
        //config.SetProperty(appIdentifierKey, appIdentifier);
        if (_testDevice == TestDevice.iOS)
        {
            var appIdentifierKey11 = "iOSAppName";
            // Note: a release build has to be done and the path to this .exe file should exist. Tweak this path if necessary
            var appIdentifier1 = "com.companyname.accordionsample";
            config.SetProperty(appIdentifierKey11, appIdentifier1);
            // Note: this is passed down from the GitHub Action. If nothing is set, fall back to a default value below
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SIMID")))
            {
                config.SetProperty("Udid", Environment.GetEnvironmentVariable("SIMID"));
            }
            else
            {
                config.SetProperty("DeviceName", "iPhone 13");
                config.SetProperty("PlatformVersion", "15.2");
            }
}

        return config;
    }

    /// <summary>
    /// Runs before each test. Checks if the current test targets a different device
    /// than the active session. If so, recreates the Appium session for the correct device.
    /// </summary>
    [SetUp]
    public void EnsureCorrectDeviceSession()
    {
        if (_testDevice != TestDevice.Android)
            return;

        var testMethodName = TestContext.CurrentContext.Test.MethodName;
        var methodAttr = testMethodName != null
            ? GetType().GetMethod(testMethodName)?.GetCustomAttribute<TargetDevice>()
            : null;

        string? requiredUdid = methodAttr?.Udid;
        if (requiredUdid == null)
        {
            var classAttr = GetType().GetCustomAttribute<TargetDevice>();
            requiredUdid = classAttr?.Udid;
        }

        if (requiredUdid != null)
        {
            if (_currentSessionUdid != null && requiredUdid != _currentSessionUdid)
            {
                // Device changed — need a new Appium session targeting the correct emulator
                Reset();
            }
            _currentSessionUdid = requiredUdid;
        }
    }

     public void TakeAndCompareScreenshot(string filename)
    {
        // Explicit wait to ensure UI is fully stable before capturing screenshot
        Thread.Sleep(1500);

#if ANDROID 
        var screenshotHelper = new AndroidScreenshotHelper(App);
        screenshotHelper.TakeAndCompareScreenshots(filename);
#elif WINDOWS
 
        var screenshotHelper = new WindowsScreenshotHelper(App);
        screenshotHelper.TakeAndCompareScreenshots(filename);
#elif IOS
 
        var screenshotHelper = new iOSScreenshotHelper(App);
        screenshotHelper.TakeAndCompareScreenshots(filename);
#elif MACOS
 
        var screenshotHelper = new MacScreenshotHelper(App);
        screenshotHelper.TakeAndCompareScreenshots(filename);
#endif
    }
    public void reportpath()
    {
#if WINDOWS
        DataBridge.report = @"..\..\..\report";
        DataBridge.htmlhomepage = @"..\..\..\report\home.html";
        DataBridge.htmldashbard = @"..\..\..\report\dashboard.html";
        DataBridge.updateStats = @"..\..\..\report\updateStats.js";

#elif ANDROID || IOS || MACOS

            DataBridge.report = @"../../../report";
            DataBridge.htmlhomepage = @"../../../report/home.html";
            DataBridge.htmldashbard = @"../../../report/dashboard.html";
            DataBridge.updateStats = @"../../../report/updateStats.js";
#endif
    }

    /// <summary>
    /// Navigates back to the home page instead of killing the app.
    /// Uses platform-specific back navigation with Reset() fallback.
    /// </summary>
    public void NavigateToHome()
    {
        try
        {
#if ANDROID
            App.Back();
#elif IOS
            App.Back();
#elif WINDOWS
            App.TapBackArrow();
#elif MACOS
            App.TapBackArrow();
#endif
            App.WaitForElement("Basics", timeout: TimeSpan.FromSeconds(2));
            Thread.Sleep(500);
        }
        catch
        {
            // Fallback to Reset() if navigation fails
            Reset();
        }
    }

    //Common Methods

    public void Basicsbutton(string filename)

    {
        App.EnterText("editor", filename);
        App.Tap("btn");
        Thread.Sleep(500);
        Option();
        Thread.Sleep(500);
    }
    public void Basicscbutton(string filename)

    {
        App.EnterText("editor", filename);
        App.Tap("btn");
        Thread.Sleep(500);
    }
    public void Option()
    {
#if ANDROID
        Thread.Sleep(2000);
        App.TapCoordinates(1022f, 223f);
#else
        App.Tap("option");
#endif
        Thread.Sleep(1000);
    }
    public void TwoTap(string filename, string filename1)
    {
        App.Tap(filename);
        App.Tap(filename1);
    }

    public void iTwoTap(string filename, string filename1)
    {
        App.Tap(filename);
        App.Tap(filename1);
#if iOS
            App.Tap("Done");
#endif
    }
    public void iTwoTap1(string field, string value)
    {
        Thread.Sleep(1000);
#if IOS
        App.Tap(field);
        App.iOSPickerInteract(field, value);
#else
        App.Tap(field);
        App.Tap(value);
#endif
    }

}
using NUnit.Framework;
using Syncfusion.UITestHelpers.Appium;
using Syncfusion.UITestHelpers.Core;
using OpenQA.Selenium.Appium;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.Screenshot;
using OpenQA.Selenium;

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
public abstract class BaseTest : UITestBase
{
    public BaseTest(TestDevice testDevice) : base(testDevice)
    {
    }

    public override IConfig GetTestConfig()
    {
        reportpath();
        var config = new Config();

        var appIdentifierKey = "AppId";

        // Note: an app with this ID has to be deployed to the emulator/device you want to run it on
        var appIdentifier = "com.companyname.SfButtonSample";
        var AppMain1 = "AppMain";
        var AppMain12 = "crc6443b590b4b829944e";

        config.SetProperty(appIdentifierKey, appIdentifier);
        config.SetProperty(AppMain1, AppMain12);

        if (_testDevice == TestDevice.Windows)
        {
            var appIdentifierKey11 = "AppName";

            // Note: a release build has to be done and the path to this .exe file should exist. Tweak this path if necessary
            var appIdentifier1 = "SfButtonSample";

            config.SetProperty(appIdentifierKey11, appIdentifier1);
        }

        // If the app ID is provided through an environment variable, like through CI, use that instead
        if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("APPID")))
        {
            appIdentifier = Environment.GetEnvironmentVariable("APPID");
        }


        if (_testDevice == TestDevice.Mac)
        {
            var Macappname = "MacApp";
            var MacappnameID = "com.companyname.SfButtonSample";
            config.SetProperty(Macappname, MacappnameID);

        }

        //config.SetProperty(appIdentifierKey, appIdentifier);

        if (_testDevice == TestDevice.iOS)
        {
            var appIdentifierKey11 = "iOSAppName";
            // Note: a release build has to be done and the path to this .exe file should exist. Tweak this path if necessary
            var appIdentifier1 = "com.companyname.SfButtonSample";

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
    /// Captures a screenshot of the current application view and compares it with a baseline image
    /// to validate UI consistency. The correct platform-specific screenshot helper is used
    /// depending on the build target (Android, iOS, Windows, or macOS).
    /// </summary>
    /// <param name="filename">The name of the screenshot file to be captured and compared.</param>
    public void TakeAndCompareScreenshot(string filename)
    {
#if ANDROID
        // Instantiate the Android-specific screenshot helper using the current app context
        var screenshotHelper = new AndroidScreenshotHelper(App);

        // Capture a screenshot and compare it with the baseline image on Android
        screenshotHelper.TakeAndCompareScreenshots(filename);

#elif WINDOWS
        // Instantiate the Windows-specific screenshot helper using the current app context
        var screenshotHelper = new WindowsScreenshotHelper(App);

        // Capture a screenshot and compare it with the baseline image on Windows
        screenshotHelper.TakeAndCompareScreenshots(filename);

#elif IOS
    // Instantiate the iOS-specific screenshot helper using the current app context
    var screenshotHelper = new iOSScreenshotHelper(App);

    // Capture a screenshot and compare it with the baseline image on iOS
    screenshotHelper.TakeAndCompareScreenshots(filename);

#elif MACOS
        // Instantiate the macOS-specific screenshot helper using the current app context
        var screenshotHelper = new MacScreenshotHelper(App);

        // Capture a screenshot and compare it with the baseline image on macOS
        screenshotHelper.TakeAndCompareScreenshots(filename);
#endif
    }


    public void reportpath()
    {
#if WINDOWS
        UITestExtendReport.report = @"..\..\..\report";
        UITestExtendReport.htmlhomepage = @"..\..\..\report\home.html";
        UITestExtendReport.htmldashbard = @"..\..\..\report\dashboard.html";
        UITestExtendReport.updateStats = @"..\..\..\report\updateStats.js";

#elif ANDROID || IOS || MACOS

            UITestExtendReport.report = @"../../../report";
            UITestExtendReport.htmlhomepage = @"../../../report/home.html";
            UITestExtendReport.htmldashbard = @"../../../report/dashboard.html";
            UITestExtendReport.updateStats = @"../../../report/updateStats.js";
#endif
    }


    //Common Methods

    public void Basicsbutton(string filename)
    {
        App.EnterText("editor", filename);
        App.Tap("btn");
        Thread.Sleep(5000);
    }


}


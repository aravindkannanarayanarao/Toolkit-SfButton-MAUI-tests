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
    public BaseTest(TestDevice testDevice) : base(testDevice)
    {
    }

    public override IConfig GetTestConfig()
    {
        reportpath();
        var config = new Config();

        var appIdentifierKey = "AppId";

        // Note: an app with this ID has to be deployed to the emulator/device you want to run it on
        var appIdentifier = "com.companyname.applicationcrbugs";
        var AppMain1 = "AppMain";
        var AppMain12 = "crc64bf759c61be87415c";

        config.SetProperty(appIdentifierKey, appIdentifier);
        config.SetProperty(AppMain1, AppMain12);

        if (_testDevice == TestDevice.Windows)
        {
            var appIdentifierKey11 = "AppName";

            // Note: a release build has to be done and the path to this .exe file should exist. Tweak this path if necessary
            var appIdentifier1 = "ApplicationCRBugs";

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
            var MacappnameID = "com.companyname.applicationcrbugs";
            config.SetProperty(Macappname, MacappnameID);
        }
        //config.SetProperty(appIdentifierKey, appIdentifier);
        if (_testDevice == TestDevice.iOS)
        {
            var appIdentifierKey11 = "iOSAppName";
            // Note: a release build has to be done and the path to this .exe file should exist. Tweak this path if necessary
            var appIdentifier1 = "com.companyname.applicationcrbugs";
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

    //Common Methods

    public void Basicsbutton(string filename)

    {
        App.EnterText("editor", filename);
        App.Tap("btn");
        Thread.Sleep(2500);
        Option();
        Thread.Sleep(1500);
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

}
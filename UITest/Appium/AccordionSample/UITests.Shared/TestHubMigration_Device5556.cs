using AccordionScripts;
using NUnit.Framework;
using OpenQA.Selenium;
using Syncfusion.UITestHelpers.Appium;
using Syncfusion.UITestHelpers.Core;
using Syncfusion.UITestHelpers.ExtendReport;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.Screenshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UITests.Shared;
using AccordionScripts1;

namespace AccordionScripts
{
    [TargetDevice("emulator-5556")]
    internal class AccordionTesthubMigration_Device5556 : BaseTest
    {
        public AccordionTesthubMigration_Device5556(TestDevice testDevice) : base(testDevice)
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
            NavigateToHome();
        }
        [Test]
        [Description("Verify that Accordion items load correctly when placed inside a StackLayout.")]
        public void AccordionInStackLayout()
        {
            App.TapButton("StackLayoutSample");
            App.WaitForElement("StackLayout Case");
            App.TapButton("Item 2");
            App.WaitForElement("Content 2");
            TakeAndCompareScreenshot("AccordionInStackLayout");
        }
        [Test]
        [Description("Verify that Accordion items load correctly when placed inside a HorizontalStackLayout.")]
        public void AccordionInHorizontalStackLayout()
        {
            App.TapButton("StackLayoutSample");
            App.WaitForElement("HorizontalStackLayout");
            App.TapButton("H Item 2");
            App.WaitForElement("H Content 2");
            TakeAndCompareScreenshot("AccordionInHorizontalStackLayout");
        }
        [Test]
        [Description("Verify that Accordion items load correctly in HorizontalStackLayout when navigated via ShellPage.")]
        public void AccordionInHorizontalStackLayoutShellPage()
        {
            App.TapButton("ShellPageSample");
#if WINDOWS
            App.WaitForElement("Navigation Options");
            App.TapButton("Navigation Options");
#endif
            App.TapButton("HorizontalStackLayout ShellPage");
            App.WaitForElement("Horizontal Content 1");
#if IOS || WINDOWS
            App.TapButton("Horizontal Layout with SfAccordion");
#endif
            TakeAndCompareScreenshot("AccordionInHorizontalStackLayoutShellPage");
        }
        [Test]
        [Description("Verify that Accordion items load correctly in HorizontalStackLayout when navigated via NavigationPushAsync.")]
        public void AccordionNavigationPushAsyncHorizontalStackLayout()
        {
            App.TapButton("NavigationSample");
            App.WaitForElement("SfAccordion Navigation Tests");
            App.TapButton("Horizontal NavigationPushAsync");
            App.WaitForElement("Horizontal Content 1");
#if IOS || WINDOWS
            App.TapButton("Horizontal Layout with SfAccordion");
#endif
            TakeAndCompareScreenshot("AccordionNavigationPushAsyncHorizontalStackLayout");
        }
        [Test]
        [Description("Verify that Accordion items load correctly in HorizontalStackLayout when navigated via NavigationPushModalAsync.")]
        public void AccordionNavigationPushModalAsyncHorizontalStackLayout()
        {
            App.TapButton("NavigationSample");
            App.WaitForElement("SfAccordion Navigation Tests");
            App.TapButton("Horizontal NavigationPushModalAsync");
            App.WaitForElement("Horizontal Content 1");
#if IOS || WINDOWS
            App.TapButton("Horizontal Layout with SfAccordion");
#endif
            TakeAndCompareScreenshot("AccordionNavigationPushModalAsyncHorizontalStackLayout");
        }
        [Test]
        [Description("Verify GlobalStyle applies correctly: ExpanderIcon at start, multiple expand enabled, increased item spacing, and slow animation.")]
        public void AccordionGlobalStyle()
        {
            App.TapButton("StyleSample");
            App.WaitForElement("GlobalStyle Item 2 - Click to Expand");
            App.TapButton("GlobalStyle Item 2 - Click to Expand");
            App.WaitForElement("Resource-based styling provides consistency and reusability");
            App.TapButton("GlobalStyle Test - Test Case ID: 180895");
            TakeAndCompareScreenshot("AccordionGlobalStyle");
        }
    }
}

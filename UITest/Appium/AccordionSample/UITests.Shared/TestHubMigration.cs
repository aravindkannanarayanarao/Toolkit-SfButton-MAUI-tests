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

namespace AccordionScripts
{
    internal class AccordionTesthubMigration : BaseTest
    {
        public AccordionTesthubMigration(TestDevice testDevice) : base(testDevice)
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
            Reset(); // Reset App after each test
        }
        [Test]
        [Description("Verify that clicking Start button with double initialization does not throw a null reference exception.")]
        public void DataPagerDoubleInitializationNoException()
        {
            App.TapButton("DatePager");
            App.WaitForElement("Start");
            App.TapButton("Start");
            App.WaitForElement("Content 1");
            TakeAndCompareScreenshot("DataPagerDoubleInitializationNoException");
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
        [Description("Verify that Accordion items load correctly when placed inside a VerticalStackLayout.")]
        public void AccordionInVerticalStackLayout()
        {
            App.TapButton("StackLayoutSample");
            App.WaitForElement("VerticalStackLayout Case");
            App.TapButton("Vertical Item 2");
            App.WaitForElement("Vertical Content 2");
            TakeAndCompareScreenshot("AccordionInVerticalStackLayout");
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
        [Description("Verify that Accordion items load correctly when placed inside an AbsoluteLayout.")]
        public void AccordionInAbsoluteLayout()
        {
            App.TapButton("StackLayoutSample");
            App.WaitForElement("AbsoluteLayout Case");
            App.TapButton("Absolute Item 2");
            App.WaitForElement("Absolute Content 2");
            TakeAndCompareScreenshot("AccordionInAbsoluteLayout");
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
        [Description("Verify that Accordion items load correctly in AbsoluteLayout when navigated via ShellPage.")]
        public void AccordionInAbsoluteLayoutShellPage()
        {
            App.TapButton("ShellPageSample");
            App.WaitForElement("Navigation Options");
            App.TapButton("Navigation Options");
            App.TapButton("AbsoluteLayout ShellPage");
            App.WaitForElement("Abs Content 1");
#if IOS || WINDOWS
            App.TapButton("Absolute Layout Sample");
#endif
            TakeAndCompareScreenshot("AccordionInAbsoluteLayoutShellPage");
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
        [Description("Verify that Accordion items load correctly in AbsoluteLayout when navigated via NavigationPushAsync.")]
        public void AccordionNavigationPushAsyncAbsoluteLayout()
        {
            App.TapButton("NavigationSample");
            App.WaitForElement("SfAccordion Navigation Tests");
            App.TapButton("Absolute NavigationPushAsync");
            App.WaitForElement("Absolute Content 1");
#if IOS || WINDOWS
            App.TapButton("Accordion Below");
#endif
            TakeAndCompareScreenshot("AccordionNavigationPushAsyncAbsoluteLayout");
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
        [Description("Verify that Accordion items load correctly in AbsoluteLayout when navigated via NavigationPushModalAsync.")]
        public void AccordionNavigationPushModalAsyncAbsoluteLayout()
        {
            App.TapButton("NavigationSample");
            App.WaitForElement("SfAccordion Navigation Tests");
            App.TapButton("Absolute NavigationPushModalAsync");
            App.WaitForElement("Absolute Content 1");
#if IOS || WINDOWS
            App.TapButton("Accordion Below");
#endif
            TakeAndCompareScreenshot("AccordionNavigationPushModalAsyncAbsoluteLayout");
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
        [Test]
        [Description("Verify ApplicationLevel style applies correctly: ExpanderIcon at start, multiple expand enabled, increased item spacing, and slow animation.")]
        public void AccordionApplicationLevelStyle()
        {
            App.TapButton("StyleSample");
            App.WaitForElement("ApplicationLevel Item 2");
            App.TapButton("ApplicationLevel Item 2");
            App.WaitForElement("Properties set directly on SfAccordion element");
            App.TapButton("GlobalStyle Test - Test Case ID: 180895");
            TakeAndCompareScreenshot("AccordionApplicationLevelStyle");
        }
    }
}
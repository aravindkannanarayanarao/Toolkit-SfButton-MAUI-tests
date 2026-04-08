using NUnit.Framework;
using AccordionScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UITests.Shared;
using Syncfusion.UITestHelpers.Core;
using Syncfusion.UITestHelpers.Appium;
using Syncfusion.UITestHelpers.Screenshot;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.ExtendReport;
using AccordionScripts1;

namespace AccordionScripts
{
    [TargetDevice("emulator-5556")]
    internal class Accordion_Device5556 : BaseTest
    {
        public Accordion_Device5556(TestDevice testDevice) : base(testDevice)
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
        [Description("TestCase1")]
        public void TestCase1()
        {
            App.Tap("MAUI");
            TakeAndCompareScreenshot("TestCase1");
        }
        [Test]
        [Description("TestCase3")]
        public void TestCase3()
        {
            App.Tap("MAUI_24619");
            TakeAndCompareScreenshot("TestCase3");
        }
        [Test]
        [Description("TestCase5")]
        public void TestCase5()
        {
            App.Tap("MAUI_24590");
            App.WaitForElement("Expander");
            App.Tap("header");
            TakeAndCompareScreenshot("TestCase5");
        }
        [Test]
        [Description("TestCase7")]
        public void TestCase7()
        {
            App.Tap("MAUI_26113");
            App.WaitForElement("header");
            App.Tap("header");
            TakeAndCompareScreenshot("TestCase7");
        }
        [Test]
        [Description("TestCase9")]
        public void TestCase9()
        {
            App.Tap("MAUI_26113_Listview");
            TakeAndCompareScreenshot("TestCase9");
        }
        [Test]
        [Description("TestCase11")]
        public void TestCase11()
        {
            App.Tap("MAUI_23400");
            TakeAndCompareScreenshot("TestCase11");
        }
        [Test]
        [Description("TestCase13")]
        public void TestCase13()
        {
            App.Tap("MAUI_23399");
            TakeAndCompareScreenshot("TestCase13");
        }
        [Test]
        [Description("TestCase15")]
        public void TestCase15()
        {
            App.Tap("MAUI_26254_ItemSpaccing_20");
            TakeAndCompareScreenshot("TestCase15");
        }
        [Test]
        [Description("TestCase17")]
        public void TestCase17()
        {
            App.Tap("VSM");
            App.WaitForElement("Header");
            App.Tap("Header");
            TakeAndCompareScreenshot("TestCase17");
        }
        [Test]
        [Description("TestCase19")]
        public void TestCase19()
        {
            App.Tap("VSM");
            App.WaitForElement("Header");
            App.Tap("Header2");
            TakeAndCompareScreenshot("TestCase19");
        }
        [Test]
        [Description("TestCase21")]
        public void TestCase21()
        {
            App.Tap("VSM");
            App.WaitForElement("Header");
            App.Tap("Header4");
            TakeAndCompareScreenshot("TestCase21");
        }
        [Test]
        [Description("TestCase23")]
        public void TestCase23()
        {
            App.Tap("MAUI_26687");
            TakeAndCompareScreenshot("TestCase23");
        }
        [Test]
        [Description("TestCase25")]
        public void TestCase25()
        {
            App.Tap("Themes");
            Thread.Sleep(7000);
            App.Tap("LightTheme");
            TakeAndCompareScreenshot("TestCase25");
        }
        [Test]
        [Description("TestCase27")]
        public void TestCase27()
        {
            App.Tap("Themes");
            App.Tap("IconPosition");
            TakeAndCompareScreenshot("TestCase27");
        }
        [Test]
        [Description("TestCase29")]
        public void TestCase29()
        {
            App.Tap("Themes");
            Thread.Sleep(7000);
            App.Tap("IsExpanded");
            App.WaitForElement("IsExpanded");
            TakeAndCompareScreenshot("TestCase29");
        }
        [Test]
        [Description("TestCase31")]
        public void TestCase31()
        {
            App.Tap("MAUI_28517");
            App.Tap("Enable");
            TakeAndCompareScreenshot("TestCase31");
        }
        [Test]
        [Description("TestCase33")]
        public void TestCase33()
        {
            App.Tap("MAUI_29715");
            App.Tap("OpenDrawer");
            TakeAndCompareScreenshot("TestCase33");
        }
        [Test]
        [Description("TestCase35")]
        public void TestCase35()
        {
            App.Tap("MAUI_27222_ExpanderIssue");
            TakeAndCompareScreenshot("TestCase35");
        }
        [Test]
        [Description("TestCase37")]
        public void TestCase37()
        {
            App.Tap("MAUI_32404");
            TakeAndCompareScreenshot("TestCase37");
        }
        [Test]
        [Description("TestCase39")]
        public void TestCase39()
        {
            App.Tap("MAUI_32404");
            App.WaitForElement("changeIsExpandedExpander1");
            App.Tap("changeIsExpandedExpander2");
            TakeAndCompareScreenshot("TestCase39");
        }
        [Test]
        [Description("TestCase41")]
        public void TestCase41()
        {
            App.Tap("MAUI_32404");
            App.WaitForElement("changeIsExpandedExpander1");
            App.Tap("changeIsExpandedExpander2");
            App.WaitForElement("changeIsExpandedExpander2");
            App.Tap("changeIsExpandedExpander1");
            TakeAndCompareScreenshot("TestCase41");
        }
        [Test]
        [Description("TestCase43")]
        public void TestCase43()
        {
            App.Tap("MAUI_31007");
            TakeAndCompareScreenshot("TestCase43");
        }
        [Test]
        [Description("TestCase46")]
        public void TestCase46()
        {
            App.Tap("MAUI_32579");
            TakeAndCompareScreenshot("TestCase46");
        }
        [Test]
        [Description("TestCase48")]
        public void TestCase48()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header Two");
            TakeAndCompareScreenshot("TestCase48");
        }
        [Test]
        [Description("TestCase50")]
        public void TestCase50()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header One");
            Thread.Sleep(7000);
            App.Tap("Header Two");
            TakeAndCompareScreenshot("TestCase50");
        }
        [Test]
        [Description("TestCase52")]
        public void TestCase52()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header Two");
            Thread.Sleep(7000);
            App.Tap("Header Three");
            TakeAndCompareScreenshot("TestCase52");
        }
        [Test]
        [Description("TestCase54")]
        public void TestCase54()
        {
            App.Tap("MAUI_35330");
            App.WaitForElement("ToggleVisibility");
            App.Tap("ToggleVisibility");
            TakeAndCompareScreenshot("TestCase54");
        }
    }
}

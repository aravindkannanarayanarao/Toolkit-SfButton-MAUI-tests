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
    [TargetDevice("emulator-5554")]
    internal class Accordion_Device5554 : BaseTest
    {
        public Accordion_Device5554(TestDevice testDevice) : base(testDevice)
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
        [Description("TestCase0")]
        public void TestCase0()
        {
            App.Tap("MAUI");
            TakeAndCompareScreenshot("TestCase0");
        }
        [Test]
        [Description("TestCase2")]
        public void TestCase2()
        {
            App.Tap("MAUI_30507");
            TakeAndCompareScreenshot("TestCase2");
        }
        [Test]
        [Description("TestCase4")]
        public void TestCase4()
        {
            App.Tap("MAUI_24619");
            App.Tap("Header");
            TakeAndCompareScreenshot("TestCase4");
        }
        [Test]
        [Description("TestCase6")]
        public void TestCase6()
        {
            App.Tap("MAUI_24590");
            TakeAndCompareScreenshot("TestCase6");
        }
        [Test]
        [Description("TestCase8")]
        public void TestCase8()
        {
            App.Tap("MAUI_26113");
            TakeAndCompareScreenshot("TestCase8");
        }
        [Test]
        [Description("TestCase10")]
        public void TestCase10()
        {
            App.Tap("MAUI_26113_Listview");
            TakeAndCompareScreenshot("TestCase10");
        }
        [Test]
        [Description("TestCase12")]
        public void TestCase12()
        {
            App.Tap("MAUI_23412");
            TakeAndCompareScreenshot("TestCase12");
        }
        [Test]
        [Description("TestCase14")]
        public void TestCase14()
        {
            App.Tap("MAUI_26124");
            TakeAndCompareScreenshot("TestCase14");
        }
        [Test]
        [Description("TestCase16")]
        public void TestCase16()
        {
            App.Tap("MAUI_26254_ItemSpaccing_0");
            TakeAndCompareScreenshot("TestCase16");
        }
        [Test]
        [Description("TestCase18")]
        public void TestCase18()
        {
            App.Tap("VSM");
            App.WaitForElement("Header");
            App.Tap("Header1");
            TakeAndCompareScreenshot("TestCase18");
        }
        [Test]
        [Description("TestCase20")]
        public void TestCase20()
        {
            App.Tap("VSM");
            App.WaitForElement("Header");
            App.Tap("Header3");
            TakeAndCompareScreenshot("TestCase20");
        }
        [Test]
        [Description("TestCase22")]
        public void TestCase22()
        {
            App.Tap("VSM");
            App.WaitForElement("Header");
            App.Tap("Header5");
            TakeAndCompareScreenshot("TestCase22");
        }
        [Test]
        [Description("TestCase24")]
        public void TestCase24()
        {
            App.Tap("Themes");
            TakeAndCompareScreenshot("TestCase24");
        }
        [Test]
        [Description("TestCase26")]
        public void TestCase26()
        {
            App.Tap("Themes");
            App.Tap("OverrideColor");
            TakeAndCompareScreenshot("TestCase26");
        }
        [Test]
        [Description("TestCase28")]
        public void TestCase28()
        {
            App.Tap("Themes");
            App.Tap("IsExpanded");
            TakeAndCompareScreenshot("TestCase28");
        }
        [Test]
        [Description("TestCase30")]
        public void TestCase30()
        {
            App.Tap("MAUI_28517");
            App.Tap("New");
            TakeAndCompareScreenshot("TestCase30");
        }
        [Test]
        [Description("TestCase32")]
        public void TestCase32()
        {
            App.Tap("MAUI_28890");
            TakeAndCompareScreenshot("TestCase32");
        }
        [Test]
        [Description("TestCase34")]
        public void TestCase34()
        {
            App.Tap("MAUI_28883");
            App.Tap("OpenDrawer");
            TakeAndCompareScreenshot("TestCase34");
        }
        [Test]
        [Description("TestCase36")]
        public void TestCase36()
        {
            App.Tap("MAUI_27222");
            TakeAndCompareScreenshot("TestCase36");
        }
        [Test]
        [Description("TestCase38")]
        public void TestCase38()
        {
            App.Tap("MAUI_32404");
            App.WaitForElement("changeIsExpandedExpander1");
            App.Tap("changeIsExpandedExpander1");
            TakeAndCompareScreenshot("TestCase38");
        }
        [Test]
        [Description("TestCase40")]
        public void TestCase40()
        {
            App.Tap("MAUI_32404");
            App.Tap("changeIsExpandedExpander1");
            App.Tap("changeIsExpandedExpander2");
            TakeAndCompareScreenshot("TestCase40");
        }
        [Test]
        [Description("TestCase42")]
        public void TestCase42()
        {
            App.Tap("MAUI_31919");
            TakeAndCompareScreenshot("TestCase42");
        }
        [Test]
        [Description("TestCase45")]
        public void TestCase45()
        {
            App.Tap("MAUI_29622");
            App.WaitForElement("header");
            App.Tap("header");
            TakeAndCompareScreenshot("TestCase45");
        }
        [Test]
        [Description("TestCase47")]
        public void TestCase47()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header One");
            TakeAndCompareScreenshot("TestCase47");
        }
        [Test]
        [Description("TestCase49")]
        public void TestCase49()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header Three");
            TakeAndCompareScreenshot("TestCase49");
        }
        [Test]
        [Description("TestCase51")]
        public void TestCase51()
        {
            App.Tap("MAUI_32579");
            App.Tap("Header One");
            App.Tap("Header Three");
            TakeAndCompareScreenshot("TestCase51");
        }
        [Test]
        [Description("TestCase53")]
        public void TestCase53()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header One");
            Thread.Sleep(7000);
            App.Tap("Header Two");
            Thread.Sleep(7000);
            App.Tap("Header Three");
            TakeAndCompareScreenshot("TestCase53");
        }
    }
}

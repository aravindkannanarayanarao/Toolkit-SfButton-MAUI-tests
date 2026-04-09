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

namespace AccordionScripts
{
    internal class Accordion : BaseTest
    {
        public Accordion(TestDevice testDevice) : base(testDevice)
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
        [Description("TestCase0")]
        public void TestCase0()
        {
            App.Tap("MAUI");

            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase0");
        }
        
        [Test]
        [Description("TestCase1")]
        public void TestCase1()
        {
            App.Tap("MAUI");

            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase1");
        }
        [Test]
        [Description("TestCase2")]
        public void TestCase2()
        {
            App.Tap("MAUI_30507");
            Thread.Sleep(7000);

            TakeAndCompareScreenshot("TestCase2");
        }
        [Test]
        [Description("TestCase3")]
        public void TestCase3()
        {
            App.Tap("MAUI_24619");

            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase3");
        }
        [Test]
        [Description("TestCase4")]
        public void TestCase4()
        {
            App.Tap("MAUI_24619");
            App.Tap("Header");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase4");
        }
        [Test]
        [Description("TestCase5")]
        public void TestCase5()
        {
            App.Tap("MAUI_24590");
            Thread.Sleep(7000);
            App.Tap("header");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase5");
        }
        [Test]
        [Description("TestCase6")]
        public void TestCase6()
        {
            App.Tap("MAUI_24590");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase6");
        }
        [Test]
        [Description("TestCase7")]
        public void TestCase7()
        {
            App.Tap("MAUI_26113");
            Thread.Sleep(7000);
            App.Tap("header");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase7");
        }
        [Test]
        [Description("TestCase8")]
        public void TestCase8()
        {
            App.Tap("MAUI_26113");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase8");
        }
        [Test]
        [Description("TestCase9")]
        public void TestCase9()
        {
            App.Tap("MAUI_26113_Listview");

            Thread.Sleep(9000);
            TakeAndCompareScreenshot("TestCase9");
        }
        [Test]
        [Description("TestCase10")]
        public void TestCase10()
        {
            App.Tap("MAUI_26113_Listview");
            Thread.Sleep(9000);
            TakeAndCompareScreenshot("TestCase10");
        }
        [Test]
        [Description("TestCase11")]
        public void TestCase11()
        {
            App.Tap("MAUI_23400");
            Thread.Sleep(6000);
            TakeAndCompareScreenshot("TestCase11");
        }
        [Test]
        [Description("TestCase12")]
        public void TestCase12()
        {
            App.Tap("MAUI_23412");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase12");
        }
        [Test]
        [Description("TestCase13")]
        public void TestCase13()
        {
            App.Tap("MAUI_23399");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase13");
        }
        [Test]
        [Description("TestCase14")]
        public void TestCase14()
        {
            App.Tap("MAUI_26124");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase14");
        }
        [Test]
        [Description("TestCase15")]
        public void TestCase15()
        {
            App.Tap("MAUI_26254_ItemSpaccing_20");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase15");
        }
        [Test]
        [Description("TestCase16")]
        public void TestCase16()
        {
            App.Tap("MAUI_26254_ItemSpaccing_0");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase16");
        }
        [Test]
        [Description("TestCase17")]
        public void TestCase17()
        {
            App.Tap("VSM");
            Thread.Sleep(7000);
            App.Tap("Header");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase17");
        }
        [Test]
        [Description("TestCase18")]
        public void TestCase18()
        {
            App.Tap("VSM");
            Thread.Sleep(7000);
            App.Tap("Header1");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase18");
        }
        [Test]
        [Description("TestCase19")]
        public void TestCase19()
        {
            App.Tap("VSM");
            Thread.Sleep(7000);
            App.Tap("Header2");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase19");
        }
        [Test]
        [Description("TestCase20")]
        public void TestCase20()
        {
            App.Tap("VSM");
            Thread.Sleep(7000);
            App.Tap("Header3");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase20");
        }
        [Test]
        [Description("TestCase21")]
        public void TestCase21()
        {
            App.Tap("VSM");
            Thread.Sleep(7000);
            App.Tap("Header4");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase21");
        }
        [Test]
        [Description("TestCase22")]
        public void TestCase22()
        {
            App.Tap("VSM");
            Thread.Sleep(7000);
            App.Tap("Header5");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase22");
        }
        [Test]
        [Description("TestCase23")]
        public void TestCase23()
        {
            App.Tap("MAUI_26687");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase23");
        }
        [Test]
        [Description("TestCase24")]
        public void TestCase24()
        {
            App.Tap("Themes");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase24");
        }
        [Test]

        [Description("TestCase25")]
        public void TestCase25()
        {
            App.Tap("Themes");
            Thread.Sleep(7000);
            App.Tap("LightTheme");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase25");
        }
        [Test]
        [Description("TestCase26")]
        public void TestCase26()
        {
            App.Tap("Themes");
            App.Tap("OverrideColor");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase26");
        }
        [Test]
        [Description("TestCase27")]
        public void TestCase27()
        {
            App.Tap("Themes");
            App.Tap("IconPosition");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase27");
        }
        [Test]
        [Description("TestCase28")]
        public void TestCase28()
        {
            App.Tap("Themes");
            App.Tap("IsExpanded");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase28");
        }
        [Test]
        [Description("TestCase29")]
        public void TestCase29()
        {
            App.Tap("Themes");
            Thread.Sleep(7000);
            App.Tap("IsExpanded");


            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase29");
        }
        [Test]
        [Description("TestCase30")]
        public void TestCase30()
        {
            App.Tap("MAUI_28517");
            App.Tap("New");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase30");
        }
        [Test]
        [Description("TestCase31")]
        public void TestCase31()
        {
            App.Tap("MAUI_28517");
            App.Tap("Enable");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase31");
        }
        [Test]
        [Description("TestCase32")]
        public void TestCase32()
        {
            App.Tap("MAUI_28890");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase32");
        }
        [Test]
        [Description("TestCase33")]
        public void TestCase33()
        {
            App.Tap("MAUI_29715");
            App.Tap("OpenDrawer");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase33");
        }
        [Test]
        [Description("TestCase34")]
        public void TestCase34()
        {
            App.Tap("MAUI_28883");
            App.Tap("OpenDrawer");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase34");
        }


        [Test]
        [Description("TestCase35")]
        public void TestCase35()
        {
            App.Tap("MAUI_27222_ExpanderIssue");
            Thread.Sleep(9000);
            TakeAndCompareScreenshot("TestCase35");
        }
        [Test]
        [Description("TestCase36")]
        public void TestCase36()
        {
            App.Tap("MAUI_27222");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase36");

        }
        [Test]
        [Description("TestCase37")]
        public void TestCase37()
        {
            App.Tap("MAUI_32404");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase37");
        }
        [Test]
        [Description("TestCase38")]
        public void TestCase38()
        {
            App.Tap("MAUI_32404");
            Thread.Sleep(7000);
            App.Tap("changeIsExpandedExpander1");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase38");
        }
        [Test]
        [Description("TestCase39")]
        public void TestCase39()
        {
            App.Tap("MAUI_32404");
            Thread.Sleep(7000);
            App.Tap("changeIsExpandedExpander2");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase39");
        }
        [Test]
        [Description("TestCase40")]
        public void TestCase40()
        {
            App.Tap("MAUI_32404");
            App.Tap("changeIsExpandedExpander1");
            App.Tap("changeIsExpandedExpander2");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase40");
        }
        [Test]
        [Description("TestCase41")]
        public void TestCase41()
        {
            App.Tap("MAUI_32404");
            Thread.Sleep(7000);
            App.Tap("changeIsExpandedExpander2");
            Thread.Sleep(7000);
            App.Tap("changeIsExpandedExpander1");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase41");
        }
        [Test]
        [Description("TestCase42")]
        public void TestCase42()
        {
            App.Tap("MAUI_31919");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase42");
        }

        [Test]
        [Description("TestCase43")]
        public void TestCase43()
        {
            App.Tap("MAUI_31007");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase43");
        }
        [Test]
        [Description("TestCase45")]
        public void TestCase45()
        {
            App.Tap("MAUI_29622");
            Thread.Sleep(7000);
            App.Tap("header");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase45");
        }
        [Test]
        [Description("TestCase46")]
        public void TestCase46()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase46");

        }
        [Test]
        [Description("TestCase47")]
        public void TestCase47()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header One");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase47");
        }
        [Test]
        [Description("TestCase48")]
        public void TestCase48()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header Two");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase48");
        }
        [Test]
        [Description("TestCase49")]
        public void TestCase49()
        {
            App.Tap("MAUI_32579");
            Thread.Sleep(7000);
            App.Tap("Header Three");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase49");
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
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase50");
        }
        [Test]
        [Description("TestCase51")]
        public void TestCase51()
        {
            App.Tap("MAUI_32579");
            App.Tap("Header One");
            App.Tap("Header Three");
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase51");
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
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase52");
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
            Thread.Sleep(7000);
            TakeAndCompareScreenshot("TestCase53");
        }
        [Test]
        [Description("TestCase54")]
        public void TestCase54()
        {
            App.Tap("MAUI_35330");
            Thread.Sleep(7000);
            App.Tap("ToggleVisibility");
            Thread.Sleep(6000);
            TakeAndCompareScreenshot("TestCase54");
        }
    }
}



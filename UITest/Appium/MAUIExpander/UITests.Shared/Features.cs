using NUnit.Framework;
using MAUI_SfAccordion_ExpanderScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Syncfusion.UITestHelpers.Core;
using Syncfusion.UITestHelpers.Appium; 
using Syncfusion.UITestHelpers.Screenshot;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.ExtendReport; 
using UITests.Shared;

namespace MAUI_SfAccordion_ExpanderScripts
{
    public class SfAccordion_CRbugs : BaseTest
    {
        public SfAccordion_CRbugs(TestDevice testDevice) : base(testDevice)
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
            NavigateToHome(); // Navigate to home instead of app restart
        }

        #region Accordion_CRbugs Features
        //1
        [Test]
        [Description("TestCase1")]
        public void TestCase1()
        {
            App.Tap("Expander");
            App.Tap("Veg Pizza");
            TakeAndCompareScreenshot("TestCase1");
        }

        //2
        [Test]
        [Description("TestCase2")]
        public void TestCase2()
        {
            App.Tap("Accordion");
            App.Tap("Cheese burger");
            TakeAndCompareScreenshot("TestCase2");
        }

        //3
        [Test]
        [Description("TestCase3")]
        public void TestCase3()
        {
            App.Tap("AccordionHeader");
            App.Tap("ChangeHeader1");
            App.Tap("ChangeHeaderBackground2");
            App.Tap("HeaderNull");
            App.Tap("ContentNull");
            TakeAndCompareScreenshot("TestCase3");
        }

        //4 
        [Test]
        [Description("TestCase4")]
        public void TestCase4()
        {
            App.Tap("BringIntoViewAccordion");
            App.Tap("BringIntoView");
            TakeAndCompareScreenshot("TestCase4");
        }

        //5 
        [Test]
        [Description("TestCase5")]
        public void TestCase5()
        {
            App.Tap("BringIntoView_FlyoutPage");
            //App.ScrollDown();
            TakeAndCompareScreenshot("TestCase5");
        }

        //6 
        [Test]
        [Description("TestCase6")]
        public void TestCase6()
        {
            App.Tap("DynamicSizeExpander");
            App.Tap("DynamicSizeMode as Header");
            App.Tap("DynamicSizeMode as Content");
            TakeAndCompareScreenshot("TestCase6");
        }

        //7
        [Test]
        [Description("TestCase7")]
        public void TestCase7()
        {
            App.Tap("GettingStarted");
            App.Tap("Recipes");
            TakeAndCompareScreenshot("TestCase7");
        }

        //8
        [Test]
        [Description("TestCase8")]
        public void TestCase8()
        {
            App.Tap("ChangeHeaderAccordion");
            App.Tap("ChangeFlowDirection");
            App.Tap("IconPosition");
            App.Tap("ChangeParentFlowDirection");
            App.Tap("IconPositionNone");
            TakeAndCompareScreenshot("TestCase8");
        }

        //9
        [Test]
        [Description("TestCase9")]
        public void TestCase9()
        {
            App.Tap("HeaderIconPositionAccordion");
            App.Tap("Cheese burger");
            App.Tap("HeaderIconPositionStart");
            App.Tap("HeaderIconPositionEnd");
            TakeAndCompareScreenshot("TestCase9");
        }

        //10
        [Test]
        [Description("TestCase10")]
        public void TestCase10()
        {
            App.Tap("HeaderIconPositionAccordion");
            App.Tap("Cheese burger");
            App.Tap("ItemSpacing");
            TakeAndCompareScreenshot("TestCase10");
        }

        //11
        [Test]
        [Description("TestCase11")]
        public void TestCase11()
        {
            App.Tap("HeaderIconPositionAccordion");
            App.Tap("AnimationDurationSlow");
            App.Tap("Cheese burger");
            Thread.Sleep(1000);
            App.Tap("AnimationDurationSlow");
            App.Tap("Cheese burger");
            TakeAndCompareScreenshot("TestCase11");
        }

        //12
        [Test]
        [Description("TestCase12")]
        public void TestCase12()
        {
            App.Tap("HeaderIconPositionAccordion");
            App.Tap("SinIn");
            App.Tap("Cheese burger");
            Thread.Sleep(1000);
            App.Tap("SinOut");
            App.Tap("Cheese burger");
            Thread.Sleep(1000);
            App.Tap("Linear");
            App.Tap("Cheese burger");
            TakeAndCompareScreenshot("TestCase12");
        }

        //13
        [Test]
        [Description("TestCase13")]
        public void TestCase13()
        {
            App.Tap("AddRemoveReplace_Accordion");
            App.Tap("Add");
            App.Tap("Replace");
            Thread.Sleep(1000);
            App.Tap("Remove");
            App.Tap("AddMultipleItem");
            Thread.Sleep(1000);
            App.Tap("Insert");
            App.Tap("Move");
            App.Tap("Reset");
            App.Tap("RemoveLastItem");
            TakeAndCompareScreenshot("TestCase13");
        }

        //14
        [Test]
        [Description("TestCase14")]
        public void TestCase14()
        {
            App.Tap("ChangeHeaderExpander");
            App.Tap("ChangeHeader");
            App.Tap("ChangeHeaderBackground");
            Thread.Sleep(1000);
            App.Tap("IconPositionStart");
            App.Tap("IconPositionEnd");
            App.Tap("ChangeHeaderNull");
            TakeAndCompareScreenshot("TestCase14");
        }

        //15
        [Test]
        [Description("TestCase15")]
        public void TestCase15()
        {
            App.Tap("AnimationExpander");
            App.Tap("Linear");
            App.Tap("SinIn");
            Thread.Sleep(1000);
            App.Tap("SinInOut");
            App.Tap("SinOut");
            App.Tap("None");
            TakeAndCompareScreenshot("TestCase15");
        }

        //16
        [Test]
        [Description("TestCase16")]
        public void TestCase16()
        {
            App.Tap("HeaderIconPositionExpander");
            App.Tap("ChangeFlowDirection");
            App.Tap("IconPosition");
            Thread.Sleep(1000);
            App.Tap("IconPositionNone");
            App.Tap("Change Header");
            TakeAndCompareScreenshot("TestCase16");
        }

        //17
        [Test]
        [Description("TestCase17")]
        public void TestCase17()
        {
            App.Tap("NullHeaderExpander");
            App.Tap("Veg Pizza");
            App.Tap("NullHeader");
            Thread.Sleep(500);
            App.Tap("NullContent");
            TakeAndCompareScreenshot("TestCase17");
        }

        //18
        [Test]
        [Description("TestCase18")]
        public void TestCase18()
        {
            App.Tap("ExpandCollpase_Accordion");
            App.Tap("ExpandItem");
            App.Tap("CollapseItem");
            Thread.Sleep(500);
            App.Tap("ExpandModeSingle");
            App.Tap("ExpandModeMultiple");
            TakeAndCompareScreenshot("TestCase18");
        }

        //19
        [Test]
        [Description("TestCase19")]
        public void TestCase19()
        {
            App.Tap("AutoOnScroll");
            App.Tap("Item10");
            TakeAndCompareScreenshot("TestCase19");
        }

        //20
        [Test]
        [Description("TestCase20")]
        public void TestCase20()
        {
            App.Tap("ExpandCollapseEvents");
            App.Tap("Item2");
            TakeAndCompareScreenshot("TestCase20");
        }

        //21
        [Test]
        [Description("TestCase21")]
        public void TestCase21()
        {
            //App.ScrollDownTo();
            App.Tap("AddAsContent_Accordion");
            App.Tap("AddContent");
            App.Tap("ChangeContent");
            Thread.Sleep(500);
            App.Tap("NullContent");
            App.Tap("AddSfListViewAsContent");
            App.Tap("AddPopUpAsContent");
            App.Tap("AddImageAsContent");
            TakeAndCompareScreenshot("TestCase21");
        }

        //22
        [Test]
        [Description("TestCase22")]
        public void TestCase22()
        {
            //App.ScrollDown();
            App.Tap("AddAsContent_Accordion");
            App.Tap("AddSfListViewAsContent");
            //App.ScrollDown();
            TakeAndCompareScreenshot("TestCase22");
        }

        //23
        [Test]
        [Description("TestCase23")]
        public void TestCase23()
        {
            //App.ScrollDown();
            App.Tap("IsExpanded_Accordion");
            App.Tap("IsExpandedTrue");
            App.Tap("IsExpandedFalse");
            TakeAndCompareScreenshot("TestCase23");
        }

        //24
        [Test]
        [Description("TestCase24")]
        public void TestCase24()
        {
            //App.ScrollDown();
            App.Tap("IsExpanded_Expander");
            App.Tap("IsExpandedTrue");
            App.Tap("IsExpandedFalse");
            TakeAndCompareScreenshot("TestCase24");
        }
        #endregion
    }
    }
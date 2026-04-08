using NUnit.Framework;
using AccordionScripts1;
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

namespace AccordionScripts1
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
            NavigateToHome(); // Navigate to home instead of app restart
        }

        #region Accordion 1 Features
        //49
        [Test]
        [Description("TestCase49")]
        public void TestCase49()
        {
			Thread.Sleep(2000);
			App.Tap("Load_RTL_sample");
            TakeAndCompareScreenshot("TestCase49");
        }

        //50
        [Test]
        [Description("TestCase50")]
        public void TestCase50()
        {
            App.Tap("Load_RTL_sample");
            Thread.Sleep(2000);
            App.Tap("Change_Flowdirection");
            TakeAndCompareScreenshot("TestCase50");
        }

        //51
        [Test]
        [Description("TestCase51")]
        public void TestCase51()
        {
            App.Tap("DynamicSizeSupport");
            Thread.Sleep(2000);
            App.Tap("AccordItem1 Header");
            App.Tap("modufyItem1");
            TakeAndCompareScreenshot("TestCase51");
        }

        //52
        [Test]
        [Description("TestCase52")]
        public void TestCase52()
        {
            App.Tap("DynamicSizeSupport");
            Thread.Sleep(2000);
            App.Tap("header 1");
            App.Tap("changeContent");
            TakeAndCompareScreenshot("TestCase52");
        }

        //53
        [Test]
        [Description("TestCase53")]
        public void TestCase53()
        {
            App.Tap("DynamicSizeSupport");
            Thread.Sleep(2000);
            #if ANDROID || IOS
            App.SetOrientationPortrait();
            App.Tap("header 1");
            App.Tap("changeContent");
            App.Tap("modifyAfterContentChange");
#else
            App.Tap("header 1");
            App.Tap("changeContent");
            App.Tap("modifyAfterContentChange");
#endif               
            TakeAndCompareScreenshot("TestCase53");
        }

        //54
        [Test]
        [Description("TestCase54")]
        public void TestCase54()
        {
#if ANDROID || IOS
            App.SetOrientationPortrait();
#endif
            App.Tap("DynamicSizeSupport");
            Thread.Sleep(2000);
            #if ANDROID || IOS
            App.ScrollDown("header 10");
            App.Tap("changeHeader");
            App.Tap("modifyAfterContentChange");
#else
            App.Tap("changeHeader");
            App.Tap("modifyAfterContentChange");
#endif
            TakeAndCompareScreenshot("TestCase54");
        }

        //55
        [Test]
        [Description("TestCase55")]
        public void TestCase55()
        {
            App.Tap("DynamicSizeSupport");
            TakeAndCompareScreenshot("TestCase55");
        }

        //56
        [Test]
        [Description("TestCase56")]
        public void TestCase56()
        {
            App.Tap("BindableAccordInGrid");
            Thread.Sleep(2000);
            #if ANDROID || IOS

            App.Tap("addItem");
            Thread.Sleep(500);
            App.SetOrientationLandscape();
#else
App.Tap("addItem");
#endif

            TakeAndCompareScreenshot("TestCase56");
        }

        //57 
        [Test]
        [Description("TestCase57")]
        public void TestCase57()
        {
#if ANDROID || IOS
            App.SetOrientationPortrait();
#endif
            App.Tap("BindableAccordInGrid");
            Thread.Sleep(2000);
            #if ANDROID || IOS
            App.SetOrientationLandscape();
            Thread.Sleep(500);
            App.Tap("addItem");
            App.SetOrientationPortrait();
#else
App.Tap("addItem");
#endif
            TakeAndCompareScreenshot("TestCase57");
        }

        //58
        [Test]
        [Description("TestCase58")]
        public void TestCase58()
        {
#if ANDROID || IOS
            App.SetOrientationPortrait();
#endif
            App.Tap("MAUI_37449");
            TakeAndCompareScreenshot("TestCase58");
        }

        //59
        [Test]
        [Description("TestCase59")]
        public void TestCase59()
        {
            App.Tap("MAUI_37208");
            App.WaitForElement("changeVisibility");
            App.Tap("changeVisibility");
            TakeAndCompareScreenshot("TestCase59");
        }

        //60
        [Test]
        [Description("TestCase60")]
        public void TestCase60()
        {
            App.Tap("MAUI_37743");
            Thread.Sleep(2000);
            App.Tap("Go to Accordion");
            Thread.Sleep(1000);
            App.Tap("close page");
            TakeAndCompareScreenshot("TestCase60");
        }

        //61
        [Test]
        [Description("TestCase61")]
        public void TestCase61()
        {
            App.Tap("MAUI_38120");
            Thread.Sleep(2000);
            App.Tap("Cheese burger");
            Thread.Sleep(1000);
            App.Tap("Veggie burger");
            TakeAndCompareScreenshot("TestCase61");
        }

        //62 
        [Test]
        [Description("TestCase62")]
        public void TestCase62()
        {
            App.Tap("MAUI_40527");
            Thread.Sleep(5000);
            App.Tap("Cheese burger");
            TakeAndCompareScreenshot("TestCase62");
        }

        //63 
        [Test]
        [Description("TestCase63")]
        public void TestCase63()
        {
            App.Tap("MAUI_44611");
            Thread.Sleep(2000);
            App.Tap("Navigate");
            Thread.Sleep(2000);
            App.Tap("back");
            Thread.Sleep(2000);
            App.Tap("Navigate");
            TakeAndCompareScreenshot("TestCase63");
        }

#endregion
    }
    }
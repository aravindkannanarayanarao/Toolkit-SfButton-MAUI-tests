using NUnit.Framework;
using MemoryLeakTestScripts;
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

namespace MemoryLeakTestScripts
{
    internal class MemoryLeakTest: BaseTest
    {
        public MemoryLeakTest(TestDevice testDevice) : base(testDevice)
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

        #region MemoryLeakTest Features

        //1
        [Test]
        [Description("TestCase1")]
        public void TestCase0()
        {
            App.Tap("accordion");
            Thread.Sleep(2000);
            #if IOS || WINDOWS  || Android
            App.Tap("back");
            Thread.Sleep(1000);
            #endif
            App.Tap("getgc");
            TakeAndCompareScreenshot("TestCase0");
        }
        //1
        [Test]
        [Description("TestCase1")]
        public void TestCase1()
        {
            App.Tap("accordion");
            Thread.Sleep(2000);
            #if IOS || WINDOWS   || Android
            App.Tap("back");
            Thread.Sleep(1000);
            #endif
            App.Tap("getgc");
            TakeAndCompareScreenshot("TestCase1");
        }

        //2
        [Test]
        [Description("TestCase2")]
        public void TestCase2()
        {
            App.Tap("expander");
            App.WaitForElement("expander");
            #if IOS || WINDOWS  || Android
            App.Tap("back");
            Thread.Sleep(1000);
            #endif
            App.Tap("getgc");
            TakeAndCompareScreenshot("TestCase2");
        }

        #endregion
    }
    }
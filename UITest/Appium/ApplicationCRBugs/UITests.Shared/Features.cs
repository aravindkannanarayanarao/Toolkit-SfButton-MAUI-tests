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


        #region Accordion Application
        [Test]
        [Description("Application")]
        public void TestCase_1()
        {
#if WINDOWS
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("IT Support Guidelines");
            Thread.Sleep(1000);
            #elif ANDROID || IOS
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            #endif
            TakeAndCompareScreenshot("TestCase_1");
        }


        #endregion
    }
    }
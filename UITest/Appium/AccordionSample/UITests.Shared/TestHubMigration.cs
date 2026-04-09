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
    }
}
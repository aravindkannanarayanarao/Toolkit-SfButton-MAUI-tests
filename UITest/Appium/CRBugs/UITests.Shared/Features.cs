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


        #region Accordion Header
        [Test]
        [Description("ImplicitStyle")]
        public void ImplicitStyle()
        {
#if WINDOWS
            App.Tap("ImplicitStylePage");
            Thread.Sleep(1000);
            App.Tap("Leave Policy");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("IT Support Guidelines");
            Thread.Sleep(1000);
            #elif ANDROID || IOS
            App.Tap("ImplicitStylePage");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            #endif
            TakeAndCompareScreenshot("ImplicitStyle");
        }


        [Test]
        [Description("ExplicitStyle")]
        public void ExplicitStyle()
        {
#if WINDOWS
            App.Tap("ExplicitStylePage");
            Thread.Sleep(1000);
            App.Tap("Leave Policy");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("IT Support Guidelines");
            Thread.Sleep(1000);
            #elif ANDROID || IOS
            App.Tap("ExplicitStylePage");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            #endif
            TakeAndCompareScreenshot("ExplicitStyle");
        }


        [Test]
        [Description("LoadedPage")]
        public void LoadedPage()
        {
#if WINDOWS            
            App.Tap("LoadedPage");
            Thread.Sleep(1000);
            App.Tap("Leave Policy");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("IT Support Guidelines");
            Thread.Sleep(1000);
            #elif ANDROID || IOS
            App.Tap("LoadedPage");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            #endif
            TakeAndCompareScreenshot("LoadedPage");
        }


        [Test]
        [Description("ConstructorPage")]
        public void ConstructorPage()
        {
#if WINDOWS
            App.Tap("ConstructorPage");
            Thread.Sleep(1000);
            App.Tap("Leave Policy");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("IT Support Guidelines");
            Thread.Sleep(1000);
            #elif ANDROID || IOS
            App.Tap("ConstructorPage");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            #endif
            TakeAndCompareScreenshot("ConstructorPage");
        }


        [Test]
        [Description("OnAppearingPage")]
        public void OnAppearingPage()
        {
#if WINDOWS            
            App.Tap("OnAppearingPage");
            Thread.Sleep(1000);
            App.Tap("Leave Policy");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("IT Support Guidelines");
            Thread.Sleep(1000);
            #elif ANDROID || IOS
            App.Tap("OnAppearingPage");
            Thread.Sleep(1000);
            App.Tap("Remote Work Policy");
            Thread.Sleep(1000);
            App.Tap("Code of Conduct");
            Thread.Sleep(1000);
            App.Tap("Security Protocols");
            Thread.Sleep(1000);
            #endif
            TakeAndCompareScreenshot("OnAppearingPage");
        }


#endregion
    }
    }
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
        //1
        [Test]
        [Description("TestCase1")]
        public void TestCase1()
        {
            TakeAndCompareScreenshot("TestCase1");
        }

        //2
        [Test]
        [Description("TestCase2")]
        public void TestCase2()
        {
            Thread.Sleep(1000);
            #if ANDROID||IOS
            Flyout1();
            App.Tap("Start");
            Flyout2();
        #elif WINDOWS
            App.Tap("Start");
        #endif
            TakeAndCompareScreenshot("TestCase2");
        }

        //3
        [Test]
        [Description("TestCase3")]
        public void TestCase3()
        {
           Thread.Sleep(1000);
           #if ANDROID||IOS
            Flyout1();
            App.Tap("None");
            Flyout2();
        #elif WINDOWS
            App.Tap("None");
        #endif
            TakeAndCompareScreenshot("TestCase3");
        }

        //4 
        [Test]
        [Description("TestCase4")]
        public void TestCase4()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Add");
            Flyout2();
        #elif WINDOWS
            App.Tap("Add");
        #endif
            TakeAndCompareScreenshot("TestCase4");
        }

        //5 
        [Test]
        [Description("TestCase5")]
        public void TestCase5()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Insert");
            Flyout2();
        #elif WINDOWS
            App.Tap("Insert");
        #endif
            TakeAndCompareScreenshot("TestCase5");
        }

        //6 
        [Test]
        [Description("TestCase6")]
        public void TestCase6()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Remove");
            Flyout2();
        #elif WINDOWS
            App.Tap("Remove");
        #endif
            TakeAndCompareScreenshot("TestCase6");
        }

        //7
        [Test]
        [Description("TestCase7")]
        public void TestCase7()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("RemoveAt");
            Flyout2();
        #elif WINDOWS
            App.Tap("RemoveAt");
        #endif
            TakeAndCompareScreenshot("TestCase7");
        }

        //8
        [Test]
        [Description("TestCase8")]
        public void TestCase8()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Replace");
            Flyout2();
        #elif WINDOWS
            App.Tap("Replace");
        #endif
            TakeAndCompareScreenshot("TestCase8");
        }

        //9 
        [Test]
        [Description("TestCase9")]
        public void TestCase9()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MoveUp");
            Flyout2();
        #elif WINDOWS
            App.Tap("MoveUp");
        #endif
            TakeAndCompareScreenshot("TestCase9");
        }

        //10
        [Test]
        [Description("TestCase10")]
        public void TestCase10()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MoveDown");
            Flyout2();
        #elif WINDOWS
			Thread.Sleep(500);
			App.Tap("MoveDown");
			Thread.Sleep(500);
			#endif
            TakeAndCompareScreenshot("TestCase10");
        }

        //11
        [Test]
        [Description("Testcase11")]
        public void Testcase11()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Clear");
            Flyout2();
        #elif WINDOWS
            App.Tap("Clear");
        #endif
            TakeAndCompareScreenshot("Testcase11");
        }

        //12
        [Test]
        [Description("TestCase12")]
        public void TestCase12()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Clear");
            Thread.Sleep(500);
            App.Tap("Add");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Clear");
            Thread.Sleep(500);
            App.Tap("Add");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase12");
        }

        //13
        [Test]
        [Description("TestCase13")]
        public void TestCase13()
        {
        #if ANDROID||IOS
            App.Tap("Item4");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("Item4");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase13");
        }

        //14
        [Test]
        [Description("TestCase14")]
        public void TestCase14()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item4");
            App.Tap("Item3");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("Multiple");
            Thread.Sleep(500);
            App.Tap("Item4");
            App.Tap("Item3");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase14");
        }

        //15
        [Test]
        [Description("TestCase15")]
        public void TestCase15()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item4");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("SingleOrNone");
            Thread.Sleep(500);
            App.Tap("Item4");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase15");
        }

        //16
        [Test]
        [Description("TestCase16")]
        public void TestCase16()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            Thread.Sleep(500);
            App.Tap("CollapseAll");
            Flyout2();
            App.Tap("Item4");
            Thread.Sleep(500);
            App.Tap("Item4");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("SingleOrNone");
            Thread.Sleep(500);
            App.Tap("CollapseAll");
            App.Tap("Item4");
            Thread.Sleep(500);
            App.Tap("Item4");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase16");
        }

        //17
        [Test]
        [Description("TestCase17")]
        public void TestCase17()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item4");
            App.Tap("Item3");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("MultipleOrNone");
            Thread.Sleep(500);
            App.Tap("Item4");
            App.Tap("Item3");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase17");
        }

        //18
        [Test]
        [Description("TestCase18")]
        public void TestCase18()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item4");
            App.Tap("Item3");
            Thread.Sleep(500);
            App.Tap("Item3");
            App.Tap("Item4");
            App.Tap("Item1");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("MultipleOrNone");
            Thread.Sleep(500);
            App.Tap("Item4");
            App.Tap("Item3");
            Thread.Sleep(500);
            App.Tap("Item3");
            App.Tap("Item4");
            App.Tap("Item1");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase18");
        }

        //19
        [Test]
        [Description("TestCase19")]
        public void TestCase19()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase19");
        }

        //20
        [Test]
        [Description("TestCase20")]
        public void TestCase20()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase20");
        }

        //21
        [Test]
        [Description("TestCase21")]
        public void TestCase21()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase21");
        }

        //22
        [Test]
        [Description("TestCase22")]
        public void TestCase22()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase22");
        }

        //23
        [Test]
        [Description("TestCase23")]
        public void TestCase23()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase23");
        }

        //24
        [Test]
        [Description("TestCase24")]
        public void TestCase24()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase24");
        }

        //25
        [Test]
        [Description("TestCase25")]
        public void TestCase25()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("SingleOrNone");
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase25");
        }

        //26
        [Test]
        [Description("TestCase26")]
        public void TestCase26()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("SingleOrNone");
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase26");
        }

        //27
        [Test]
        [Description("TestCase27")]
        public void TestCase27()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("SingleOrNone");
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase27");
        }

        //28
        [Test]
        [Description("TestCase28")]
        public void TestCase28()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("SingleOrNone");
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase28");
        }

        //29  
        [Test]
        [Description("TestCase29")]
        public void TestCase29()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("SingleOrNone");
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase29");
        }

        //30
        [Test]
        [Description("TestCase30")]
        public void TestCase30()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("SingleOrNone");
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("SingleOrNone");
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase30");
        }

        //31
        [Test]
        [Description("TestCase31")]
        public void TestCase31()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Multiple");
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase31");
        }

        //32 
        [Test]
        [Description("TestCase32")]
        public void TestCase32()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Multiple");
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase32");
        }

        //33
        [Test]
        [Description("TestCase33")]
        public void TestCase33()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Multiple");
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase33");
        }
        //34
        [Test]
        [Description("TestCase34")]
        public void TestCase34()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Multiple");
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase34");
        }
        //35
        [Test]
        [Description("TestCase35")]
        public void TestCase35()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Multiple");
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase35");
        }
        //36
        [Test]
        [Description("TestCase36")]
        public void TestCase36()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("Multiple");
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase36");
        }

        //37
        [Test]
        [Description("TestCase37")]
        public void TestCase37()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("MultipleOrNone");
            App.Tap("ExpandAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase37");
        }
        //38
        [Test]
        [Description("TestCase38")]
        public void TestCase38()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("MultipleOrNone");
            App.Tap("CollapseAll");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase38");
        }
        //39
        [Test]
        [Description("TestCase39")]
        public void TestCase39()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("MultipleOrNone");
            App.Tap("ExpandCollapseSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase39");
        }
        //40
        [Test]
        [Description("TestCase40")]
        public void TestCase40()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("MultipleOrNone");
            App.Tap("ExpandCollapseMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase40");
        }

        //41
        [Test]
        [Description("TestCase41")]
        public void TestCase41()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("MultipleOrNone");
            App.Tap("CollapseExpandSingle");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase41");
        }

        //42
        [Test]
        [Description("TestCase42")]
        public void TestCase42()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("MultipleOrNone");
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("MultipleOrNone");
            App.Tap("CollapseExpandMultiple");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase42");
        }

        //43
        [Test]
        [Description("TestCase43")]
        public void TestCase43()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Top");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item3");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("Top");
            Thread.Sleep(500);
            App.Tap("Item3");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase43");
        }

        //44
        [Test]
        [Description("TestCase44")]
        public void TestCase44()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            Thread.Sleep(500);
            App.Tap("ScrollNone");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item18");
            Thread.Sleep(500);
            #elif WINDOWS
            App.Tap("Multiple");
            Thread.Sleep(500);
            App.Tap("ScrollNone");
            Thread.Sleep(500);
            App.Tap("Item18");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase44");
        }

        //45
        [Test]
        [Description("TestCase45")]
        public void TestCase45()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("Multiple");
            Thread.Sleep(500);
            App.Tap("MakeVisible");
            Thread.Sleep(500);
            Flyout2();
            App.Tap("Item18");
            Thread.Sleep(1500);
            #elif WINDOWS
            App.Tap("Multiple");
            Thread.Sleep(500);
            App.Tap("MakeVisible");
            Thread.Sleep(500);
            App.Tap("Item18");
            Thread.Sleep(1500);
            #endif
            TakeAndCompareScreenshot("TestCase45");
        }

        //46
        [Test]
        [Description("TestCase46")]
        public void TestCase46()
        {
#if ANDROID||IOS
            App.SetOrientationLandscape();
#endif
            TakeAndCompareScreenshot("TestCase46");
        }

        //47
        [Test]
        [Description("TestCase47")]
        public void TestCase47()
        {
#if ANDROID || IOS
            App.SetOrientationPortrait();
#endif
        #if ANDROID||IOS
            Flyout1();
            App.Tap("RTL");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("RTL");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase47");
        }

        //48
        [Test]
        [Description("TestCase48")]
        public void TestCase48()
        {
        #if ANDROID||IOS
            Flyout1();
            App.Tap("ItemSpacing");
            Thread.Sleep(500);
            Flyout2();
        #elif WINDOWS
            App.Tap("ItemSpacing");
            Thread.Sleep(500);
            #endif
            TakeAndCompareScreenshot("TestCase48");
        }

#endregion
    }
    }
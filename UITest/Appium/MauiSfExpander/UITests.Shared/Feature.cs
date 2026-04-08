using NUnit.Framework;
using Syncfusion.UITestHelpers.Core;
using Syncfusion.UITestHelpers.Appium; 
using Syncfusion.UITestHelpers.Screenshot;
using Syncfusion.UITestHelpers.NUnit;
using Syncfusion.UITestHelpers.ExtendReport; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UITests.Shared;

namespace MauiSfDemoScripts
{
    public class Feature : BaseTest
    {
        public Feature(TestDevice testDevice) : base(testDevice)
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

        //1
        [Test]
        [Description("TestCase1")]
        public void TestCase1()
        {
            App.Tap("IconPositionStart");
            TakeAndCompareScreenshot("TestCase1");
        }

        //2
        [Test]
        [Description("TestCase2")]
        public void TestCase2()
        {
            App.Tap("IconPositionEnd");
            TakeAndCompareScreenshot("TestCase2");
        }

        //3
        [Test]
        [Description("TestCase3")]
        public void TestCase3()
        {
            App.Tap("IconPositionNone");
            TakeAndCompareScreenshot("TestCase3");
        }

        //4 
        [Test]
        [Description("TestCase4")]
        public void TestCase4()
        {
            App.Tap("IconPositionStart");
            App.Tap("IconPositionEnd");
            TakeAndCompareScreenshot("TestCase4");
        }

        //5 
        [Test]
        [Description("TestCase5")]
        public void TestCase5()
        {
            App.Tap("IconPositionEnd");
            App.Tap("IconPositionStart");
            TakeAndCompareScreenshot("TestCase5");
        }

        //6 
        [Test]
        [Description("TestCase6")]
        public void TestCase6()
        {
            App.Tap("IconPositionStart");
            App.Tap("IconPositionNone");
            TakeAndCompareScreenshot("TestCase6");
        }

        //7
        [Test]
        [Description("TestCase7")]
        public void TestCase7()
        {
            App.Tap("IconPositionNone");
            App.Tap("IconPositionStart");
            TakeAndCompareScreenshot("TestCase7");
        }

        //8
        [Test]
        [Description("TestCase8")]
        public void TestCase8()
        {
            App.Tap("IconPositionEnd");
            App.Tap("IconPositionNone");

            TakeAndCompareScreenshot("TestCase8");
        }

        //9
        [Test]
        [Description("TestCase9")]
        public void TestCase9()
        {

            App.Tap("IconPositionNone");
            App.Tap("IconPositionEnd");
            TakeAndCompareScreenshot("TestCase9");
        }

        //10
        [Test]
        [Description("TestCase10")]
        public void TestCase10()
        {
            TakeAndCompareScreenshot("TestCase10");
        }

        //11
        [Test]
        [Description("TestCase11")]
        public void TestCase11()
        {
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase11");
        }

        //12
        [Test]
        [Description("TestCase12")]
        public void TestCase12()
        {

            TakeAndCompareScreenshot("TestCase12");
        }

        //13
        [Test]
        [Description("TestCase13")]
        public void TestCase13()
        {

            TakeAndCompareScreenshot("TestCase13");
        }

        //14
        [Test]
        [Description("TestCase14")]
        public void TestCase14()
        {
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase14");
        }

        //15
        [Test]
        [Description("TestCase15")]
        public void TestCase15()
        {
            App.Tap("HeaderNull");
            TakeAndCompareScreenshot("TestCase15");
        }

        //16
        [Test]
        [Description("TestCase16")]
        public void TestCase16()
        {
            App.Tap("HeaderBackgroundColor");
            TakeAndCompareScreenshot("TestCase16");
        }

        //17
        [Test]
        [Description("TestCase17")]
        public void TestCase17()
        {
            App.Tap("ChangeHeader");

            TakeAndCompareScreenshot("TestCase17");
        }

        //18
        [Test]
        [Description("TestCase18")]
        public void TestCase18()
        {
            App.Tap("IconColor");

            TakeAndCompareScreenshot("TestCase18");
        }

        //19
        [Test]
        [Description("TestCase19")]
        public void TestCase19()
        {
            App.Tap("IconColor");
            TakeAndCompareScreenshot("TestCase19");
        }

        //20
        [Test]
        [Description("TestCase20")]
        public void TestCase20()
        {
            App.Tap("HeaderNullConstructor");
            TakeAndCompareScreenshot("TestCase20");
        }

        //21
        [Test]
        [Description("TestCase21")]
        public void TestCase21()
        {

            App.Tap("ContentNullConstructor");
            TakeAndCompareScreenshot("TestCase21");
        }

        //22
        [Test]
        [Description("TestCase22")]
        public void TestCase22()
        {

            App.Tap("ChangeHeader");
            App.Tap("HeaderBackgroundColor");
            TakeAndCompareScreenshot("TestCase22");
        }

        //23
        [Test]
        [Description("TestCase23")]
        public void TestCase23()
        {

            TakeAndCompareScreenshot("TestCase23");
        }

        //24
        [Test]
        [Description("TestCase24")]
        public void TestCase24()
        {

            App.Tap("ContentSetOnRuntime");
            TakeAndCompareScreenshot("TestCase24");
        }

        //25
        [Test]
        [Description("TestCase25")]
        public void TestCase25()
        {
            TakeAndCompareScreenshot("TestCase25");
        }

        //26
        [Test]
        [Description("TestCase26")]
        public void TestCase26()
        {
            TakeAndCompareScreenshot("TestCase26");
        }

        //27
        [Test]
        [Description("TestCase27")]
        public void TestCase27()
        {
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase27");
        }

        //28
        [Test]
        [Description("TestCase28")]
        public void TestCase28()
        {
            //App.ScrollDown("ChangeContentText");
            App.Tap("ChangeContentText");
            TakeAndCompareScreenshot("TestCase28");
        }

        //29
        [Test]
        [Description("TestCase29")]
        public void TestCase29()
        {
            App.Tap("FullContentChangeAndExpanded");
            TakeAndCompareScreenshot("TestCase29");
        }

        //30
        [Test]
        [Description("TestCase30")]
        public void TestCase30()
        {
            //App.ScrollDown("FullContentChangeAndCollapsed");
            App.Tap("FullContentChangeAndCollapsed");
            TakeAndCompareScreenshot("TestCase30");
        }

        //31
        [Test]
        [Description("TestCase31")]
        public void TestCase31()
        {
            //App.ScrollDown("ChangeContentText");
            App.Tap("ChangeContentText");
            TakeAndCompareScreenshot("TestCase31");
        }

        //32
        [Test]
        [Description("TestCase32")]
        public void TestCase32()
        {
            App.Tap("ContentNull");
            TakeAndCompareScreenshot("TestCase32");
        }

        //33
        [Test]
        [Description("TestCase33")]
        public void TestCase33()
        {
            //App.ScrollDown("NullContentExpanded");
            App.Tap("NullContentExpanded");
            TakeAndCompareScreenshot("TestCase33");
        }

        //34
        [Test]
        [Description("TestCase34")]
        public void TestCase34()
        {
            //App.ScrollDown("NullContentCollapsed");
            App.Tap("NullContentCollapsed");
            TakeAndCompareScreenshot("TestCase34");
        }

        //35
        [Test]
        [Description("TestCase35")]
        public void TestCase35()
        {
            //App.ScrollDown("AddSfListViewAsContent");
            App.Tap("AddSfListViewAsContent");
            TakeAndCompareScreenshot("TestCase35");
        }

        //36
        [Test]
        [Description("TestCase36")]
        public void TestCase36()
        {
            //App.ScrollDown("AddSfPopupAsContent");
            App.Tap("AddSfPopupAsContent");
            App.Tap("Click To Show Popup");
            TakeAndCompareScreenshot("TestCase36");
        }

        //37
        [Test]
        [Description("TestCase37")]
        public void TestCase37()
        {
            //App.ScrollDown("AddImageAsContent");
            App.Tap("AddImageAsContent");
            TakeAndCompareScreenshot("TestCase37");
        }

        //38
        [Test]
        [Description("TestCase38")]
        public void TestCase38()
        {
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase38");
        }

        //39
        [Test]
        [Description("TestCase39")]
        public void TestCase39()
        {
            App.Tap("ExpandCollapse");
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase39");
        }

        //40
        [Test]
        [Description("TestCase40")]
        public void TestCase40()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("Linear");
            TakeAndCompareScreenshot("TestCase40");
        }

        //41
        [Test]
        [Description("TestCase41")]
        public void TestCase41()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("SinIn");
            TakeAndCompareScreenshot("TestCase41");
        }

        //42
        [Test]
        [Description("TestCase42")]
        public void TestCase42()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("SinOut");
            TakeAndCompareScreenshot("TestCase42");
        }

        //43
        [Test]
        [Description("TestCase43")]
        public void TestCase43()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("SinInOut");
            TakeAndCompareScreenshot("TestCase43");
        }

        //44
        [Test]
        [Description("TestCase44")]
        public void TestCase44()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("None");
            TakeAndCompareScreenshot("TestCase44");
        }

        //45
        [Test]
        [Description("TestCase45")]
        public void TestCase45()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("Linear");
            App.Tap("SinInOut");
            TakeAndCompareScreenshot("TestCase45");
        }

        //46
        [Test]
        [Description("TestCase46")]
        public void TestCase46()
        {
            //App.ScrollDown("Animation");
            App.Tap("Animation");
            App.Tap("SinOut");
            TakeAndCompareScreenshot("TestCase46");
        }

        //47
        [Test]
        [Description("TestCase47")]
        public void TestCase47()
        {
            //App.ScrollDown("FlowDirectionPage");
            App.Tap("FlowDirectionPage");
            TakeAndCompareScreenshot("TestCase47");
        }

        //48
        [Test]
        [Description("TestCase48")]
        public void TestCase48()
        {
            //App.ScrollDown("FlowDirectionPage");
            App.Tap("FlowDirectionPage");
            App.Tap("RTLtoLTR");
            TakeAndCompareScreenshot("TestCase48");
        }

        //49
        [Test]
        [Description("TestCase49")]
        public void TestCase49()
        {
            //App.ScrollDown("FlowDirectionPage");
            App.Tap("FlowDirectionPage");
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase49");
        }

        //50
        [Test]
        [Description("TestCase50")]
        public void TestCase50()
        {
            //App.ScrollDown("FlowDirectionPage");
            App.Tap("FlowDirectionPage");
            App.Tap("ExpandCollapse");
            App.Tap("ExpandCollapse");
            TakeAndCompareScreenshot("TestCase50");
        }

        //51
        [Test]
        [Description("TestCase51")]
        public void TestCase51()
        {
            //App.ScrollDown("ContentSetLoadingCS");
            App.Tap("ContentSetLoadingCS");
            TakeAndCompareScreenshot("TestCase51");
        }

        //52
        [Test]
        [Description("TestCase52")]
        public void TestCase52()
        {
            //App.ScrollDown("AddContentExpanded");
            //App.ScrollDown("AddContentExpanded");
            App.Tap("AddContentExpanded");
            TakeAndCompareScreenshot("TestCase52");
        }

        //53
        [Test]
        [Description("TestCase53")]
        public void TestCase53()
        {
            //App.ScrollDown("AddContentCollapse");
            //App.ScrollDown("AddContentCollapse");
            App.Tap("AddContentCollapse");
            TakeAndCompareScreenshot("TestCase53");
        }

        //54
        [Test]
        [Description("TestCase54")]
        public void TestCase54()
        {
            //App.ScrollDown("AddListViewAsContentOnLoading");
            //App.ScrollDown("AddListViewAsContentOnLoading");
            App.Tap("AddListViewAsContentOnLoading");
            TakeAndCompareScreenshot("TestCase54");
        }

        //55
        [Test]
        [Description("TestCase55")]
        public void TestCase55()
        {
            //App.ScrollDown("AddListViewAsContentOnLoading");
            //App.ScrollDown("AddListViewAsContentOnLoading");
            App.Tap("AddListViewAsContentOnLoading");
            TakeAndCompareScreenshot("TestCase55");
        }

        //56
        [Test]
        [Description("TestCase56")]
        public void TestCase56()
        {
            //App.ScrollDown("AddPopupAsContentOnLoading");
            //App.ScrollDown("AddPopupAsContentOnLoading");
            App.Tap("AddPopupAsContentOnLoading");
            TakeAndCompareScreenshot("TestCase56");
        }

        //57
        [Test]
        [Description("TestCase57")]
        public void TestCase57()
        {
            //App.ScrollDown("AddPopupAsContentOnLoading");
            //App.ScrollDown("AddPopupAsContentOnLoading");
            App.Tap("AddPopupAsContentOnLoading");
            TakeAndCompareScreenshot("TestCase57");
        }

        //58
        [Test]
        [Description("TestCase58")]
        public void TestCase58()
        {
            //App.ScrollDown("AddImageAsContentOnLoading");
            App.Tap("AddImageAsContentOnLoading");
            TakeAndCompareScreenshot("TestCase58");
        }

        //59
        [Test]
        [Description("TestCase59")]
        public void TestCase59()
        {
            //App.ScrollDown("SetFlowDirectionParent");
            App.Tap("SetFlowDirectionParent");
            TakeAndCompareScreenshot("TestCase59");
        }

        //60
        [Test]
        [Description("TestCase60")]
        public void TestCase60()
        {
            //App.ScrollDown("ChangeToRTL");
            //App.ScrollDown("ChangeToRTL");
            App.Tap("ChangeToRTL");
            TakeAndCompareScreenshot("TestCase60");
        }

        //61
        [Test]
        [Description("TestCase61")]
        public void TestCase61()
        {
            App.Tap("ChangeHeader");
            //App.ScrollDown("ChangeToRTL");
            //App.ScrollDown("ChangeToRTL");
            App.Tap("ChangeToRTL");
            TakeAndCompareScreenshot("TestCase61");
        }

        //62
        [Test]
        [Description("TestCase62")]
        public void TestCase62()
        {
            //App.ScrollDown("FlowDirectionPage");
            App.Tap("FlowDirectionPage");
            App.Tap("HeaderIconPositionStart");
            TakeAndCompareScreenshot("TestCase62");
        }

        //63
        [Test]
        [Description("TestCase63")]
        public void TestCase63()
        {
            //App.ScrollDown("FlowDirectionPage");
            App.Tap("FlowDirectionPage");
            App.Tap("HeaderIconPositionEnd");
            TakeAndCompareScreenshot("TestCase63");
        }

    }
}

using NUnit.Framework;
using UITests.Shared;
using Syncfusion.UITestHelpers.Appium;
using Syncfusion.UITestHelpers.Core;
using Syncfusion.UITestHelpers.Screenshot;

namespace SfButtonScripts
{
    public class Properties : BaseTest
    {
        public Properties(TestDevice testDevice) : base(testDevice)
        {
        }
        [TearDown]
        public void TearDown()
        {
            Reset(); // Reset App each and evry test
        }
        #region Properties
        [Test]
        [Category("Basic Button")]

        public void ButtonInitial()
        {
            Basicsbutton("ButtonInitial");
            Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonInitial");
        }
        [Test]
        [Category("Basic Button size")]

        public void ButtonSize()
        {
            Basicsbutton("ButtonSize");
            Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonSize");
        }
        [Test]
        [Category("Command")]

        public void Command1()
        {
            Basicsbutton("CommandSample");
           // App.WaitForElement("Command");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmd");
            Thread.Sleep(2000); TakeAndCompareScreenshot("Command1");
        }
        [Test]
        [Category("Command parameter")]

        public void Commandparameter()
        {
            Basicsbutton("CommandSample");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmd");
            App.Tap("cmdp");
            Thread.Sleep(2000); TakeAndCompareScreenshot("Commandparameter");
        }
        [Test]
        [Category("IsBusyFeature")]

        public void IsBusyFeature()
        {
            Basicsbutton("IsBusyFeature");
            Thread.Sleep(2000); TakeAndCompareScreenshot("IsBusyFeature");
        }
        [Test]
        [Category("place holder text")]

        public void placeholdertext()
        {
            Basicsbutton("ButtonSize");
            //App.Tap("em");
            App.ClearText("em");
            App.DismissKeyboard();
            Thread.Sleep(2000); TakeAndCompareScreenshot("placeholdertext");
        }
        [Test]
        [Category("place holder textcolor")]

        public void placeholdertextcolor()
        {
            Basicsbutton("ButtonSize");
            //App.Tap("ps");
            App.ClearText("ps");
            App.DismissKeyboard();
            Thread.Sleep(2000); TakeAndCompareScreenshot("placeholdertextcolor");
        }
//         [Test]
//         [Category("Visualstate")]

//         public void Visualstate()
//         {
//             Basicsbutton("Visualstate");
//             App.Tap("btn");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Visualstate");
//         }
//         [Test]
//         [Category("Layouts")]

//         public void Layouts()
//         {
//             Basicsbutton("Layouts");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Layouts");
//         }
//         [Test]
//         [Category("FontFamily")]

//         public void FontFamily1()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Family");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Roboto-Medium");
// #else
// App.iOSPickerInteract("Family","Roboto-Medium");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FontFamily1");
//         }
//         [Test]
//         [Category("FontFamily")]

//         public void FontFamily2()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Family");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Roboto-Regular");
// #else
//             App.iOSPickerInteract("Family", "Roboto-Regular");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FontFamily2");
//         }
//         [Test]
//         [Category("FontFamily")]

//         public void FontFamily3()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Family");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("SamanthaDemo");
// #else
//             App.iOSPickerInteract("Family", "SamanthaDemo");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FontFamily3");
//         }
//         [Test]
//         [Category("FontFamily")]

//         public void FontFamily4()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Family");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("OpenSansSemibold");
// #else
//             App.iOSPickerInteract("Family", "OpenSansSemibold");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FontFamily4");
//         }
//         [Test]
//         [Category("FontFamily")]

//         public void FontFamily5()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Family");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("OpenSansRegular");
// #else
//             App.iOSPickerInteract("Family", "OpenSansRegular");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FontFamily5");
//         }
//         [Test]
//         [Category("ButtonHeight")]

//         public void ButtonHeight1()
//         {
//             Basicsbutton("Properties");
//             App.Tap("btnheighslider");
//             App.ClearText("btnheighslider");
//             App.EnterText("btnheighslider", "70");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonHeight1");
//         }
//         [Test]
//         [Category("ButtonHeight")]

//         public void ButtonHeight2()
//         {
//             Basicsbutton("Properties");
//             App.Tap("btnheighslider");
//             App.ClearText("btnheighslider");
//             App.EnterText("btnheighslider", "120");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonHeight2");
//         }
//         [Test]
//         [Category("ButtonHeight")]

//         public void ButtonHeight3()
//         {
//             Basicsbutton("Properties");
//             App.Tap("btnheighslider");
//             App.ClearText("btnheighslider");
//             App.EnterText("btnheighslider", "200");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonHeight3");
//         }
//         [Test]
//         [Category("ButtonWidth")]

//         public void ButtonWidth1()
//         {
//             Basicsbutton("Properties");
//             App.Tap("btnwidtslider");
//             App.ClearText("btnwidtslider");
//             App.EnterText("btnwidtslider", "200");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonWidth1");
//         }
//         [Test]
//         [Category("ButtonWidth")]

//         public void ButtonWidth2()
//         {
//             Basicsbutton("Properties");
//             App.Tap("btnwidtslider");
//             App.ClearText("btnwidtslider");
//             App.EnterText("btnwidtslider", "150");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonWidth2");
//         }
//         [Test]
//         [Category("ButtonWidth")]

//         public void ButtonWidth3()
//         {
//             Basicsbutton("Properties");
//             App.Tap("btnwidtslider");
//             App.ClearText("btnwidtslider");
//             App.EnterText("btnwidtslider", "100");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonWidth3");
//         }
//         [Test]
//         [Category("ButtonThickness")]

//         public void ButtonThickness1()
//         {
//             Basicsbutton("Properties");
//             App.Tap("bslider");
//             App.ClearText("bslider");
//             App.EnterText("bslider", "0");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonThickness1");
//         }
//         [Test]
//         [Category("ButtonThickness")]

//         public void ButtonThickness2()
//         {
//             Basicsbutton("Properties");
//             App.Tap("bslider");
//             App.ClearText("bslider");
//             App.EnterText("bslider", "20");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ButtonThickness2");
//         }
//         [Test]
//         [Category("ImageSpacing")]

//         public void ImageSpacing1()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Showic");
//             App.Tap("paddingslider");
//             App.ClearText("paddingslider");
//             App.EnterText("paddingslider", "0");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ImageSpacing1");
//         }
//         [Test]
//         [Category("ImageSpacing")]

//         public void ImageSpacing2()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Showic");
//             App.Tap("paddingslider");
//             App.ClearText("paddingslider");
//             App.EnterText("paddingslider", "15");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ImageSpacing2");
//         }
//         [Test]
//         [Category("FlowDirection")]

//         public void FlowDirection1()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Showic");
//             App.Tap("direction");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("RightToLeft");
// #else
//             App.iOSPickerInteract("direction","RightToLeft");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FlowDirection1");
//         }
//         [Test]
//         [Category("FlowDirection")]

//         public void FlowDirection2()
//         {
//             Basicsbutton("Properties");
//             App.Tap("Showic");
//             App.Tap("direction");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("LeftToRight");
// #else
//             App.iOSPickerInteract("direction","LeftToRight");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("FlowDirection2");
//         }
//         [Test]
//         [Category("ISEnable")]

//         public void ISEnableoff()
//         {
//             Basicsbutton("Properties");
//             App.Tap("IsEnab");
//             App.Tap("tes");
//             App.Tap("tes");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ISEnableoff");
//         }
//         [Test]
//         [Category("ISEnable")]

//         public void ISEnableOn()
//         {
//             Basicsbutton("Properties");
//             App.Tap("tes");
//             App.Tap("tes");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ISEnableOn");
//         }
//         [Test]
//         [Category("ISVisible")]

//         public void ISVisibleOn()
//         {
//             Basicsbutton("Properties");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ISVisibleOn");
//         }
//         [Test]
//         [Category("ISVisible")]

//         public void ISVisibleOff()
//         {
//             Basicsbutton("Properties");
//             App.Tap("isvis");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("ISVisibleOff");
//         }
//         [Test]
//         [Category("Button pressed background color")]
//         [Category("Views")]
//         [Description("XAMARIN_24037")]
//         public void Buttonpressedbackgroundcolor()
//         {
//             Basicsbutton("XAMARIN_24037");
//             App.TouchAndHold("btn");
//             TakeAndCompareScreenshot("Buttonpressedbackgroundcolor");
//         }
//         #endregion
//         #region Features
//         [Test]
//         [Category("name property")]

//         public void name_1()
//         {
//             Basicsbutton("Features");
//             //App.Tap("name");
//             App.ClearText("name");
//             App.EnterText("name", "SfButton");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("name_1");
//         }
//         [Test]
//         [Category("text color property")]

//         public void textcolor_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("TextColor");  

// #if ANDROID || WINDOWS || MACOS          
//             App.Tap("Green");
// #else
//             App.iOSPickerInteract("TextColor","Green");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("textcolor_1");
//         }
//         [Test]
//         [Category("text color property")]

//         public void textcolor_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("TextColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Black");
// #else
//             App.iOSPickerInteract("TextColor","Black");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("textcolor_2");
//         }
//         [Test]
//         [Category("text color property")]

//         public void textcolor_3()
//         {
//             Basicsbutton("Features");
//             App.Tap("TextColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Yellow");
// #else
//             App.iOSPickerInteract("TextColor","Yellow");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("textcolor_3");
//         }
//         [Test]
//         [Category("text color property")]

//         public void textcolor_4()
//         {
//             Basicsbutton("Features");
//             App.Tap("TextColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Orange");
// #else
//             App.iOSPickerInteract("TextColor","Orange");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("textcolor_4");
//         }
//         [Test]
//         [Category("text color property")]

//         public void textcolor_5()
//         {
//             Basicsbutton("Features");
//             App.Tap("TextColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Blue");
// #else
//             App.iOSPickerInteract("TextColor","Blue");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("textcolor_5");
//         }
//         [Test]
//         [Category("show icon property")]

//         public void showicon_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("showicon_1");
//         }
//         [Test]
//         [Category("image source property")]

//         public void imagesource_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
//             App.Tap("imagesource");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("avatar10.png");
// #else
//             App.iOSPickerInteract("imagesource","avatar10.png");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagesource_1");
//         }
//         [Test]
//         [Category("image source property")]

//         public void imagesource_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
//             App.Tap("imagesource");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("avatar1.png");
// #else
//             App.iOSPickerInteract("imagesource","avatar1.png");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagesource_2");
//         }
//         [Test]
//         [Category("image width property")]

//         public void imagewidth_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
//             App.Tap("ImageWidthslider");
//             App.ClearText("ImageWidthslider");
//             App.EnterText("ImageWidthslider", "30");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagewidth_1");
//         }
//         [Test]
//         [Category("image width property")]

//         public void imagewidth_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
//             App.Tap("ImageWidthslider");
//             App.ClearText("ImageWidthslider");
//             App.EnterText("ImageWidthslider", "18");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagewidth_2");
//         }
//         [Test]
//         [Category("corner radius property")]

//         public void cornerradius_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("CornerRadiusslider");
//             App.ClearText("CornerRadiusslider");
//             App.EnterText("CornerRadiusslider", "15");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("cornerradius_1");
//         }
//         [Test]
//         [Category("corner radius property")]

//         public void cornerradius_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("CornerRadiusslider");
//             App.ClearText("CornerRadiusslider");
//             App.EnterText("CornerRadiusslider", "0");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("cornerradius_2");
//         }
// 		[Test]
//         [Category("border color property")]

//         public void bordercolor_0dummy()
//         {
//             Basicsbutton("Features");
//            // App.WaitForElement("Background");
//             App.Tap("BorderColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Black");
// #else
//             App.iOSPickerInteract("BorderColor","Black");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("bordercolor_dummy");
//         }
//         [Test]
//         [Category("border color property")]

//         public void bordercolor_1()
//         {
//             Basicsbutton("Features");
//            // App.WaitForElement("Background");
//             App.Tap("BorderColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Black");
// #else
//             App.iOSPickerInteract("BorderColor","Black");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("bordercolor_1");
//         }
//         [Test]
//         [Category("border color property")]

//         public void bordercolor_2()
//         {
//             Basicsbutton("Features");
//            // App.WaitForElement("Background");
//             App.Tap("BorderColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Green");
           
// #else
//             App.iOSPickerInteract("BorderColor","Green");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("bordercolor_2");
//         }
//         [Test]
//         [Category("border color property")]

//         public void bordercolor_3()
//         {
//             Basicsbutton("Features");
//            // App.WaitForElement("Background");
//             App.Tap("BorderColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Yellow");
// #else
//             App.iOSPickerInteract("BorderColor","Yellow");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("bordercolor_3");
//         }
//         [Test]
//         [Category("border color property")]

//         public void bordercolor_4()
//         {
//             Basicsbutton("Features");
//            // App.WaitForElement("Background");
//             App.Tap("BorderColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Orange");
// #else
//             App.iOSPickerInteract("BorderColor","Orange");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("bordercolor_4");
//         }
//         [Test]
//         [Category("border color property")]

//         public void bordercolor_5()
//         {
//             Basicsbutton("Features");
//            // App.WaitForElement("Background");
//             App.Tap("BorderColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Blue");
// #else
//             App.iOSPickerInteract("BorderColor","Blue");
           
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("bordercolor_5");
//         }
//         [Test]
//         [Category("stroke thickness property")]

//         public void strokethickness_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("thicknessslider");
//             App.ClearText("thicknessslider");
//             App.EnterText("thicknessslider", "15");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("strokethickness_1");
//         }
//         [Test]
//         [Category("stroke thickness property")]

//         public void strokethickness_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("thicknessslider");
//             App.ClearText("thicknessslider");
//             App.EnterText("thicknessslider", "0");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("strokethickness_2");
//         }
//         [Test]
//         [Category("padding property")]

//         public void padding_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("paddingslider");
//             App.ClearText("paddingslider");
//             App.EnterText("paddingslider", "15");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("padding_1");
//         }
//         [Test]
//         [Category("padding property")]

//         public void padding_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("paddingslider");
//             App.ClearText("paddingslider");
//             App.EnterText("paddingslider", "0");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("padding_2");
//         }
//         [Test]
//         [Category("image alignment property")]

//         public void imagealignment_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("image");
//             App.Tap("End");
// #else
//             //App.ScrollTo("Start");
//             App.Tap("image");
//             App.iOSPickerInteract("image","End");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagealignment_1");
//         }
//         [Test]
//         [Category("image alignment property")]

//         public void imagealignment_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("image");
//             App.Tap("Top");
// #else
//             //App.ScrollTo("Start");
//             App.Tap("image");
//              App.iOSPickerInteract("image","Top");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagealignment_2");
//         }
//         [Test]
//         [Category("image alignment property")]

//         public void imagealignment_3()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("image");
//             App.Tap("Start");
// #else
//             //App.ScrollTo("Start");
//             App.Tap("image");
//              App.iOSPickerInteract("image","Start");
//            // App.Tap("Done");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagealignment_3");
//         }
//         [Test]
//         [Category("image alignment property")]

//         public void imagealignment_4()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("image");
//             App.Tap("Bottom");
// #else
//             //App.ScrollTo("Start");
//             App.Tap("image");
//              App.iOSPickerInteract("image","Bottom");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagealignment_4");
//         }
//         [Test]
//         [Category("image alignment property")]

//         public void imagealignment_5()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("image");
//             App.Tap("Left");
// #else
//             //App.ScrollTo("Start");
//             App.Tap("image");
//              App.iOSPickerInteract("image","Left");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagealignment_5");
//         }
//         [Test]
//         [Category("image alignment property")]

//         public void imagealignment_6()
//         {
//             Basicsbutton("Features");
//             App.Tap("ShowIcon");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("image");
//             App.Tap("Right");
// #else
//             //App.ScrollTo("Start");
//             App.Tap("image");
//              App.iOSPickerInteract("image","Right");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("imagealignment_6");
//         }
//         [Test]
//         [Category("font size property")]

//         public void fontsize_1()
//         {
//             Basicsbutton("Features");
//             App.Tap("fontsizeslider");
//             App.ClearText("fontsizeslider");
//             App.EnterText("fontsizeslider", "30");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("fontsize_1");
//         }
//         [Test]
//         [Category("font size property")]

//         public void fontsize_2()
//         {
//             Basicsbutton("Features");
//             App.Tap("fontsizeslider");
//             App.ClearText("fontsizeslider");
//             App.EnterText("fontsizeslider", "14");
//             App.DismissKeyboard();
//             Thread.Sleep(2000); TakeAndCompareScreenshot("fontsize_2");
//         }
//         [Test]
//         [Category("font attribute property")]

//         public void fontattribute_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Attribute");
//             App.Tap("None");
// #else
//             //App.ScrollTo("Bold");
//             App.Tap("Attribute");
//             App.iOSPickerInteract("Attribute","None");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("fontattribute_1");
//         }
//         [Test]
//         [Category("font attribute property")]

//         public void fontattribute_2()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Attribute");
//             App.Tap("Italic");
// #else
//             //App.ScrollTo("Bold");
//             App.Tap("Attribute");
//             App.iOSPickerInteract("Attribute","Italic");
            

// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("fontattribute_2");
//         }
//         [Test]
//         [Category("font attribute property")]

//         public void fontattribute_3()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Attribute");
//             App.Tap("Bold");
// #else
//             //App.ScrollTo("Bold");
//             App.Tap("Attribute");
//             App.iOSPickerInteract("Attribute","Bold");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("fontattribute_3");
//         }
//         [Test]
//         [Category("BackgroundImage property")]

//         public void BackgroundImage_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("BackgroundImage");
//             App.Tap("backgroundimage");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("backgroundimage");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BackgroundImage_1");
//         }
//         [Test]
//         [Category("HorizontalTextAlignment property")]

//         public void HorizontalTextAlignment_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("HorizontalTextAlignment");
//             App.Tap("HorizontalText");
//             App.Tap("Start");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("HorizontalText");
//             App.iOSPickerInteract("HorizontalText","Start");
        
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("HorizontalTextAlignment_1");
//         }
//         [Test]
//         [Category("HorizontalTextAlignment property")]

//         public void HorizontalTextAlignment_2()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("HorizontalTextAlignment");
//             App.Tap("HorizontalText");
//             App.Tap("Center");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("HorizontalText");
//             App.iOSPickerInteract("HorizontalText","Center");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("HorizontalTextAlignment_2");
//         }
//         [Test]
//         [Category("HorizontalTextAlignment property")]

//         public void HorizontalTextAlignment_3()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("HorizontalTextAlignment");
//             App.Tap("HorizontalText");
//             App.Tap("End");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("HorizontalText");
//             App.iOSPickerInteract("HorizontalText","End");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("HorizontalTextAlignment_3");
//         }
//         [Test]
//         [Category("VerticalTextAlignment property")]

//         public void VerticalTextAlignment_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("VerticalTextAlignment");
//             App.Tap("VerticalText");
//             App.Tap("Start");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("VerticalText");
//             App.iOSPickerInteract("VerticalText","Start");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("VerticalTextAlignment_1");
//         }
//         [Test]
//         [Category("VerticalTextAlignment property")]

//         public void VerticalTextAlignment_2()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("VerticalTextAlignment");
//             App.Tap("VerticalText");
//             App.Tap("Center");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("VerticalText");
//             App.iOSPickerInteract("VerticalText","Center");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("VerticalTextAlignment_2");
//         }
//         [Test]
//         [Category("VerticalTextAlignment property")]

//         public void VerticalTextAlignment_3()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("VerticalTextAlignment");
//             App.Tap("VerticalText");
//             App.Tap("End");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("VerticalText");
//             App.iOSPickerInteract("VerticalText","End");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("VerticalTextAlignment_3");
//         }
//         [Test]
//         [Category("Command property")]

//         public void Command_1()
//         {
//             Basicsbutton("Features");
//             Thread.Sleep(1000);
//             App.Tap("text");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Command");
// #else
//             //App.ScrollTo("LightGray");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Command_1");
//         }
//         [Test]
//         [Category("Command property")]

//         public void Command_2()
//         {
//             Basicsbutton("Features");
//             Thread.Sleep(1000);
//             App.DoubleTap("text");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Command");
// #else
//             //App.ScrollTo("LightGray");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Command_2");
//         }
//         [Test]
//         [Category("Content property")]

//         public void Content_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Content");
//             App.Tap("contenT");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("contenT");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Content_1");
//         }
//         [Test]
//         [Category("DashArray property")]

//         public void DashArray_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("DashArray");
//             App.Tap("dasharray");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("dasharray");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("DashArray_1");
//         }
// 		[Test]
//         [Category("Background property")]

//         public void Background_0()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Background");
//             App.WaitForElement("Background");
//             App.Tap("background");
//             App.Tap("Green");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("background");
//             App.iOSPickerInteract("background","Green");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Background_0");
//         }
//         [Test]
//         [Category("Background property")]

//         public void Background_1()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Background");
//            // App.WaitForElement("Background");
//             App.Tap("background");
//             App.Tap("Green");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("background");
//             App.iOSPickerInteract("background","Green");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Background_1");
//         }
//         [Test]
//         [Category("Background property")]

//         public void Background_2()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Background");
//             App.Tap("background");
//             App.Tap("Yellow");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("background");
//             App.iOSPickerInteract("background","Yellow");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Background_2");
//         }
//         [Test]
//         [Category("Background property")]

//         public void Background_3()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Background");
//             App.Tap("background");
//             App.Tap("Orange");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("background");
//             App.iOSPickerInteract("background","Orange");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Background_3");
//         }
//         [Test]
//         [Category("Background property")]

//         public void Background_4()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Background");
//             App.Tap("background");
//             App.Tap("LightGray");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("background");
//             App.iOSPickerInteract("background","LightGray");
        
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Background_4");
//         }
//         [Test]
//         [Category("Background property")]

//         public void Background_5()
//         {
//             Basicsbutton("Features");
// #if ANDROID || WINDOWS || MACOS
//             //App.ScrollTo("Background");
//             App.Tap("background");
//             App.Tap("Blue");
// #else
//             //App.ScrollTo("LightGray");
//             App.Tap("background");
//             App.iOSPickerInteract("background","Blue");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Background_5");
//         }
//         [Test]

//         public void Feature_1()
//         {
//             Basicsbutton("Features");
//             //App.Tap("name");
//             App.ClearText("name");
//             App.EnterText("name", "SfButton");
//             App.DismissKeyboard();
//             App.Tap("TextColor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Orange");
//             App.Tap("ShowIcon");
//             App.Tap("imagesource");
//             App.Tap("avatar10.png");

//             App.Tap("ImageWidthslider");
//             App.ClearText("ImageWidthslider");
//             App.EnterText("ImageWidthslider", "30");

//             App.Tap("BorderColor");
//             App.Tap("Green");

//             App.Tap("thicknessslider");
//             App.ClearText("thicknessslider");
//             App.EnterText("thicknessslider", "15");

//             App.Tap("image");
//             App.Tap("Bottom");
// #else
//             App.iOSPickerInteract("TextColor","Orange");
//             App.Tap("ShowIcon");
//             App.Tap("imagesource");
//             App.iOSPickerInteract("imagesource","avatar10.png");
//             App.Tap("ImageWidthslider");
//             App.ClearText("ImageWidthslider");
//             App.EnterText("ImageWidthslider", "30");
//             App.DismissKeyboard();
//             App.Tap("BorderColor");
//             App.iOSPickerInteract("BorderColor","Green");

//             App.Tap("thicknessslider");
//             App.ClearText("thicknessslider");
//             App.EnterText("thicknessslider", "15");
//             App.DismissKeyboard();
//             App.Tap("image");
//             App.iOSPickerInteract("image","Bottom");
            
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("Feature_1");
//         }
//         [Test]
//         [Category("GettingStartedMobile property")]

//         public void GettingStartedMobile_1()
//         {
//             Basicsbutton("GettingStartedMobile");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("GettingStartedMobile_1");
//         }
//         [Test]
//         [Category("CustomizationMobile property")]

//         public void CustomizationMobile_1()
//         {
//             Basicsbutton("CustomizationMobile");
//             App.Tap("TextColorblue");
//             App.Tap("background");
//             App.Tap("backgroundcolor");
//             App.Tap("Bordercolor");
//             App.Tap("bordercolor");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Borderthicknessslider");
//             App.ClearText("Borderthicknessslider");
//             App.EnterText("Borderthicknessslider", "9");
// App.DismissKeyboard();
//             App.Tap("Cornerradiussliderleft");
//             App.ClearText("Cornerradiussliderleft");
//             App.EnterText("Cornerradiussliderleft", "15");
// App.DismissKeyboard();
//             App.Tap("Cornerradiussliderright");
//             App.ClearText("Cornerradiussliderright");
//             App.EnterText("Cornerradiussliderright", "15");
// App.DismissKeyboard();           
// #else
//             App.Tap("Borderthicknessslider");
//             App.ClearText("Borderthicknessslider");
//             App.EnterText("Borderthicknessslider", "9");
// App.DismissKeyboard();
//             App.Tap("Cornerradiussliderleft");
//             App.ClearText("Cornerradiussliderleft");
//             App.EnterText("Cornerradiussliderleft", "15");
// App.DismissKeyboard();
//             App.Tap("Cornerradiussliderright");
//             App.ClearText("Cornerradiussliderright");
//             App.EnterText("Cornerradiussliderright", "15");
// App.DismissKeyboard();         
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("CustomizationMobile_1");
//         }
//         [Test]
//         [Category("CustomizationMobile property")]

//         public void CustomizationMobile_2()
//         {
//             Basicsbutton("CustomizationMobile");
// #if ANDROID || WINDOWS || MACOS
//             App.Tap("Backgroundimage");
// #else
//             //App.ScrollDownTo("Show Background Image");
//             App.Tap("Backgroundimage");
// #endif
//             Thread.Sleep(2000); TakeAndCompareScreenshot("CustomizationMobile_2");
//         }
//         [Test]
//         [Category("SfButton1 property")]

//         public void SfButton1()
//         {
//             Basicsbutton("SfButton1");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("SfButton1");
//         }
//         [Test]
//         [Category("SfButton2 property")]

//         public void SfButton2()
//         {
//             Basicsbutton("SfButton2");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("SfButton2");
//         }
//         [Test]
//         [Category("SfButton3 property")]

//         public void SfButton3()
//         {
//             Basicsbutton("SfButton3");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("SfButton3");
//         }
//         #endregion
//         #region Bugs
//         [Test]
//         [Category("SfButton Horizontal Options behavior is different from framework button control (TaskID 851093)")]

//         public void BugTask_851093()
//         {
//             Basicsbutton("Task_851093");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugTask_851093");
//         }
//         [Test]
//         [Category("Press the Test Button Expected Behavior ( Last two buttons IsEnabled should be changed) TaskID 856303")]

//         public void BugTask_856303_1()
//         {
//             Basicsbutton("Bug856303");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugTask_856303_1");
//         }
//         [Test]
//         [Category("Press the Test Button Expected Behavior(Last two buttons IsEnabled should be changed) TaskID 856303")]

//         public void BugTask_856303_2()
//         {
//             Basicsbutton("Bug856303");
//             App.Tap("te");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugTask_856303_2");
//         }
//         [Test]
//         [Category("SfButtons inside VerticalStackLayout does not scroll when start scroll on SfButton TaskID 866382")]

//         public void BugTask_866382()
//         {
//             Basicsbutton("Bug866382");
//             //App.ScrollDown(strategy: Xamarin.UITest.ScrollStrategy.Gesture);
//             Thread.Sleep(2000);
//             TakeAndCompareScreenshot("BugTask_866382");
//         }
//         [Test]
//         [Category("SfButton Clicked Event and Opacity issue in .NET MAUI TaskID 855758")]

//         public void BugTask_855758_1()
//         {
//             Basicsbutton("Bug855758");
//             App.Tap("btn");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugTask_855758_1");
//         }
//         [Test]
//         [Category("SfButton Clicked Event and Opacity issue in .NET MAUI TaskID 855758")]

//         public void BugTask_855758_2()
//         {
//             Basicsbutton("Bug855758_1");
//             App.Tap("img");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugTask_855758_2");
//         }
//         [Test]
//         [Category("SfButton Clicked Event and Opacity issue in .NET MAUI TaskID 855758")]

//         public void BugTask_855758_3()
//         {
//             Basicsbutton("Bug855758");
//           //  App.WaitForElement("btn");
//             App.Tap("btn");
//             App.Tap("btn1");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugTask_855758_3");
//         }
//         [Test]
//         [Category("XAMARIN 35358_Run time LRT to RTL Flow direction switch issues")]

//         public void BugButtonRtl1_1()
//         {
//             Basicsbutton("ButtonRtl1");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugButtonRtl1_1");
//         }
//         [Test]
//         [Category("XAMARIN 35358_Run time LRT to RTL Flow direction switch issues")]

//         public void BugButtonRtl1_2()
//         {
//             Basicsbutton("ButtonRtl1");
//            // App.WaitForElement("Changeflow"); 
//             App.Tap("Changeflow");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugButtonRtl1_2");
//         }
//         [Test]
//         [Category("XAMARIN 35358_Run time LRT to RTL Flow direction switch issues")]

//         public void BugButtonRtl2()
//         {
//             Basicsbutton("ButtonRtl2");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("BugButtonRtl2");
//         }
//         [Test]

//         public void SfButton2_1()
//         {
//             Basicsbutton("SfButton2");
//             App.Tap("cl");
//             Thread.Sleep(2000); TakeAndCompareScreenshot("SfButton2_1");
//         }
//         [Test]
//         [Category("Buttons")]
//         [Category("Views")]
//         [Description("XAMARIN_24037")]
//         public void XAMARIN_24037_1()
//         {
//             Basicsbutton("XAMARIN_24037");
//             Thread.Sleep(2000);
//             TakeAndCompareScreenshot("XAMARIN_24037_1");
//         }
//         [Test]
//         [Category("Buttons")]
//         [Category("Views")]
//         [Description("XAMARIN_24037")]
//         public void XAMARIN_24037_2()
//         {
//             Basicsbutton("XAMARIN_24037");
//             App.TouchAndHold("btn");
//             Thread.Sleep(2000);
//             TakeAndCompareScreenshot("XAMARIN_24037_2");
//         }
//         [Test]
//         [Category("Buttons")]
//         [Category("Views")]
//         [Description("XAMARIN_24037")]
//         public void XAMARIN_24037_3()
//         {
//             Basicsbutton("XAMARIN_24037");
//             App.Tap("btn");
//             Thread.Sleep(2000);
//             TakeAndCompareScreenshot("XAMARIN_24037_3");
//         }
//         [Test]
//         [Category("Buttons")]
//         [Category("Button")]
//         [Description("IR")]
//         public void XAMARIN_26477()
//         {
//             Basicsbutton("XAMARIN_26477");

//             App.TouchAndHold("up2");
// #if ANDROID || WINDOWS || MACOS
//            // App.ScrollTo("up");
// #else
//             //App.ScrollDownTo("up");
// #endif
//             Thread.Sleep(2000);
//             TakeAndCompareScreenshot("XAMARIN_26477");
//         }
        #endregion
    }
}

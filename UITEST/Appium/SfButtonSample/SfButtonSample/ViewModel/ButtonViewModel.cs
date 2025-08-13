using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.Toolkit.Chips;

namespace SfButtonSample.ViewModel;

public class ButtonViewModel : INotifyPropertyChanged
{
    SfButton button = new();
    private string _text = "Syncfusion";

    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            OnPropertyChanged();
        }
    }

    private TextTransform _textTransforms;
    public TextTransform TextTransforms
    {
        get { return _textTransforms; }
        set { _textTransforms = value; OnPropertyChanged(nameof(TextTransforms)); }
    }

    public string[] TextTransformList { get; set; } = new string[] {  "None", "Default", "Lowercase", "Uppercase"};

    private int _textTransformListSelectedIndex = 1;
    public int TextTransformListSelectedIndex
    {
        get { return _textTransformListSelectedIndex; }
        set
        {
            if (_textTransformListSelectedIndex != value)
            {
                _textTransformListSelectedIndex = value;
                TextTransforms= TextTransform.Parse<TextTransform>(TextTransformList[value]);
                OnPropertyChanged(nameof(TextTransformListSelectedIndex));
            }
        }
    }

    private Color _textColor;

    public Color TextColor
    {
        get { return _textColor; }
        set { _textColor = value; OnPropertyChanged(); }
    }

    public string[] TextColorList { get; set; } = new string[] { "Black", "Green", "Yellow", "Orange", "Blue" };

    private int textColorSelectedIndex = 1;

    public int TextColorSelectedIndex
    {
        get { return textColorSelectedIndex; }
        set
        {
            textColorSelectedIndex = value;
            TextColor = Color.Parse(TextColorList[value]);
        }
    }

    private bool showICon;

    public bool ShowIcon
    {
        get { return showICon; }
        set { showICon = value; OnPropertyChanged(); }
    }

    private ImageSource imageSource;

    public ImageSource ImageSource
    {
        get { return imageSource; }
        set { imageSource = value; OnPropertyChanged(); }
    }

    public string[] ImageSourceList { get; set; } = new string[] { "avatar1.png", "avatar10.png" };

    private int imageSourceSelectedIndex = 0;

    public int ImageSourceSelectedIndex
    {
        get { return imageSourceSelectedIndex; }
        set
        {
            imageSourceSelectedIndex = value;
            ImageSource = ImageSourceList[value];
        }
    }
    private bool isChecked;

    public bool IsChecked
    {
        get { return isChecked; }
        set { isChecked = value; OnPropertyChanged(); }
    }

    private bool isEnabled = true;

    public bool IsEnabled
    {
        get { return isEnabled; }
        set { isEnabled = value; OnPropertyChanged(); }
    }

    private bool isVisible = true;

    public bool IsVisible
    {
        get { return isVisible; }
        set { isVisible = value; OnPropertyChanged(); }
    }

    private FlowDirection flowDirection;

    public FlowDirection FlowDirection
    {
        get { return flowDirection; }
        set { flowDirection = value; OnPropertyChanged(); }
    }

    public string[] FlowDirectionList { get; set; } = new string[] { "LeftToRight", "RightToLeft" };

    private int flowDirectionSelectedIndex;

    public int FlowDirectionSelectedIndex
    {
        get { return flowDirectionSelectedIndex; }
        set
        {
            flowDirectionSelectedIndex = value;
            FlowDirection = FlowDirection.Parse<FlowDirection>(FlowDirectionList[value]);
        }
    }

    private int imageWidth = 18;

    public int ImageWidth
    {
        get { return imageWidth; }
        set { imageWidth = value; OnPropertyChanged(); }
    }

    private int buttonheight = 50;

    public int ButtonHeight
    {
        get { return buttonheight; }
        set { buttonheight = value; OnPropertyChanged(); }
    }

    private int buttonwidth = 300;

    public int ButtonWidth
    {
        get { return buttonwidth; }
        set { buttonwidth = value; OnPropertyChanged(); }
    }
    private int borderthickness = 10;

    public int BorderThickness
    {
        get { return borderthickness; }
        set { borderthickness = value; OnPropertyChanged(); }
    }

    private int borderwidth = 300;

    public int BorderWidth
    {
        get { return borderwidth; }
        set { borderwidth = value; OnPropertyChanged(); }
    }



    private CornerRadius cornerRadius = 8;

    public CornerRadius CornerRadius
    {
        get { return cornerRadius; }
        set { cornerRadius = value; OnPropertyChanged(); }
    }

    private double cornerRadiusSlider = 8;
    public double CornerRadiusSlider
    {
        get { return cornerRadiusSlider; }
        set
        {
            cornerRadiusSlider = value; CornerRadius = new CornerRadius(cornerRadiusSlider, CornerRadiusSlider, CornerRadiusSlider, CornerRadiusSlider);
            OnPropertyChanged();
        }
    }

    private Color borderColor;

    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; OnPropertyChanged(); }
    }

    public string[] BorderColorList { get; set; } = new string[] { "Black", "Green", "Yellow", "Orange", "Blue" };

    private int borderColorSelectedIndex = 2;

    public int BorderSelectedIndex
    {
        get { return borderColorSelectedIndex; }
        set
        {
            borderColorSelectedIndex = value;
            BorderColor = Color.Parse(BorderColorList[value]);
        }
    }

    private Color background;

    public Color Background
    {
        get { return background; }
        set { background = value; OnPropertyChanged(); }
    }

    public string[] BackgroundList { get; set; } = new string[] { "LightGray", "Green", "Yellow", "Orange", "Blue" };

    private int backgroundSelectedIndex = 0;

    public int BackgroundSelectedIndex
    {
        get { return backgroundSelectedIndex; }
        set
        {
            backgroundSelectedIndex = value;
            Background = Color.Parse(BackgroundList[value]);
        }
    }

    private float strokeThickness;

    public float StrokeThickness
    {
        get { return strokeThickness; }
        set { strokeThickness = value; OnPropertyChanged(); }
    }

    private float thicknessSlider = 8;
    public float ThicknessSlider
    {
        get { return thicknessSlider; }
        set
        {
            thicknessSlider = value;
            StrokeThickness = thicknessSlider;
            OnPropertyChanged();
        }
    }
#if ANDROID

        private Thickness padding =2;
#else
    private Thickness padding;
#endif

    public Thickness Padding
    {
        get { return padding; }
        set { padding = value; OnPropertyChanged(); }
    }

#if ANDROID
        private double paddingSlider =8 ;
#else
    private double paddingSlider = 8;

#endif
    public double PaddingSlider
    {
        get { return paddingSlider; }
        set
        {
            paddingSlider = value; Padding = new Thickness(paddingSlider, paddingSlider, paddingSlider, paddingSlider);
            OnPropertyChanged();
        }
    }

    private Alignment imageAlignment;

    public Alignment ImageAlignment
    {
        get { return imageAlignment; }
        set { imageAlignment = value; OnPropertyChanged(); }
    }

    public string[] ImageAlignmentList { get; set; } = new string[] { "Start", "End", "Top", "Bottom", "Left", "Right" };

    private int imageAlignmentSelectedIndex = 0;

    public int ImageAlignmentSelectedIndex
    {
        get { return imageAlignmentSelectedIndex; }
        set
        {
            imageAlignmentSelectedIndex = value;
            ImageAlignment = Alignment.Parse<Alignment>(ImageAlignmentList[value]);
        }
    }

    private double fontSize = 14d;

    public double FontSize
    {
        get { return fontSize; }
        set { fontSize = value; OnPropertyChanged(); }
    }

    private FontAttributes fontAttributes = FontAttributes.None;

    public FontAttributes FontAttributes
    {
        get { return fontAttributes; }
        set { fontAttributes = value; OnPropertyChanged(); }
    }

    public string[] FontAttributesList { get; set; } = new string[] { "None", "Bold", "Italic" };

    private int fontAttributesSelectedIndex = 1;

    public int FontAttributesSelectedIndex
    {
        get { return fontAttributesSelectedIndex; }
        set
        {
            fontAttributesSelectedIndex = value;
            FontAttributes = FontAttributes.Parse<FontAttributes>(FontAttributesList[value]);
        }
    }

    private string fontFamily;

    public string FontFamily
    {
        get { return fontFamily; }

        set { fontFamily = value; OnPropertyChanged(); }
    }

    public string[] FontFamilyList { get; set; } = new string[] { "OpenSansRegular", "OpenSansSemibold", "SamanthaDemo", "Roboto-Regular", "Roboto-Medium" };

    private int fontFamilySelectedIndex;

    public int FontFamilySelectedIndex
    {
        get { return fontFamilySelectedIndex; }
        set
        {
            fontFamilySelectedIndex = value;
            FontFamily = FontFamilyList[value];
        }
    }

    private string backgroundImage;

    public string BackgroundImage
    {
        get { return backgroundImage; }
        set { backgroundImage = value; OnPropertyChanged(); }
    }

    private bool isCheckedBackgroundImage;

    public bool IsCheckedBackgroundImage
    {
        get { return isCheckedBackgroundImage; }
        set
        {
            isCheckedBackgroundImage = value;
            if (value)
            {
                BackgroundImage = "nature.jpg";
            }
            else
            {
                BackgroundImage = String.Empty;
            }

            OnPropertyChanged();
        }
    }

    private bool isCheckable;

    public bool IsCheckable
    {
        get { return isCheckable; }
        set { isCheckable = value; OnPropertyChanged(); }
    }

    

    private bool enableRippleEffect = true;

    public bool EnableRippleEffect
    {
        get { return enableRippleEffect; }
        set { enableRippleEffect = value; OnPropertyChanged(); }
    }

    private TextAlignment horizontalTextAlignment;

    public TextAlignment HorizontalTextAlignment
    {
        get { return horizontalTextAlignment; }
        set { horizontalTextAlignment = value; OnPropertyChanged(); }
    }

    public string[] TextAlignmentList { get; set; } = new string[] { "Center", "Start", "End" };

    private int textAlignmentSelectedIndex = 0;

    public int HorizontalTextAlignmentSelectedIndex
    {
        get { return textAlignmentSelectedIndex; }
        set
        {
            textAlignmentSelectedIndex = value;
            HorizontalTextAlignment = TextAlignment.Parse<TextAlignment>(TextAlignmentList[value]);
        }
    }

    private TextAlignment verticalTextAlignment;

    public TextAlignment VerticalTextAlignment
    {
        get { return verticalTextAlignment; }
        set { verticalTextAlignment = value; OnPropertyChanged(); }
    }

    private int verticaltextAlignmentSelectedIndex = 0;

    public int VerticalTextAlignmentSelectedIndex
    {
        get { return verticaltextAlignmentSelectedIndex; }
        set
        {
            verticaltextAlignmentSelectedIndex = value;
            VerticalTextAlignment = TextAlignment.Parse<TextAlignment>(TextAlignmentList[value]);
        }
    }

    private int commandCount;

    public Command<int> Command { get; set; }

    private string commandText;

    public string CommandText
    {
        get { return commandText; }
        set { commandText = value; OnPropertyChanged(); }
    }
    public ButtonViewModel()
    {
        Command = new Command<int>(execute: (int a) =>
        {
            if (a > 0)
                commandCount += a;
            else
                commandCount++;
            if (commandCount == 1)
            {
                CommandText = $"Command Triggered {commandCount} time";
            }

            else
                CommandText = $"Command Triggered {commandCount} times";

        });
    }

    private int commandParameter;

    public int CommandParameter
    {
        get { return commandParameter; }
        set { commandParameter = value; OnPropertyChanged(); }
    }

    private float[] dashArray;

    public float[] DashArray
    {
        get { return dashArray; }
        set { dashArray = value; OnPropertyChanged(); }
    }


    private void OnPropertyChanged([CallerMemberName] String propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
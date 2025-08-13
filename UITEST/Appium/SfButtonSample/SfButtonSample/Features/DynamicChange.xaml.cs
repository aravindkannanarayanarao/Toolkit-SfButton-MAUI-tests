using Syncfusion.Maui.Core;
using Syncfusion.Maui.Buttons;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SfButtonSample.Features;

public partial class DynamicChange : ContentPage
{
	public DynamicChange()
	{
		InitializeComponent();

       
    }
    private void opacitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        if (value != null && button is SfButton)
        {
            button.Padding = value;
        }

    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		if(picker1.SelectedIndex==0)
		{
			button.Background = Colors.Green;
		}
        if (picker1.SelectedIndex == 1)
        {
            button.Background = Colors.Yellow;
        }
        if (picker1.SelectedIndex == 2)
        {
            button.Background = Colors.Orange;
        }
    }

    private void picker2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker2.SelectedIndex == 0)
        {
            button.CornerRadius = 8;
        }
        if (picker2.SelectedIndex == 1)
        {
            button.CornerRadius = 16;
        }
        if (picker2.SelectedIndex == 2)
        {
            button.CornerRadius = 24;
        }
    }

    private void picker3_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        if (picker3.SelectedIndex == 0)
        {
            button.Stroke = Colors.Red;
        }
        if (picker3.SelectedIndex == 1)
        {
            button.Stroke = Colors.Blue;
        }
        if (picker3.SelectedIndex == 2)
        {
            button.Stroke = Colors.Pink;
        }
    }

    private void picker4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker4.SelectedIndex == 0)
        {
            button.StrokeThickness = 4;
        }
        if (picker4.SelectedIndex == 1)
        {
            button.StrokeThickness = 6;
        }
        if (picker4.SelectedIndex == 2)
        {
            button.StrokeThickness = 8;
        }
    }

    private void picker5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker5.SelectedIndex == 0)
        {
            button.Text = "BusyIndicator";
        }
        if (picker5.SelectedIndex == 1)
        {
            button.Text = "Chip";
        }
        if (picker5.SelectedIndex == 2)
        {
            button.Text = "Entry";
        }
    }

    private void picker6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker6.SelectedIndex == 0)
        {
            button.TextColor = Colors.White;
        }
        if (picker6.SelectedIndex == 1)
        {
            button.TextColor = Colors.Black;
        }
        if (picker6.SelectedIndex == 2)
        {
            button.TextColor = Colors.Yellow;
        }
    }

    private void picker7_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker7.SelectedIndex == 0)
        {
            button.FontSize = 16;
        }
        if (picker7.SelectedIndex == 1)
        {
            button.FontSize = 20;
        }
        if (picker7.SelectedIndex == 2)
        {
            button.FontSize = 25;
        }
    }

    private void picker8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker8.SelectedIndex == 0)
        {
            button.HorizontalTextAlignment = TextAlignment.Center;
        }
        if (picker8.SelectedIndex == 1)
        {
            button.HorizontalTextAlignment = TextAlignment.End;
        }
        if (picker8.SelectedIndex == 2)
        {
            button.HorizontalTextAlignment = TextAlignment.Start;
        }
    }

    private void picker9_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker9.SelectedIndex == 0)
        {
            button.VerticalTextAlignment = TextAlignment.Center;
        }
        if (picker9.SelectedIndex == 1)
        {
            button.VerticalTextAlignment = TextAlignment.End;
        }
        if (picker9.SelectedIndex == 2)
        {
            button.VerticalTextAlignment = TextAlignment.Start;
        }
    }

    private void picker10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker10.SelectedIndex == 0)
        {
            button.ShowIcon = true;
            button.ImageSource="avatar1.png";
            
        }
        if (picker10.SelectedIndex == 1)
        {
            button.ShowIcon = true;
            button.ImageSource = "avatar10.png";  
        }
    }

    private void CheckBox_CheckedChanged(object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        if (check.IsChecked == true)
        {
            button.ShowIcon = true;
        }
        else
        {
            button.ShowIcon = false;
        }
    }

    private void picker11_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker11.SelectedIndex == 0)
        {
            button.ImageSize = 20;
        }
        if (picker11.SelectedIndex == 1)
        {
            button.ImageSize = 25;
        }
    }

    private void picker12_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker12.SelectedIndex == 0)
        {
            button.ImageAlignment = (Syncfusion.Maui.Toolkit.Chips.Alignment)Alignment.End;
        }
        if (picker12.SelectedIndex == 1)
        {
            button.ImageAlignment = (Syncfusion.Maui.Toolkit.Chips.Alignment)Alignment.Start;
        }
        if (picker12.SelectedIndex == 2)
        {
            button.ImageAlignment = (Syncfusion.Maui.Toolkit.Chips.Alignment)Alignment.Top;
        }
        if (picker12.SelectedIndex == 3)
        {
            button.ImageAlignment = (Syncfusion.Maui.Toolkit.Chips.Alignment)Alignment.Bottom;
        }
        if (picker12.SelectedIndex == 4)
        {
            button.ImageAlignment = (Syncfusion.Maui.Toolkit.Chips.Alignment)Alignment.Left;
        }
    }

    private void picker13_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker13.SelectedIndex == 0)
        {
            button.BackgroundImageSource = "nature.jpg";
        }
    }

    private void check1_CheckedChanged(object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        if (check1.IsChecked == true)
        {
            button.DashArray = new float[] { 3, 4 };
        }
        else
        {
            button.DashArray = null;
        }

    }

    private void picker14_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(picker14.SelectedIndex == 0)
        {
            button.FontAttributes = FontAttributes.Bold;
            
        }
        if(picker14.SelectedIndex == 1)
        {
            button.FontAttributes = FontAttributes.Italic;
        }
        
    }

    private void check1_CheckedChanged_1(object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        if (check2.IsChecked == true)
        {
            //// Define the DataTemplate in C#
            var happyTemplate = new DataTemplate(() =>
            {
                // Create the HorizontalStackLayout
                var stackLayout = new Microsoft.Maui.Controls.StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.Center
                };



                // Create the SfBusyIndicator
                var busyIndicator = new SfBusyIndicator()
                {
                    AnimationType = AnimationType.SingleCircle,
                    IsRunning = true,
                    TextColor = Colors.White,
                    WidthRequest = 80,
                    HeightRequest = 60,
                    IndicatorColor = Colors.Yellow,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End
                };



                // Create the Label
                var label = new Label
                {
                    Text = "Loading...",
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Colors.White
                };



                // Add the busyIndicator and label to the stackLayout
                stackLayout.Children.Add(busyIndicator);
                stackLayout.Children.Add(label);



                // Return the constructed stackLayout as the root of the DataTemplate
                return stackLayout;

            });
            button.Content = happyTemplate;
            //button.Content = (DataTemplate)Resources["happyTemplate"];

        }
        else
        {
            button.Content = null;
        }
        
    }

    private void picker15_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (picker15.SelectedIndex == 0)
        {
            button.FontFamily = "OpenSans-Regular";

        }
        if (picker15.SelectedIndex == 1)
        {

            button.FontFamily = "OpenSans-Semibold";
        }
    }

    
}

using System.ComponentModel;

namespace SfButtonSample.Bugs;

public partial class Bug856303 : ContentPage
{
    int count = 0;
    public Bug856303()
    {
        InitializeComponent();
    }
    private void SfButton_Clicked(object sender, EventArgs e)
    {
        //button.IsVisible = !button.IsVisible;
    }
}


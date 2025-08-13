using Syncfusion.Maui.Buttons;

namespace SfButtonSample.Bugs;

public partial class Bug855758 : ContentPage
{
        int count = 0;

    public Bug855758()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        sfButton.Opacity = 1;
    }

    private async void SfButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("SfButton Clicked", "Clicked Event Invoked", "OK");
    }
}

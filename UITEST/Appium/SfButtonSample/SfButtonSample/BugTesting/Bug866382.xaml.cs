namespace SfButtonSample.Bugs;

public partial class Bug866382 : ContentPage
{
	public Bug866382()
	{
		InitializeComponent();
	}
    async void SfButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await DisplayAlert("Button Clicked", "SfButton clicked event was triggred", "Ok");
    }
}
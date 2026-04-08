namespace AccordionSample;

public partial class MAUI_30325 : ContentPage
{
    public MAUI_30325()
    {
        InitializeComponent();
        viewModel.SetSections();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
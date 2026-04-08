namespace AccordionSample;

public partial class MAUI_28883 : ContentPage
{
	public MAUI_28883()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		this.navigationDrawer.DrawerSettings.IsOpen = true;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        this.navigationDrawer.DrawerSettings.DrawerWidth = (float)Application.Current!.MainPage!.Width;
    }
}
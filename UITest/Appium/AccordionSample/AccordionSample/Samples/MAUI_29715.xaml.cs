namespace AccordionSample;

public partial class MAUI_29715 : ContentPage
{
	public MAUI_29715()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.navigationDrawer.DrawerSettings.IsOpen = true;
    }
}
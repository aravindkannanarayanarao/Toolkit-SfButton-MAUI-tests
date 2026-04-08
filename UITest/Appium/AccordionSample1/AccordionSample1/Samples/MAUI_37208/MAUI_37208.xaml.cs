namespace AccordionSample1;

public partial class MAUI_37208 : ContentPage
{
	public MAUI_37208()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        hiddenStack.IsVisible = !hiddenStack.IsVisible;
    }
}
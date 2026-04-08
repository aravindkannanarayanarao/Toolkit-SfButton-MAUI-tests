namespace AccordionSample1.MAUI_44611;

public partial class Expander : ContentPage
{
	public Expander()
	{
		InitializeComponent();
	}

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Page1());
    }
}
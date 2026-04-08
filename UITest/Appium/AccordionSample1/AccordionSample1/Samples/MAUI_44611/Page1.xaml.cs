namespace AccordionSample1.MAUI_44611;

public partial class Page1 : ContentPage
{
    Page page = null;
    public Page1()
	{
		InitializeComponent();
	}

    [Obsolete]
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (page is null)
        {
            page = new Expander();
        }

        Device.BeginInvokeOnMainThread(() =>
        {
            Navigation.PushAsync(page);
        });
    }
}
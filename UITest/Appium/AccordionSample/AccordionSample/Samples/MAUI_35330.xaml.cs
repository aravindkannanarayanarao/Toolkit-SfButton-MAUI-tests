namespace AccordionSample;

public partial class MAUI_35330 : ContentPage
{
	public MAUI_35330()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewModel)!.IsAccordionVisible = !(this.BindingContext as ViewModel)!.IsAccordionVisible;
    }
}
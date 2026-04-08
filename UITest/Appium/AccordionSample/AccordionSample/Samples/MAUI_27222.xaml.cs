namespace AccordionSample;

public partial class MAUI_27222 : ContentPage
{
	public MAUI_27222()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        expander1.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
    }
}
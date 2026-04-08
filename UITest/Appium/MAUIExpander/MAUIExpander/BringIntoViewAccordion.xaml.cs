namespace MAUIExpander;

public partial class BringIntoViewAccordion : ContentPage
{
	public BringIntoViewAccordion()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Accordion1.BringIntoView(lastitem);
    }
}
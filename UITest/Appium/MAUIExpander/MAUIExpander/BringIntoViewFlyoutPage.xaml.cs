namespace MAUIExpander;

public partial class BringIntoViewFlyoutPage : FlyoutPage
{
	public BringIntoViewFlyoutPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Accordion1.BringIntoView(lastitem);
	}
}
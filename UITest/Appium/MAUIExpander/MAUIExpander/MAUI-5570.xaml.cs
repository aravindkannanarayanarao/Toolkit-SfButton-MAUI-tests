namespace MAUIExpander;

public partial class MAUI_5570 : ContentPage
{
	public MAUI_5570()
	{
		InitializeComponent();
	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		accordion.IsExpanded = true;
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		accordion.IsExpanded = false;
	}

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		accordion1.IsExpanded = true;
	}

	private void Button_Clicked_3(object sender, EventArgs e)
	{
		accordion1.IsExpanded = false;
	}

	private void Button_Clicked_4(object sender, EventArgs e)
	{
		Accordion1.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Single;
	}

	private void Button_Clicked_5(object sender, EventArgs e)
	{
		Accordion1.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.SingleOrNone;
	}

	private void Button_Clicked_6(object sender, EventArgs e)
	{
		Accordion1.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Multiple;
	}

	private void Button_Clicked_7(object sender, EventArgs e)
	{
		Accordion1.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.MultipleOrNone;
	}
}
namespace MAUIExpander;

public partial class AccordionHeader : ContentPage
{
	public AccordionHeader()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70 ,Background= Colors.Purple};
		Label label = new Label() { Text = "Header Changed" ,VerticalTextAlignment = TextAlignment.Center,Margin=10 };
		grid.Add(label);
		Accordion1.Header = grid;
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70 };
		Label label = new Label() { Text = "Header Changed2", VerticalTextAlignment = TextAlignment.Center, Margin = 10 };
		grid.Add(label);
		Accordion2.Header = grid;
	}

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		Accordion2.HeaderBackground = Colors.SteelBlue;
	}

	private void Button_Clicked_3(object sender, EventArgs e)
	{
		Accordion2.BackgroundColor = Colors.OrangeRed;
	}

	private void Button_Clicked_4(object sender, EventArgs e)
	{
		Accordion2.Header = null;
	}

	private void Button_Clicked_5(object sender, EventArgs e)
	{
		if(Accordion2.IsExpanded)
		{
			Accordion2.IsExpanded = false;
		}
		else
		{
			Accordion2.IsExpanded = true;
		}
	}

	private void Button_Clicked_6(object sender, EventArgs e)
	{
		Accordion2.Content = null;
	}

	private void Button_Clicked_7(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70 };
		Label label = new Label() { Text = "Veggie burger, garden burger, or tofu burger uses a meat analogue, a meat substitute such as tofu, textured vegetable protein, seitan (wheat gluten), Quorn, beans, grains or an assortment of vegetables, which are ground up and formed into patties", VerticalTextAlignment = TextAlignment.Center, Margin = 10 };
		grid.Add(label);
		Accordion2.Content = grid;
	}
}
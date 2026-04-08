namespace MAUIExpander;

public partial class ES_826470 : ContentPage
{
	public ES_826470()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if(accordion.FlowDirection == FlowDirection.RightToLeft)
		{
			accordion.FlowDirection = FlowDirection.LeftToRight;
		}
		else
		{
			accordion.FlowDirection = FlowDirection.RightToLeft;
		}
    }

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		if (accordion.HeaderIconPosition == Syncfusion.Maui.Expander.ExpanderIconPosition.End)
		{
			accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
		}
		else if (accordion.HeaderIconPosition == Syncfusion.Maui.Expander.ExpanderIconPosition.Start)
		{
			accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
		}
		else
		{
			accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
		}
	}

	private void Button_Clicked_5(object sender, EventArgs e)
	{
		accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.None;
	}

	private void Button_Clicked_9(object sender, EventArgs e)
	{
		if (contentPage.FlowDirection == FlowDirection.RightToLeft)
		{
			contentPage.FlowDirection = FlowDirection.LeftToRight;
		}
		else
		{
			contentPage.FlowDirection = FlowDirection.RightToLeft;
		}
	}

	private void Button_Clicked_8(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70, VerticalOptions = LayoutOptions.Center, BackgroundColor = Colors.DeepPink };
		Label label = new Label() { Text = "Header Changed For expander" };
		grid.Add(label);
		accordion1.Header = grid;
	}
}
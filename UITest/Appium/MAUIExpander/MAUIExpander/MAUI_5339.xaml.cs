using Syncfusion.Maui.Expander;

namespace MAUIExpander;

public partial class MAUI_5339 : ContentPage
{
	public MAUI_5339()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70 };
		Label label = new Label() { Text = "Header Changed" };
		grid.Add(label);
		expander.Header = grid;
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		expander.HeaderBackground = Colors.SkyBlue;
	}

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		expander1.HeaderIconPosition = ExpanderIconPosition.End;
	}

	private void Button_Clicked_3(object sender, EventArgs e)
	{
		expander.HeaderIconPosition = ExpanderIconPosition.Start;
	}

	private void Button_Clicked_4(object sender, EventArgs e)
	{
		expander1.HeaderBackground = Colors.LightPink;
	}

	private void Button_Clicked_5(object sender, EventArgs e)
	{
		expander.HeaderIconPosition = ExpanderIconPosition.None;
	}

	private void Button_Clicked_6(object sender, EventArgs e)
	{
		expander.Header = null;
	}

	private void Button_Clicked_7(object sender, EventArgs e)
	{
		expander.HeaderIconColor = Colors.Black;
	}

	private void Button_Clicked_8(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70 };
		Label label = new Label() { Text = "Header Changed For expander 2" };
		grid.Add(label);
		expander1.Header = grid;
	}

	private void Button_Clicked_9(object sender, EventArgs e)
	{
		if(expander.IsExpanded)
		{
			expander.IsExpanded = false;
		}
		else
		{
			expander.IsExpanded = true;
		}
	}
}
using Syncfusion.Maui.Expander;

namespace MAUIExpander;

public partial class MAUI_5343 : ContentPage
{
	public MAUI_5343()
	{
		InitializeComponent();
	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		expander.FlowDirection = FlowDirection.RightToLeft;
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
        expander.HeaderBackground = Colors.SkyBlue;
	}

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		if(expander.HeaderIconPosition == ExpanderIconPosition.End)
		{
			expander.HeaderIconPosition = ExpanderIconPosition.Start;
		}
		else if(expander.HeaderIconPosition == ExpanderIconPosition.Start)
		{
			expander.HeaderIconPosition = ExpanderIconPosition.End;
		}
		else
		{
			expander.HeaderIconPosition = ExpanderIconPosition.End;
		}
	}


	private void Button_Clicked_5(object sender, EventArgs e)
	{
		expander.HeaderIconPosition = ExpanderIconPosition.None;
	}


	private void Button_Clicked_8(object sender, EventArgs e)
	{
		Grid grid = new Grid() { HeightRequest = 70 , VerticalOptions= LayoutOptions.Center , BackgroundColor = Colors.DeepPink};
		Label label = new Label() { Text = "Header Changed For expander" };
		grid.Add(label);
		expander.Header = grid;
	}

	private void Button_Clicked_9(object sender, EventArgs e)
	{
		if (this.FlowDirection == FlowDirection.RightToLeft)
		{
			this.FlowDirection = FlowDirection.LeftToRight;
		}
		else
		{
			this.FlowDirection = FlowDirection.RightToLeft;
		}
	}

	private void Button_Clicked_3(object sender, EventArgs e)
	{
		expander.FlowDirection = FlowDirection.LeftToRight;
	}

	private void Button_Clicked_4(object sender, EventArgs e)
	{
		System.Diagnostics.Debug.WriteLine("HeaderIconPosition : " + expander.HeaderIconPosition);
	}
}
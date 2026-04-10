namespace MAUIExpander;

public partial class ES_823715 : ContentPage
{
	public ES_823715()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
    }

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
	}

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		accordion.ItemSpacing = 10;
	}

	private void Button_Clicked_3(object sender, EventArgs e)
	{
		accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.None;
	}

	private void Button_Clicked_4(object sender, EventArgs e)
	{
		accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.Linear;
	}

	private void Button_Clicked_5(object sender, EventArgs e)
	{
		accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.SinIn;
	}

	private void Button_Clicked_6(object sender, EventArgs e)
	{
		accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.SinOut;
	}

	private void Button_Clicked_7(object sender, EventArgs e)
	{
		accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.SinInOut;
	}

	private void Button_Clicked_8(object sender, EventArgs e)
	{
		accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.None;
	}

	private void Button_Clicked_9(object sender, EventArgs e)
	{
		accordion.AnimationDuration = 200;
	}

	private void Button_Clicked_10(object sender, EventArgs e)
	{
		accordion.AnimationDuration = 6000;
	}
}
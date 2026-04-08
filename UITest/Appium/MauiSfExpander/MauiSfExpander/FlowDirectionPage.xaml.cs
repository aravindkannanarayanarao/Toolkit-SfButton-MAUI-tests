namespace MauiSfExpander;

public partial class FlowDirectionPage : ContentPage
{
	public FlowDirectionPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		expander.FlowDirection = FlowDirection.LeftToRight;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (expander.IsExpanded == true)
        {
            expander.IsExpanded = false;
        }
        else
        {
            expander.IsExpanded = true;
        }
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
    }
}

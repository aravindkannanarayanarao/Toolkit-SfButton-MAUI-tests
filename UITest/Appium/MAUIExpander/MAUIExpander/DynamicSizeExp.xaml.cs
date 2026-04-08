namespace MAUIExpander;

public partial class DynamicSizeExp : ContentPage
{
	public DynamicSizeExp()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!tofu.IsVisible)
        {
            tofu.IsVisible = true;
            //tofurate.IsVisible = true;
        }
        else if (!total.IsVisible)
        {
            total.IsVisible = true;
            //amount.IsVisible = true;
        }
        else
        {
            total.IsVisible = false;
            //amount.IsVisible = false;
            tofu.IsVisible = false;
            //tofurate.IsVisible = false;
        }
    }

    private void Button1_Clicked(object sender, EventArgs e)
    {
        if (label1.FontSize == 16)
        {
            label1.FontSize = 28;
        }
        else if (label1.FontSize == 28)
        {
            label1.FontSize = 35;
        }
        else
        {
            label1.FontSize = 16;
        }
    }
}
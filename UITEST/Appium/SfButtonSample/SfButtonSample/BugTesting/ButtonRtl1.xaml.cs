namespace SfButtonSample.Bugs;

public partial class ButtonRtl1 : ContentPage
{
	public ButtonRtl1()
	{
		InitializeComponent();
    }
    private void SfButton_Clicked(object sender, EventArgs e)
    {
        stack.FlowDirection = FlowDirection.RightToLeft;
    }
}
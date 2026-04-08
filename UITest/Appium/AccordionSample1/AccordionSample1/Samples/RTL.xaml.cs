namespace AccordionSample1;

public partial class RTL : ContentPage
{
	public RTL()
	{
		InitializeComponent();
	}

    private void RTL_Clicked(object sender, EventArgs e)
    {
        if(sender is Button button)
        {
            if (button.Text == "RTL")
            {
                this.FlowDirection = FlowDirection.RightToLeft;
                button.Text = "LTR";
            }
            else
            {
                this.FlowDirection = FlowDirection.LeftToRight;
                button.Text = "RTL";
            }
        } 
    }
}
namespace AccordionSample;

public partial class MAUI_28517 : ContentPage
{
	public MAUI_28517()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        ContentView view = new ContentView();
        Button closebutton = new Button() { Text = "Button" };
        view.Content = closebutton;
        this.contentView.Content = view;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        this.contentView.Content = accordion;
    }
}
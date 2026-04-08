namespace MemoryLeakTestSample;

public partial class AccordionPage : ContentPage
{
	public AccordionPage()
	{
		InitializeComponent();
	}

    

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}
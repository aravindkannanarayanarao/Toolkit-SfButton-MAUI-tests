namespace MemoryLeakTestSample;

public partial class ExpanderPage : ContentPage
{
	public ExpanderPage()
	{
		InitializeComponent();
	}

    private void BackButton_Clicked2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}
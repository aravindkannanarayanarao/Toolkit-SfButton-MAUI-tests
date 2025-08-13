namespace SfButtonSample.Bugs;

public partial class SfButton1 : ContentPage
{
	public SfButton1()
	{
		InitializeComponent();
        
    }

    private void ButtonId_Clicked(object sender, EventArgs e)
    {
        labelID.Text = buttonid.AutomationId.ToString();
    }
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        buttonimage.ImageSource = "dotnet_bot.png";
        buttonimage.Padding = new Thickness(20, 0, 0, 0);
        buttonimage.ScaleTo(2);
    }

    private void listView_SelectionChanged(object sender, Syncfusion.Maui.ListView.ItemSelectionChangedEventArgs e)
    {

    }

    private void buttonList_Clicked(object sender, EventArgs e)
    {
        listView.BackgroundColor = Colors.Yellow;
    }

    private void listView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {

    }
}
using Syncfusion.Maui.Popup;

namespace MauiSfExpander;

public partial class PopupOnLoadingPage : ContentPage
{
    SfPopup popup;
    public PopupOnLoadingPage()
	{
		InitializeComponent();
       
        Grid contentView = new Grid();
        contentView.Padding = new Thickness(10, 10, 10, 10);
        Button button = new Button() { Text = "Click To Show Popup" };
        button.HeightRequest = 50;
        button.Clicked += show_Clicked;

        contentView.Children.Add(button);
        expander.Content = contentView;
    }
    private void show_Clicked(object? sender, EventArgs e)
    {
        popup = new SfPopup();
        popup.Show();
    }
}
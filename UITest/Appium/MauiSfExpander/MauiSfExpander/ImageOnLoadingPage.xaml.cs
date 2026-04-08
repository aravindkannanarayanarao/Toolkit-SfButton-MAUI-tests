namespace MauiSfExpander;

public partial class ImageOnLoadingPage : ContentPage
{
	public ImageOnLoadingPage()
	{
		InitializeComponent();

        Grid contentView = new Grid();
        contentView.Padding = new Thickness(10, 10, 10, 10);
        Image image = new Image();
        image.Source = "dotnet_bot.png";
        image.HeightRequest = 100;
        image.HorizontalOptions = LayoutOptions.Center;
        contentView.Children.Add(image);
        expander.Content = contentView;
    }
}
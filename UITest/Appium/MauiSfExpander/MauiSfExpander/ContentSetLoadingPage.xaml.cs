using Syncfusion.Maui.Expander;
namespace MauiSfExpander;

public partial class ContentSetLoadingPage : ContentPage
{
	public ContentSetLoadingPage()
	{
		InitializeComponent();
        Grid grid = new Grid();

        Label label = new Label() { Text = "Content Set On Loading " };
        grid.Children.Add(label);
        expander.Content = grid;
        expander.IsExpanded = true;
    }
}
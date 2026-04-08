namespace MauiSfExpander;

public partial class AddContentExpanded : ContentPage
{
	public AddContentExpanded()
	{
		InitializeComponent();
        Grid grid = new Grid();

        Label label = new Label() { Text = "Content Set On Loading Expanded" };
        grid.Children.Add(label);
        expander.Content = grid;
    }
}
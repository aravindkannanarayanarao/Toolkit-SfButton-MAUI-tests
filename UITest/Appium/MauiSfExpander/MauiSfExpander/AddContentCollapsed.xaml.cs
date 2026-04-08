namespace MauiSfExpander;

public partial class AddContentCollapsed : ContentPage
{
	public AddContentCollapsed()
	{
		InitializeComponent();
        Grid grid = new Grid();

        Label label = new Label() { Text = "Content Set On Loading Collapsed" };
        grid.Children.Add(label);
        expander.Content = grid;
        expander.IsExpanded = false; 
    }
}
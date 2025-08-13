namespace SfButtonSample.Features;

public partial class Features : ContentPage
{
	public Features()
	{
		InitializeComponent();


	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (check.IsChecked == true)
        {
            chip.Content = (DataTemplate)Resources["happyTemplate"];
            // stackLayout.Children.Add(label);
            //chip.Content = stackLayout;
        }
        else
        {
            chip.Content = null;
        }
    }

    private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            chip.DashArray = new float[] { 4, 4 };
        }
        else
        {
            chip.DashArray = null;

        }
    }
}
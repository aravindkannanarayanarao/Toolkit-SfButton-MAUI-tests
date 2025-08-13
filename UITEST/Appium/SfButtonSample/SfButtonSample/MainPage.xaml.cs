
using Binding = SfButtonSample.Features;

namespace SfButtonSample;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
        InitializeComponent();
	}
    string name;
    private void Editor_TextChanged(object sender, TextChangedEventArgs e)
    {
        name = (sender as Entry).Text;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var type = Type.GetType("SfButtonSample.SBSample." + name);
            Navigation.PushAsync(Activator.CreateInstance(type) as ContentPage);
        }
        catch
        {
            try
            {
                var type = Type.GetType("SfButtonSample.Features." + name);
                Navigation.PushAsync(Activator.CreateInstance(type) as ContentPage);
            }
            catch
            {
                var type = Type.GetType("SfButtonSample.Bugs." + name);
                Navigation.PushAsync(Activator.CreateInstance(type) as ContentPage);

            }
        }
    }
}



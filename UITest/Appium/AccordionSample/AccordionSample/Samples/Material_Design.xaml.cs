using AccordionSample.Samples;

namespace AccordionSample;

public partial class Material_Design : ContentPage
{
	public Material_Design()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var expanderView = new Basics_Expander();
        expanderView.Visual = VisualMarker.Default;
        Navigation.PushAsync(expanderView);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var accordionView = new AccordionChildren();
        accordionView.Visual = VisualMarker.Default;
        Navigation.PushAsync(accordionView);
    }
}
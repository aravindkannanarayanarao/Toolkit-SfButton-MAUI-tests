using Syncfusion.Maui.Expander;

namespace CRBugs;

public partial class OnAppearingPage : ContentPage
{
	public OnAppearingPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Multiple;
        accordion.AnimationEasing = ExpanderAnimationEasing.SinIn;
        accordion.ItemSpacing = 100;
        accordion.HeaderIconPosition = ExpanderIconPosition.Start;
        accordion.AnimationDuration = 400;
    }
}
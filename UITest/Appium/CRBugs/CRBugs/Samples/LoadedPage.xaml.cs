using Syncfusion.Maui.Expander;

namespace CRBugs;

public partial class LoadedPage : ContentPage
{
	public LoadedPage()
	{
		InitializeComponent();
        accordion.Loaded += Accordion_Loaded;
	}

    private void Accordion_Loaded(object? sender, EventArgs e)
    {
        accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Single;
        accordion.AnimationEasing = ExpanderAnimationEasing.SinIn;
        accordion.ItemSpacing = 100;
        accordion.HeaderIconPosition = ExpanderIconPosition.Start;
        accordion.AnimationDuration = 400;
    }
}
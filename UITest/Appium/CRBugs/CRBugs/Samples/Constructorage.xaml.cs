using Syncfusion.Maui.Expander;

namespace CRBugs;

public partial class Constructorage : ContentPage
{
	public Constructorage()
	{
		InitializeComponent();
        accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Multiple;
        accordion.AnimationEasing = ExpanderAnimationEasing.SinIn;
        accordion.ItemSpacing = 100;
        accordion.HeaderIconPosition = ExpanderIconPosition.Start;
        accordion.AnimationDuration = 400;
    }
}
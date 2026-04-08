using AccordionSample.MAUI_31007;

namespace AccordionSample.MAUI_32404;

public partial class MAUI_32404 : ContentPage
{
    public MAUI_32404()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ViewModel.ExpanderItems[0].IsExpanded = !ViewModel.ExpanderItems[0].IsExpanded;
    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        ViewModel.ExpanderItems[1].IsExpanded = !ViewModel.ExpanderItems[1].IsExpanded;
    }
}
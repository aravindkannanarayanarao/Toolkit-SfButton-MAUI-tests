using Microsoft.Maui.Controls;

namespace AccordionSample;

/// <summary>
/// SfAccordion Sample for Global and Application-Level Styles
/// Covers Test Cases: 180895, 180906
/// - GlobalStyle: ExpanderIcon at start, multiple expand, increased spacing, slow animation
/// - ApplicationLevel: Setting Accordion API at application level with same expected results
/// </summary>
public partial class SfAccordionStyleSample : ContentPage
{
    public SfAccordionStyleSample()
    {
        InitializeComponent();
        Title = "SfAccordion - Styling";
    }

}


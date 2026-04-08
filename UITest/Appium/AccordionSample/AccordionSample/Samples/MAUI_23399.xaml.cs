using Syncfusion.Maui.Accordion;

namespace AccordionSample;

public partial class MAUI_23399 : ContentPage
{
	public MAUI_23399()
	{
		InitializeComponent();
	}

    [Obsolete]
    private void Item_Clicked(object sender, EventArgs args)
    {
        var headerlabel = new Label();
        var headerGrid = new Grid();
        headerGrid.Children.Add(headerlabel);

        headerlabel.Text = "Header15";
        headerlabel.FontAttributes = FontAttributes.Bold;

        var contentlabel = new Label();
        var contentGrid = new Grid();
        contentGrid.Children.Add(contentlabel);

        contentlabel.Text = "The Accordion is a vertically collapsible content panel that displays one or more panels at a time within the available space.";

        var accordionitem = new AccordionItem();
        accordionitem.IsExpanded = true;
        accordionitem.HeaderBackground = Color.FromHex("#D3D3D3");

        accordionitem.Header = headerGrid;
        accordionitem.Content = contentGrid;

        accordion.Items.Insert(0, accordionitem);
    }

}
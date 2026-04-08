using Microsoft.Maui;
using Syncfusion.Maui.Accordion;

namespace AccordionSample;

public partial class AccordionChildren : FlyoutPage
{
    public AccordionChildren()
    {
        InitializeComponent();
    }

    //private void Add_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Insert_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Remove_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void RemoveAt_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Clear_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Replace_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Single_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void SingleorNone_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Multiple_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void MultipleorNone_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ExpColSingle_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ExpColMultiple_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ColExpSingle_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ColExpMultiple_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ExpandAll_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void CollapseAll_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void RTL_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void BringIntoView_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Start_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void End_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void None_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ItemSpacing_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void Top_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void MakeVisible_Clicked(object sender, EventArgs e)
    //{

    //}

    //private void ScrollNone_Clicked(object sender, EventArgs e)
    //{

    //}

    #region Real Time updates
    private void Add_Clicked(object sender, EventArgs e)
    {
        var item = new AccordionItem();
        var header = new Grid();
        var content = new Grid();
        header.Children.Add(new Label { Text = "Added Header", FontAttributes = FontAttributes.Bold });
        content.Children.Add(new Label { Text = "Added Item" });
        item.Header = header;
        item.Content = content;
        Accordion.Children.Add(item);
    }

    private void Insert_Clicked(object sender, EventArgs e)
    {
        AccordionItem item = new AccordionItem();
        var header = new Grid();
        var content = new Grid();
        header.Children.Add(new Label { Text = "Inserted Header", FontAttributes = FontAttributes.Bold });
        content.Children.Add(new Label { Text = "Inserted Content", FontAttributes = FontAttributes.Italic });
        item.Header = header;
        item.Content = content;
        Accordion.Children.Insert(2, item);
    }
    private void Remove_Clicked(object sender, EventArgs e)
    {
        Accordion.Children.Remove(Item2);
    }
    private void RemoveAt_Clicked(object sender, EventArgs e)
    {
        Accordion.Children.RemoveAt(1);
    }
    private void Clear_Clicked(object sender, EventArgs e)
    {
        Accordion.Children.Clear();
    }

    private void Replace_Clicked(object sender, EventArgs e)
    {
        var item = new AccordionItem();
        var header = new Grid();
        var content = new Grid();
        header.Children.Add(new Label { Text = "Replaced Header", FontAttributes = FontAttributes.Bold });
        content.Children.Add(new Label { Text = "Replaced Item" });
        item.Header = header;
        item.Content = content;
        Accordion.Children[3] = item;
    }
    #endregion

    #region Expand Collapse
    private void ExpandAll_Clicked(object sender, EventArgs e)
    {
        foreach (var item in Accordion.Items)
        {
            item.IsExpanded = true;
        }
    }
    private void CollapseAll_Clicked(object sender, EventArgs e)
    {
        foreach (var item in Accordion.Items)
            item.IsExpanded = false;

    }

    private void ExpColSingle_Clicked(object sender, EventArgs e)
    {
        Accordion.Items[2].IsExpanded = true;
        Accordion.Items[2].IsExpanded = false;
    }

    private void ExpColMultiple_Clicked(object sender, EventArgs e)
    {
        foreach (var item in Accordion.Items)
            item.IsExpanded = true;

        foreach (var item in Accordion.Items)
            item.IsExpanded = false;
    }

    private void ColExpSingle_Clicked(object sender, EventArgs e)
    {
        Accordion.Items[2].IsExpanded = false;
        Accordion.Items[2].IsExpanded = true;
    }

    private void ColExpMultiple_Clicked(object sender, EventArgs e)
    {
        foreach (var item in Accordion.Items)
            item.IsExpanded = false;

        foreach (var item in Accordion.Items)
            item.IsExpanded = true;
    }
    #endregion

    #region ExpandMode
    private void Single_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = AccordionExpandMode.Single;
    }

    private void SingleorNone_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = AccordionExpandMode.SingleOrNone;
    }

    private void Multiple_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = AccordionExpandMode.Multiple;
    }

    private void MultipleorNone_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = AccordionExpandMode.MultipleOrNone;
    }
    #endregion

    #region Icon Position
    private void Start_Clicked(object sender, EventArgs e)
    {
        Accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
    }

    private void End_Clicked(object sender, EventArgs e)
    {
        Accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
    }

    private void None_Clicked(object sender, EventArgs e)
    {
        Accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.None;
    }
    #endregion

    #region AutoScrollToPosition
    private void Top_Clicked(object sender, EventArgs e)
    {
        Accordion.AutoScrollPosition = AccordionAutoScrollPosition.Top;
    }

    private void MakeVisible_Clicked(object sender, EventArgs e)
    {
        Accordion.AutoScrollPosition = AccordionAutoScrollPosition.MakeVisible;
    }

    private void ScrollNone_Clicked(object sender, EventArgs e)
    {
        Accordion.AutoScrollPosition = AccordionAutoScrollPosition.None;
    }
    #endregion

    private void RTL_Clicked(object sender, EventArgs e)
    {
        Accordion.FlowDirection = FlowDirection.RightToLeft;
    }
    private void BringIntoView_Clicked(object sender, EventArgs e)
    {
        Accordion.BringIntoView(Item19);
    }

    private void ItemSpacing_Clicked(object sender, EventArgs e)
    {
        Accordion.ItemSpacing = 20;
    }
}
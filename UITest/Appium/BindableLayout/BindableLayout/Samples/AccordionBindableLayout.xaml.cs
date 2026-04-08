namespace BindableLayout;

public partial class AccordionBindableLayout : FlyoutPage
{
    public AccordionBindableLayout()
    {
        InitializeComponent();
    }

    private void Add_Clicked(object sender, EventArgs e)
    {
        var item = new Model();
        item.Name = "Added Header";
        item.Description = "Added Content";
        viewModel.Info.Add(item);
    }

    private void Insert_Clicked(object sender, EventArgs e)
    {
        var item = new Model();
        item.Name = "Inserted Header";
        item.Description = "Inserted Content";
        viewModel.Info.Insert(1, item);
    }

    private void Remove_Clicked(object sender, EventArgs e)
    {
        viewModel.Info.Remove(viewModel.Info[1]);
    }
    private void RemoveAt_Clicked(object sender, EventArgs e)
    {
        viewModel.Info.RemoveAt(1);
    }
    private void Clear_Clicked(object sender, EventArgs e)
    {
        viewModel.Info.Clear();
    }
    private void MoveUp_Clicked(object sender, EventArgs e)
    {
        viewModel.Info.Move(3, 1);
    }

    private void MoveDown_Clicked(object sender, EventArgs e)
    {
        viewModel.Info.Move(1, 3);
    }

    private void Replace_Clicked(object sender, EventArgs e)
    {
        var item = new Model();
        item.Name = "Replaced Header";
        item.Description = "Replaced Content";
        viewModel.Info[2] = item;
    }

    private void ExpandAll_Clicked(object sender, EventArgs e)
    {
        foreach (var item in Accordion.Items)
            item.IsExpanded = true;
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

    private void Single_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Single;
    }

    private void SingleorNone_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.SingleOrNone;
    }

    private void Multiple_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.Multiple;
    }

    private void MultipleorNone_Clicked(object sender, EventArgs e)
    {
        Accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.MultipleOrNone;
    }

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

    private void RTL_Clicked(object sender, EventArgs e)
    {
        Accordion.FlowDirection = FlowDirection.RightToLeft;
    }

    private void ItemSpacing_Clicked(object sender, EventArgs e)
    {
        Accordion.ItemSpacing = 20;
    }

    private void Top_Clicked(object sender, EventArgs e)
    {
        Accordion.AutoScrollPosition = Syncfusion.Maui.Accordion.AccordionAutoScrollPosition.Top;
    }

    private void MakeVisible_Clicked(object sender, EventArgs e)
    {
        Accordion.AutoScrollPosition = Syncfusion.Maui.Accordion.AccordionAutoScrollPosition.MakeVisible;
    }

    private void ScrollNone_Clicked(object sender, EventArgs e)
    {
        Accordion.AutoScrollPosition = Syncfusion.Maui.Accordion.AccordionAutoScrollPosition.None;
    }

}
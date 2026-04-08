using Syncfusion.Maui.Accordion;

namespace AccordionSample;

public partial class MasterDetailPage1 : FlyoutPage
{
	public MasterDetailPage1()
	{
		InitializeComponent();
	}

    private void expandModePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                accordion.ExpandMode = AccordionExpandMode.Single;
                break;
            case 1:
                accordion.ExpandMode = AccordionExpandMode.SingleOrNone;
                break;
            case 2:
                accordion.ExpandMode = AccordionExpandMode.Multiple;
                break;
            case 3:
                accordion.ExpandMode = AccordionExpandMode.MultipleOrNone;
                break;
        }

    }

    private void ExpandCollapse_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                var item1Header = new Grid();
                item1Header.Children.Add(new Label
                {
                    Text = "Replaced Header",
                    FontAttributes = FontAttributes.Bold,
                });

                var item1Content = new Grid();
                item1Content.Children.Add(new Label
                {
                    Text = "Replaced Content",
                    FontAttributes = FontAttributes.Italic,
                });

                AccordionItem item1 = new AccordionItem();
                item1.Header = item1Header;
                item1.Content = item1Content;

                accordion.Items[3] = item1;
                break;
            case 1:
                accordion.Items.Move(1, 3);
                break;
            case 2:
                accordion.Items.Move(3, 1);
                break;
            case 3:
                accordion.Items.Clear();
                break;
            case 4:
                accordion.Items.Clear();
                var itemHeader = new Grid();
                itemHeader.Children.Add(new Label
                {
                    Text = "New Header",
                    FontAttributes = FontAttributes.Bold,
                });

                var itemContent = new Grid();
                itemContent.Children.Add(new Label
                {
                    Text = "New Content",
                    FontAttributes = FontAttributes.Italic,
                });

                AccordionItem item = new AccordionItem();
                item.Header = itemHeader;
                item.Content = itemContent;

                accordion.Items.Add(item);
                break;
        }
    }

    private void AutoScrollPositionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                accordion.AutoScrollPosition = AccordionAutoScrollPosition.MakeVisible;
                break;
            case 1:
                accordion.AutoScrollPosition = AccordionAutoScrollPosition.Top;
                break;
            case 2:
                accordion.AutoScrollPosition = AccordionAutoScrollPosition.None;
                break;
        }
    }

    private void IconPositionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
                break;
            case 1:
                accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
                break;
            case 2:
                accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.None;
                break;
        }
    }

    private void collectionChange_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                {
                    var headerGrid = new Grid();
                    var contentGrid = new Grid();
                    headerGrid.Children.Add(new Label { Text = "Header Modified" });
                    contentGrid.Children.Add(new Label { Text = "Content changed in runtime" });
                    accordion.Items[2].Header = headerGrid;
                    accordion.Items[5].Content = contentGrid;

                    var itemHeader = new Grid();
                    itemHeader.Children.Add(new Label
                    {
                        Text = "New Header",
                        FontAttributes = FontAttributes.Bold,
                    });

                    var itemContent = new Grid();
                    itemContent.Children.Add(new Label
                    {
                        Text = "New Content",
                        FontAttributes = FontAttributes.Italic,
                    });

                    AccordionItem item = new AccordionItem();
                    item.Header = itemHeader;
                    item.Content = itemContent;

                    accordion.Items.Add(item);
                }
                break;
            case 1:
                {
                    var item2Header = new Grid();
                    item2Header.Children.Add(new Label
                    {
                        Text = "Inserted Header",
                        FontAttributes = FontAttributes.Bold,
                    });

                    var item2Content = new Grid();
                    item2Content.Children.Add(new Label
                    {
                        Text = "Inserted Content",
                        FontAttributes = FontAttributes.Italic,
                    });

                    AccordionItem item2 = new AccordionItem();
                    item2.Header = item2Header;
                    item2.Content = item2Content;

                    accordion.Items.Insert(5, item2);

                }
                break;
            case 2:
                accordion.Items.Remove(Item2);
                break;
            case 3:
                accordion.Items.RemoveAt(4);
                break;
        }
    }

    private void Handle_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                var item1Header = new Grid();
                item1Header.Children.Add(new Label
                {
                    Text = "Replaced Header",
                    FontAttributes = FontAttributes.Bold,
                });

                var item1Content = new Grid();
                item1Content.Children.Add(new Label
                {
                    Text = "Replaced Content",
                    FontAttributes = FontAttributes.Italic,
                });

                AccordionItem item1 = new AccordionItem();
                item1.Header = item1Header;
                item1.Content = item1Content;

                accordion.Items[3] = item1;
                break;
            case 1:
                accordion.Items.Move(1, 3);
                break;
            case 2:
                accordion.Items.Move(3, 1);
                break;
            case 3:
                accordion.Items.Clear();
                break;
            case 4:
                accordion.Items.Clear();
                var itemHeader = new Grid();
                itemHeader.Children.Add(new Label
                {
                    Text = "New Header",
                    FontAttributes = FontAttributes.Bold,
                });

                var itemContent = new Grid();
                itemContent.Children.Add(new Label
                {
                    Text = "New Content",
                    FontAttributes = FontAttributes.Italic,
                });

                AccordionItem item = new AccordionItem();
                item.Header = itemHeader;
                item.Content = itemContent;

                accordion.Items.Add(item);
                break;
        }
    }

    private void HeaderBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                item0.HeaderBackground = Colors.Yellow;
                break;
            case 1:
                item0.HeaderBackground = Colors.Red;
                break;
        }
    }

    private void AnimationEasing_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.None;
                break;
            case 1:
                accordion.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.Linear;
                break;
        }
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        accordion.BringIntoView(item);
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        accordion.FlowDirection = FlowDirection.RightToLeft;
    }
}
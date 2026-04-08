namespace AccordionSample;

public partial class Basics_Expander : FlyoutPage
{
	public Basics_Expander()
	{
		InitializeComponent();
	}

    private void IconPositionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0:
                expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
                break;
            case 1:
                expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
                break;
            case 2:
                expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.None;
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
                expander.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.None;
                break;
            case 1:
                expander.AnimationEasing = Syncfusion.Maui.Expander.ExpanderAnimationEasing.Linear;
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
                expander.HeaderBackground = Colors.Yellow;
                break;
            case 1:
                expander.HeaderBackground = Colors.Red;
                break;
        }
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        expander.FlowDirection = FlowDirection.RightToLeft;
    }

    private void Switch_Toggled_1(object sender, ToggledEventArgs e)
    {
        expander.IsExpanded = e.Value;
    }
}
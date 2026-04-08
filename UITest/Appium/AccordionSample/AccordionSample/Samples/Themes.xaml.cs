using Syncfusion.Maui.Core;
using Syncfusion.Maui.Themes;

namespace AccordionSample;

public partial class Themes : ContentPage
{
    private ICollection<ResourceDictionary>? mergedDictionaries;

    public Themes()
    {
        InitializeComponent();
        var pageResources = Resources;
        this.mergedDictionaries = (pageResources as ResourceDictionary)?.MergedDictionaries;
    }

    private void LightTheme_Clicked(object sender, EventArgs e)
    {
        if (this.mergedDictionaries != null)
        {
            foreach (var item in this.mergedDictionaries.Reverse<ResourceDictionary>())
            {
                var dictionary = item as ResourceDictionary;
                if (dictionary.ContainsKey("SyncfusionTheme"))
                {
                    var themeType = dictionary["SyncfusionTheme"] as string;
                    mergedDictionaries.Remove(item);
                    mergedDictionaries.Add(new LightThemeColors());
                }
            }
        }
    }
    private void OverrideColor_Clicked(object sender, EventArgs e)
    {
        if (this.mergedDictionaries != null)
        {
            foreach (var item in this.mergedDictionaries.Reverse<ResourceDictionary>())
            {
                var dictionary = item as ResourceDictionary;
                if (dictionary.ContainsKey("SyncfusionTheme"))
                {
                    var themeType = dictionary["SyncfusionTheme"] as string;
                    mergedDictionaries.Remove(item);
                    var darkTheme = new DarkThemeColors
                    {
                        ["SfAccordionNormalHeaderBackground"] = Colors.DarkViolet,
                        ["SfAccordionNormalHeaderIconColor"] = Colors.DarkRed,
                        ["SfExpanderNormalHeaderBackground"] = Colors.DarkViolet,
                        ["SfExpanderNormalHeaderIconColor"] = Colors.DarkRed,
                    };
                    mergedDictionaries.Add(darkTheme);
                }
            }
        }
    }

    private void IconPosition_Clicked(object sender, EventArgs e)
    {
        if (Accordion.HeaderIconPosition == Syncfusion.Maui.Expander.ExpanderIconPosition.Start)
            Accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
        else
            Accordion.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;

        if (item2.HeaderIconPosition == Syncfusion.Maui.Expander.ExpanderIconPosition.Start)
            item2.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
        else
            item2.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;

        if (item3.HeaderIconPosition == Syncfusion.Maui.Expander.ExpanderIconPosition.Start)
            item3.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
        else
            item3.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;

    }

    private void IsExpanded_Clicked(object sender, EventArgs e)
    {
        if (item1.IsExpanded)
            item1.IsExpanded = false;
        else
            item1.IsExpanded = true;

        if (item2.IsExpanded)
            item2.IsExpanded = false;
        else
            item2.IsExpanded = true;

        if (item3.IsExpanded)
            item3.IsExpanded = false;
        else
            item3.IsExpanded = true;
    }
}
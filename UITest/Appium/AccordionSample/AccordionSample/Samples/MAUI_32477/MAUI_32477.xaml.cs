using Syncfusion.Maui.ListView;

namespace AccordionSample;

public partial class MAUI_32477 : FlyoutPage
{
	public MAUI_32477()
	{
		InitializeComponent();
        MasterPage.ListView.ItemSelected += ListView_ItemSelected;

    }
    private void ListView_ItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        var item = e.SelectedItem as MAUI_32477MasterMenuItem;
        if (item == null)
            return;
        var page = (Page)Activator.CreateInstance(item.TargetType);
        page!.Title = item.Title;

        Detail = new NavigationPage(page);
        //IsPresented = false;

        MasterPage.ListView.SelectedItem = null;
    }
}
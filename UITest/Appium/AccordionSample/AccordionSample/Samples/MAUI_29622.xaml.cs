using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AccordionSample;

public partial class MAUI_29622 : ContentPage
{
	public MAUI_29622()
	{
		InitializeComponent();
	}

    private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        DisplayAlert("Alert!", "ListViewItem tapped", "Cancel");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //this.listView.LayoutManager.ScrollToRowIndex(listView.DataSource.DisplayItems.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.End);
        this.listView!.ItemsLayout!.ScrollToRowIndex(listView!.DataSource!.DisplayItems.Count - 1, ScrollToPosition.End);
    }
}

public class MAUI_29622_ViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Supplier> Suppliers { get; set; }

    public MAUI_29622_ViewModel()
    {
        Suppliers = new ObservableCollection<Supplier>
             {
                 new Supplier() { Name = "Supplier Number 1"},
                 new Supplier() { Name = "Supplier Number 2"},
                 new Supplier() { Name = "Supplier Number 3"},
                 new Supplier() { Name = "Supplier Number 4"},
                 new Supplier() { Name = "Supplier Number 5"},
                 new Supplier() { Name = "Supplier Number 6"},
                 new Supplier() { Name = "Supplier Number 7"},
                 new Supplier() { Name = "Supplier Number 8"},
                 new Supplier() { Name = "Supplier Number 9"},
                 new Supplier() { Name = "Supplier Number 10"},
                 new Supplier() { Name = "Supplier Number 11"},
                 new Supplier() { Name = "Supplier Number 12"},
                 new Supplier() { Name = "Supplier Number 13"},
                 new Supplier() { Name = "Supplier Number 14"},
                 new Supplier() { Name = "Supplier Number 15"},
                 new Supplier() { Name = "Supplier Number 16"},
                 new Supplier() { Name = "Supplier Number 17"},
                 new Supplier() { Name = "Supplier Number 18"},
                 new Supplier() { Name = "Supplier Number 19"},
                 new Supplier() { Name = "Supplier Number 20"},
                 new Supplier() { Name = "Supplier Number 21"},
                 new Supplier() { Name = "Supplier Number 22"},
                 new Supplier() { Name = "Supplier Number 23"},
                 new Supplier() { Name = "Supplier Number 24"},
                 new Supplier() { Name = "Supplier Number 25"},
                 new Supplier() { Name = "Supplier Number 26"},
                 new Supplier() { Name = "Supplier Number 27"},
                 new Supplier() { Name = "Supplier Number 28"},
                 new Supplier() { Name = "Supplier Number 29"},
                 new Supplier() { Name = "Supplier Number 30"},
                 new Supplier() { Name = "Supplier Number 31"},
                 new Supplier() { Name = "Supplier Number 32"},
                 new Supplier() { Name = "Supplier Number 33"},
                 new Supplier() { Name = "Supplier Number 34"},
                 new Supplier() { Name = "Supplier Number 35"},
                 new Supplier() { Name = "Supplier Number 36"},
                 new Supplier() { Name = "Supplier Number 37"},
                 new Supplier() { Name = "Supplier Number 38"},
                 new Supplier() { Name = "Supplier Number 39"},
                 new Supplier() { Name = "Supplier Number 40"}
             };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

public class Supplier
{
    public string? Name { get; set; }

}
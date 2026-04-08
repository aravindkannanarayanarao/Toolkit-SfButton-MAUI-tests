using System.Collections.ObjectModel;

namespace AccordionSample.MAUI_31007;

public partial class MAUI_31007 : ContentPage
{
    public MAUI_31007()
    {
        InitializeComponent();
    }
}

public class ViewModel
{
    public ObservableCollection<int> Items { get; set; }

    public ViewModel()
    {
        Items = new ObservableCollection<int>
            { 1, 2, 3, 4, 5};
    }
}

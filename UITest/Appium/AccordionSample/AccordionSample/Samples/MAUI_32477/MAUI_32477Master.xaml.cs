using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AccordionSample;

public partial class MAUI_32477Master : ContentPage
{
	public ListView ListView;
	public MAUI_32477Master()
	{
        //BindingContext = new MAUI_32477MasterViewModel();
        InitializeComponent();
        ListView= MenuItemsListView;
	}
}

internal class MAUI_32477MasterViewModel : INotifyPropertyChanged
{
    public ObservableCollection<MAUI_32477MasterMenuItem> MenuItems { get; set; }

    public MAUI_32477MasterViewModel()
    {
        MenuItems = new ObservableCollection<MAUI_32477MasterMenuItem>(new[]
        {
                    new MAUI_32477MasterMenuItem { Id = 0, Title = "Start", TargetType= typeof(StartView)  },
                    new MAUI_32477MasterMenuItem { Id = 1, Title = "Other", TargetType= typeof(OtherView)  }
                });
    }

    #region INotifyPropertyChanged Implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged == null)
            return;

        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
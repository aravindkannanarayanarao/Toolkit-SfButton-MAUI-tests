using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SfButtonSample;

public class MainViewModel : INotifyPropertyChanged
{
    int count = 0;
    public ICommand GoodCommand { get; }
    public ICommand BadCommand { get; }
    public MainViewModel()
    {
        GoodCommand = new Command(Good);
        BadCommand = new Command(Bad);
        MyCommand = new Command(ExecuteMyCommand);
    }
    public ICommand MyCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string brandFilterChecked1;
    public string BrandFilterChecked1
    {
        get { return brandFilterChecked1; }
        set
        {
            if (brandFilterChecked1 != value)
            {
                brandFilterChecked1 = value;
                OnPropertyChanged(nameof(BrandFilterChecked1));
            }
        }
    }
    private void ExecuteMyCommand()
    {
        BrandFilterChecked1 = "Button Clicked"; 
    }
    private void Good()
    {
        ;
    }

    private void Bad()
    {
        ;
    }

}
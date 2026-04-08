
using Syncfusion.Maui.Accordion;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace AccordionSample;

public partial class MAUI_28890 : ContentPage
{
    public MAUI_28890()
    {
        InitializeComponent();
        Accordion.BindingContext = viewModel.Info;
        LoadAccordionItems();
    }

    internal void LoadAccordionItems()
    {
        var model1 = new Model();
        model1.Name = "Item Header 1";
        model1.Description = "Item Content 1";

        var model2 = new Model();
        model2.Name = "Item Header 2";
        model2.Description = "Item Content 2";

        var item1 = new AccordionItem();
        item1.BindingContext = model1;


        var headerlabel = new Label();
        var headerGrid = new Grid();
        headerGrid.Children.Add(headerlabel);

        headerlabel.SetBinding(Label.TextProperty, new Binding("Name"));
        headerlabel.HeightRequest = 50;
        headerlabel.TextColor = Colors.Green;

        item1.Header = headerGrid;


        var contentlabel = new Label();
        var contentGrid = new Grid();
        contentGrid.Children.Add(contentlabel);

        contentlabel.SetBinding(Label.TextProperty, new Binding("Description"));
        contentlabel.HeightRequest = 50;
        contentlabel.TextColor = Colors.Green;

        item1.Content = contentGrid;

        var item2 = new AccordionItem();
        item2.BindingContext = model2;

        var headerlabel1 = new Label();
        var headerGrid1 = new Grid();
        headerGrid1.Children.Add(headerlabel1);

        headerlabel1.SetBinding(Label.TextProperty, new Binding("Name"));
        headerlabel1.HeightRequest = 50;
        headerlabel1.TextColor = Colors.Green;

        item2.Header = headerGrid1;

        var contentlabel1 = new Label();
        var contentGrid1 = new Grid();
        contentGrid1.Children.Add(contentlabel1);

        contentlabel1.SetBinding(Label.TextProperty, new Binding("Description"));
        contentlabel1.TextColor = Colors.Green;
        contentlabel1.HeightRequest = 50;

        item2.Content = contentGrid1;

        Accordion.Items.Add(item1);
        Accordion.Items.Add(item2);
    }
}

    public class AccordionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model> Info { get; set; }

        public AccordionViewModel()
        {
            Info = new ObservableCollection<Model>
             {
                 new Model() { Name = "Item1", Description = "Information1" },
                 new Model() { Name = "Item2", Description = "Information2" },
                 new Model() { Name = "Item3", Description = "Information3" },
                 new Model() { Name = "Item4", Description = "Information4" },
                 new Model() { Name = "Item5", Description = "Information5" }
             };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class Model
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
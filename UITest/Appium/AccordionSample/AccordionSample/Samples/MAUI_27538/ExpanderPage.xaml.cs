using System.Collections.ObjectModel;

namespace AccordionSample;

public partial class ExpanderPage : ContentPage
{
    public ObservableCollection<Contact>? contactsInfo { get; set; }

    public ExpanderPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Contact t1 = new Contact();

        t1.ContactName = "Header 1";
        t1.CallTime = "Content 1";

        Contact t2 = new Contact();

        t2.ContactName = "Header 2";
        t2.CallTime = "Content 2";

        Contact t3 = new Contact();

        t3.ContactName = "Header 3";
        t3.CallTime = "Content 3";


        contactsInfo = new ObservableCollection<Contact>();
        contactsInfo.Add(t1);
        contactsInfo.Add(t2);
        contactsInfo.Add(t3);

        listView.ItemsSource = contactsInfo;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current!.MainPage = new NavigationPage(new MainPage());
    }
}
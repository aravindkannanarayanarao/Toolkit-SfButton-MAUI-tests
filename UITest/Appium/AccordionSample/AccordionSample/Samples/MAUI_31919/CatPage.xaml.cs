namespace AccordionSample.MAUI_31919;

public partial class CatPage : ContentPage
{
	public CatPage()
	{
		InitializeComponent();
	}

    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string catName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
        // This works because route names are unique in this application.
        await Shell.Current.GoToAsync($"catdetails?name={catName}");
        // The full route is shown below.
        // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
    }
}
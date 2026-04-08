namespace AccordionSample.MAUI_31919;

public partial class MonkeysPage : ContentPage
{
	public MonkeysPage()
	{
		InitializeComponent();
	}

    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string monkeyName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
        // This works because route names are unique in this application.
        //await Shell.Current.GoToAsync($"monkeydetails?name={monkeyName}");
        // The full route is shown below.
        // await Shell.Current.GoToAsync($"//animals/monkeys/monkeydetails?name={monkeyName}");
    }
}
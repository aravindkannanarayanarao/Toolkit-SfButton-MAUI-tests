
namespace AccordionSample1.MAUI_37743;

public partial class MAUI_37743 : ContentPage
{
	public MAUI_37743()
	{
		InitializeComponent();
	}

    private void Add_Button_Clicked(object sender, EventArgs e)
    {
        var vm = this.BindingContext as MAUI_37743_ViewModel;
        vm!.AddItem();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation?.PopAsync();
        DisplayAlert("Alert", "Navigated back from Accordian page", "Ok");
    }
}
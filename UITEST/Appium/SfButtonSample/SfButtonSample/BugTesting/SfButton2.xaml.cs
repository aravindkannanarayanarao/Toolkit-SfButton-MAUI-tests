
using Syncfusion.Maui.Popup;
namespace SfButtonSample.Bugs;

public partial class SfButton2 : ContentPage
{
	public SfButton2()
	{
		InitializeComponent();
        
    }

    private void button2_Clicked(object sender, EventArgs e)
    {

    }

    private void PopUpButton_Clicked(object sender, EventArgs e)
    {
        popup.Show(); 
    }
}
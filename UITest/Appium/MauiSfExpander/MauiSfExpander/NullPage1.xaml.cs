using Syncfusion.Maui.Expander;
namespace MauiSfExpander;


public partial class NullPage1 : ContentPage
{
	public NullPage1()
	{
		InitializeComponent();
		expander.Content = null;
	}
}
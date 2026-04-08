namespace MAUI_SfAccordion_ExpanderSample
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage()
        {
            InitializeComponent();
        }

        private async void _935140_Expander_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new _935140());
        }
    }
}

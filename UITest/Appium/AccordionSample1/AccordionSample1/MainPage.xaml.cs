using AccordionSample1.DynamicSupport;
using AccordionSample1.MAUI_37449;
using AccordionSample1.MAUI_37743;
using AccordionSample1.MAUI_44611;

namespace AccordionSample1
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private void Load_RTL_sample_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RTL());
        }

        private void DynamicSizeSupport_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DynamicSize());
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BindableAccordIonGrid());
        }

        private void Navigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FirstPage());
        }

        private void MAUI_37449_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_37499());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_37208());
        }

        private void MAUI_40527_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_40527());
        }

        private void MAUI_44611_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

        private void MAUI_38120_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_38120());
        }
    }

}

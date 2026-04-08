
using AccordionSample.Samples.MAUI_27222;
using AccordionSample.Samples.MAUI_27943;

namespace AccordionSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MasterDetailPage1());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_24619());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_24590());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_26113());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_26113_Listview());
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_23400());
        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_23412());
        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_23399());

        }

        private void Button_Clicked_8(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_26124());
        }

        private void Button_Clicked_9(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_26254_ItemSpacing_20());
        }

        private void Button_Clicked_10(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_26254_ItemSpacing_0());
        }

        private void Button_Clicked_11(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Basics_Expander());
        }

        private void Button_Clicked_12(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VSM());
        }

        private void Button_Clicked_13(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_26687());
        }

        private void Themes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Themes());
        }

        private void AccordionChildren_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccordionChildren());
        }

        private void XAMARIN_28517_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_28517());
        }

        private void XAMARIN_28890_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_28890());
        }

        private void XAMARIN_28883_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_28883());
        }

        private void XAMARIN_29715_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_29715());
        }

        private void XAMARIN_27943_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_27943());
        }

        private void MAUI_30325_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_30325());
        }

        private void MAUI_30507_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_30507());
        }

        private void Material_Design_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Material_Design());
        }

        private void Button_Clicked_14(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_32477());
        }

        private void MAUI_27538_Clicked(object sender, EventArgs e)
        {
            App.Current!.MainPage = new MAUI_27538();
        }

        private void MAUI_27222_ExpanderIssue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExpanderIssue());
        }

        private void MAUI_27222_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_27222());
        }

        private void MAUI_32404_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_32404.MAUI_32404());
        }

        private void MAUI_31919_Clicked(object sender, EventArgs e)
        {
            App.Current!.MainPage = new AccordionSample.MAUI_31919.MAUI_31919();
        }

        private void MAUI_31007_Clicked(object sender, EventArgs e)
        {
            App.Current!.MainPage = new AccordionSample.MAUI_31007.MAUI_31007();
        }

        private void MAUI_29622_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_29622());
        }

        private void MAUI_32579_Clicked(object sender, EventArgs e)
        {
            App.Current!.MainPage = new MAUI_32579.AppShell();
        }

        private void MAUI_35330_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_35330());

        }
        
        private void MAUI_28517_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_28517());
        }

        private void MAUI_28890_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_28890());
        }

        private void MAUI_29715_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_29715());
        }

        private void MAUI_28883_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_28883());
        }

        private void MAUI_27943_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_27943_TabbedPage());
        }

        private void MAUI_Clicked_14(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MAUI_32477());
        }

        private void DatePager_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SfAccordionDataPagerSample());
        }
        private void NavigationSample_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SfAccordionNavigationSample());
        }
        private void StyleSample_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SfAccordionStyleSample());
        }
        private void ShellPageSample_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SfAccordionShellPageSample());
        }

        private void StackLayoutSample_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SfAccordionStackLayoutSample());
        }

    }
}

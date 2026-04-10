namespace MAUIExpander;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
	}


    private async void Expander_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void Accordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Accordion());

    }

    private async void AccordionHeader_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccordionHeader());

    }

    private async void BringIntoViewAccordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BringIntoViewAccordion() );

    }

    private async void BringIntoView_FlyoutPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BringIntoViewFlyoutPage());

    }

    private async void DynamicSizeExpander_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DynamicSizeExp());

    }

    private async void GettingStarted_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GettingStarted() );

    }

    private async void ChangeHeaderAccordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ES_826470());

    }

    private async void HeaderIconPositionAccordion_Clikced(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new  ES_823715());

    }

    private async void AddRemoveReplace_Accordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ES_823716());

    }

    private async void ChangeHeaderExpander_Clikced(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MAUI_5339());
    }

    private async void AnimationExpander_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MAUI_5341());

    }

    private async void HeaderIconPositionExpander_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MAUI_5343());

    }

    private async void NullHeaderExpander_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MAUI_5344());

    }

    private async void ExpandCollpase_Accordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MAUI_5570());

    }

    private async void ExpandMode_Accordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Task_825074());

    }

    private async void ExpandCollapseEvents_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TASK_825141());

    }

    private async void AddAsContent_Accordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TASK_823721());

    }

    private async void IsExpanded_Accordion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TASK_827168());
    }

    private async void IsExpanded_Expander_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Task827168Exp());

    }
}
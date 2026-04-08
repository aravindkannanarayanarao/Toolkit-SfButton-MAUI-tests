using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Syncfusion.Maui.Accordion;

namespace AccordionSample;

public partial class SfAccordionNavigationSample : ContentPage
{
    public SfAccordionNavigationSample()
    {
        InitializeComponent();
        Title = "SfAccordion - Navigation Scenarios";
    }

    private async void OnHorizontalPushAsyncClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SfAccordionNavigationHorizontalSample(), animated: false);
    }

    private async void OnAbsolutePushAsyncClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SfAccordionNavigationAbsoluteSample(), animated: false);
    }

    private async void OnHorizontalPushModalAsyncClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new SfAccordionNavigationHorizontalSample()), animated: false);
    }

    private async void OnAbsolutePushModalAsyncClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new SfAccordionNavigationAbsoluteSample()), animated: false);
    }
}

public class SfAccordionNavigationHorizontalSample : ContentPage
{
    public SfAccordionNavigationHorizontalSample()
    {
        AutomationId = "Horizontal Stack Layout";
        Title = "Horizontal Stack Layout";

        var scrollView = new ScrollView();
        var mainStack = new VerticalStackLayout { Padding = 20, Spacing = 10 };

        mainStack.Add(new Label
        {
            Text = "Horizontal Layout with SfAccordion",
            AutomationId="Horizontal Layout with SfAccordion",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold
        });

        var horizontalStack = new HorizontalStackLayout
        {
            AutomationId = "HorizontalStackLayoutNav",
            Padding = 10,
            Spacing = 10,
            BackgroundColor = Color.FromArgb("#FFF8E8")
        };

        var accordion = new SfAccordion
        {
            WidthRequest = 250,
        };

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Horizontal Item 1" },
            Content = new Label { Text = "Horizontal Content 1", Padding = 10 }
        });

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Horizontal Item 2" },
            Content = new Label { Text = "Horizontal Content 2", Padding = 10 }
        });

        horizontalStack.Add(accordion);
        mainStack.Add(horizontalStack);

        scrollView.Content = mainStack;
        Content = scrollView;
    }
}

public class SfAccordionNavigationAbsoluteSample : ContentPage
{
    public SfAccordionNavigationAbsoluteSample()
    {
        AutomationId = "Absolute Layout with SfAccordion";
        Title = "Absolute Layout with SfAccordion";

        var absolute = new AbsoluteLayout
        {
            BackgroundColor = Color.FromArgb("#F0E8F8"),
        };

        var header = new Label
        {
            Text = "Accordion Below",
            AutomationId= "Accordion Below",
            FontAttributes = FontAttributes.Bold,
            FontSize = 16,
            BackgroundColor = Colors.Transparent
        };

        AbsoluteLayout.SetLayoutBounds(header, new Rect(10, 10, 1, 40));
        AbsoluteLayout.SetLayoutFlags(header, AbsoluteLayoutFlags.WidthProportional);

        absolute.Add(header);

        var accordionContainer = new Grid
        {
            BackgroundColor = Colors.Transparent,
            HeightRequest = 260,
            Padding = new Thickness(10, 60, 10, 10)
        };

        var accordion = new SfAccordion();
        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Absolute Item 1" },
            Content = new Label { Text = "Absolute Content 1", Padding = 10 }
        });

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Absolute Item 2" },
            Content = new Label { Text = "Absolute Content 2", Padding = 10 }
        });

        accordionContainer.Add(accordion);

        AbsoluteLayout.SetLayoutBounds(accordionContainer, new Rect(0, 0, 1, 1));
        AbsoluteLayout.SetLayoutFlags(accordionContainer, AbsoluteLayoutFlags.All);

        absolute.Add(accordionContainer);

        Content = absolute;
    }
}

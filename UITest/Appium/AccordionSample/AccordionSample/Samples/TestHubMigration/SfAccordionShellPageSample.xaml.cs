using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Syncfusion.Maui.Accordion;

namespace AccordionSample;

/// <summary>
/// SfAccordion Sample with ShellPage navigation
/// Covers Test Cases: 108840, 108841
/// </summary>
public partial class SfAccordionShellPageSample : ContentPage
{
    public SfAccordionShellPageSample()
    {
        InitializeComponent();
        Title = "SfAccordion - ShellPage Navigation";
    }

    private async void OnHorizontalShellPageClicked(object sender, EventArgs e)
    {
        await Shell.Current.Dispatcher.DispatchAsync(async () =>
        {
            await Shell.Current.GoToAsync(nameof(SfAccordionHorizontalShellPage));
        });
    }

    private async void OnAbsoluteShellPageClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SfAccordionAbsoluteShellPage));
    }
}

/// <summary>
/// Horizontal StackLayout ShellPage Sample
/// </summary>
public class SfAccordionHorizontalShellPage : ContentPage
{
    private readonly VerticalStackLayout _mainStack;
    private bool _isInitialized = false;

    public SfAccordionHorizontalShellPage()
    {
        Title = "Horizontal Layout";

        _mainStack = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 20
        };

        _mainStack.Add(new Label
        {
            Text = "Horizontal Layout with SfAccordion",
            AutomationId="Horizontal Layout with SfAccordion",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold
        });

        // Placeholder — Accordion added later
        _mainStack.Add(new ActivityIndicator
        {
            IsRunning = true,
            Color = Colors.Blue,
            AutomationId = "LoadingIndicator"
        });

        _mainStack.Add(new Button
        {
            Text = "Go Back",
            AutomationId = "BackButton",
            Command = new Command(async () => await Shell.Current.GoToAsync(".."))
        });

        Content = _mainStack;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_isInitialized)
            return;

        _isInitialized = true;

        // Small delay gives automation time to stabilize page
        Device.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(150); // <-- FIX FOR AUTOMATION

            BuildAccordion();
        });
    }

    private void BuildAccordion()
    {
        var horizontalStack = new HorizontalStackLayout
        {
            Padding = 10,
            BackgroundColor = Colors.LightYellow,
            AutomationId = "HorizontalContainer"
        };

        var accordion = new SfAccordion
        {
            WidthRequest = 250,
            HorizontalOptions = LayoutOptions.Start,
            AutomationId = "HorizontalAccordion"
        };

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Horizontal Item 1", Padding = 5 },
            Content = new Label { Text = "Horizontal Content 1", Padding = 10 }
        });

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Horizontal Item 2", Padding = 5 },
            Content = new Label { Text = "Horizontal Content 2", Padding = 10 }
        });

        horizontalStack.Add(accordion);

        // Remove loading indicator
        _mainStack.RemoveAt(1);
        _mainStack.Insert(1, horizontalStack);
    }
}

/// <summary>
/// Absolute Layout ShellPage Sample
/// </summary>
public class SfAccordionAbsoluteShellPage : ContentPage
{
    public SfAccordionAbsoluteShellPage()
    {

        Title = "Absolute Layout";

        var mainStack = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 20
        };

        mainStack.Add(new Label
        {
            Text = "AbsoluteLayout Sample",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold
        });

        var absoluteLayout = new AbsoluteLayout
        {
            BackgroundColor = Colors.Lavender,
            HeightRequest = 350
        };

        var titleLabel = new Label
        {
            Text = "Absolute Layout Sample",
            AutomationId="Absolute Layout Sample",
            FontSize = 14,
            FontAttributes = FontAttributes.Bold,
            VerticalTextAlignment = TextAlignment.Center
        };

        AbsoluteLayout.SetLayoutBounds(titleLabel, new Rect(0, 0, 1, 50));
        AbsoluteLayout.SetLayoutFlags(titleLabel, AbsoluteLayoutFlags.WidthProportional);

        absoluteLayout.Add(titleLabel);

        var accordionContainer = new Grid();

        AbsoluteLayout.SetLayoutBounds(accordionContainer, new Rect(0, 50, 1, 300));
        AbsoluteLayout.SetLayoutFlags(accordionContainer, AbsoluteLayoutFlags.WidthProportional);

        var accordion = new SfAccordion();

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Abs Item 1" },
            Content = new Label { Text = "Abs Content 1", Padding = 10 }
        });

        accordion.Items.Add(new AccordionItem
        {
            Header = new Label { Text = "Abs Item 2" },
            Content = new Label { Text = "Abs Content 2", Padding = 10 }
        });

        accordionContainer.Add(accordion);
        absoluteLayout.Add(accordionContainer);

        mainStack.Add(absoluteLayout);

        mainStack.Add(new Button
        {
            Text = "Go Back",
            Command = new Command(async () => await Shell.Current.GoToAsync(".."))
        });

        Content = new ScrollView { Content = mainStack };

    }
}

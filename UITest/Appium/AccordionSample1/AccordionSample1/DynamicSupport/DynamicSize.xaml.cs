namespace AccordionSample1.DynamicSupport;

public partial class DynamicSize : ContentPage
{
    Label contentLablel1 = new Label();
    Label contentLablel2 = new Label();
    Label contentLablel3 = new Label();
    public DynamicSize()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        this.Appearing += ExpandableListView_Appearing;
        base.OnAppearing();
    }

    private void ExpandableListView_Appearing(object? sender, EventArgs e)
    {
        participantGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.1, GridUnitType.Star) });
        participantGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.5, GridUnitType.Star) });
        participantGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
        var collection = viewModel.Info;
        int partLine = 0;
        for (int i = 0; i < 1; i++)
        {
            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "PartyType" });
            participantGrid.Children.Add(new Label { Text = collection[i].Description });
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Claim:" });
            participantGrid.Children.Add(new Label { Text = "50$" });
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Rep:" });
            participantGrid.Children.Add(new Label { Text = "10" });
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1.8, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Phone:" });
            participantGrid.Children.Add(new Label { Text = "9898973873" });
            Button callRep = new Button
            {
                Text = "Button1",
                BackgroundColor = Colors.Transparent,
                VerticalOptions = LayoutOptions.Center,
            };
            participantGrid.Children.Add(callRep);
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1.8, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Email:" });
            participantGrid.Children.Add(new Label { Text = "dhsdsagfhg@fsaf.com" });
            Button sendEmail = new Button
            {
                Text = "Button2",
                BackgroundColor = Colors.Transparent,
                VerticalOptions = LayoutOptions.Center,
            };
            participantGrid.Children.Add(sendEmail);
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.8, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Is Lead?:" });
            participantGrid.Children.Add(new Label { Text = "Yes" });
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.8, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Is Secondary?:" });
            participantGrid.Children.Add(new Label { Text = "No" });
            partLine++;

            participantGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.8, GridUnitType.Star) });
            participantGrid.Children.Add(new Label { Text = "Respondent" });
            partLine++;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        var gridLabel = new Grid();
        gridLabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.1, GridUnitType.Star) });
        gridLabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.5, GridUnitType.Star) });
        gridLabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
        gridLabel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        int partLine = 0;
        contentLablel1.Text = "Party time";
        contentLablel1.IsVisible = false;
        gridLabel.Children.Add(contentLablel1);
        partLine++;
        gridLabel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        contentLablel2.Text = "label 3:";
        gridLabel.Children.Add(contentLablel2);
        gridLabel.Children.Add(contentLablel3);
        accordItem2.Content = gridLabel;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        label1.IsVisible = true;
        label4.FontSize = 35;
        label3.IsVisible = true;
        label2.IsVisible = true;
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        contentLablel1.IsVisible = true;
        contentLablel3.Text = "The Accordion is a vertically collapsible content panel that displays one or more  AccordionItem at a time within the available space. There are options to expand below or above the header. Also, you can customize to auto scroll an item upon expanding based on your requirement";
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {

        var gridLabel = new Grid();
        gridLabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.1, GridUnitType.Star) });
        gridLabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.5, GridUnitType.Star) });
        gridLabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
        gridLabel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        int partLine = 0;
        contentLablel1.Text = "Party time";
        contentLablel1.IsVisible = false;
        gridLabel.Children.Add(contentLablel1);
        partLine++;
        contentLablel2.Text = "Claim:";
        gridLabel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        gridLabel.Children.Add(contentLablel2);
        contentLablel2.Text = "label 3:";
        gridLabel.Children.Add(contentLablel3);
        partLine++;

        accordItem8.Header = gridLabel;
    }
}
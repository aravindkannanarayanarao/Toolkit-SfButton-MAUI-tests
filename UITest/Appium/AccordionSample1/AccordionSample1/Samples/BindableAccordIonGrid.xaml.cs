namespace AccordionSample1;

public partial class BindableAccordIonGrid : ContentPage
{
	public BindableAccordIonGrid()
	{
		InitializeComponent();
	}

    private void addItem_Clicked(object sender, EventArgs e)
    {
        var item = new Model();
        item.Name = "Added Header";
        item.Description = "Added Content";
        viewModel.Info.Add(item);
    }
}
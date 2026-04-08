using Syncfusion.Maui.Accordion;

namespace MAUIExpander;

public partial class ES_823716 : ContentPage
{
	public ES_823716()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		accordion.Items.Add(GenerateInvoiceHeaderAccordion());
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
		accordion.Items[0]= GenerateInvoiceHeaderAccordion();
	}

	private void Button_Clicked_2(object sender, EventArgs e)
	{
		accordion.Items.Remove(accordion3);
	}

	private void Button_Clicked_3(object sender, EventArgs e)
	{
		accordion.Items.Insert(0, GenerateInvoiceHeaderAccordion());
	}

	private AccordionItem GenerateInvoiceHeaderAccordion()
	{
		var item = new AccordionItem();
		var headerGrid = new Grid() { Padding = new Thickness(10, 0, 0, 10) ,HeightRequest =60 };
		var headerLabel = new Label() { TextColor = Color.FromHex("#495F6E"), Text = "Invoice Date", HeightRequest = 50, VerticalTextAlignment = TextAlignment.Center };
		headerGrid.Children.Add(headerLabel);

		var contentGrid = new Grid() { Padding = new Thickness(10, 0, 0, 10), BackgroundColor = Color.FromHex("#FFFFFF") };
		var contentLabel = new Label() { TextColor = Color.FromHex("#303030"), Text = "11.03 AM, 15 January 2019", HeightRequest = 50, VerticalTextAlignment = TextAlignment.Center };
		contentGrid.Children.Add(contentLabel);

		item.Header = headerGrid;
		item.Content = contentGrid;
		return item;
	}

	private void Button_Clicked_5(object sender, EventArgs e)
	{
		accordion.Items.Clear();
		accordion.Items.Add(GeneratePaymentDetailsAccordion());
	}

	private void Button_Clicked_4(object sender, EventArgs e)
	{
		accordion.Items.Move(0, 1);
	}
	private AccordionItem GeneratePaymentDetailsAccordion()
	{
		var item = new AccordionItem();
		var headerGrid = new Grid() { Padding = new Thickness(10, 0, 10, 10) };
		var headerLabel = new Label() { TextColor = Color.FromHex("#495F6E"), Text = "Payment Details", HeightRequest = 50, VerticalTextAlignment = TextAlignment.Center };
		headerGrid.Children.Add(headerLabel);

		var contentGrid = new Grid() { Padding = new Thickness(10, 0, 10, 10), BackgroundColor = Color.FromHex("#FFFFFF") };
		contentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
		contentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
		contentGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

		contentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
		contentGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

		var contentLabel0 = new Label() { TextColor = Color.FromHex("#303030"), Text = "Card Payment" };
		var contentLabel1 = new Label() { TextColor = Color.FromHex("#303030"), Text = "Third-Party coupons" };
		var contentLabel2 = new Label() { TextColor = Color.FromHex("#303030"), Text = "Total Amount Paid", FontAttributes = FontAttributes.Bold };
		var contentLabel3 = new Label() { TextColor = Color.FromHex("#303030"), Text = "$31,000.00", HorizontalTextAlignment = TextAlignment.End };
		var contentLabel4 = new Label() { TextColor = Color.FromHex("#303030"), Text = "$5,000.00", HorizontalTextAlignment = TextAlignment.End };
		var contentLabel5 = new Label() { TextColor = Color.FromHex("#303030"), Text = "$36,000.00", HorizontalTextAlignment = TextAlignment.End, FontAttributes = FontAttributes.Bold };


		contentGrid.Add(contentLabel0, 0, 0);
		contentGrid.Add(contentLabel1, 0, 1);
		contentGrid.Add(contentLabel2, 0, 2);
		contentGrid.Add(contentLabel3, 1, 0);
		contentGrid.Add(contentLabel4, 1, 1);
		contentGrid.Add(contentLabel5, 1, 2);

		item.Header = headerGrid;
		item.Content = contentGrid;
		return item;
	}

	private void Button_Clicked_6(object sender, EventArgs e)
	{
		accordion.Items.Add(GenerateInvoiceHeaderAccordion());
		accordion.Items.Add(GeneratePaymentDetailsAccordion());
	}

	private void Button_Clicked_7(object sender, EventArgs e)
	{
		accordion.Items.Remove(accordion.Items[accordion.Items.Count-1]);
	}
}
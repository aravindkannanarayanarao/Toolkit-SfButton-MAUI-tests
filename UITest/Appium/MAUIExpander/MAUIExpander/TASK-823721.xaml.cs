using Syncfusion.Maui.Expander;
using Syncfusion.Maui.ListView;
using Syncfusion.Maui.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUIExpander
{
    public partial class TASK_823721 : ContentPage
    {
        SfListView listView1;
        SfListView listViewB;
        SfPopup popup;
        SfExpander expander;
        public TASK_823721()
        {
            InitializeComponent();
        }

        //public ContentProp()
        //{
        //    InitializeComponent();

        //    #region IsExpanded
        //    //IsExpanded set OnLoading in code behind
        //    Acc1.IsExpanded = false;
        //    Acc2.IsExpanded = false;
        //    Acc3.IsExpanded = false;
        //    #endregion

        //    #region Content
        //    //Content set OnLoading in code behind
        //    //Grid contentView1 = new Grid();
        //    //contentView1.Padding = new Thickness(10, 10, 10, 10);
        //    //Label label1 = new Label() { Text = "Pacific Veggie pizza is a great choice if you believe more is more. It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives" };
        //    //contentView1.Children.Add(label1);
        //    //Acc1.Content = contentView1;
        //    #endregion

        //    #region ListView
        //    //Set OnLoading Content of expander with SfListView
        //    //BookInfoRepository viewModel = new BookInfoRepository();
        //    //listView1 = new SfListView();
        //    //listView1.ItemSize = 100;
        //    //listView1.ItemsSource = viewModel.BookInfo;
        //    //listView1.ItemTemplate = new DataTemplate(() =>
        //    //{
        //    //    var grid = new Grid();
        //    //    grid.RowDefinitions.Add(new RowDefinition());
        //    //    var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Colors.Teal, FontSize = 21 };
        //    //    bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
        //    //    grid.Children.Add(bookName);
        //    //    return grid;
        //    //});
        //    //ListViewAccordion.Content = listView1;
        //    #endregion

        //    #region Image
        //    //Grid contentView = new Grid();
        //    //contentView.Padding = new Thickness(10, 10, 10, 10);
        //    //Image image = new Image();
        //    //image.Source = "dotnet_bot.png";
        //    //image.HeightRequest = 100;
        //    //image.HorizontalOptions = LayoutOptions.Center;
        //    //contentView.Children.Add(image);
        //    //Acc1.Content = contentView;

        //    #endregion

        //    #region PopUp
        //    //Set OnLoading Content of expander with Popup
        //    //expander = new SfExpander();
        //    //Grid headerView = new Grid();
        //    //headerView.HeightRequest = 50;
        //    //Label label = new Label() { Text = "Popup as Expander Content Z" };
        //    //label.VerticalOptions = LayoutOptions.Center;

        //    //headerView.Children.Add(label);
        //    //expander.Header = headerView;

        //    //Grid contentView = new Grid();
        //    //contentView.Padding = new Thickness(10, 10, 10, 10);
        //    //Button button = new Button() { Text = " CB Show Popup" };
        //    //button.Clicked += show_Clicked;

        //    //contentView.Children.Add(button);
        //    //expander.Content = contentView;

        //    //stack.Children.Add(expander);
        //    #endregion
        //}




        private void AddContent_Clicked(object sender, EventArgs e)
        {
            //Acc1.Content = null;

            //first null already set content and then add new content
            Grid contentView1 = new Grid();
            contentView1.Padding = new Thickness(10, 10, 10, 10);
            Label label1 = new Label() { Text = "Pacific Veggie pizza is a great choice if you believe more is more. It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives" };
            contentView1.Children.Add(label1);
            Acc1.Content = contentView1;

            Grid contentView2 = new Grid();
            contentView2.Padding = new Thickness(10, 10, 10, 10);
            Label label2 = new Label() { Text = "Jerked Chicken Pizza. Indulge in the delectable flavours of spicy Jamaican jerk chicken pieces on a creamy pizza that has been cooked to perfection!" };
            contentView2.Children.Add(label2);
            Acc2.Content = contentView2;

            Grid contentView3 = new Grid();
            contentView3.Padding = new Thickness(10, 10, 10, 10);
            Label label3 = new Label() { Text = "American cheese melts beautifully and has just the right amount of sharpness, making it the perfect all-rounder for a classic cheeseburger." };
            contentView3.Children.Add(label3);
            Acc3.Content = contentView3;

        }

        private void ChangeContent_Clicked(object sender, EventArgs e)
        {
            //ContentLabel1.Text = "Pacific Veggie pizza is a great choice if you believe more is more. It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives";
            //ContentLabel2.Text = "Jerked Chicken Pizza. Indulge in the delectable flavours of spicy Jamaican jerk chicken pieces on a creamy pizza that has been cooked to perfection!";
            ContentLabel3.Text = "American cheese melts beautifully and has just the right amount of sharpness, making it the perfect all-rounder for a classic cheeseburger";


        }

        private void IsExpandedTrue_Clicked(object sender, EventArgs e)
        {
            Acc1.IsExpanded = true;
            Acc2.IsExpanded = true;
            Acc3.IsExpanded = true;
            ListViewAccordion.IsExpanded = true;
            PopUpAccordion.IsExpanded = true;
            ComplexAccordion.IsExpanded = true;
        }
        private void IsExpandedFalse_Clicked(object sender, EventArgs e)
        {
            Acc1.IsExpanded = false;
            Acc2.IsExpanded = false;
            Acc3.IsExpanded = false;
            ListViewAccordion.IsExpanded = false;
            PopUpAccordion.IsExpanded = false;
            ComplexAccordion.IsExpanded = false;
        }

        private void NullContent_Clicked(object sender, EventArgs e)
        {
            Acc1.Content = null;
            Acc2.Content = null;
            Acc3.Content = null;
            ListViewAccordion.Content = null;
            PopUpAccordion.Content = null;
            ComplexAccordion.Content = null;
        }

        private void show_Clicked(object sender, EventArgs e)
        {
            popup = new SfPopup();
            popup.Show();
        }

        private void AddSfListViewAsContent_Clicked(object sender, EventArgs e)
        {
            BookInfoRepository viewModel = new BookInfoRepository();
            listViewB = new SfListView();
            listViewB.ItemSize = 100;
            listViewB.ItemsSource = viewModel.BookInfo;
            listViewB.ItemTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Colors.Teal, FontSize = 21 };
                bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
                grid.Children.Add(bookName);
                return grid;
            });
            Acc1.Content = listViewB;


            //BookInfoRepository viewModel = new BookInfoRepository();
            //listViewB = new ListView();
            //listViewB.ItemsSource = viewModel.BookInfo;
            //listViewB.ItemTemplate = new DataTemplate(() =>
            //{
            //    var grid = new Grid();
            //    grid.RowDefinitions.Add(new RowDefinition());
            //    var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Colors.Teal, FontSize = 21 };
            //    bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
            //    grid.Children.Add(bookName);
            //    return grid;
            //});
            //Acc1.Content = listViewB;

        }

        private void AddImageAsContent_Clicked(object sender, EventArgs e)
        {
            Grid contentView = new Grid();
            contentView.Padding = new Thickness(10, 10, 10, 10);
            Image image = new Image();
            image.Source = "dotnet_bot.png";
            image.HeightRequest = 100;
            image.HorizontalOptions = LayoutOptions.Center;
            contentView.Children.Add(image);
            Acc1.Content = contentView;

        }

        private void AddPopUpAsContent_Clicked(object sender, EventArgs e)
        {
            Grid contentView = new Grid();
            contentView.Padding = new Thickness(10, 10, 10, 10);
            Button button = new Button() { Text = " CB Show Popup" };
            button.HeightRequest = 50;
            button.Clicked += show_Clicked;

            contentView.Children.Add(button);
            Acc1.Content = contentView;

        }
    }
}
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
    public partial class ContentIsExpanded : ContentPage
    {
        SfListView listView1;
        SfPopup popup;
        SfExpander expander;
        public ContentIsExpanded()
        {
            InitializeComponent();

#region IsExpanded
            //IsExpanded set OnLoading in code behind
            Exp1.IsExpanded = true;
            Exp2.IsExpanded = false;
            Exp3.IsExpanded = true;
#endregion

#region Content
            //Content set OnLoading in code behind
            //Grid contentView1 = new Grid();
            //contentView1.Padding = new Thickness(10, 10, 10, 10);
            //Label label1 = new Label() { Text = "Pacific Veggie pizza is a great choice if you believe more is more. It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives" };
            //contentView1.Children.Add(label1);
            //Exp1.Content = contentView1;
#endregion


            
#region ListView
            //Set OnLoading Content of expander with SfListView
            //BookInfoRepository viewModel = new BookInfoRepository();
            //listView1 = new SfListView();
            //listView1.ItemSize = 100;
            //listView1.ItemsSource = viewModel.BookInfo;
            //listView1.ItemTemplate = new DataTemplate(() => {
            //    var grid = new Grid();
            //    grid.RowDefinitions.Add(new RowDefinition());
            //    var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Colors.Teal, FontSize = 21 };
            //    bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
            //    grid.Children.Add(bookName);
            //    return grid;
            //});
            //ListViewExpander.Content = listView1;
#endregion
            

            
 #region PopUp
            //Set OnLoading Content of expander with Popup
            //expander = new SfExpander();
            //Grid headerView = new Grid();
            //headerView.HeightRequest = 50;
            //Label label = new Label() { Text = "Popup as Expander Content" };
            //headerView.Children.Add(label);
            //expander.Header = headerView;

            //Grid contentView = new Grid();
            //contentView.Padding = new Thickness(10, 10, 10, 10);
            //Button button = new Button() { Text = " CB Show Popup"};
            //button.Clicked += show_Clicked;

            //contentView.Children.Add(button);
            //expander.Content = contentView;

            //stack.Children.Add(expander);
#endregion
        }




        private void AddContent_Clicked(object sender, EventArgs e)
        {

            //first null already set content and then add new content
            Grid contentView1 = new Grid();
            contentView1.Padding = new Thickness(10, 10, 10, 10);
            Label label1 = new Label() { Text = "Pacific Veggie pizza is a great choice if you believe more is more. It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives" };
            contentView1.Children.Add(label1);
            Exp1.Content = contentView1;

            Grid contentView2 = new Grid();
            contentView2.Padding = new Thickness(10, 10, 10, 10);
            Label label2 = new Label() { Text = "Jerked Chicken Pizza. Indulge in the delectable flavours of spicy Jamaican jerk chicken pieces on a creamy pizza that has been cooked to perfection!" };
            contentView2.Children.Add(label2);
            Exp2.Content = contentView2;

            Grid contentView3 = new Grid();
            contentView3.Padding = new Thickness(10, 10, 10, 10);
            Label label3 = new Label() { Text = "American cheese melts beautifully and has just the right amount of sharpness, making it the perfect all-rounder for a classic cheeseburger." };
            contentView3.Children.Add(label3);
            Exp3.Content = contentView3;

        }

        private void ChangeContent_Clicked(object sender, EventArgs e)
        {
            ContentLabel1.Text = "Pacific Veggie pizza is a great choice if you believe more is more. It has (almost) everything: roasted red peppers, baby spinach, onions, mushrooms, tomatoes, and black olives";
            //ContentLabel2.Text = "Jerked Chicken Pizza. Indulge in the delectable flavours of spicy Jamaican jerk chicken pieces on a creamy pizza that has been cooked to perfection!";
            ContentLabel3.Text = "American cheese melts beautifully and has just the right amount of sharpness, making it the perfect all-rounder for a classic cheeseburger";
            
                
        }

        private void IsExpandedTrue_Clicked(object sender, EventArgs e)
        {
            Exp1.IsExpanded = true;
            Exp2.IsExpanded = true;
            Exp3.IsExpanded = true;
            ListViewExpander.IsExpanded = true;
            PopUpExpander.IsExpanded = true;
        }
        private void IsExpandedFalse_Clicked(object sender, EventArgs e)
        {
            Exp1.IsExpanded = false;
            Exp2.IsExpanded = false;
            Exp3.IsExpanded = false;
            ListViewExpander.IsExpanded = false;
            PopUpExpander.IsExpanded = false;
        }

        private void NullContent_Clicked(object sender, EventArgs e)
        {
            Exp1.Content = null;
            Exp2.Content = null;
            Exp3.Content = null;
            ListViewExpander.Content = null;
            PopUpExpander.Content = null;
        }

        private void show_Clicked(object sender, EventArgs e)
        {
            popup = new SfPopup();
            popup.Show();
        }

        private void AddSfListViewAsContent_Clicked(object sender, EventArgs e)
        {
            BookInfoRepository viewModel = new BookInfoRepository();
            listView = new SfListView();
            listView.ItemSize = 100;
            listView.ItemsSource = viewModel.BookInfo;
            listView.ItemTemplate = new DataTemplate(() => {
                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Colors.Teal, FontSize = 21 };
                bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
                grid.Children.Add(bookName);
                return grid;
            });
            Exp1.Content = listView;

        }

        private void AddImageAsContent_Clicked(object sender, EventArgs e)
        {
            Grid contentView = new Grid();
            contentView.Padding = new Thickness(10, 10, 10, 10);
            Image image = new Image();
            image.Source = "dotnet_bot.png";
            image.HeightRequest = 100;
            image.HorizontalOptions= LayoutOptions.Center;
            contentView.Children.Add(image);
            Exp1.Content = contentView;

        }

        private void AddPopUpAsContent_Clicked(object sender, EventArgs e)
        {
            Grid contentView = new Grid();
            contentView.Padding = new Thickness(10, 10, 10, 10);
            Button button = new Button() { Text = " CB Show Popup" };
            button.HeightRequest = 50;
            button.Clicked += show_Clicked;

            contentView.Children.Add(button);
            Exp1.Content = contentView;

        }
    }
}
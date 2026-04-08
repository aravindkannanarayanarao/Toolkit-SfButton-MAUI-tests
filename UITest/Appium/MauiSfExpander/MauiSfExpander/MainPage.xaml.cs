
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Core.Carousel;
using Syncfusion.Maui.Expander;
using Syncfusion.Maui.ListView;
using Syncfusion.Maui.Popup;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiSfExpander
{
    public partial class MainPage : ContentPage
    {
        SfListView listViewB;
        SfPopup popup;
        
        public MainPage()
        {
            InitializeComponent();
            BookInfoRepository viewModel = new BookInfoRepository();
            expander.IsExpanded = true;
            
           
            //expander.Header = null;
            // expander.Content = null;


        }
        public class BookInfo : INotifyPropertyChanged
        {
            private string bookName;
            private string bookDesc;

            public string BookName
            {
                get { return bookName; }
                set
                {
                    bookName = value;
                    OnPropertyChanged("BookName");
                }
            }

            public string BookDescription
            {
                get { return bookDesc; }
                set
                {
                    bookDesc = value;
                    OnPropertyChanged("BookDescription");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged(string name)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public class BookInfoRepository
        {
            private ObservableCollection<BookInfo> bookInfo;

            public ObservableCollection<BookInfo> BookInfo
            {
                get { return bookInfo; }
                set { this.bookInfo = value; }
            }

            public BookInfoRepository()
            {
                GenerateBookInfo();
            }

            internal void GenerateBookInfo()
            {
                bookInfo = new ObservableCollection<BookInfo>();
                bookInfo.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is a programming paradigm" });
                bookInfo.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions" });

            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.Start;
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.End;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            expander.HeaderIconPosition = Syncfusion.Maui.Expander.ExpanderIconPosition.None;
           
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            expander.Header = null;        
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            expander.HeaderIconColor = Colors.Red;
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            expander.HeaderBackground = Brush.Pink;
        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            
            Grid grid = new Grid();
            Label label = new Label() { Text = "Expander Header Changed" };
            grid.Children.Add(label);  
            expander.Header = grid;
        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            
            if (expander.IsExpanded == true)
            {
                expander.IsExpanded = false;
            }
            else
            {
                expander.IsExpanded = true;
            }
        }

        private void Button_Clicked_8(object sender, EventArgs e)
        {
            HorizontalStackLayout grid = new HorizontalStackLayout ();
            Image image = new Image() { Source = "dotnet_bot.png", HeightRequest = 30, WidthRequest = 50 };
            Label label = new Label() { Text = "Header Set On Runtime",VerticalTextAlignment=TextAlignment.Center};
            grid.Children.Add(image);
            grid.Children.Add(label);
            expander.Header = grid;
        }

        private void Button_Clicked_9(object sender, EventArgs e)
        {
            Grid grid = new Grid();
            
            Label label = new Label() { Text = "Content Set On Runtime" };
            grid.Children.Add(label);
            expander.Content = grid;

            
        }

        private void Button_Clicked_10(object sender, EventArgs e)
        {
            //SfExpander expander = new SfExpander(); 
            expander.IsExpanded = true;
            Grid grid1 = new Grid();

            Label label1 = new Label() { Text = "Full Content Change And Expanded" };
            grid1.Children.Add(label1);
            expander.Content = grid1;
        }

        private void Button_Clicked_11(object sender, EventArgs e)
        {
            //SfExpander expander = new SfExpander();
            
            Grid grid2 = new Grid();

            Label label2 = new Label() { Text = "Full Content Change And Collapsed" };
            grid2.Children.Add(label2);
            expander.Content = grid2;
            expander.IsExpanded = false;
        }

        private void Button_Clicked_12(object sender, EventArgs e)
        {
            expander.IsExpanded = true;
            Grid grid1 = new Grid();

            Label label1 = new Label() { Text = "Content Text Changed" };
            grid1.Children.Add(label1);
            expander.Content = grid1;
        }

        private void Button_Clicked_13(object sender, EventArgs e)
        {
            expander.Content = null;
        }

        private void Button_Clicked_14(object sender, EventArgs e)
        {
            expander.IsExpanded=true;
            expander.Content = null;
        }

        private void Button_Clicked_15(object sender, EventArgs e)
        {
            expander.IsExpanded = false;
            expander.Content = null;
        }

        private void Button_Clicked_16(object sender, EventArgs e)
        {
            BookInfoRepository viewModel = new BookInfoRepository();
            listViewB = new SfListView();
            listViewB.ItemSize = 100;
            listViewB.ItemsSource = viewModel.BookInfo;
            listViewB.ItemTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition());
                var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Colors.Teal, FontSize = 15 };
                bookName.SetBinding(Label.TextProperty, new Binding("BookName"));
                grid.Children.Add(bookName);
                return grid;
            });
            expander.Content = listViewB;
        }

        private void Button_Clicked_17(object sender, EventArgs e)
        {
            Grid contentView = new Grid();
            contentView.Padding = new Thickness(10, 10, 10, 10);
            Button button = new Button() { Text = "Click To Show Popup" };
            button.HeightRequest = 50;
            button.Clicked += show_Clicked;

            contentView.Children.Add(button);
            expander.Content = contentView;

        }

        private void show_Clicked(object? sender, EventArgs e)
        {
            popup = new SfPopup();
            popup.Show();
        }

        private void Button_Clicked_18(object sender, EventArgs e)
        {
            Grid contentView = new Grid();
            contentView.Padding = new Thickness(10, 10, 10, 10);
            Image image = new Image();
            image.Source = "dotnet_bot.png";
            image.HeightRequest = 100;
            image.HorizontalOptions = LayoutOptions.Center;
            contentView.Children.Add(image);
            expander.Content = contentView;
        }

        private async void Button_Clicked_19(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Animation());
        }

        private async void Button_Clicked_20(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlowDirectionPage());
        }

        private async void Button_Clicked_21(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NullPage());
        }

        private async void Button_Clicked_22(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NullPage1());
        }

        private async void Button_Clicked_23(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentSetLoadingPage());
        }

        private async void Button_Clicked_24(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContentExpanded());
        }

        private async void Button_Clicked_25(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContentCollapsed());
        }

        private async void Button_Clicked_26(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewLoading());
        }

        private void Button_Clicked_27(object sender, EventArgs e)
        {
            expander.FlowDirection = FlowDirection.RightToLeft;
        }

        private async void Button_Clicked_28(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageOnLoadingPage());
        }

        private async void Button_Clicked_29(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PopupOnLoadingPage());
        }

        private async void Button_Clicked_30(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlowDirectionParent());
        }
    }

}

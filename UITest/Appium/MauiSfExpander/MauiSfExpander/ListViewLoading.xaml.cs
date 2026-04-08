using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiSfExpander;

public partial class ListViewLoading : ContentPage
{
    SfListView listViewB;
    public ListViewLoading()
	{
		InitializeComponent();
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

}
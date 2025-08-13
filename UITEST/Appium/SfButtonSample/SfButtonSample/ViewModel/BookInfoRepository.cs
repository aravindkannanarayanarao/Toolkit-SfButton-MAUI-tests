using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SfButtonSample
{
    class BookInfoRepository
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
            bookInfo.Add(new BookInfo() { BookName = "Book1" });
            bookInfo.Add(new BookInfo() { BookName = "Book2" });
            bookInfo.Add(new BookInfo() { BookName = "Book3" });
            bookInfo.Add(new BookInfo() { BookName = "Book4" });
        }
    }   

}

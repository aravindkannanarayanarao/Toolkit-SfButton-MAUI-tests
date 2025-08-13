using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfButtonSample
{
    class BookInfo : INotifyPropertyChanged
    {
        private string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; OnPropertyChanged("BookName"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

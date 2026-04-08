using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakTestSample
{
    public class InvoiceItem : INotifyPropertyChanged
    {
        #region Fields

        private string? itemName;
        private string? itemPrice;

        #endregion

        #region Properties

        public string? ItemName
        {
            get { return itemName; }
            set
            {
                if (itemName != value)
                {
                    itemName = value;
                    this.RaisedOnPropertyChanged("ItemName");
                }
            }
        }
        public string? ItemPrice
        {
            get { return itemPrice; }
            set
            {
                if (itemPrice != value)
                {
                    itemPrice = value;
                    this.RaisedOnPropertyChanged("ItemPrice");
                }
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}

using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemoryLeakTestSample
{
    public class AccordionPageViewModel : BindableBase, INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<InvoiceItem>? ItemInfo { get; set; }

        #endregion

        #region Constructor

        public AccordionPageViewModel()
        {
            ItemInfo = new ObservableCollection<InvoiceItem>();
            for (int i = 0; i < items.Count(); i++)
            {
                var invoiceItem = new InvoiceItem();
                invoiceItem.ItemName = items[i];
                invoiceItem.ItemPrice = prices[i];
                ItemInfo.Add(invoiceItem);
            }
        }

        #endregion

        #region Fields

        string[] items = new string[]
        {
        "2018 Porche Outback",
        "All-Weather Mats",
        "Door Edge Guard Kit",
        "Rear Bumper Cover",
        "Wheel Locks",
        "Gas Full Tank"
        };

        string[] prices = new string[]
        {
            "$35,705.00",
            "$101.00",
            "$162.00",
            "$107.00",
            "$81.00",
            "$64.00"
        };

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}

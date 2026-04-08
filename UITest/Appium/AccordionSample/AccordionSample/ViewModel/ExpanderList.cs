using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionSample
{
    public class ExpanderList
    {
        private ObservableCollection<string> _pages;
        public ObservableCollection<string> Pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                
            }
        }
        public ObservableCollection<ExpanderProperties> ExpanderItems { get; set; }
        public ExpanderList()
        {
            Pages = new ObservableCollection<string>
            {
                "Page 1",
                "Page 23456",
                "Page 3"
            };
            ExpanderItems = new ObservableCollection<ExpanderProperties>();
            ExpanderItems.Add(new ExpanderProperties { IsExpanded = true });
            ExpanderItems.Add(new ExpanderProperties { IsExpanded = false });
        }
    }
}

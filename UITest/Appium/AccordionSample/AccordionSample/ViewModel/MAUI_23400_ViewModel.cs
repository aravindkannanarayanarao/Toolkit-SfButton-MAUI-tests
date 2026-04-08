using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionSample
{
    public class MAUI_23400_ViewModel
    {
        private List<ContentView>? contentPages;
        public List<ContentView>? ContentPages
        {
            get { return contentPages; }
            set { this.contentPages = value; }
        }

        public MAUI_23400_ViewModel()
        {
            ContentPages = new List<ContentView>();

            var page1 = new Page1();
            var page2 = new Page2();
            var page3 = new Page3();
            var page4 = new Page1();

            ContentPages.Add(page1);
            ContentPages.Add(page2);
            ContentPages.Add(page3);
            ContentPages.Add(page4);
        }
    }

}

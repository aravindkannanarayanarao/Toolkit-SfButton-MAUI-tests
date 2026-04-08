using Syncfusion.Maui.Accordion;
using Syncfusion.Maui.Expander;
using System.Collections.ObjectModel;

namespace CRBugs
{
    public partial class Header : ContentPage
    {
        public Header()
        {
            InitializeComponent();

        }





        private void Button_Clicked(object sender, EventArgs e)
        {
            //accordion.ExpandMode = Syncfusion.Maui.Accordion.AccordionExpandMode.MultipleOrNone;          
            // accordion.AnimationEasing = ExpanderAnimationEasing.SinOut;

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            // accordion.ItemSpacing = 200;
            //accordion.AutoScrollPosition = Syncfusion.Maui.Accordion.AccordionAutoScrollPosition.Top;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            //accordion.HeaderIconPosition = ExpanderIconPosition.End;
            //accordion.AnimationDuration = 500;

            //accordion.Items = new ObservableCollection<AccordionItem>
            //{
            //    new AccordionItem
            //    {
            //        Header = new Label { Text = "New Header" },
            //        Content = new Label { Text = "New content dynamically set." }
            //    }
            //};
        }
    }
}

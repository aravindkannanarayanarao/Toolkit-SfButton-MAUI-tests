using Syncfusion.Maui.Accordion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUIExpander
{
    public partial class TASK_825141 : ContentPage
    {
        public TASK_825141()
        {
            InitializeComponent();
            //accordion.Collapsed += Accordion_Collapsed;
            //accordion.Collapsing += Accordion_Collapsing;
            //accordion.Expanded += Accordion_Expanded;
            //accordion.Expanding += Accordion_Expanding;
        }

        private void HookEvents_Clicked(object sender, EventArgs e)
        {
            accordion.Collapsed += Accordion_Collapsed;
            accordion.Collapsing += Accordion_Collapsing;
            accordion.Expanded += Accordion_Expanded;
            accordion.Expanding += Accordion_Expanding;
        }

        private void Accordion_Expanded(object sender, Syncfusion.Maui.Accordion.ExpandedAndCollapsedEventArgs e)
        {
            headerlabel3.BackgroundColor = Colors.Red;
            var value = e.Index.ToString();
            DisplayAlert("Expanded Event triggered Index:", value, "ok");
        }
           
        private void Accordion_Expanding(object sender, Syncfusion.Maui.Accordion.ExpandingAndCollapsingEventArgs e)
        {
            if(e.Index == 1)
            {
               // e.Cancel = true;
            }
            
            var value = e.Index.ToString();
            DisplayAlert("Expanding Event triggered Index:", value, "ok");
        }

        private void Accordion_Collapsing(object sender, Syncfusion.Maui.Accordion.ExpandingAndCollapsingEventArgs e)
        {
            if (e.Index == 2)
            {
               // e.Cancel = true;
            }
            var value = e.Index.ToString();
            DisplayAlert("Collapsing Event triggered Index:", value, "ok");
        }

        private void Accordion_Collapsed(object sender, Syncfusion.Maui.Accordion.ExpandedAndCollapsedEventArgs e)
        {
            var value = e.Index.ToString();
            DisplayAlert("Collapsed Event triggered Index:", value, "ok");
        }

        private void AccItem1IsExpandedTrue_Clicked(object sender, EventArgs e)
        {
            AccordionItem1.IsExpanded = true;
        }

        private void AccItem1IsExpandedFalse_Clicked(object sender, EventArgs e)
        {
            AccordionItem1.IsExpanded = false;
        }

        private void AccItem2IsExpandedTrue_Clicked(object sender, EventArgs e)
        {
            
            AccordionItem2.IsExpanded = true;
        }

        private void AccItem2IsExpandedFalse_Clicked(object sender, EventArgs e)
        {
           
             AccordionItem2.IsExpanded = false;
        }
    }
}
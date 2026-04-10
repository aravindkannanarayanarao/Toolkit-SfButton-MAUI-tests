using Syncfusion.Maui.Expander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUIExpander
{
    public partial class MAUI_5344 : ContentPage
    {
        public MAUI_5344()
        {
            InitializeComponent();

            expander.Expanding += Expander_Expanding;   
            expander.Expanded += Expander_Expanded;
            expander.Collapsing += Expander_Collapsing;
            expander.Collapsed += Expander_Collapsed;
        }

        private void Expander_Collapsed(object sender, ExpandedAndCollapsedEventArgs e)
        {
            //label1.Text = "Burger and Pizza";
            var ex = sender as SfExpander;
            ex.Header.BackgroundColor = Colors.Yellow;
        }

        private void Expander_Collapsing(object sender, ExpandingAndCollapsingEventArgs e)
        {
            expander.AnimationDuration = 500;
            expander.Header.BackgroundColor = Colors.GreenYellow;
            //e.Cancel = true;
        }

        private void Expander_Expanded(object sender, ExpandedAndCollapsedEventArgs e)
        {
            //label1.Text = "Veg Pizza";
            var ex = sender as SfExpander;
            ex.Header.BackgroundColor = Colors.Fuchsia;
        }

        private void Expander_Expanding(object sender, ExpandingAndCollapsingEventArgs e)
        {
            expander.Header.BackgroundColor = Colors.Pink;
            // e.Cancel = true;
        }

        private void expander2_Collapsed(object sender, ExpandedAndCollapsedEventArgs e)
        {
            label2.Text = "Burger and Pizza";
            var ex = sender as SfExpander;
            ex.Header.BackgroundColor = Colors.Yellow;
        }

        private void expander2_Collapsing(object sender, ExpandingAndCollapsingEventArgs e)
        {
            expander2.AnimationDuration = 500;
            expander2.Header.BackgroundColor = Colors.GreenYellow;
            //e.Cancel = true;
        }

        private void expander2_Expanded(object sender, ExpandedAndCollapsedEventArgs e)
        {
            var ex = sender as SfExpander;
            ex.Header.BackgroundColor = Colors.Ivory;
        }

        private void expander2_Expanding(object sender, ExpandingAndCollapsingEventArgs e)
        {
            expander2.Header.BackgroundColor = Colors.Pink;
           // e.Cancel = true;
        }

        private void WireEventforExpander3_Clicked(object sender, EventArgs e)
        {
            expander3.Collapsed += Expander_Collapsed;
            expander3.Collapsing += Expander_Collapsing;
            expander3.Expanded += Expander_Expanded;
            expander3.Expanding += Expander_Expanding;
        }


        private void NullHeader_Clicked(object sender, EventArgs e)
        {
            expander.Header = null;
            expander2.Header = null;
            expander3.Header = null;
        }
        private void NullContent_Clicked(object sender, EventArgs e)
        {
            expander.Content = null;
            expander2.Content = null;
            expander3.Content = null;
        }
    }
}
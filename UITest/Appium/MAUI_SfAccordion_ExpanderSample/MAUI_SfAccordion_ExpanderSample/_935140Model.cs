//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Diagnostics;
//using Microsoft.Maui.Graphics;
using Microsoft.Maui.Primitives;
using Microsoft.Maui.Layouts;
using Syncfusion.Maui.Expander;

namespace MAUIExpander
{
    public partial class _935140 : ContentPage
    {
        
        public _935140()
        {
            InitializeComponent();
        	BindingContext = viewModel;
        }

        private void ScrollStateChanged(object sender, Syncfusion.Maui.ListView.ScrollStateChangedEventArgs e)
        {
			if (e.ScrollState != Syncfusion.Maui.ListView.ListViewScrollState.Idle)
			{
				for (int i=0; i < viewModel.BookInfo.Count; i++)
				{
					viewModel.BookInfo[i].Duration = 0;
				}
			}
			else
			{
				for (int i=0; i < viewModel.BookInfo.Count; i++)
				{
					viewModel.BookInfo[i].Duration = 300;
				}
			} 
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			viewModel.BookInfo[0].Duration = 0;
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
			viewModel.BookInfo[0].Duration = 8000;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            viewModel.BookInfo[0].Expanded = true;
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            viewModel.BookInfo[0].Expanded = false;
        }
    }
}
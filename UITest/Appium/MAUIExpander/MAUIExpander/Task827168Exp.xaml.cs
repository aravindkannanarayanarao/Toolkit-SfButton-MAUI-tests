
using Syncfusion.Maui.Expander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUIExpander
{
    public partial class Task827168Exp : ContentPage
    {
        Label l1;
        Label l2;
        public Task827168Exp()
        {
            InitializeComponent();

            //SfExpander expander = new SfExpander();

            //l1 = new Label()
            //{
            //    Text = "Veg Pizza" , TextColor = Colors.Black
            //};
            //l2 = new Label()
            //{
            //    Text = "Veg pizza is prepared with the items that meet vegetarian standards by not including any meat or animal tissue products."
            //    ,
            //    TextColor = Colors.Black
            //};
            //Grid Headerview = new Grid();
            //Headerview.Children.Add(l1);

            //Grid contentview = new Grid();
            //contentview.Children.Add(l2);

            //expander.Header = Headerview;
            //expander.Content = contentview;

            //VisualStateGroupList visualStateGroupList = new VisualStateGroupList();
            //VisualStateGroup commonStateGroup = new VisualStateGroup();

            //VisualState expanded = new VisualState
            //{
            //    Name = "Expanded"
            //};
            //expanded.Setters.Add(new Setter { Property = SfExpander.HeaderBackgroundProperty, Value = Colors.Red });
            //expanded.Setters.Add(new Setter { Property = SfExpander.HeaderBackgroundProperty, Value = Colors.Red });

            //VisualState collapsed = new VisualState
            //{
            //    Name = "Collapsed"
            //};
            //collapsed.Setters.Add(new Setter { Property = SfExpander.HeaderBackgroundProperty, Value = Colors.Green });
            //collapsed.Setters.Add(new Setter { Property = SfExpander.HeaderBackgroundProperty, Value = Colors.Green });

            //commonStateGroup.States.Add(expanded);
            //commonStateGroup.States.Add(collapsed);

            //visualStateGroupList.Add(commonStateGroup);
            //VisualStateManager.SetVisualStateGroups(expander, visualStateGroupList);
            //this.Content = expander;
        }

        private void IsExpandedTrue_Clicked(object sender, EventArgs e)
        {
           expander.IsExpanded = true;
           
        }

        private void IsExpandedFalse_Clicked(object sender, EventArgs e)
        {
           expander.IsExpanded = false;
           
        }
    }
}
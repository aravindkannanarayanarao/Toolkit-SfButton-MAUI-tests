using Syncfusion.Maui.Accordion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MAUIExpander
{
    public partial class TASK_827168 : ContentPage
    {
       // SfAccordion accordion;
        public TASK_827168()
        {
            InitializeComponent();
          // InitializeAccordionItems();
           // this.Content = accordion;
        }

        private void IsExpandedTrue_Clicked(object sender, EventArgs e)
        {
            AccItem1.IsExpanded = true;
            AccItem2.IsExpanded = true;
        }

        private void IsExpandedFalse_Clicked(object sender, EventArgs e)
        {
            AccItem1.IsExpanded = false;
            AccItem2.IsExpanded = false;
        }

        private void InitializeAccordionItems()
        {
            accordion = new SfAccordion();
            accordion.Items.Add(GenerateAccordionItem());
        }

        public AccordionItem GenerateAccordionItem()
        {
            var item = new AccordionItem();




            var headerGrid = new Grid() { Padding = new Thickness(10, 0, 0, 10) };
            var headerLabel = new Label() { TextColor = Color.FromHex("#495F6E"), Text = "Invoice Date", HeightRequest = 50, VerticalTextAlignment = TextAlignment.Center };
            headerGrid.Children.Add(headerLabel);

            var contentGrid = new Grid() { Padding = new Thickness(10, 0, 0, 10), BackgroundColor = Color.FromHex("#FFFFFF") };
            var contentLabel = new Label() { TextColor = Color.FromHex("#303030"), Text = "11.03 AM, 15 January 2019", HeightRequest = 50, VerticalTextAlignment = TextAlignment.Center };
            contentGrid.Children.Add(contentLabel);

            item.Header = headerGrid;
            item.Content = contentGrid;


            //item.IconColor = Color.Accent;
            VisualStateGroupList visualStateGroupList = new VisualStateGroupList();
            VisualStateGroup commonStateGroup = new VisualStateGroup();

            VisualState expanded = new VisualState
            {
                Name = "Expanded"
            };
            expanded.Setters.Add(new Setter { Property = AccordionItem.HeaderBackgroundProperty, Value = Colors.Red });
            expanded.Setters.Add(new Setter { Property = AccordionItem.HeaderBackgroundProperty, Value = Colors.Red });

            VisualState collapsed = new VisualState
            {
                Name = "Collapsed"
            };
            collapsed.Setters.Add(new Setter { Property = AccordionItem.HeaderBackgroundProperty, Value = Colors.Green });
            collapsed.Setters.Add(new Setter { Property = AccordionItem.HeaderBackgroundProperty, Value = Colors.Green });

            commonStateGroup.States.Add(expanded);
            commonStateGroup.States.Add(collapsed);

            visualStateGroupList.Add(commonStateGroup);
            VisualStateManager.SetVisualStateGroups(item, visualStateGroupList);
            return item;
        }
    }
}
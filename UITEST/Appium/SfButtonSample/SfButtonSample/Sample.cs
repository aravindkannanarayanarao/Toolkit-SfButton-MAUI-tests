using System;
using Microsoft.Maui.Controls;

namespace SfButtonSample
{
    public class Sample : ContentPage
    {

        string name;
        public Sample()
        {
            VerticalStackLayout stacklayout = new VerticalStackLayout();
            var masterEntry = new Entry();
            masterEntry.AutomationId = "Entry";
            masterEntry.TextChanged += MasterEntry_TextChanged;
            stacklayout.Children.Add(masterEntry);
            masterEntry.Unfocused += MasterEntry_Unfocused;
            var subEntry = new Entry() { BackgroundColor = Colors.Green };
            subEntry.AutomationId = "subEntry";
            stacklayout.Children.Add(subEntry);
            Content = stacklayout;
        }
        private void MasterEntry_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                var type = Type.GetType("SfButtonSample.SBSample." + name);
                Navigation.PushAsync(Activator.CreateInstance(type) as ContentPage);
            }
            catch
            {
                try
                {
                    var type = Type.GetType("SfButtonSample.Features." + name);
                    Navigation.PushAsync(Activator.CreateInstance(type) as ContentPage);
                }
                catch
                {
                    var type = Type.GetType("SfButtonSample.Bugs." + name);
                    Navigation.PushAsync(Activator.CreateInstance(type) as ContentPage);

                }
            }
        }



        private void MasterEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = (sender as Entry).Text;
        }

    }
}

using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace MAUIExpander
{  
    public class FoodSelectionIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "\ue72D";
            }
            else
            {
                return "\ue72E";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

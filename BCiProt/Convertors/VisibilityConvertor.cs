using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BCiProt
{
    /// <summary>
    /// The imageButton control has an image and text so then if the control doesn't have any image, 
    /// then we have an image control without any image (Blank Space). 
    /// To prevent this issue, I created a simple convertor to check image value. 
    /// If the image value is null, the image box will go invisible.
    /// WPF has provided a feature for this solution and calls it Convertor. 
    /// This class inherits from IValueConverter and, finally, implements it.
    /// </summary>
    public class VisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using ultra_comment_viewer.src.commons;

namespace ultra_comment_viewer.src.view.converter
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? UIStrings.DISCONNECT_BUTTON : UIStrings.CONNECT_BUTTON;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
           
        }
    }
}

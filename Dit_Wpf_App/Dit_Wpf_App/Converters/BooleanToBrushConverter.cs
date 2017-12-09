using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Dit_Wpf_App.Converters
{
    public class BooleanToBrushConverter : BaseValueConverter<BooleanToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterString = parameter as string;
            // Check if parameter is null or empty and if it is, return transparent brush.
            if (string.IsNullOrEmpty(parameterString)) return new SolidColorBrush();

            // Get seperate parameters.
            var parameters = parameterString.Split('|');
            var param1 = parameters[0];
            var param2 = parameters[1];
            
            // If value is not a boolean return transparent brush.
            if (!(value is bool active)) return new SolidColorBrush();

            // Check if parameter 1 can be converted into brush and if it can't, return transparent brush.
            if (!new BrushConverter().CanConvertFrom(param1.GetType()) && param1 != "transparent") return new SolidColorBrush();

            // Check if parameter 2 can be converted into brush and if it can't, return transparent brush.
            if (!new BrushConverter().CanConvertFrom(param2.GetType()) && param2 != "transparent") return new SolidColorBrush();

            var brush1 = param1 == "transparent" ? new SolidColorBrush(): new BrushConverter().ConvertFrom(param1);
            var brush2 = param2 == "transparent" ? new SolidColorBrush() : new BrushConverter().ConvertFrom(param2);
            // Return brush1 if active, return brush2 if not.
            return active ? brush1 : brush2;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

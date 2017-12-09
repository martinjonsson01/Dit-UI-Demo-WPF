using System;
using System.Globalization;
using System.Windows;

namespace Dit_Wpf_App.Converters
{
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class StringToTripBreadcrumbConverter : BaseValueConverter<StringToTripBreadcrumbConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
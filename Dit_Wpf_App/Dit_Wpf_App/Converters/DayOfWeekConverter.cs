using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Dit_Wpf_App.Converters
{
    public class DayOfWeekConverter : BaseValueConverter<DayOfWeekConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var day = value is DayOfWeek week ? week : DayOfWeek.Sunday;
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "M";
                case DayOfWeek.Tuesday:
                    return "T";
                case DayOfWeek.Wednesday:
                    return "O";
                case DayOfWeek.Thursday:
                    return "T";
                case DayOfWeek.Friday:
                    return "F";
                case DayOfWeek.Saturday:
                    return "L";
                case DayOfWeek.Sunday:
                    return "S";
                default:
                    return "";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

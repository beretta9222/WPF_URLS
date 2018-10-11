using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf_Urls.Helpers
{
    public class FontConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int count;
            int.TryParse(values[1].ToString(), out count);
            int avg; //= 150;// (int)parameter;
            int.TryParse(values[0].ToString(), out avg);
            return ((count > avg) ? new SolidColorBrush(Color.FromRgb(0, 150, 0)) : new SolidColorBrush(Color.FromRgb(255, 255, 255)));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Globalization;
using System.Windows.Data;

namespace FNZ.Bomb.Converters
{
    class CountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int retval = 0;

            if (value is System.Collections.ICollection collection)
            {
                retval = collection.Count;
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

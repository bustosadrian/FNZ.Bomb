using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FNZ.Bomb.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;

            flag = value != null;

            if (IsInverse)
            {
                flag = !flag;
            }

            return (flag ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool IsInverse { get; set; }
    }
}

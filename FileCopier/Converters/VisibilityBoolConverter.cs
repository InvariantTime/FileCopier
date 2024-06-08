using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FileCopier.Converters
{
    public class VisibilityBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolValue)
                throw new Exception("Unable to convert to bool");

            return boolValue switch
            {
                true => Visibility.Visible,
                false => Visibility.Hidden
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

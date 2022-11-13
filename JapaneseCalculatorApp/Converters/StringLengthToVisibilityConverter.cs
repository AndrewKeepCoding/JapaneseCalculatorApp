using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
using System;

namespace JapaneseCalculatorApp.Converters;

public class StringLengthToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return ((value as string)?.Length > (parameter is int threshold is true
            ? threshold
            : 0) is true)
                ? Visibility.Visible
                : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
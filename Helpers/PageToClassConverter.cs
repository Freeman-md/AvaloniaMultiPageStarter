using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Controls;
using AvaloniaMultiPageStarter.ViewModels.Layout;

namespace AvaloniaMultiPageStarter.Helpers;

public class PageToClassConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is PageType current && parameter is string target)
        {
            if (Enum.TryParse<PageType>(target, out var parsed) && current == parsed)
                return "active";
        }

        return null!;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}

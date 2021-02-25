using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KittenView.Core.Converters
{
    public class NameFormatValueConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return value + "VND";
        }
    }
}
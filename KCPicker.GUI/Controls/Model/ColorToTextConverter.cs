// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace KCPicker.GUI.Controls.Model
{
    public class ColorToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (!(value is Color))
            //    throw new ArgumentException(nameof(value));

            return GUI.Model.Converters.ColorConverter.ARGBToHexString((Color)(value ?? Colors.Aqua));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KCPicker.GUI.Controls.Model
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((value as bool?) ?? false ?
                Visibility.Visible : Visibility.Hidden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility))
                throw new ArgumentException(nameof(value));

            return (Visibility)value == Visibility.Visible;
        }
    }
}

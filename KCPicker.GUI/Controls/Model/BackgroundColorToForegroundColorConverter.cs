// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace KCPicker.GUI.Controls.Model
{
    public class BackgroundColorToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return Colors.Black;

            if (!(value is Color))
                throw new ArgumentException(nameof(value));

            return CalculateForegroundColor((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static Color CalculateForegroundColor(Color backgoundColor)
        {
            return (backgoundColor.R + backgoundColor.G + backgoundColor.B) >= Constants.RGBThreshold ||
                backgoundColor.A <= Constants.AlphaThreshold ? Colors.Black : Colors.White;
        }
    }
}

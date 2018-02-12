// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;
using MediaConverter = System.Windows.Media.ColorConverter;
using System;

namespace KCPicker.GUI.Model
{
    public static class ColorConverter
    {
        public static MediaColor BGRToRGB(DrawingColor color)
        {
            return MediaColor.FromRgb(color.B, color.G, color.R);
        }

        public static MediaColor RGBToRGB(DrawingColor color)
        {
            return MediaColor.FromRgb(color.R, color.G, color.B);
        }

        public static string ColorToHex(DrawingColor color)
        {
            return ColorToHex(RGBToRGB(color));
        }

        public static string ColorToHex(MediaColor color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static MediaColor HexToColor(string hexColor)
        {
            var color = MediaConverter.ConvertFromString(hexColor) ?? throw new ArgumentException(nameof(hexColor));
            return (MediaColor)color; 
        }


    }
}

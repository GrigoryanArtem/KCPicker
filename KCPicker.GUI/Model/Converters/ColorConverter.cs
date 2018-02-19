// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;
using MediaConverter = System.Windows.Media.ColorConverter;
using System;
using System.Collections.Generic;

namespace KCPicker.GUI.Model.Converters
{
    public static class ColorConverter
    {
        private static Dictionary<ColorConverterMode, Func<MediaColor, string>> mConverters;

        static ColorConverter()
        {
            mConverters = new Dictionary<ColorConverterMode, Func<MediaColor, string>>
            {
                {ColorConverterMode.ARGB_HEX, ARGBToHexString},
                {ColorConverterMode.RGB_HEX, RGBToHexString},
            };
        }

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
            return ARGBToHexString(RGBToRGB(color));
        }

        public static string ARGBToHexString(MediaColor color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static string RGBToHexString(MediaColor color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static string ARGBToString(MediaColor color)
        {
            return $"({color.A}, {color.R}, {color.G}, {color.B})";
        }

        public static string RGBToString(MediaColor color)
        {
            return $"({color.R}, {color.G}, {color.B})";
        }

        public static MediaColor HexToColor(string hexColor)
        {
            var color = MediaConverter.ConvertFromString(hexColor) ?? throw new ArgumentException(nameof(hexColor));
            return (MediaColor)color; 
        }

        public static string ColorToString(MediaColor color, ColorConverterMode converterMode = ColorConverterMode.ARGB_HEX)
        {
            return mConverters[converterMode](color);
        }
    }
}

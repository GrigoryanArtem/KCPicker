// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;

namespace KCPicker.GUI.Model
{
    public static class ColorConverter
    {
        public static MediaColor ConvertBGRToRGB(DrawingColor color)
        {
            return MediaColor.FromRgb(color.B, color.G, color.R);
        }

        public static MediaColor ConvertRGBToRGB(DrawingColor color)
        {
            return MediaColor.FromRgb(color.R, color.G, color.B);
        }

        public static string ConvertToHex(DrawingColor color)
        {
            return ConvertToHex(ConvertRGBToRGB(color));
        }

        public static string ConvertToHex(MediaColor color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}

// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using MediaColor = System.Windows.Media.Color;

namespace KCPicker.GUI.Model
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class ScreenColorPicker
    {
        #region Members

        private static IntPtr dc = GetWindowDC(IntPtr.Zero);

        #endregion

        #region Public methods

        public static MediaColor GetColorFromCursorPosition()
        {
            POINT point;
            GetCursorPos(out point);
            return GetColor(point.X, point.Y);
        }

        public static Bitmap GetBitmapFromCursorPosition(int width, int height)
        {
            POINT p;
            GetCursorPos(out p);

            int leftTopX = p.X - (width / 2);
            int leftTopY = p.Y - (height / 2);

            var bmp = new Bitmap(width, height);

            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            graph.CopyFromScreen(leftTopX, leftTopY, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            return bmp;
        }

        private static MediaColor GetColor(int x, int y)
        {
            uint color = GetPixel(dc, x, y);
            return Converters.ColorConverter.BGRToRGB(Color.FromArgb((int)color));
        }

        #endregion

        #region Private methods

        [DllImport("gdi32")]
        private static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetCursorPos(out POINT pt);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        #endregion
    }
}

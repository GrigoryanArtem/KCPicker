// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KCPicker.GUI.Model
{
    public static class ScreenCapturePainter
    {
        #region Public methods

        public static void DrawScreenCapture(this Canvas canvas, System.Drawing.Bitmap screenCapture)
        {
            canvas.Children.Clear();
            canvas.Background = new SolidColorBrush(Colors.Transparent);

            double step = (Math.Min(canvas.ActualWidth, canvas.ActualHeight)
                - Constants.DefaultPadding) / (double)(canvas.ActualWidth < canvas.ActualHeight ?
                screenCapture.Width : screenCapture.Height);

            double realWidth = step * screenCapture.Width;
            double realHeight = step * screenCapture.Height;

            double xPadding = (canvas.ActualWidth - realWidth) / 2.0;
            double yPadding = (canvas.ActualHeight - realHeight) / 2.0;

            for (int x = 0; x < screenCapture.Width; x++)
                for (int y = 0; y < screenCapture.Height; y++)
                    canvas.Children.Add(CreateSquare((x * step + xPadding, y * step + yPadding), step,
                        ColorConverter.ConvertRGBToRGB(screenCapture.GetPixel(x, y))));

            for (int x = 0; x <= screenCapture.Width; x++)
                canvas.Children.Add(CreateVerticalLine((x * step + xPadding, yPadding), realHeight,
                    (x == screenCapture.Width / 2 || x == screenCapture.Width / 2 + 1)));

            for (int y = 0; y <= screenCapture.Height; y++)
                canvas.Children.Add(CreateHorizontalLine((xPadding, y * step + yPadding), realWidth,
                    (y == screenCapture.Height / 2 || y == screenCapture.Height / 2 + 1)));
        }

        #endregion

        #region Private methods

        private static Rectangle CreateSquare((double X, double Y) leftTop, double sideLength, Color color)
        {
            var resultRectangle = new Rectangle();

            resultRectangle.Fill = new SolidColorBrush(color);

            resultRectangle.Width = sideLength;
            resultRectangle.Height = sideLength;

            Canvas.SetLeft(resultRectangle, leftTop.X);
            Canvas.SetTop(resultRectangle, leftTop.Y);

            return resultRectangle;
        }

        private static Line CreateVerticalLine((double X, double Y) position, double length, bool isBold)
        {
            return CreateLine(position, (position.X, position.Y + length), isBold);
        }

        private static Line CreateHorizontalLine((double X, double Y) position, double length, bool isBold)
        {
            return CreateLine(position, (position.X + length, position.Y), isBold);
        }

        private static Line CreateLine((double X, double Y) startPoint, (double X, double Y) endPoint, bool isBold)
        {
            Line resultLine = new Line();

            resultLine.Stroke = new SolidColorBrush(Colors.Gray);
            resultLine.StrokeThickness = isBold ?
                Constants.BoldThickness : Constants.DefaultThickness;

            resultLine.X1 = startPoint.X;
            resultLine.X2 = endPoint.X;

            resultLine.Y1 = startPoint.Y;
            resultLine.Y2 = endPoint.Y;

            return resultLine;
        }

        #endregion
    }
}

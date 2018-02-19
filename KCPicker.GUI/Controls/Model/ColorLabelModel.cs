// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0


using KCPicker.GUI.Model;
using Prism.Mvvm;
using System.Windows.Media;

namespace KCPicker.GUI.Controls.Model
{
    public class ColorLabelModel : BindableBase
    {
        #region Members

        private Color mColor;

        #endregion

        #region Poperties

        public Color Color
        {
            get
            {
                return mColor;
            }
            set
            {
                mColor = value;

                RaisePropertyChanged(nameof(Color));
                RaisePropertyChanged(nameof(ForegroundColor));
                RaisePropertyChanged(nameof(BackgroundColor));
                RaisePropertyChanged(nameof(ColorName));
            }
        }

        public string ColorName
        {
            get
            {
                return GUI.Model.Converters.ColorConverter.ARGBToHexString(mColor);
            }
        }

        public Brush ForegroundColor
        {
            get
            {
                return new SolidColorBrush(CalculateForegroundColor(mColor));
            }
        }

        public Brush BackgroundColor
        {
            get
            {
                return new SolidColorBrush(mColor);
            }
        }

        #endregion

        #region Private methods

        private Color CalculateForegroundColor(Color backgoundColor)
        {
            return (backgoundColor.R + backgoundColor.G + backgoundColor.B) >= Constants.RGBThreshold ||
                backgoundColor.A <= Constants.AlphaThreshold ? Colors.Black : Colors.White;
        }

        #endregion
    }
}

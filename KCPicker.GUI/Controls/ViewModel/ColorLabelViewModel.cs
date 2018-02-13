// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Controls.Model;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Media;

namespace KCPicker.GUI.Controls.ViewModel
{
    public class ColorLabelViewModel : BindableBase
    {
        #region Members

        private ColorLabelModel mModel = new ColorLabelModel();

        #endregion

        public ColorLabelViewModel()
        {
            mModel.PropertyChanged += (sender, e) => RaisePropertyChanged(e.PropertyName);
        }

        #region Properties

        public Color Color
        {
            get
            {
                return mModel.Color;
            }
            set
            {
                mModel.Color = value;
            }
        }
        public Brush ForegroundColor => mModel.ForegroundColor;
        public Brush BackgroundColor => mModel.BackgroundColor;
        public string ColorName => mModel.ColorName;

        #endregion
    }
}

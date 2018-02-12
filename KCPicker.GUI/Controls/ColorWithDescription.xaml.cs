// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KCPicker.GUI.Controls
{
    /// <summary>
    /// Логика взаимодействия для ColorWithDescription.xaml
    /// </summary>
    public partial class ColorWithDescription : UserControl
    {
        private Color mColor;

        public ColorWithDescription(Color color)
        {
            InitializeComponent();
            ctrlColorLabel.Color = Colors.Black;
        }

        #region DependencyProperties

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorWithDescription));

        #endregion

        #region Events


        #endregion

        #region Properties

        public Color Color
        {
            get
            {
                return mColor;
            }
            set
            {
                mColor = value;

                //ctrlMainGrid.Background = new SolidColorBrush(mColor);
                //ctrlColorTB.Text = GUI.Model.ColorConverter.ColorToHex(mColor);
            }
        }

        #endregion
    }
}

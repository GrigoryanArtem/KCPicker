// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Controls.ViewModel;
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
    /// Логика взаимодействия для ColorLabel.xaml
    /// </summary>
    public partial class ColorLabel : UserControl
    {
        private ColorLabelViewModel mColorLabelVM = new ColorLabelViewModel();

        public ColorLabel()
        {
            InitializeComponent();

            DataContext = mColorLabelVM;
        }

        #region DependencyProperties

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Color), typeof(Color?), typeof(ColorLabel));

        #endregion

        #region Properties

        public Color? Color
        {
            get
            {
                return mColorLabelVM.Color;
            }
            set
            {
                mColorLabelVM.Color = value ?? Colors.Transparent;
            }
        }

        #endregion
    }
}

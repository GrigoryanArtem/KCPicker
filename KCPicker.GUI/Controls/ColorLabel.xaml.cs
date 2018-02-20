// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Controls.ViewModel;
using KCPicker.GUI.Model.Converters;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            DataContext = this;
        }

        #region DependencyProperties

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof(Color), typeof(Color?), typeof(ColorLabel),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty TextModeProperty = DependencyProperty.Register(nameof(TextMode), typeof(ColorConverterMode), typeof(ColorLabel),
            new FrameworkPropertyMetadata(ColorConverterMode.ARGB_HEX, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region Properties

        [Bindable(true)]
        public Color? Color
        {
            get
            {
                return (Color?)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        [Bindable(true)]
        public ColorConverterMode TextMode
        {
            get
            {
                return (ColorConverterMode)GetValue(TextModeProperty);
            }
            set
            {
                SetValue(TextModeProperty, value);
            }
        }

        #endregion
    }
}

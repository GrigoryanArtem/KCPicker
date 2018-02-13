// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System.Windows;
using System.Windows.Controls;

namespace KCPicker.GUI.Controls
{
    /// <summary>
    /// Логика взаимодействия для FocusableТextBox.xaml
    /// </summary>
    public partial class FocusableТextBox : UserControl
    {
        public FocusableТextBox()
        {
            InitializeComponent();
        }

        #region DependencyProperties

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(FocusableТextBox));

        #endregion

        public string Text
        {
            get
            {
                return ctrlTextBox.Text;
            }
            set
            {
                ctrlTextBox.Text = value;
            }
        }
    }
}

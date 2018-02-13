﻿// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KCPicker.GUI.Controls
{
    /// <summary>
    /// Логика взаимодействия для ColorWithDescription.xaml
    /// </summary>
    public partial class ColorLabelWithDescription : UserControl
    {
        public ColorLabelWithDescription()
        {
            InitializeComponent();
        }

        public ColorLabelWithDescription(ColorDescriptionPair colorWithDescription) : this()
        {
            ColorWithDescription = colorWithDescription;
        }

        #region DependencyProperties

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(ColorWithDescription), typeof(ColorDescriptionPair), typeof(ColorLabelWithDescription));

        #endregion

        #region Events


        #endregion

        #region Properties

        public ColorDescriptionPair ColorWithDescription
        {
            get
            {
                return new ColorDescriptionPair(ctrlColorLabel.Color.Value, ctrlDescriptionTextBox.Text);
            }
            set
            {
                ctrlColorLabel.Color = value.Color;
                ctrlDescriptionTextBox.Text = value.Description;
            }
        }

        #endregion
    }
}
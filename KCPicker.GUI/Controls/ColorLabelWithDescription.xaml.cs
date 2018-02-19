// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            //ColorWithDescription = colorWithDescription;
        }

        #region DependencyProperties

        public static readonly DependencyProperty RemoveCommandProperty = DependencyProperty.Register(nameof(RemoveCommand), typeof(ICommand), typeof(ColorLabelWithDescription));
        public static readonly DependencyProperty SelectCommandProperty = DependencyProperty.Register(nameof(SelectCommand), typeof(ICommand), typeof(ColorLabelWithDescription));
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof(Color), typeof(Color?), typeof(ColorLabelWithDescription));

        #endregion

        #region Events


        #endregion

        #region Properties

        //public Color? Color
        //{
        //    get
        //    {
        //        return ctrlColorLabel.Color.Value;
        //    }
        //    set
        //    {
        //        ctrlColorLabel.Color = value;                
        //    }
        //}

        //public ColorDescriptionPair ColorWithDescription
        //{
        //    get
        //    {
        //        return new ColorDescriptionPair(ctrlColorLabel.Color.Value, ctrlDescriptionTextBox.Text);
        //    }
        //    set
        //    {
        //        ctrlColorLabel.Color = value.Color;
        //        ctrlDescriptionTextBox.Text = value.Description;
        //    }
        //}

        public ICommand RemoveCommand
        {
            get
            {
                return ctrlRemoveBTN.Command;
            }
            set
            {
                ctrlRemoveBTN.Command = value;
            }
        }

        public ICommand SelectCommand
        {
            get
            {
                return ctrlSelectBTN.Command;
            }
            set
            {
                ctrlSelectBTN.Command = value;
            }
        }

        #endregion
    }
}

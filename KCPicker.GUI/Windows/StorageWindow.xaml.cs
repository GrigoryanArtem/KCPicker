// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Controls;
using KCPicker.GUI.Model.Storages;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace KCPicker.GUI.Windows
{
    /// <summary>
    /// Логика взаимодействия для StorageWindow.xaml
    /// </summary>
    public partial class StorageWindow : MetroWindow
    {
        public StorageWindow()
        {
            InitializeComponent();

            var colors = ColorsStorageService.Instance.Colors.Colors;

            foreach(var color in colors)
            {
                var cdp = new ColorLabelWithDescription(color);
                cdp.Margin = new Thickness(0, 0, 0, 3);

                ctrlList.Children.Add(cdp);
            }
        }
    }
}

// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Model;
using KCPicker.GUI.Model.Storages;
using KCPicker.GUI.Windows;
using MahApps.Metro.Controls;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KCPicker.GUI
{
    public partial class MainWindow : MetroWindow
    {
        Timer timer = new Timer(Constants.TimerInterval);

        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += OnTick;
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            DrawScreenCapture();
        }

        private void OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            ctrlColorLabel.Color = e.NewValue;
            //ctrlColorLabel.Foreground = new SolidColorBrush(CalculateForegroundColor(e.NewValue));
            //ctrlColorLabel.Text = Model.ColorConverter.ColorToHex(e.NewValue.Value);
        }

        private Color CalculateForegroundColor(Color? backgoundColor)
        {
            if (backgoundColor is null)
                return Colors.Black;

            Color color = backgoundColor.Value;
            return (color.R + color.G + color.B) >= Constants.RGBThreshold ||
                color.A <= Constants.AlphaThreshold ? Colors.Black : Colors.White;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                ctrlCanvas.Visibility = Visibility.Hidden;
                timer.Stop();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift && !timer.Enabled)
            {
                ctrlCanvas.Visibility = Visibility.Visible;
                timer.Start();
            }

            if (e.Key == Key.C && e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
                ctrlColorPicker.SelectedColor = ScreenColorPicker.GetColorFromCursorPosition();
        }

        private void DrawScreenCapture()
        {
            var screenCapture = ScreenColorPicker.GetBitmapFromCursorPosition(
                Properties.Settings.Default.GridWidth, Properties.Settings.Default.GridHeight);
            Dispatcher.Invoke(() => ctrlCanvas.DrawScreenCapture(screenCapture));
        }

        private void OnRightButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
                Clipboard.SetText(ctrlColorPicker.SelectedColorText);
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Topmost = !Topmost;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Topmost = Properties.Settings.Default.Topmost;
            ctrlColorPicker.SelectedColor = Properties.Settings.Default.Color;
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Topmost = Topmost;
            Properties.Settings.Default.Color = ctrlColorPicker.SelectedColor ?? Colors.White;
            Properties.Settings.Default.Save();
            ColorsStorageService.Instance.Save();
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            ColorsStorageService.Instance.Colors.Add(ctrlColorLabel.Color.Value);
        }

        private void OnStorageClick(object sender, RoutedEventArgs e)
        {
            StorageWindow sw = new StorageWindow();

            sw.Owner = this;
            sw.Show();
        }

        private void OnColseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}

// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Model;
using KCPicker.GUI.Model.Storages;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace KCPicker.GUI.Controls.Model
{
    public class ColorsStorageViewerModel : BindableBase
    {
        public ColorsStorageViewerModel()
        {
            ColorsStorageService.Instance.Colors.Colors.CollectionChanged += (sender, e) => RaisePropertyChanged(nameof(Colors));
        }

        public ObservableCollection<ColorLabelWithDescription> Colors
        {
            get
            {
                return new ObservableCollection<ColorLabelWithDescription>(
                    ColorsStorageService.Instance.Colors.Colors.Select(color => new ColorLabelWithDescription(color)));
            }            
        }

        public void RemoveColor(ColorDescriptionPair color)
        {
            ColorsStorageService.Instance.Colors.Remove(color);
        }
    }
}

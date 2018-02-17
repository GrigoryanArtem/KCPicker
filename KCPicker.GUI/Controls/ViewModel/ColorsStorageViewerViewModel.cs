// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using KCPicker.GUI.Controls.Model;
using KCPicker.GUI.Model;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace KCPicker.GUI.Controls.ViewModel
{
    public class ColorsStorageViewerViewModel : BindableBase
    {
        private ColorsStorageViewerModel mModel = new ColorsStorageViewerModel();

        public ColorsStorageViewerViewModel()
        {
            mModel.PropertyChanged += (sender, e) => RaisePropertyChanged(e.PropertyName);

            RemoveCommand = new DelegateCommand<ColorDescriptionPair>(cdp => {
                mModel.RemoveColor(cdp);
            });
        }

        public ObservableCollection<ColorLabelWithDescription> Colors => mModel.Colors;

        public DelegateCommand<ColorDescriptionPair> RemoveCommand { get; }
    }
}

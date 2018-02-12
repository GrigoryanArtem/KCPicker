// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace KCPicker.GUI.Model.Storages
{
    public class ColorsStorageService
    {
        #region Members

        private ColorsStorage mColors;
        private static readonly Lazy<ColorsStorageService> mLazy =
            new Lazy<ColorsStorageService>(() => new ColorsStorageService());

        #endregion

        private ColorsStorageService()
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();

            using (var stream = storage.OpenFile(Constants.ColorStorageFileName, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.ReadWrite))
            {
                mColors = ColorsStorage.Open(stream);
            }
        }

        #region Properties

        public static ColorsStorageService Instance => mLazy.Value;

        public ColorsStorage Colors => mColors;

        #endregion

        public void Save()
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();

            using (var stream = storage.OpenFile(Constants.ColorStorageFileName, FileMode.OpenOrCreate,
                FileAccess.Write, FileShare.None))
            {
                ColorsStorage.Save(mColors, stream);
            }
        }
    }
}

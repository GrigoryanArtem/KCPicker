// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media;
using KCPicker.GUI.Model.Converters;

namespace KCPicker.GUI.Model.Storages
{
    public class ColorsStorage
    {
        #region Members

        private ObservableCollection<ColorDescriptionPair> mColors = new ObservableCollection<ColorDescriptionPair>();

        #endregion

        #region Properties

        public ObservableCollection<ColorDescriptionPair> Colors =>
            mColors;

        #endregion

        #region Public methods

        public void Add(string hexColor)
        {
            Add(Converters.ColorConverter.HexToColor(hexColor));
        }

        public void Add(string hexColor, string description)
        {
            Add(Converters.ColorConverter.HexToColor(hexColor), description);
        }

        public void Add(Color color)
        {
            Add(ColorDescriptionPair.Create(color));
        }

        public void Add(Color color, string description)
        {
            Add(ColorDescriptionPair.Create(color, description));
        }

        public void Add(ColorDescriptionPair item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (mColors.Contains(item))
                throw new ArgumentException("color is already exist");

            mColors.Add(item);
        }

        public void Remove(ColorDescriptionPair item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (!mColors.Contains(item))
                throw new ArgumentException("color is not exist");

            mColors.Remove(item);
        }

        public void Update(ColorDescriptionPair item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            var color = mColors.Where(cdp => item.Color.Equals(cdp.Color)).FirstOrDefault();

            if(color is null)
                throw new ArgumentException("color is not exist");

            color.Description = item.Description;
        }

        #endregion

        #region Serialization

        public static ColorsStorage Open(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader reader = new StreamReader(stream))
            {
                using (JsonReader jsonReader = new JsonTextReader(reader))
                {
                    return serializer.Deserialize<ColorsStorage>(jsonReader) ?? new ColorsStorage();
                }
            }
        }

        public static void Save(ColorsStorage storage, Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter writer = new StreamWriter(stream))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jsonWriter, storage);
                }
            }
        }

        #endregion
    }
}

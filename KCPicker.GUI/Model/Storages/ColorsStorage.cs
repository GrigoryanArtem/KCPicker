// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KCPicker.GUI.Model.Storages
{
    public class ColorsStorage
    {
        #region Members

        private Dictionary<string, string> mColors = new Dictionary<string, string>();

        #endregion

        #region Properties

        public IEnumerable<(string HexColor, string Description)> Colors =>
            mColors.Select(item => (item.Key, item.Value));

        #endregion

        #region Public methods

        public void Add(string hexColor)
        {
            Add(hexColor, String.Empty);
        }

        public void Add(string hexColor, string description)
        {
            if (mColors.ContainsKey(hexColor))
                throw new ArgumentException("color is already exist");

            mColors.Add(hexColor, description);
        }

        public void Remove(string hexColor)
        {
            if(!mColors.ContainsKey(hexColor))
                throw new ArgumentException("color is not exist");

            mColors.Remove(hexColor);
        }

        public void Update(string hexColor, string description)
        {
            if (!mColors.ContainsKey(hexColor))
                throw new ArgumentException("color is not exist");

            mColors[hexColor] = description;
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

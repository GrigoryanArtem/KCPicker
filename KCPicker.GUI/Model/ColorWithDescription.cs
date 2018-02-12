// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Windows.Media;

namespace KCPicker.GUI.Model
{
    public class ColorWithDescription
    {
        #region Properties

        public Color Color { get; set; }
        public string Description { get; set; }

        #endregion

        public ColorWithDescription() { }

        public ColorWithDescription(Color color) : this(color, String.Empty) { }

        public ColorWithDescription(Color color, string description)
        {
            Color = color;
            Description = description;
        }
    }
}

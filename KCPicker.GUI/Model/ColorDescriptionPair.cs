// Copyright 2017 Grigoryan Artem
// Licensed under the Apache License, Version 2.0

using System;
using System.Windows.Media;

namespace KCPicker.GUI.Model
{
    public class ColorDescriptionPair
    {
        #region Properties

        public Color Color { get; set; }
        public string Description { get; set; }

        #endregion

        public ColorDescriptionPair() { }

        public ColorDescriptionPair(Color color) : this(color, String.Empty) { }

        public ColorDescriptionPair(Color color, string description)
        {
            Color = color;
            Description = description;            
        }

        public static ColorDescriptionPair Create(Color color, string description = null)
        {
            return new ColorDescriptionPair(color, description ?? String.Empty);
        }

        #region Operators

        public static bool operator ==(ColorDescriptionPair x, ColorDescriptionPair y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x.Color.Equals(y.Color) && x.Description.Equals(y.Description);
        }

        public static bool operator !=(ColorDescriptionPair x, ColorDescriptionPair y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            return obj is ColorDescriptionPair && this == obj as ColorDescriptionPair;
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode() ^ Description.GetHashCode();
        }

        #endregion
    }
}

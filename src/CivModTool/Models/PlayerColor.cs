using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.PlayerColor
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "PlayerColors")]
        public PlayerColors PlayerColors { get; set; }

        [XmlElement(ElementName = "Colors")]
        public List<Colors> Colors { get; set; }
    }

    [XmlRoot(ElementName = "PlayerColors")]
    public class PlayerColors
    {
        [XmlElement(ElementName = "Row")]
        public PlayerColor Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class PlayerColor
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "PrimaryColor")]
        public string PrimaryColor { get; set; }

        [XmlElement(ElementName = "SecondaryColor")]
        public string SecondaryColor { get; set; }

        [XmlElement(ElementName = "TextColor")]
        public string TextColor { get; set; }
    }

    [XmlRoot(ElementName = "Colors")]
    public class Colors
    {
        [XmlElement(ElementName = "Row")]
        public Color Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Color
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Red")]
        public string Red { get; set; }

        [XmlElement(ElementName = "Green")]
        public string Green { get; set; }

        [XmlElement(ElementName = "Blue")]
        public string Blue { get; set; }

        [XmlElement(ElementName = "Alpha")]
        public string Alpha { get; set; }
    }
}
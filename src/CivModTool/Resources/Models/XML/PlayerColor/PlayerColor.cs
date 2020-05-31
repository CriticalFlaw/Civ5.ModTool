using System.Collections.Generic;
using System.Xml.Serialization;
using CivModTool.Models.XML.PlayerColor.Color;

namespace CivModTool.Models.XML.PlayerColor
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "PlayerColors")]
        public PlayerColors PlayerColors { get; set; }

        [XmlElement(ElementName = "Colors")] public List<Colors> Colors { get; set; }
    }

    [XmlRoot(ElementName = "PlayerColors", Namespace = "PlayerColor")]
    public class PlayerColors
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Type")] public string Type { get; set; }

        [XmlElement(ElementName = "PrimaryColor")]
        public string PrimaryColor { get; set; }

        [XmlElement(ElementName = "SecondaryColor")]
        public string SecondaryColor { get; set; }

        [XmlElement(ElementName = "TextColor")]
        public string TextColor { get; set; }
    }
}
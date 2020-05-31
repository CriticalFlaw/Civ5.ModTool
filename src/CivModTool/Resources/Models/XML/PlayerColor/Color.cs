using System.Xml.Serialization;

namespace CivModTool.Models.XML.PlayerColor.Color
{
    [XmlRoot(ElementName = "Colors", Namespace = "Color")]
    public class Colors
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Type")] public string Type { get; set; }

        [XmlElement(ElementName = "Red")] public string Red { get; set; }

        [XmlElement(ElementName = "Green")] public string Green { get; set; }

        [XmlElement(ElementName = "Blue")] public string Blue { get; set; }

        [XmlElement(ElementName = "Alpha")] public string Alpha { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.GameText
{
    [XmlRoot(ElementName = "GameData", Namespace = "GameText")]
    public class GameData
    {
        [XmlElement(ElementName = "Language_en_US")]
        public Text Text { get; set; }
    }

    [XmlRoot(ElementName = "Language_en_US")]
    public class Text
    {
        [XmlElement(ElementName = "Row")]
        public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "Tag")]
        public string Tag { get; set; }
    }
}
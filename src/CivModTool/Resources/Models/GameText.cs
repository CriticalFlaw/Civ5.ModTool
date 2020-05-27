using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.GameText
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "Language_en_US")]
        public Language_en_US Language_en_US { get; set; }
    }

    [XmlRoot(ElementName = "Language_en_US")]
    public class Language_en_US
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Text")] public string Text { get; set; }

        [XmlAttribute(AttributeName = "Tag")] public string Tag { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.XML.IconAtlas
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "IconTextureAtlases")]
        public IconTextureAtlases IconTextureAtlases { get; set; }
    }

    [XmlRoot(ElementName = "IconTextureAtlases", Namespace = "IconAtlas")]
    public class IconTextureAtlases
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Atlas")] public string Atlas { get; set; }

        [XmlElement(ElementName = "IconSize")] public int IconSize { get; set; }

        [XmlElement(ElementName = "Filename")] public string Filename { get; set; }

        [XmlElement(ElementName = "IconsPerRow")]
        public int IconsPerRow { get; set; }

        [XmlElement(ElementName = "IconsPerColumn")]
        public int IconsPerColumn { get; set; }
    }
}
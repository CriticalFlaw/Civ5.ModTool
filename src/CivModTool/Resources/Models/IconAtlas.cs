using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.IconAtlas
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

        [XmlElement(ElementName = "IconSize")] public string IconSize { get; set; }

        [XmlElement(ElementName = "Filename")] public string Filename { get; set; }

        [XmlElement(ElementName = "IconsPerRow")]
        public string IconsPerRow { get; set; }

        [XmlElement(ElementName = "IconsPerColumn")]
        public string IconsPerColumn { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_SpyNames", Namespace = "SpyNames")]
    public class SpyNames
    {
        [XmlElement(ElementName = "Row")]
        public List<SpyName> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class SpyName
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "SpyName")]
        public string Name { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.SpyNames
{
    [XmlRoot(ElementName = "Civilization_SpyNames", Namespace = "SpyNames")]
    public class Civilization_SpyNames
    {
        [XmlElement(ElementName = "Row")]
        public List<SpyNames> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class SpyNames
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "SpyName")]
        public string SpyName { get; set; }
    }
}
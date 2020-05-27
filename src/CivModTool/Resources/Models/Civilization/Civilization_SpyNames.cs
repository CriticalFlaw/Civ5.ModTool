using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.SpyNames
{
    [XmlRoot(ElementName = "Civilization_SpyNames")]
    public class Civilization_SpyNames
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "SpyName")] public string SpyName { get; set; }
    }
}
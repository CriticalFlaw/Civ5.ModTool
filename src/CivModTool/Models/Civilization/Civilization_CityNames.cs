using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_CityNames")]
    public class CityNames
    {
        [XmlElement(ElementName = "Row")]
        public List<CityName> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class CityName
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "CityName")]
        public string Name { get; set; }
    }
}
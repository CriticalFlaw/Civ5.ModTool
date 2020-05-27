using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.Religions
{
    [XmlRoot(ElementName = "Civilization_Religions", Namespace = "Religions")]
    public class Civilization_Religions
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "ReligionType")]
        public string ReligionType { get; set; }
    }
}
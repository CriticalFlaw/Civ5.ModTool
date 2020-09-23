using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.Religions
{
    [XmlRoot(ElementName = "Civilization_Religions", Namespace = "Religions")]
    public class Civilization_Religion
    {
        [XmlElement(ElementName = "Row")]
        public Religion Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Religion
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "ReligionType")]
        public string ReligionType { get; set; }
    }
}
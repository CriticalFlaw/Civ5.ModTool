using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_Religions")]
    public class Religions
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
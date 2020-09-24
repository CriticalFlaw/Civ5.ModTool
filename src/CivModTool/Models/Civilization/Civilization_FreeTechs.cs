using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_FreeTechs", Namespace = "FreeTechs")]
    public class FreeTechs
    {
        [XmlElement(ElementName = "Row")]
        public FreeTech Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class FreeTech
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "TechType")] public string TechType { get; set; }
    }
}
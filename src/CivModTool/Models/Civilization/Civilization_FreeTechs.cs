using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.FreeTechs
{
    [XmlRoot(ElementName = "Civilization_FreeTechs", Namespace = "FreeTechs")]
    public class Civilization_FreeTechs
    {
        [XmlElement(ElementName = "Row")]
        public FreeTechs Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class FreeTechs
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "TechType")] public string TechType { get; set; }
    }
}
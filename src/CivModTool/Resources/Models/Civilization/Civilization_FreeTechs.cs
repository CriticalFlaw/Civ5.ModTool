using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.FreeTechs
{
    [XmlRoot(ElementName = "Civilization_FreeTechs", Namespace = "FreeTechs")]
    public class Civilization_FreeTechs
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "TechType")] public string TechType { get; set; }
    }
}
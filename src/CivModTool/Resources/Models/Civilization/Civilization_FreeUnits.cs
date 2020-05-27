using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.FreeUnits
{
    [XmlRoot(ElementName = "Civilization_FreeUnits", Namespace = "FreeUnits")]
    public class Civilization_FreeUnits
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "UnitClassType")]
        public string UnitClassType { get; set; }

        [XmlElement(ElementName = "UnitAIType")]
        public string UnitAIType { get; set; }

        [XmlElement(ElementName = "Count")] public string Count { get; set; }
    }
}
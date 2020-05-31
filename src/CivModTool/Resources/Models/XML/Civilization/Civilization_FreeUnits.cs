using System.Xml.Serialization;

namespace CivModTool.Models.XML.Civilization.FreeUnits
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
        public string UnitAiType { get; set; }

        [XmlElement(ElementName = "Count")] public int Count { get; set; }
    }
}
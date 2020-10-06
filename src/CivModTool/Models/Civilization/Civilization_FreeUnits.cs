using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_FreeUnits")]
    public class FreeUnits
    {
        [XmlElement(ElementName = "Row")]
        public FreeUnit Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class FreeUnit
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "UnitClassType")]
        public string UnitClassType { get; set; }

        [XmlElement(ElementName = "UnitAIType")]
        public string UnitAiType { get; set; }

        [XmlElement(ElementName = "Count")]
        public int Count { get; set; }
    }
}
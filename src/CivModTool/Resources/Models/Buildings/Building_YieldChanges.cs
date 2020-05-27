using System.Xml.Serialization;

namespace CivModTool.Models.Buildings.YieldChanges
{
    [XmlRoot(ElementName = "Building_YieldChanges")]
    public class Building_YieldChanges
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")] public string Yield { get; set; }
    }
}
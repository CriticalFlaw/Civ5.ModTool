using System.Xml.Serialization;

namespace CivModTool.Models.XML.Buildings.YieldChangesPerPop
{
    [XmlRoot(ElementName = "Building_YieldChangesPerPop", Namespace = "YieldChangesPerPop")]
    public class Building_YieldChangesPerPop
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
using System.Xml.Serialization;

namespace CivModTool.Models.Building.YieldChangesPerPop
{
    [XmlRoot(ElementName = "Building_YieldChangesPerPop", Namespace = "YieldChangesPerPop")]
    public class Building_YieldChangesPerPop
    {
        [XmlElement(ElementName = "Row")]
        public YieldChangesPerPop Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class YieldChangesPerPop
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")]
        public string Yield { get; set; }
    }
}
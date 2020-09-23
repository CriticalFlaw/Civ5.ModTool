using System.Xml.Serialization;

namespace CivModTool.Models.Building.YieldModifiers
{
    [XmlRoot(ElementName = "Building_YieldModifiers", Namespace = "YieldModifiers")]
    public class Building_YieldModifiers
    {
        [XmlElement(ElementName = "Row")]
        public YieldModifier Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class YieldModifier
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")]
        public int Yield { get; set; }
    }
}
using System.Xml.Serialization;

namespace CivModTool.Models.Building
{
    [XmlRoot(ElementName = "Building_YieldModifiers")]
    public class YieldModifiers
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
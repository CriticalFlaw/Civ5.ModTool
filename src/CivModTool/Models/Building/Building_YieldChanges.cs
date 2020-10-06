using System.Xml.Serialization;

namespace CivModTool.Models.Building
{
    [XmlRoot(ElementName = "Building_YieldChanges")]
    public class YieldChanges
    {
        [XmlElement(ElementName = "Row")]
        public YieldChange Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class YieldChange
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")]
        public int Yield { get; set; }
    }
}
using System.Xml.Serialization;

namespace CivModTool.Models.Building
{
    [XmlRoot(ElementName = "Building_YieldChangesPerPop", Namespace = "YieldChangesPerPop")]
    public class YieldChangesPerPop
    {
        [XmlElement(ElementName = "Row")]
        public YieldChangePerPop Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class YieldChangePerPop
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")]
        public string Yield { get; set; }
    }
}
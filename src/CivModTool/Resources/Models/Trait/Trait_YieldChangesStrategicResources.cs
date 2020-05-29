using System.Xml.Serialization;

namespace CivModTool.Models.Trait.YieldChangesStrategicResources
{
    [XmlRoot(ElementName = "Trait_YieldChangesStrategicResources", Namespace = "YieldChangesStrategicResources")]
    public class Trait_YieldChangesStrategicResources
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")] public string Yield { get; set; }
    }
}
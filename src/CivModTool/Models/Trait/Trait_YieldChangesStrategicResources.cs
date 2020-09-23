using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Trait.YieldChangesStrategicResources
{
    [XmlRoot(ElementName = "Trait_YieldChangesStrategicResources", Namespace = "YieldChangesStrategicResources")]
    public class Trait_YieldChangesStrategicResources
    {
        [XmlElement(ElementName = "Row")]
        public List<YieldChangesStrategicResources> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class YieldChangesStrategicResources
    {
        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }

        [XmlElement(ElementName = "YieldType")]
        public string YieldType { get; set; }

        [XmlElement(ElementName = "Yield")]
        public int Yield { get; set; }
    }
}
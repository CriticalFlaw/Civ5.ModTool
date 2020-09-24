using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Trait
{
    [XmlRoot(ElementName = "Trait_ResourceQuantityModifiers", Namespace = "ResourceQuantityModifiers")]
    public class ResourceQuantityModifiers
    {
        [XmlElement(ElementName = "Row")]
        public List<ResourceQuantityModifier> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class ResourceQuantityModifier
    {
        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }

        [XmlElement(ElementName = "ResourceType")]
        public string ResourceType { get; set; }

        [XmlElement(ElementName = "ResourceQuantityModifier")]
        public int Yield { get; set; }
    }
}
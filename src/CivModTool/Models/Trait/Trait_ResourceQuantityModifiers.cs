using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Trait.ResourceQuantityModifiers
{
    [XmlRoot(ElementName = "Trait_ResourceQuantityModifiers", Namespace = "ResourceQuantityModifiers")]
    public class Trait_ResourceQuantityModifiers
    {
        [XmlElement(ElementName = "Row")]
        public List<ResourceQuantityModifiers> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class ResourceQuantityModifiers
    {
        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }

        [XmlElement(ElementName = "ResourceType")]
        public string ResourceType { get; set; }

        [XmlElement(ElementName = "ResourceQuantityModifier")]
        public int ResourceQuantityModifier { get; set; }
    }
}
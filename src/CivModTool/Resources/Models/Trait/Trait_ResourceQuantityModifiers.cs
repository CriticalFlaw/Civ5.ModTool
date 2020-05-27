﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Trait.ResourceQuantityModifiers
{
    [XmlRoot(ElementName = "Trait_ResourceQuantityModifiers")]
    public class Trait_ResourceQuantityModifiers
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row", Namespace = "ResourceQuantityModifiers")]
    public class Row
    {
        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }

        [XmlElement(ElementName = "ResourceType")]
        public string ResourceType { get; set; }

        [XmlElement(ElementName = "ResourceQuantityModifier")]
        public string ResourceQuantityModifier { get; set; }
    }
}
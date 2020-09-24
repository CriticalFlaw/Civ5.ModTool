using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Building
{
    [XmlRoot(ElementName = "Building_Flavors", Namespace = "Flavors")]
    public class Flavors
    {
        [XmlElement(ElementName = "Row")]
        public List<Flavor> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Flavor
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "FlavorType")]
        public string FlavorType { get; set; }

        [XmlElement(ElementName = "Flavor")]
        public string Value { get; set; }
    }
}
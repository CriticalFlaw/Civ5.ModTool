using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Building.Flavors
{
    [XmlRoot(ElementName = "Building_Flavors", Namespace = "Flavors")]
    public class Building_Flavors
    {
        [XmlElement(ElementName = "Row")]
        public List<Flavors> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Flavors
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "FlavorType")]
        public string FlavorType { get; set; }

        [XmlElement(ElementName = "Flavor")]
        public string Flavor { get; set; }
    }
}
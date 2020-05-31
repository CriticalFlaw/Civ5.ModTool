using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.XML.Buildings.Flavors
{
    [XmlRoot(ElementName = "Building_Flavors", Namespace = "Flavors")]
    public class Building_Flavors
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }

        [XmlElement(ElementName = "FlavorType")]
        public string FlavorType { get; set; }

        [XmlElement(ElementName = "Flavor")] public string Flavor { get; set; }
    }
}
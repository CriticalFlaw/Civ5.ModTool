using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Leader
{
    [XmlRoot(ElementName = "Leader_Flavors", Namespace = "Flavors")]
    public class Flavors
    {
        [XmlElement(ElementName = "Row")]
        public List<Flavor> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Flavor
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "FlavorType")]
        public string FlavorType { get; set; }

        [XmlElement(ElementName = "Flavor")]
        public int Value { get; set; }
    }
}
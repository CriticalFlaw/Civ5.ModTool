using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.XML.Leader.Flavors
{
    [XmlRoot(ElementName = "Leader_Flavors", Namespace = "Flavors")]
    public class Leader_Flavors
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "FlavorType")]
        public string FlavorType { get; set; }

        [XmlElement(ElementName = "Flavor")] public int Flavor { get; set; }
    }
}
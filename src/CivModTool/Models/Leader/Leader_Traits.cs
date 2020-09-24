using System.Xml.Serialization;

namespace CivModTool.Models.Leader
{
    [XmlRoot(ElementName = "Leader_Traits", Namespace = "Traits")]
    public class Traits
    {
        [XmlElement(ElementName = "Row")]
        public Trait Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Trait
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }
    }
}
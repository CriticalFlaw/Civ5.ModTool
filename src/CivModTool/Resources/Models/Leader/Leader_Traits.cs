using System.Xml.Serialization;

namespace CivModTool.Models.Leader.Traits
{
    [XmlRoot(ElementName = "Leader_Traits", Namespace = "Traits")]
    public class Leader_Traits
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "TraitType")]
        public string TraitType { get; set; }
    }
}
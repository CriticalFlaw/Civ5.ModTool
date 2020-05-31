using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.XML.Leader.MinorCivApproachBiases
{
    [XmlRoot(ElementName = "Leader_MinorCivApproachBiases", Namespace = "MinorCivApproachBiases")]
    public class Leader_MinorCivApproachBiases
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "MinorCivApproachType")]
        public string MinorCivApproachType { get; set; }

        [XmlElement(ElementName = "Bias")] public int Bias { get; set; }
    }
}
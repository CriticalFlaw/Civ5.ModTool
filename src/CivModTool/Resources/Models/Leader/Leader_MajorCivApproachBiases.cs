using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Leader.MajorCivApproachBiases
{
    [XmlRoot(ElementName = "Leader_MajorCivApproachBiases", Namespace = "MajorCivApproachBiases")]
    public class Leader_MajorCivApproachBiases
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "MajorCivApproachType")]
        public string MajorCivApproachType { get; set; }

        [XmlElement(ElementName = "Bias")] public string Bias { get; set; }
    }
}
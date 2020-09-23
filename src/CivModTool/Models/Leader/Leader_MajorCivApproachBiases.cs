using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Leader.MajorCivApproachBiases
{
    [XmlRoot(ElementName = "Leader_MajorCivApproachBiases", Namespace = "MajorCivApproachBiases")]
    public class Leader_MajorCivApproachBiases
    {
        [XmlElement(ElementName = "Row")]
        public List<MajorCivApproachBiases> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class MajorCivApproachBiases
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "MajorCivApproachType")]
        public string MajorCivApproachType { get; set; }

        [XmlElement(ElementName = "Bias")]
        public int Bias { get; set; }
    }
}
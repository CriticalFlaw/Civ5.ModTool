using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Leader
{
    [XmlRoot(ElementName = "Leader_MinorCivApproachBiases", Namespace = "MinorCivApproachBiases")]
    public class MinorCivApproachBiases
    {
        [XmlElement(ElementName = "Row")]
        public List<MinorCivApproachBias> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class MinorCivApproachBias
    {
        [XmlElement(ElementName = "LeaderType")]
        public string LeaderType { get; set; }

        [XmlElement(ElementName = "MinorCivApproachType")]
        public string MinorCivApproachType { get; set; }

        [XmlElement(ElementName = "Bias")]
        public int Bias { get; set; }
    }
}
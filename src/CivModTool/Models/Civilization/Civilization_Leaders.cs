using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.Leaders
{
    [XmlRoot(ElementName = "Civilization_Leaders", Namespace = "Leaders")]
    public class Civilization_Leaders
    {
        [XmlElement(ElementName = "Row")]
        public Leader Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Leader
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "LeaderheadType")]
        public string LeaderheadType { get; set; }
    }
}
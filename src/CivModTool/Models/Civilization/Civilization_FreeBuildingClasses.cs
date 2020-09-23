using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.FreeBuildingClasses
{
    [XmlRoot(ElementName = "Civilization_FreeBuildingClasses", Namespace = "FreeBuildingClasses")]
    public class Civilization_FreeBuildingClasses
    {
        [XmlElement(ElementName = "Row")]
        public FreeBuildingClasses Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class FreeBuildingClasses
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "BuildingClassType")]
        public string BuildingClassType { get; set; }
    }
}
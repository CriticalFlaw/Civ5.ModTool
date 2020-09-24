using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_FreeBuildingClasses", Namespace = "FreeBuildingClasses")]
    public class FreeBuildingClasses
    {
        [XmlElement(ElementName = "Row")]
        public FreeBuildingClass Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class FreeBuildingClass
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "BuildingClassType")]
        public string BuildingClassType { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "Civilization_BuildingClassOverrides", Namespace = "BuildingClassOverrides")]
    public class BuildingClassOverrides
    {
        [XmlElement(ElementName = "Row")]
        public List<BuildingClassOverrides> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class BuildingClassOverride
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "BuildingClassType")]
        public string BuildingClassType { get; set; }

        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }
    }
}
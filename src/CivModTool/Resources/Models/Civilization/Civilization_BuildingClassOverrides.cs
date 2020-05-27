using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.BuildingClassOverrides
{
    [XmlRoot(ElementName = "Civilization_BuildingClassOverrides")]
    public class Civilization_BuildingClassOverrides
    {
        [XmlElement(ElementName = "Row")] public List<Row> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "BuildingClassType")]
        public string BuildingClassType { get; set; }

        [XmlElement(ElementName = "BuildingType")]
        public string BuildingType { get; set; }
    }
}
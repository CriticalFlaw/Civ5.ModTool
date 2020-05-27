using System.Xml.Serialization;
using CivModTool.Models.Leader.Flavors;
using CivModTool.Models.Leader.MajorCivApproachBiases;
using CivModTool.Models.Leader.MinorCivApproachBiases;
using CivModTool.Models.Leader.Traits;

namespace CivModTool.Models.Leader
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "Leaders")] public Leaders Leaders { get; set; }

        [XmlElement(ElementName = "Leader_Traits")]
        public Leader_Traits Leader_Traits { get; set; }

        [XmlElement(ElementName = "Leader_MajorCivApproachBiases")]
        public Leader_MajorCivApproachBiases Leader_MajorCivApproachBiases { get; set; }

        [XmlElement(ElementName = "Leader_MinorCivApproachBiases")]
        public Leader_MinorCivApproachBiases Leader_MinorCivApproachBiases { get; set; }

        [XmlElement(ElementName = "Leader_Flavors")]
        public Leader_Flavors Leader_Flavors { get; set; }
    }

    [XmlRoot(ElementName = "Leaders")]
    public class Leaders
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Type")] public string Type { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Civilopedia")]
        public string Civilopedia { get; set; }

        [XmlElement(ElementName = "CivilopediaTag")]
        public string CivilopediaTag { get; set; }

        [XmlElement(ElementName = "ArtDefineTag")]
        public string ArtDefineTag { get; set; }

        [XmlElement(ElementName = "VictoryCompetitiveness")]
        public string VictoryCompetitiveness { get; set; }

        [XmlElement(ElementName = "WonderCompetitiveness")]
        public string WonderCompetitiveness { get; set; }

        [XmlElement(ElementName = "MinorCivCompetitiveness")]
        public string MinorCivCompetitiveness { get; set; }

        [XmlElement(ElementName = "Boldness")] public string Boldness { get; set; }

        [XmlElement(ElementName = "DiploBalance")]
        public string DiploBalance { get; set; }

        [XmlElement(ElementName = "WarmongerHate")]
        public string WarmongerHate { get; set; }

        [XmlElement(ElementName = "WorkAgainstWillingness")]
        public string WorkAgainstWillingness { get; set; }

        [XmlElement(ElementName = "WorkWithWillingness")]
        public string WorkWithWillingness { get; set; }

        [XmlElement(ElementName = "DenounceWillingness")]
        public string DenounceWillingness { get; set; }

        [XmlElement(ElementName = "DoFWillingness")]
        public string DoFWillingness { get; set; }

        [XmlElement(ElementName = "Loyalty")] public string Loyalty { get; set; }

        [XmlElement(ElementName = "Neediness")]
        public string Neediness { get; set; }

        [XmlElement(ElementName = "Forgiveness")]
        public string Forgiveness { get; set; }

        [XmlElement(ElementName = "Chattiness")]
        public string Chattiness { get; set; }

        [XmlElement(ElementName = "Meanness")] public string Meanness { get; set; }

        [XmlElement(ElementName = "PortraitIndex")]
        public string PortraitIndex { get; set; }

        [XmlElement(ElementName = "IconAtlas")]
        public string IconAtlas { get; set; }
    }
}
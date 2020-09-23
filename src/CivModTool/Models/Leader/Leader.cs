using CivModTool.Models.Leader.Flavors;
using CivModTool.Models.Leader.MajorCivApproachBiases;
using CivModTool.Models.Leader.MinorCivApproachBiases;
using CivModTool.Models.Leader.Traits;
using System.Xml.Serialization;

namespace CivModTool.Models.Leader
{
    [XmlRoot(ElementName = "GameData", Namespace = "Leader")]
    public class GameData
    {
        [XmlElement(ElementName = "Leaders")]
        public Leaders Leaders { get; set; }

        [XmlElement(ElementName = "Leader_Traits")]
        public Leader_Traits Leader_Traits { get; set; }

        [XmlElement(ElementName = "Leader_MajorCivApproachBiases")]
        public Leader_MajorCivApproachBiases Leader_MajorCivApproachBiases { get; set; }

        [XmlElement(ElementName = "Leader_MinorCivApproachBiases")]
        public Leader_MinorCivApproachBiases Leader_MinorCivApproachBiases { get; set; }

        [XmlElement(ElementName = "Leader_Flavors")]
        public Leader_Flavors Leader_Flavors { get; set; }
    }

    [XmlRoot(ElementName = "Leader")]
    public class Leaders
    {
        [XmlElement(ElementName = "Row")]
        public Leader Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Leader
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Civilopedia")]
        public string Civilopedia { get; set; }

        [XmlElement(ElementName = "CivilopediaTag")]
        public string CivilopediaTag { get; set; }

        [XmlElement(ElementName = "ArtDefineTag")]
        public string ArtDefineTag { get; set; }

        [XmlElement(ElementName = "VictoryCompetitiveness")]
        public int VictoryCompetitiveness { get; set; }

        [XmlElement(ElementName = "WonderCompetitiveness")]
        public int WonderCompetitiveness { get; set; }

        [XmlElement(ElementName = "MinorCivCompetitiveness")]
        public int MinorCivCompetitiveness { get; set; }

        [XmlElement(ElementName = "Boldness")]
        public int Boldness { get; set; }

        [XmlElement(ElementName = "DiploBalance")]
        public int DiploBalance { get; set; }

        [XmlElement(ElementName = "WarmongerHate")]
        public int WarmongerHate { get; set; }

        [XmlElement(ElementName = "WorkAgainstWillingness")]
        public int WorkAgainstWillingness { get; set; }

        [XmlElement(ElementName = "WorkWithWillingness")]
        public int WorkWithWillingness { get; set; }

        [XmlElement(ElementName = "DenounceWillingness")]
        public int DenounceWillingness { get; set; }

        [XmlElement(ElementName = "DoFWillingness")]
        public int DoFWillingness { get; set; }

        [XmlElement(ElementName = "Loyalty")]
        public int Loyalty { get; set; }

        [XmlElement(ElementName = "Neediness")]
        public int Neediness { get; set; }

        [XmlElement(ElementName = "Forgiveness")]
        public int Forgiveness { get; set; }

        [XmlElement(ElementName = "Chattiness")]
        public int Chattiness { get; set; }

        [XmlElement(ElementName = "Meanness")]
        public int Meanness { get; set; }

        [XmlElement(ElementName = "PortraitIndex")]
        public int PortraitIndex { get; set; }

        [XmlElement(ElementName = "IconAtlas")]
        public string IconAtlas { get; set; }
    }
}
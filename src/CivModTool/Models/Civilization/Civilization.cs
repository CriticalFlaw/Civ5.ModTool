using System.Xml.Serialization;

namespace CivModTool.Models.Civilization
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "Civilizations")]
        public Civilizations Civilizations { get; set; }

        [XmlElement(ElementName = "Civilization_Leaders")]
        public Leaders Leaders { get; set; }

        [XmlElement(ElementName = "Civilization_CityNames")]
        public CityNames CityNames { get; set; }

        [XmlElement(ElementName = "Civilization_FreeBuildingClasses")]
        public FreeBuildingClasses FreeBuildingClasses { get; set; }

        [XmlElement(ElementName = "Civilization_FreeTechs")]
        public FreeTechs FreeTechs { get; set; }

        [XmlElement(ElementName = "Civilization_FreeUnits")]
        public FreeUnits FreeUnits { get; set; }

        [XmlElement(ElementName = "Civilization_Religions")]
        public Religions Religions { get; set; }

        [XmlElement(ElementName = "Civilization_BuildingClassOverrides")]
        public BuildingClassOverrides BuildingClassOverrides { get; set; }

        [XmlElement(ElementName = "Civilization_SpyNames")]
        public SpyNames SpyNames { get; set; }
    }

    [XmlRoot(ElementName = "Civilization")]
    public class Civilizations
    {
        [XmlElement(ElementName = "Row")]
        public Civilization Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Civilization
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "DerivativeCiv")]
        public string DerivativeCiv { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "ShortDescription")]
        public string ShortDescription { get; set; }

        [XmlElement(ElementName = "Adjective")]
        public string Adjective { get; set; }

        [XmlElement(ElementName = "Civilopedia")]
        public string Civilopedia { get; set; }

        [XmlElement(ElementName = "CivilopediaTag")]
        public string CivilopediaTag { get; set; }

        [XmlElement(ElementName = "DefaultPlayerColor")]
        public string DefaultPlayerColor { get; set; }

        [XmlElement(ElementName = "ArtDefineTag")]
        public string ArtDefineTag { get; set; }

        [XmlElement(ElementName = "ArtStyleType")]
        public string ArtStyleType { get; set; }

        [XmlElement(ElementName = "ArtStyleSuffix")]
        public string ArtStyleSuffix { get; set; }

        [XmlElement(ElementName = "ArtStylePrefix")]
        public string ArtStylePrefix { get; set; }

        [XmlElement(ElementName = "PortraitIndex")]
        public int PortraitIndex { get; set; }

        [XmlElement(ElementName = "IconAtlas")]
        public string IconAtlas { get; set; }

        [XmlElement(ElementName = "AlphaIconAtlas")]
        public string AlphaIconAtlas { get; set; }

        [XmlElement(ElementName = "SoundtrackTag")]
        public string SoundtrackTag { get; set; }

        [XmlElement(ElementName = "MapImage")]
        public string MapImage { get; set; }

        [XmlElement(ElementName = "DawnOfManQuote")]
        public string DawnOfManQuote { get; set; }

        [XmlElement(ElementName = "DawnOfManImage")]
        public string DawnOfManImage { get; set; }
    }
}
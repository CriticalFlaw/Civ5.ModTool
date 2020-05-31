using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Civilization
    {
        public string
            Adjective; //The text string for the qualifier to things that belong to this civ.For American, its "American"

        public bool
            AiPlayable =
                true; //If true, the AI can select this civ. Setting both Playable and AIPlayable to false is a good way to remove a civ from a game, without actually deleting the assets (and makes other mods compatible)

        public string AlphaIconAtlas; //IconTextureAtlases. The Icon Atlas that has the alpha layer for this icon
        public string ArtDefineTag; //NOT USED
        public string ArtStylePrefix; //Used to pick different flavors of improvements and wonder art
        public string ArtStyleSuffix; //Used to pick different flavors of improvements and wonder art

        public string
            ArtStyleType; //Defines the art style used for buildings that are used in this civilization's cities

        public List<string> Cities;
        public string Civilopedia; // NOT USED
        public string CivilopediaTag; //	Starting text string for the pedia entry

        public string
            DawnOfManAudio; //The audio file that is played the loading(Dawn of Man) screen.Typically this is the reading of the Quote

        public string DawnOfManImage; //The picture(as a.dds file) that is shown on the loading(Dawn of Man) screen
        public string DawnOfManQuote; //The text string that is displayed on the loading(Dawn of Man) screen

        public string
            DefaultPlayerColor; //The default color of this civ for borders, unit flags, etc.The color has to be specified in the CIV5PlayerColors

        public string DerivativeCiv; //NOT USED

        public string
            Description; //	Text string description of the civ, for America it is "American Empire" located in the TXT_KEY_CIV_AMERICA_DESC

        public string FreeBuilding;
        public string FreeTech;
        public string FreeUnit;
        public string FreeUnitAi;
        public string IconAtlas; //IconTextureAtlases. The Icon Atlas that holds the icons for this civ
        public int Id;
        public string LeaderheadType;

        public string
            MapImage; //The picture (as a.dds file) that is displayed when the civ is selected from the civilization selection menu. Typically this is a map of the civilization

        public bool Playable = true; //If true, human player can select this civ.
        public int PortraitIndex = -1; //The number of the icon in the icon atlas used for this civ
        public string Religion;
        public string ShortDescription; //The short text string for this civ.For america its "America"
        public List<string> Spies;
        public string Strategy; // NOT USED
        public string Type; // Used to reference this civilization typically in the CIVILIZATION_<name> format

        public BuildingOverride UniqueBuilding;
        //public UnitOverride UniqueUnit;
    }

    internal class BuildingOverride
    {
        public string BuildingClassType;
        public string BuildingType;
    }

    internal class UnitOverride
    {
        public string UnitClassType;
        public string UnitType;
    }
}
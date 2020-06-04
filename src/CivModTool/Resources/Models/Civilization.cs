using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Civilization
    {
        public string Adjective;

        //NOT USED
        public bool AiPlayable = true;
        public string AlphaIconAtlas;
        public string ArtDefineTag;
        public string ArtStylePrefix;
        public string ArtStyleSuffix;
        public string ArtStyleType;
        public List<string> Cities;
        public string Civilopedia;
        public string CivilopediaTag;
        public string DawnOfManAudio;
        public string DawnOfManImage;
        public string DawnOfManQuote;
        public string DefaultPlayerColor;
        public string DerivativeCiv;
        public string Description;
        public string FreeBuilding;
        public string FreeTech;
        public string FreeUnit;
        public string FreeUnitAi;
        public string IconAtlas;
        public string LeaderheadType;
        public string MapImage;

        public bool Playable = true;
        public int PortraitIndex = -1;
        public string Religion;
        public string ShortDescription;
        public List<string> Spies;
        public string Strategy;
        public string Type;
        public List<BuildingOverride> UniqueBuildings;
        public List<UnitOverride> UniqueUnits;
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
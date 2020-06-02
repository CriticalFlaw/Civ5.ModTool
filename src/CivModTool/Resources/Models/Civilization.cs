using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Civilization
    {
        public string Type;
        public string Adjective;
        public string Description;
        public string ShortDescription;
        public string CivilopediaTag;
        public string ArtStylePrefix;
        public string ArtStyleSuffix;
        public string ArtStyleType;
        public string FreeBuilding;
        public string FreeTech;
        public string FreeUnit;
        public string FreeUnitAi;
        public string Religion;
        public string DawnOfManAudio;
        public string DawnOfManQuote;
        public int PortraitIndex = -1;
        public List<string> Cities;
        public List<string> Spies;
        public string LeaderheadType;
        public string DefaultPlayerColor;
        public List<BuildingOverride> UniqueBuildings;
        public List<UnitOverride> UniqueUnits;
        public string IconAtlas;
        public string AlphaIconAtlas;
        public string MapImage;
        public string DawnOfManImage;

        //NOT USED
        public bool AiPlayable = true;

        public bool Playable = true;
        public string DerivativeCiv;
        public string ArtDefineTag;
        public string Strategy;
        public string Civilopedia;
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
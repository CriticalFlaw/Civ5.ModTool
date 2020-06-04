using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Trait
    {
        public int AbleToAnnexCityStates; //?
        public int AfraidMinorPerTurnInfluence; //?
        public int AngerFreeIntrusionOfCityStates; //?
        public int BonusReligiousBelief; //?
        public int CapitalBuildingModifier;
        public int CapitalThemingBonusModifier; //?
        public int CityConnectionTradeRouteChange; //?
        public int CityCultureBonus;
        public int CityStateBonusModifier;
        public int CityStateCombatModifier;
        public int CityStateFriendshipModifier;
        public int CityUnhappinessModifier;
        public string CombatBonusImprovement; //?
        public int CombatBonusVsHigherTech; //?
        public int CombatBonusVsLargerCiv; //?
        public int CrossesMountainsAfterGreatGeneral; //?
        public int CultureBuildingYieldChange; //?
        public int CultureFromKills;
        public string Description;
        public int DofGreatPersonModifier; //?
        public int EmbarkedAllWater; //?
        public bool EmbarkedNotCivilian;
        public int EmbarkedToLandFlatCost; //?
        public int ExtraEmbarkMoves;
        public int ExtraFoundedCityTerritoryClaimRange; //?
        public int ExtraSpies; //?
        public int FaithFromUnimprovedForest; //?
        public bool FasterAlongRiver;
        public int FasterInHills; //?
        public bool FightWellDamaged;
        public string FreeBuilding; //?
        public string FreeBuildingOnConquest; //?
        public int FreeSocialPoliciesPerEra; //?
        public string FreeUnit; //UnitClasses
        public string FreeUnitPrereqTech; //Technologies
        public int GoldenAgeCombatModifier;
        public int GoldenAgeDurationModifier;
        public int GoldenAgeGreatArtistRateModifier; //?
        public int GoldenAgeGreatMusicianRateModifier; //?
        public int GoldenAgeGreatWriterRateModifier; //?
        public int GoldenAgeMoveChange;
        public int GoldenAgeTourismModifier; //?
        public int GreatGeneralExtraBonus;
        public int GreatGeneralRateModifier;
        public int GreatPeopleRateModifier;
        public int GreatPersonGiftInfluence; // ?
        public int GreatScientistRateModifier;
        public int ImprovementMaintenanceModifier; //?
        public int LandBarbarianConversionExtraUnits; //?
        public int LandBarbarianConversionPercent;
        public int LandTradeRouteRangeBonus; //?
        public int LandUnitMaintenanceModifier; //?
        public int LevelExperienceModifier;
        public int LuxuryHappinessRetention; //?
        public int MaxGlobalBuildingProductionModifier;
        public int MaxPlayerBuildingProductionModifier;
        public int MaxTeamBuildingProductionModifier;
        public int MayaCalendarBonuses; //?
        public bool MoveFriendlyWoodsAsRoad;
        public int NaturalWonderFirstFinderGold; //?
        public int NaturalWonderHappinessModifier; //?
        public int NaturalWonderSubsequentFinderGold; //?
        public int NaturalWonderYieldModifier; //?
        public int NavalUnitMaintenanceModifier; //?
        public int NearbyImprovementBonusRange; //?
        public int NearbyImprovementCombatBonus; //?
        public int NoAnnexing; //?
        public int NoHillsImprovementMaintenance; //?
        public int NumTradeRoutesModifier; //?
        public string ObsoleteTech; //Technologies
        public int PlotBuyCostModifier;
        public int PlotCultureCostModifier;
        public int PlunderModifier;
        public int PolicyCostModifier;
        public int PopulationUnhappinessModifier;
        public string PrereqTech;
        public int RazeSpeedModifier; //?
        public List<ResourceQuantityModifiers> ResourceQuantityModifiers;
        public int RiverTradeRoad; //?
        public int SeaBarbarianConversionPercent;
        public string ShortDescription;
        public int StaysAliveZeroCities; //?
        public int TechBoostFromCapitalScienceBuildings; //?
        public int TechFromCityConquer; //?
        public int TradeBuildingModifier; //?
        public int TradeReligionModifier; //?
        public int TradeRouteChange;
        public int TradeRouteResourceModifier; //?
        public string Type;
        public int UniqueLuxuryCities; //?
        public int UniqueLuxuryQuantity; //?
        public int UniqueLuxuryRequiresNewArea; //?
        public int UnresearchedTechBonusFromKills; //?
        public int WonderProductionModifier;
        public int WorkerSpeedModifier; //?
        public List<YieldChangesStrategicResources> YieldChangesStrategicResources;
    }

    internal class YieldChangesStrategicResources
    {
        public int Yield;
        public string YieldType; //Yields
    }

    internal class ResourceQuantityModifiers
    {
        public int ResourceQuantityModifier;
        public string ResourceType;
    }
}
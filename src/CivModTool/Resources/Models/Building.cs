using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Building
    {
        public bool AffectSpiesNow;
        public int Airlift;
        public int AirModifier;
        public bool AllowsFoodTradeRoutes;
        public bool AllowsProductionTradeRoutes;
        public bool AllowsRangeStrike;
        public bool AllowsWaterRoutes; //Allows trade routes over water
        public string ArtDefineTag;
        public bool ArtInfoCulturalVariation;
        public bool ArtInfoEraVariation;
        public bool ArtInfoRandomVariation;
        public bool BorderObstacle; //The owner's territory costs 1 more movement point for enemy units (global effect)
        public string BuildingClass; //BuildingClasses
        public int BuildingProductionModifier;
        public bool Capital; //The Building can only be built in the capital if True
        public int CapturePlunderModifier;
        public int CitiesPrereq;
        public int CityConnectionTradeRouteModifier;
        public int CityCountUnhappinessMod;
        public int CityStateTradeRouteProductionModifier;
        public bool CityWall;
        public string Civilopedia; //Language_en_US(Tag)
        public int ConquestProb;
        public int Cost;
        public int Culture;
        public int CultureRateModifier;
        public int Defense;
        public string Description; //Language_en_US(Tag)
        public bool DiplomaticVoting;
        public int DisplayPosition;
        public string EnhancedYieldTech; //Technologies
        public bool Espionage;
        public int EspionageModifier;
        public int Experience;
        public int ExtraCityHitPoints;
        public int ExtraLeagueVotes;
        public bool ExtraLuxuries;
        public int ExtraMissionarySpreads;
        public int ExtraSpies;
        public int FaithCost;
        public bool Flat; //Requires that the city not be built on a hill
        public List<Flavors> Flavors;
        public int FoodKept;
        public bool FoundsReligion;
        public string FreeBuilding; //BuildingClasses
        public string FreeBuildingThisCity;
        public int FreeGreatPeople;
        public string FreeGreatWork;
        public int FreePolicies;
        public string FreePromotion; //UnitPromotions
        public string FreePromotionRemoved;
        public string FreeStartEra; //Eras
        public int FreeTechs;
        public bool FreshWater; //Requires that the city be built next to a river or fresh water lake
        public int GlobalCultureRateModifier;
        public int GlobalDefenseMod;
        public int GlobalEspionageModifier;
        public int GlobalExperience;
        public int GlobalGreatPeopleRateModifier;
        public int GlobalPlotBuyCostModifier;
        public int GlobalPlotCultureCostModifier;
        public int GlobalPopulationChange;
        public int GlobalSpaceProductionModifier;
        public int Gold;
        public bool GoldenAge;
        public int GoldenAgeModifier;
        public int GoldMaintenance; //The amount of gold the building deducts from your income each turn
        public int GreatGeneralRateModifier;
        public int GreatPeopleRateChange;
        public int GreatPeopleRateModifier;
        public int GreatPersonExpendGold;
        public int GreatScientistBeakerModifier;
        public int GreatWorkCount;
        public string GreatWorkSlotType;
        public int GreatWorksTourismModifier;
        public int Happiness;
        public int HappinessPerCity;
        public int HappinessPerXPolicies;
        public int HealRateChange;
        public string Help; //Language_en_US(Tag)
        public bool Hill; //Requires that the city be built on a hill
        public int HolyCity;
        public int HurryCostModifier;
        public string IconAtlas; //IconTextureAtlases
        public int Id;
        public int InstantMilitaryIncrease;
        public int InstantSpyRankChange;
        public bool IsReligious;
        public int LandmarksTourismPercent;
        public int LeagueCost;
        public int LevelPrereq;
        public bool MapCentering;
        public string MaxStartEra; //Eras
        public int MedianTechPercentChange;
        public int MilitaryProductionModifier;
        public int MinAreaSize;
        public int MinorFriendshipChange;
        public bool Mountain; //Requires that the city be built next to a mountain
        public int MutuallyExclusiveGroup = -1;
        public bool NearbyMountainRequired; //Requires that a mountain be within the city's borders
        public string NearbyTerrainRequired; //Terrains The specified terrain must exist within the city's borders
        public bool NeverCapture;
        public bool NoOccupiedUnhappiness;
        public int NukeExplosionRand;
        public bool NukeImmune;
        public int NukeModifier;
        public bool NullifyInfluenceModifier;
        public int NumCityCostMod;
        public int NumTradeRouteBonus;
        public string ObsoleteTech; //Technologies
        public bool PlayerBorderObstacle; //?
        public int PlotBuyCostModifier;
        public int PlotCultureCostModifier;
        public string PolicyBranchType;
        public int PolicyCostModifier;
        public int PortraitIndex = -1;
        public string PrereqTech; //Technologies
        public string ProhibitedCityTerrain;
        public string Quote; //Language_en_US(Tag)
        public int ReligiousPressureModifier;
        public string ReplacementBuildingClass; //BuildingClasses
        public bool River; //Requires that the city be built next to a river
        public int SpaceProductionModifier;
        public int SpecialistCount;
        public int SpecialistExtraCulture;
        public string SpecialistType; //Specialists
        public int SpyRankChange;
        public string Strategy; //Language_en_US(Tag)
        public bool TeamShare;
        public int TechEnhancedTourism;
        public int TechShare;
        public string ThemingBonusHelp; //?
        public int TradeRouteLandDistanceModifier;
        public int TradeRouteLandGoldBonus;
        public int TradeRouteModifier;
        public int TradeRouteRecipientBonus;
        public int TradeRouteSeaDistanceModifier;
        public int TradeRouteSeaGoldBonus;
        public int TradeRouteTargetBonus;
        public string TrainedFreePromotion; //UnitPromotions
        public string Type;
        public int UnhappinessModifier;
        public int UnitUpgradeCostMod;
        public int UnlockedByBelief;
        public int UnlockedByLeague;
        public int UnmoddedHappiness;
        public int VictoryPoints;
        public string VictoryPrereq; //Victories
        public bool Water;
        public int WonderProductionModifier;
        public string WonderSplashAnchor;
        public string WonderSplashAudio;
        public string WonderSplashImage;
        public int WorkerSpeedModifier;
        public int XBuiltTriggersIdeologyChoice;
        public List<YieldChanges> YieldChanges;
        public List<YieldChanges> YieldModifiers;
    }

    internal class YieldChanges
    {
        public int Yield;
        public string YieldType;
    }

    internal class Flavors
    {
        public int Count;
        public string FlavorType;
    }
}
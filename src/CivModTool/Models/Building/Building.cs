using System.Xml.Serialization;

namespace CivModTool.Models.Building
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "Building")]
        public Buildings Buildings { get; set; }

        [XmlElement(ElementName = "Building_Flavors")]
        public Flavors Flavors { get; set; }

        [XmlElement(ElementName = "Building_YieldChanges")]
        public YieldChanges YieldChanges { get; set; }

        [XmlElement(ElementName = "Building_YieldChangesPerPop")]
        public YieldChangesPerPop YieldChangesPerPop { get; set; }

        [XmlElement(ElementName = "Building_YieldModifiers")]
        public YieldModifiers YieldModifiers { get; set; }
    }

    [XmlRoot(ElementName = "Building")]
    public class Buildings
    {
        [XmlElement(ElementName = "Row")]
        public Building Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Building
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Civilopedia")]
        public string Civilopedia { get; set; }

        [XmlElement(ElementName = "Strategy")]
        public string Strategy { get; set; }

        [XmlElement(ElementName = "Help")]
        public string Help { get; set; }

        [XmlElement(ElementName = "ThemingBonusHelp")]
        public string ThemingBonusHelp { get; set; }

        [XmlElement(ElementName = "Quote")]
        public string Quote { get; set; }

        [XmlElement(ElementName = "GoldMaintenance")]
        public int GoldMaintenance { get; set; }

        [XmlElement(ElementName = "MutuallyExclusiveGroup")]
        public int MutuallyExclusiveGroup { get; set; }

        [XmlElement(ElementName = "TeamShare")]
        public int TeamShare { get; set; }

        [XmlElement(ElementName = "Water")]
        public int Water { get; set; }

        [XmlElement(ElementName = "River")]
        public int River { get; set; }

        [XmlElement(ElementName = "FreshWater")]
        public int FreshWater { get; set; }

        [XmlElement(ElementName = "Mountain")]
        public int Mountain { get; set; }

        [XmlElement(ElementName = "NearbyMountainRequired")]
        public int NearbyMountainRequired { get; set; }

        [XmlElement(ElementName = "Hill")]
        public int Hill { get; set; }

        [XmlElement(ElementName = "Flat")]
        public int Flat { get; set; }

        [XmlElement(ElementName = "FoundsReligion")]
        public int FoundsReligion { get; set; }

        [XmlElement(ElementName = "IsReligious")]
        public int IsReligious { get; set; }

        [XmlElement(ElementName = "BorderObstacle")]
        public int BorderObstacle { get; set; }

        [XmlElement(ElementName = "PlayerBorderObstacle")]
        public int PlayerBorderObstacle { get; set; }

        [XmlElement(ElementName = "Capital")]
        public int Capital { get; set; }

        [XmlElement(ElementName = "GoldenAge")]
        public int GoldenAge { get; set; }

        [XmlElement(ElementName = "MapCentering")]
        public int MapCentering { get; set; }

        [XmlElement(ElementName = "NeverCapture")]
        public int NeverCapture { get; set; }

        [XmlElement(ElementName = "NukeImmune")]
        public int NukeImmune { get; set; }

        [XmlElement(ElementName = "AllowsWaterRoutes")]
        public int AllowsWaterRoutes { get; set; }

        [XmlElement(ElementName = "ExtraLuxuries")]
        public int ExtraLuxuries { get; set; }

        [XmlElement(ElementName = "DiplomaticVoting")]
        public int DiplomaticVoting { get; set; }

        [XmlElement(ElementName = "AffectSpiesNow")]
        public int AffectSpiesNow { get; set; }

        [XmlElement(ElementName = "NullifyInfluenceModifier")]
        public int NullifyInfluenceModifier { get; set; }

        [XmlElement(ElementName = "Cost")]
        public int Cost { get; set; }

        [XmlElement(ElementName = "FaithCost")]
        public int FaithCost { get; set; }

        [XmlElement(ElementName = "LeagueCost")]
        public int LeagueCost { get; set; }

        [XmlElement(ElementName = "UnlockedByBelief")]
        public int UnlockedByBelief { get; set; }

        [XmlElement(ElementName = "UnlockedByLeague")]
        public int UnlockedByLeague { get; set; }

        [XmlElement(ElementName = "HolyCity")]
        public int HolyCity { get; set; }

        [XmlElement(ElementName = "NumCityCostMod")]
        public int NumCityCostMod { get; set; }

        [XmlElement(ElementName = "HurryCostModifier")]
        public int HurryCostModifier { get; set; }

        [XmlElement(ElementName = "MinAreaSize")]
        public int MinAreaSize { get; set; }

        [XmlElement(ElementName = "ConquestProb")]
        public int ConquestProb { get; set; }

        [XmlElement(ElementName = "CitiesPrereq")]
        public int CitiesPrereq { get; set; }

        [XmlElement(ElementName = "LevelPrereq")]
        public int LevelPrereq { get; set; }

        [XmlElement(ElementName = "CultureRateModifier")]
        public int CultureRateModifier { get; set; }

        [XmlElement(ElementName = "GlobalCultureRateModifier")]
        public int GlobalCultureRateModifier { get; set; }

        [XmlElement(ElementName = "GreatPeopleRateModifier")]
        public int GreatPeopleRateModifier { get; set; }

        [XmlElement(ElementName = "GlobalGreatPeopleRateModifier")]
        public int GlobalGreatPeopleRateModifier { get; set; }

        [XmlElement(ElementName = "GreatGeneralRateModifier")]
        public int GreatGeneralRateModifier { get; set; }

        [XmlElement(ElementName = "GreatPersonExpendGold")]
        public int GreatPersonExpendGold { get; set; }

        [XmlElement(ElementName = "GoldenAgeModifier")]
        public int GoldenAgeModifier { get; set; }

        [XmlElement(ElementName = "UnitUpgradeCostMod")]
        public int UnitUpgradeCostMod { get; set; }

        [XmlElement(ElementName = "Experience")]
        public int Experience { get; set; }

        [XmlElement(ElementName = "GlobalExperience")]
        public int GlobalExperience { get; set; }

        [XmlElement(ElementName = "FoodKept")]
        public int FoodKept { get; set; }

        [XmlElement(ElementName = "Airlift")]
        public int Airlift { get; set; }

        [XmlElement(ElementName = "AirModifier")]
        public int AirModifier { get; set; }

        [XmlElement(ElementName = "NukeModifier")]
        public int NukeModifier { get; set; }

        [XmlElement(ElementName = "NukeExplosionRand")]
        public int NukeExplosionRand { get; set; }

        [XmlElement(ElementName = "HealRateChange")]
        public int HealRateChange { get; set; }

        [XmlElement(ElementName = "Happiness")]
        public int Happiness { get; set; }

        [XmlElement(ElementName = "UnmoddedHappiness")]
        public int UnmoddedHappiness { get; set; }

        [XmlElement(ElementName = "UnhappinessModifier")]
        public int UnhappinessModifier { get; set; }

        [XmlElement(ElementName = "HappinessPerCity")]
        public int HappinessPerCity { get; set; }

        [XmlElement(ElementName = "HappinessPerXPolicies")]
        public int HappinessPerXPolicies { get; set; }

        [XmlElement(ElementName = "CityCountUnhappinessMod")]
        public int CityCountUnhappinessMod { get; set; }

        [XmlElement(ElementName = "NoOccupiedUnhappiness")]
        public int NoOccupiedUnhappiness { get; set; }

        [XmlElement(ElementName = "WorkerSpeedModifier")]
        public int WorkerSpeedModifier { get; set; }

        [XmlElement(ElementName = "MilitaryProductionModifier")]
        public int MilitaryProductionModifier { get; set; }

        [XmlElement(ElementName = "SpaceProductionModifier")]
        public int SpaceProductionModifier { get; set; }

        [XmlElement(ElementName = "GlobalSpaceProductionModifier")]
        public int GlobalSpaceProductionModifier { get; set; }

        [XmlElement(ElementName = "BuildingProductionModifier")]
        public int BuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "WonderProductionModifier")]
        public int WonderProductionModifier { get; set; }

        [XmlElement(ElementName = "CityConnectionTradeRouteModifier")]
        public int CityConnectionTradeRouteModifier { get; set; }

        [XmlElement(ElementName = "CapturePlunderModifier")]
        public int CapturePlunderModifier { get; set; }

        [XmlElement(ElementName = "PolicyCostModifier")]
        public int PolicyCostModifier { get; set; }

        [XmlElement(ElementName = "PlotCultureCostModifier")]
        public int PlotCultureCostModifier { get; set; }

        [XmlElement(ElementName = "GlobalPlotCultureCostModifier")]
        public int GlobalPlotCultureCostModifier { get; set; }

        [XmlElement(ElementName = "PlotBuyCostModifier")]
        public int PlotBuyCostModifier { get; set; }

        [XmlElement(ElementName = "GlobalPlotBuyCostModifier")]
        public int GlobalPlotBuyCostModifier { get; set; }

        [XmlElement(ElementName = "GlobalPopulationChange")]
        public int GlobalPopulationChange { get; set; }

        [XmlElement(ElementName = "TechShare")]
        public int TechShare { get; set; }

        [XmlElement(ElementName = "FreeTechs")]
        public int FreeTechs { get; set; }

        [XmlElement(ElementName = "FreePolicies")]
        public int FreePolicies { get; set; }

        [XmlElement(ElementName = "FreeGreatPeople")]
        public int FreeGreatPeople { get; set; }

        [XmlElement(ElementName = "MedianTechPercentChange")]
        public int MedianTechPercentChange { get; set; }

        [XmlElement(ElementName = "Gold")]
        public int Gold { get; set; }

        [XmlElement(ElementName = "AllowsRangeStrike")]
        public int AllowsRangeStrike { get; set; }

        [XmlElement(ElementName = "Espionage")]
        public int Espionage { get; set; }

        [XmlElement(ElementName = "AllowsFoodTradeRoutes")]
        public int AllowsFoodTradeRoutes { get; set; }

        [XmlElement(ElementName = "AllowsProductionTradeRoutes")]
        public int AllowsProductionTradeRoutes { get; set; }

        [XmlElement(ElementName = "Defense")]
        public int Defense { get; set; }

        [XmlElement(ElementName = "ExtraCityHitPoints")]
        public int ExtraCityHitPoints { get; set; }

        [XmlElement(ElementName = "GlobalDefenseMod")]
        public int GlobalDefenseMod { get; set; }

        [XmlElement(ElementName = "MinorFriendshipChange")]
        public int MinorFriendshipChange { get; set; }

        [XmlElement(ElementName = "VictoryPoints")]
        public int VictoryPoints { get; set; }

        [XmlElement(ElementName = "ExtraMissionarySpreads")]
        public int ExtraMissionarySpreads { get; set; }

        [XmlElement(ElementName = "ReligiousPressureModifier")]
        public int ReligiousPressureModifier { get; set; }

        [XmlElement(ElementName = "EspionageModifier")]
        public int EspionageModifier { get; set; }

        [XmlElement(ElementName = "GlobalEspionageModifier")]
        public int GlobalEspionageModifier { get; set; }

        [XmlElement(ElementName = "ExtraSpies")]
        public int ExtraSpies { get; set; }

        [XmlElement(ElementName = "SpyRankChange")]
        public int SpyRankChange { get; set; }

        [XmlElement(ElementName = "InstantSpyRankChange")]
        public int InstantSpyRankChange { get; set; }

        [XmlElement(ElementName = "TradeRouteRecipientBonus")]
        public int TradeRouteRecipientBonus { get; set; }

        [XmlElement(ElementName = "TradeRouteTargetBonus")]
        public int TradeRouteTargetBonus { get; set; }

        [XmlElement(ElementName = "NumTradeRouteBonus")]
        public int NumTradeRouteBonus { get; set; }

        [XmlElement(ElementName = "LandmarksTourismPercent")]
        public int LandmarksTourismPercent { get; set; }

        [XmlElement(ElementName = "InstantMilitaryIncrease")]
        public int InstantMilitaryIncrease { get; set; }

        [XmlElement(ElementName = "GreatWorksTourismModifier")]
        public int GreatWorksTourismModifier { get; set; }

        [XmlElement(ElementName = "XBuiltTriggersIdeologyChoice")]
        public int XBuiltTriggersIdeologyChoice { get; set; }

        [XmlElement(ElementName = "TradeRouteSeaDistanceModifier")]
        public int TradeRouteSeaDistanceModifier { get; set; }

        [XmlElement(ElementName = "TradeRouteSeaGoldBonus")]
        public int TradeRouteSeaGoldBonus { get; set; }

        [XmlElement(ElementName = "TradeRouteLandDistanceModifier")]
        public int TradeRouteLandDistanceModifier { get; set; }

        [XmlElement(ElementName = "TradeRouteLandGoldBonus")]
        public int TradeRouteLandGoldBonus { get; set; }

        [XmlElement(ElementName = "CityStateTradeRouteProductionModifier")]
        public int CityStateTradeRouteProductionModifier { get; set; }

        [XmlElement(ElementName = "GreatScientistBeakerModifier")]
        public int GreatScientistBeakerModifier { get; set; }

        [XmlElement(ElementName = "BuildingClass")]
        public string BuildingClass { get; set; }

        [XmlElement(ElementName = "ArtDefineTag")]
        public string ArtDefineTag { get; set; }

        [XmlElement(ElementName = "NearbyTerrainRequired")]
        public string NearbyTerrainRequired { get; set; }

        [XmlElement(ElementName = "ProhibitedCityTerrain")]
        public string ProhibitedCityTerrain { get; set; }

        [XmlElement(ElementName = "VictoryPrereq")]
        public string VictoryPrereq { get; set; }

        [XmlElement(ElementName = "FreeStartEra")]
        public string FreeStartEra { get; set; }

        [XmlElement(ElementName = "MaxStartEra")]
        public string MaxStartEra { get; set; }

        [XmlElement(ElementName = "ObsoleteTech")]
        public string ObsoleteTech { get; set; }

        [XmlElement(ElementName = "EnhancedYieldTech")]
        public string EnhancedYieldTech { get; set; }

        [XmlElement(ElementName = "TechEnhancedTourism")]
        public int TechEnhancedTourism { get; set; }

        [XmlElement(ElementName = "FreeBuilding")]
        public string FreeBuilding { get; set; }

        [XmlElement(ElementName = "FreeBuildingThisCity")]
        public string FreeBuildingThisCity { get; set; }

        [XmlElement(ElementName = "FreePromotion")]
        public string FreePromotion { get; set; }

        [XmlElement(ElementName = "TrainedFreePromotion")]
        public string TrainedFreePromotion { get; set; }

        [XmlElement(ElementName = "FreePromotionRemoved")]
        public string FreePromotionRemoved { get; set; }

        [XmlElement(ElementName = "ReplacementBuildingClass")]
        public string ReplacementBuildingClass { get; set; }

        [XmlElement(ElementName = "PrereqTech")]
        public string PrereqTech { get; set; }

        [XmlElement(ElementName = "PolicyBranchType")]
        public string PolicyBranchType { get; set; }

        [XmlElement(ElementName = "SpecialistType")]
        public string SpecialistType { get; set; }

        [XmlElement(ElementName = "SpecialistCount")]
        public int SpecialistCount { get; set; }

        [XmlElement(ElementName = "GreatWorkSlotType")]
        public string GreatWorkSlotType { get; set; }

        [XmlElement(ElementName = "FreeGreatWork")]
        public string FreeGreatWork { get; set; }

        [XmlElement(ElementName = "GreatWorkCount")]
        public int GreatWorkCount { get; set; }

        [XmlElement(ElementName = "SpecialistExtraCulture")]
        public int SpecialistExtraCulture { get; set; }

        [XmlElement(ElementName = "GreatPeopleRateChange")]
        public int GreatPeopleRateChange { get; set; }

        [XmlElement(ElementName = "ExtraLeagueVotes")]
        public int ExtraLeagueVotes { get; set; }

        [XmlElement(ElementName = "CityWall")]
        public int CityWall { get; set; }

        [XmlElement(ElementName = "DisplayPosition")]
        public int DisplayPosition { get; set; }

        [XmlElement(ElementName = "PortraitIndex")]
        public int PortraitIndex { get; set; }

        [XmlElement(ElementName = "WonderSplashImage")]
        public string WonderSplashImage { get; set; }

        [XmlElement(ElementName = "WonderSplashAnchor")]
        public string WonderSplashAnchor { get; set; }

        [XmlElement(ElementName = "WonderSplashAudio")]
        public string WonderSplashAudio { get; set; }

        [XmlElement(ElementName = "IconAtlas")]
        public string IconAtlas { get; set; }

        [XmlElement(ElementName = "ArtInfoCulturalVariation")]
        public int ArtInfoCulturalVariation { get; set; }

        [XmlElement(ElementName = "ArtInfoEraVariation")]
        public int ArtInfoEraVariation { get; set; }

        [XmlElement(ElementName = "ArtInfoRandomVariation")]
        public int ArtInfoRandomVariation { get; set; }
    }
}
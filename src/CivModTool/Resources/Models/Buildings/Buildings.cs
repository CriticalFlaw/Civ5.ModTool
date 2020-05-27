using System.Xml.Serialization;
using CivModTool.Models.Buildings.Flavors;
using CivModTool.Models.Buildings.YieldChanges;
using CivModTool.Models.Buildings.YieldChangesPerPop;
using CivModTool.Models.Buildings.YieldModifiers;

namespace CivModTool.Models.Buildings
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "Buildings")]
        public Buildings Buildings { get; set; }

        [XmlElement(ElementName = "Building_Flavors")]
        public Building_Flavors Building_Flavors { get; set; }

        [XmlElement(ElementName = "Building_YieldChanges")]
        public Building_YieldChanges Building_YieldChanges { get; set; }

        [XmlElement(ElementName = "Building_YieldChangesPerPop")]
        public Building_YieldChangesPerPop Building_YieldChangesPerPop { get; set; }

        [XmlElement(ElementName = "Building_YieldModifiers")]
        public Building_YieldModifiers Building_YieldModifiers { get; set; }
    }

    [XmlRoot(ElementName = "Buildings", Namespace = "Buildings")]
    public class Buildings
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

        [XmlElement(ElementName = "Strategy")] public string Strategy { get; set; }

        [XmlElement(ElementName = "Help")] public string Help { get; set; }

        [XmlElement(ElementName = "ThemingBonusHelp")]
        public string ThemingBonusHelp { get; set; }

        [XmlElement(ElementName = "Quote")] public string Quote { get; set; }

        [XmlElement(ElementName = "GoldMaintenance")]
        public string GoldMaintenance { get; set; }

        [XmlElement(ElementName = "MutuallyExclusiveGroup")]
        public string MutuallyExclusiveGroup { get; set; }

        [XmlElement(ElementName = "TeamShare")]
        public string TeamShare { get; set; }

        [XmlElement(ElementName = "Water")] public string Water { get; set; }

        [XmlElement(ElementName = "River")] public string River { get; set; }

        [XmlElement(ElementName = "FreshWater")]
        public string FreshWater { get; set; }

        [XmlElement(ElementName = "Mountain")] public string Mountain { get; set; }

        [XmlElement(ElementName = "NearbyMountainRequired")]
        public string NearbyMountainRequired { get; set; }

        [XmlElement(ElementName = "Hill")] public string Hill { get; set; }

        [XmlElement(ElementName = "Flat")] public string Flat { get; set; }

        [XmlElement(ElementName = "FoundsReligion")]
        public string FoundsReligion { get; set; }

        [XmlElement(ElementName = "IsReligious")]
        public string IsReligious { get; set; }

        [XmlElement(ElementName = "BorderObstacle")]
        public string BorderObstacle { get; set; }

        [XmlElement(ElementName = "PlayerBorderObstacle")]
        public string PlayerBorderObstacle { get; set; }

        [XmlElement(ElementName = "Capital")] public string Capital { get; set; }

        [XmlElement(ElementName = "GoldenAge")]
        public string GoldenAge { get; set; }

        [XmlElement(ElementName = "MapCentering")]
        public string MapCentering { get; set; }

        [XmlElement(ElementName = "NeverCapture")]
        public string NeverCapture { get; set; }

        [XmlElement(ElementName = "NukeImmune")]
        public string NukeImmune { get; set; }

        [XmlElement(ElementName = "AllowsWaterRoutes")]
        public string AllowsWaterRoutes { get; set; }

        [XmlElement(ElementName = "ExtraLuxuries")]
        public string ExtraLuxuries { get; set; }

        [XmlElement(ElementName = "DiplomaticVoting")]
        public string DiplomaticVoting { get; set; }

        [XmlElement(ElementName = "AffectSpiesNow")]
        public string AffectSpiesNow { get; set; }

        [XmlElement(ElementName = "NullifyInfluenceModifier")]
        public string NullifyInfluenceModifier { get; set; }

        [XmlElement(ElementName = "Cost")] public string Cost { get; set; }

        [XmlElement(ElementName = "FaithCost")]
        public string FaithCost { get; set; }

        [XmlElement(ElementName = "LeagueCost")]
        public string LeagueCost { get; set; }

        [XmlElement(ElementName = "UnlockedByBelief")]
        public string UnlockedByBelief { get; set; }

        [XmlElement(ElementName = "UnlockedByLeague")]
        public string UnlockedByLeague { get; set; }

        [XmlElement(ElementName = "HolyCity")] public string HolyCity { get; set; }

        [XmlElement(ElementName = "NumCityCostMod")]
        public string NumCityCostMod { get; set; }

        [XmlElement(ElementName = "HurryCostModifier")]
        public string HurryCostModifier { get; set; }

        [XmlElement(ElementName = "MinAreaSize")]
        public string MinAreaSize { get; set; }

        [XmlElement(ElementName = "ConquestProb")]
        public string ConquestProb { get; set; }

        [XmlElement(ElementName = "CitiesPrereq")]
        public string CitiesPrereq { get; set; }

        [XmlElement(ElementName = "LevelPrereq")]
        public string LevelPrereq { get; set; }

        [XmlElement(ElementName = "CultureRateModifier")]
        public string CultureRateModifier { get; set; }

        [XmlElement(ElementName = "GlobalCultureRateModifier")]
        public string GlobalCultureRateModifier { get; set; }

        [XmlElement(ElementName = "GreatPeopleRateModifier")]
        public string GreatPeopleRateModifier { get; set; }

        [XmlElement(ElementName = "GlobalGreatPeopleRateModifier")]
        public string GlobalGreatPeopleRateModifier { get; set; }

        [XmlElement(ElementName = "GreatGeneralRateModifier")]
        public string GreatGeneralRateModifier { get; set; }

        [XmlElement(ElementName = "GreatPersonExpendGold")]
        public string GreatPersonExpendGold { get; set; }

        [XmlElement(ElementName = "GoldenAgeModifier")]
        public string GoldenAgeModifier { get; set; }

        [XmlElement(ElementName = "UnitUpgradeCostMod")]
        public string UnitUpgradeCostMod { get; set; }

        [XmlElement(ElementName = "Experience")]
        public string Experience { get; set; }

        [XmlElement(ElementName = "GlobalExperience")]
        public string GlobalExperience { get; set; }

        [XmlElement(ElementName = "FoodKept")] public string FoodKept { get; set; }

        [XmlElement(ElementName = "Airlift")] public string Airlift { get; set; }

        [XmlElement(ElementName = "AirModifier")]
        public string AirModifier { get; set; }

        [XmlElement(ElementName = "NukeModifier")]
        public string NukeModifier { get; set; }

        [XmlElement(ElementName = "NukeExplosionRand")]
        public string NukeExplosionRand { get; set; }

        [XmlElement(ElementName = "HealRateChange")]
        public string HealRateChange { get; set; }

        [XmlElement(ElementName = "Happiness")]
        public string Happiness { get; set; }

        [XmlElement(ElementName = "UnmoddedHappiness")]
        public string UnmoddedHappiness { get; set; }

        [XmlElement(ElementName = "UnhappinessModifier")]
        public string UnhappinessModifier { get; set; }

        [XmlElement(ElementName = "HappinessPerCity")]
        public string HappinessPerCity { get; set; }

        [XmlElement(ElementName = "HappinessPerXPolicies")]
        public string HappinessPerXPolicies { get; set; }

        [XmlElement(ElementName = "CityCountUnhappinessMod")]
        public string CityCountUnhappinessMod { get; set; }

        [XmlElement(ElementName = "NoOccupiedUnhappiness")]
        public string NoOccupiedUnhappiness { get; set; }

        [XmlElement(ElementName = "WorkerSpeedModifier")]
        public string WorkerSpeedModifier { get; set; }

        [XmlElement(ElementName = "MilitaryProductionModifier")]
        public string MilitaryProductionModifier { get; set; }

        [XmlElement(ElementName = "SpaceProductionModifier")]
        public string SpaceProductionModifier { get; set; }

        [XmlElement(ElementName = "GlobalSpaceProductionModifier")]
        public string GlobalSpaceProductionModifier { get; set; }

        [XmlElement(ElementName = "BuildingProductionModifier")]
        public string BuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "WonderProductionModifier")]
        public string WonderProductionModifier { get; set; }

        [XmlElement(ElementName = "CityConnectionTradeRouteModifier")]
        public string CityConnectionTradeRouteModifier { get; set; }

        [XmlElement(ElementName = "CapturePlunderModifier")]
        public string CapturePlunderModifier { get; set; }

        [XmlElement(ElementName = "PolicyCostModifier")]
        public string PolicyCostModifier { get; set; }

        [XmlElement(ElementName = "PlotCultureCostModifier")]
        public string PlotCultureCostModifier { get; set; }

        [XmlElement(ElementName = "GlobalPlotCultureCostModifier")]
        public string GlobalPlotCultureCostModifier { get; set; }

        [XmlElement(ElementName = "PlotBuyCostModifier")]
        public string PlotBuyCostModifier { get; set; }

        [XmlElement(ElementName = "GlobalPlotBuyCostModifier")]
        public string GlobalPlotBuyCostModifier { get; set; }

        [XmlElement(ElementName = "GlobalPopulationChange")]
        public string GlobalPopulationChange { get; set; }

        [XmlElement(ElementName = "TechShare")]
        public string TechShare { get; set; }

        [XmlElement(ElementName = "FreeTechs")]
        public string FreeTechs { get; set; }

        [XmlElement(ElementName = "FreePolicies")]
        public string FreePolicies { get; set; }

        [XmlElement(ElementName = "FreeGreatPeople")]
        public string FreeGreatPeople { get; set; }

        [XmlElement(ElementName = "MedianTechPercentChange")]
        public string MedianTechPercentChange { get; set; }

        [XmlElement(ElementName = "Gold")] public string Gold { get; set; }

        [XmlElement(ElementName = "AllowsRangeStrike")]
        public string AllowsRangeStrike { get; set; }

        [XmlElement(ElementName = "Espionage")]
        public string Espionage { get; set; }

        [XmlElement(ElementName = "AllowsFoodTradeRoutes")]
        public string AllowsFoodTradeRoutes { get; set; }

        [XmlElement(ElementName = "AllowsProductionTradeRoutes")]
        public string AllowsProductionTradeRoutes { get; set; }

        [XmlElement(ElementName = "Defense")] public string Defense { get; set; }

        [XmlElement(ElementName = "ExtraCityHitPoints")]
        public string ExtraCityHitPoints { get; set; }

        [XmlElement(ElementName = "GlobalDefenseMod")]
        public string GlobalDefenseMod { get; set; }

        [XmlElement(ElementName = "MinorFriendshipChange")]
        public string MinorFriendshipChange { get; set; }

        [XmlElement(ElementName = "VictoryPoints")]
        public string VictoryPoints { get; set; }

        [XmlElement(ElementName = "ExtraMissionarySpreads")]
        public string ExtraMissionarySpreads { get; set; }

        [XmlElement(ElementName = "ReligiousPressureModifier")]
        public string ReligiousPressureModifier { get; set; }

        [XmlElement(ElementName = "EspionageModifier")]
        public string EspionageModifier { get; set; }

        [XmlElement(ElementName = "GlobalEspionageModifier")]
        public string GlobalEspionageModifier { get; set; }

        [XmlElement(ElementName = "ExtraSpies")]
        public string ExtraSpies { get; set; }

        [XmlElement(ElementName = "SpyRankChange")]
        public string SpyRankChange { get; set; }

        [XmlElement(ElementName = "InstantSpyRankChange")]
        public string InstantSpyRankChange { get; set; }

        [XmlElement(ElementName = "TradeRouteRecipientBonus")]
        public string TradeRouteRecipientBonus { get; set; }

        [XmlElement(ElementName = "TradeRouteTargetBonus")]
        public string TradeRouteTargetBonus { get; set; }

        [XmlElement(ElementName = "NumTradeRouteBonus")]
        public string NumTradeRouteBonus { get; set; }

        [XmlElement(ElementName = "LandmarksTourismPercent")]
        public string LandmarksTourismPercent { get; set; }

        [XmlElement(ElementName = "InstantMilitaryIncrease")]
        public string InstantMilitaryIncrease { get; set; }

        [XmlElement(ElementName = "GreatWorksTourismModifier")]
        public string GreatWorksTourismModifier { get; set; }

        [XmlElement(ElementName = "XBuiltTriggersIdeologyChoice")]
        public string XBuiltTriggersIdeologyChoice { get; set; }

        [XmlElement(ElementName = "TradeRouteSeaDistanceModifier")]
        public string TradeRouteSeaDistanceModifier { get; set; }

        [XmlElement(ElementName = "TradeRouteSeaGoldBonus")]
        public string TradeRouteSeaGoldBonus { get; set; }

        [XmlElement(ElementName = "TradeRouteLandDistanceModifier")]
        public string TradeRouteLandDistanceModifier { get; set; }

        [XmlElement(ElementName = "TradeRouteLandGoldBonus")]
        public string TradeRouteLandGoldBonus { get; set; }

        [XmlElement(ElementName = "CityStateTradeRouteProductionModifier")]
        public string CityStateTradeRouteProductionModifier { get; set; }

        [XmlElement(ElementName = "GreatScientistBeakerModifier")]
        public string GreatScientistBeakerModifier { get; set; }

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
        public string TechEnhancedTourism { get; set; }

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
        public string SpecialistCount { get; set; }

        [XmlElement(ElementName = "GreatWorkSlotType")]
        public string GreatWorkSlotType { get; set; }

        [XmlElement(ElementName = "FreeGreatWork")]
        public string FreeGreatWork { get; set; }

        [XmlElement(ElementName = "GreatWorkCount")]
        public string GreatWorkCount { get; set; }

        [XmlElement(ElementName = "SpecialistExtraCulture")]
        public string SpecialistExtraCulture { get; set; }

        [XmlElement(ElementName = "GreatPeopleRateChange")]
        public string GreatPeopleRateChange { get; set; }

        [XmlElement(ElementName = "ExtraLeagueVotes")]
        public string ExtraLeagueVotes { get; set; }

        [XmlElement(ElementName = "CityWall")] public string CityWall { get; set; }

        [XmlElement(ElementName = "DisplayPosition")]
        public string DisplayPosition { get; set; }

        [XmlElement(ElementName = "PortraitIndex")]
        public string PortraitIndex { get; set; }

        [XmlElement(ElementName = "WonderSplashImage")]
        public string WonderSplashImage { get; set; }

        [XmlElement(ElementName = "WonderSplashAnchor")]
        public string WonderSplashAnchor { get; set; }

        [XmlElement(ElementName = "WonderSplashAudio")]
        public string WonderSplashAudio { get; set; }

        [XmlElement(ElementName = "IconAtlas")]
        public string IconAtlas { get; set; }

        [XmlElement(ElementName = "ArtInfoCulturalVariation")]
        public string ArtInfoCulturalVariation { get; set; }

        [XmlElement(ElementName = "ArtInfoEraVariation")]
        public string ArtInfoEraVariation { get; set; }

        [XmlElement(ElementName = "ArtInfoRandomVariation")]
        public string ArtInfoRandomVariation { get; set; }
    }
}
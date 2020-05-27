using System.Xml.Serialization;
using CivModTool.Models.Trait.ResourceQuantityModifiers;
using CivModTool.Models.Trait.YieldChangesStrategicResources;

namespace CivModTool.Models.Trait
{
    [XmlRoot(ElementName = "GameData")]
    public class GameData
    {
        [XmlElement(ElementName = "Traits")] public Traits Traits { get; set; }

        [XmlElement(ElementName = "Trait_YieldChangesStrategicResources")]
        public Trait_YieldChangesStrategicResources Trait_YieldChangesStrategicResources { get; set; }

        [XmlElement(ElementName = "Trait_ResourceQuantityModifiers")]
        public Trait_ResourceQuantityModifiers Trait_ResourceQuantityModifiers { get; set; }
    }

    [XmlRoot(ElementName = "Traits")]
    public class Traits
    {
        [XmlElement(ElementName = "Row")] public Row Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Type")] public string Type { get; set; }

        [XmlElement(ElementName = "ShortDescription")]
        public string ShortDescription { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "LevelExperienceModifier")]
        public string LevelExperienceModifier { get; set; }

        [XmlElement(ElementName = "GreatPeopleRateModifier")]
        public string GreatPeopleRateModifier { get; set; }

        [XmlElement(ElementName = "GreatScientistRateModifier")]
        public string GreatScientistRateModifier { get; set; }

        [XmlElement(ElementName = "GreatGeneralRateModifier")]
        public string GreatGeneralRateModifier { get; set; }

        [XmlElement(ElementName = "GreatGeneralExtraBonus")]
        public string GreatGeneralExtraBonus { get; set; }

        [XmlElement(ElementName = "GreatPersonGiftInfluence")]
        public string GreatPersonGiftInfluence { get; set; }

        [XmlElement(ElementName = "MaxGlobalBuildingProductionModifier")]
        public string MaxGlobalBuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "MaxTeamBuildingProductionModifier")]
        public string MaxTeamBuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "MaxPlayerBuildingProductionModifier")]
        public string MaxPlayerBuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "CityUnhappinessModifier")]
        public string CityUnhappinessModifier { get; set; }

        [XmlElement(ElementName = "PopulationUnhappinessModifier")]
        public string PopulationUnhappinessModifier { get; set; }

        [XmlElement(ElementName = "CityStateBonusModifier")]
        public string CityStateBonusModifier { get; set; }

        [XmlElement(ElementName = "CityStateFriendshipModifier")]
        public string CityStateFriendshipModifier { get; set; }

        [XmlElement(ElementName = "CityStateCombatModifier")]
        public string CityStateCombatModifier { get; set; }

        [XmlElement(ElementName = "LandBarbarianConversionPercent")]
        public string LandBarbarianConversionPercent { get; set; }

        [XmlElement(ElementName = "LandBarbarianConversionExtraUnits")]
        public string LandBarbarianConversionExtraUnits { get; set; }

        [XmlElement(ElementName = "SeaBarbarianConversionPercent")]
        public string SeaBarbarianConversionPercent { get; set; }

        [XmlElement(ElementName = "LandUnitMaintenanceModifier")]
        public string LandUnitMaintenanceModifier { get; set; }

        [XmlElement(ElementName = "NavalUnitMaintenanceModifier")]
        public string NavalUnitMaintenanceModifier { get; set; }

        [XmlElement(ElementName = "CapitalBuildingModifier")]
        public string CapitalBuildingModifier { get; set; }

        [XmlElement(ElementName = "PlotBuyCostModifier")]
        public string PlotBuyCostModifier { get; set; }

        [XmlElement(ElementName = "PlotCultureCostModifier")]
        public string PlotCultureCostModifier { get; set; }

        [XmlElement(ElementName = "CultureFromKills")]
        public string CultureFromKills { get; set; }

        [XmlElement(ElementName = "CityCultureBonus")]
        public string CityCultureBonus { get; set; }

        [XmlElement(ElementName = "CapitalThemingBonusModifier")]
        public string CapitalThemingBonusModifier { get; set; }

        [XmlElement(ElementName = "PolicyCostModifier")]
        public string PolicyCostModifier { get; set; }

        [XmlElement(ElementName = "CityConnectionTradeRouteChange")]
        public string CityConnectionTradeRouteChange { get; set; }

        [XmlElement(ElementName = "WonderProductionModifier")]
        public string WonderProductionModifier { get; set; }

        [XmlElement(ElementName = "PlunderModifier")]
        public string PlunderModifier { get; set; }

        [XmlElement(ElementName = "ImprovementMaintenanceModifier")]
        public string ImprovementMaintenanceModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeDurationModifier")]
        public string GoldenAgeDurationModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeMoveChange")]
        public string GoldenAgeMoveChange { get; set; }

        [XmlElement(ElementName = "GoldenAgeCombatModifier")]
        public string GoldenAgeCombatModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeTourismModifier")]
        public string GoldenAgeTourismModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeGreatArtistRateModifier")]
        public string GoldenAgeGreatArtistRateModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeGreatMusicianRateModifier")]
        public string GoldenAgeGreatMusicianRateModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeGreatWriterRateModifier")]
        public string GoldenAgeGreatWriterRateModifier { get; set; }

        [XmlElement(ElementName = "ExtraEmbarkMoves")]
        public string ExtraEmbarkMoves { get; set; }

        [XmlElement(ElementName = "NaturalWonderFirstFinderGold")]
        public string NaturalWonderFirstFinderGold { get; set; }

        [XmlElement(ElementName = "NaturalWonderSubsequentFinderGold")]
        public string NaturalWonderSubsequentFinderGold { get; set; }

        [XmlElement(ElementName = "NaturalWonderYieldModifier")]
        public string NaturalWonderYieldModifier { get; set; }

        [XmlElement(ElementName = "NaturalWonderHappinessModifier")]
        public string NaturalWonderHappinessModifier { get; set; }

        [XmlElement(ElementName = "NearbyImprovementCombatBonus")]
        public string NearbyImprovementCombatBonus { get; set; }

        [XmlElement(ElementName = "NearbyImprovementBonusRange")]
        public string NearbyImprovementBonusRange { get; set; }

        [XmlElement(ElementName = "CultureBuildingYieldChange")]
        public string CultureBuildingYieldChange { get; set; }

        [XmlElement(ElementName = "CombatBonusVsHigherTech")]
        public string CombatBonusVsHigherTech { get; set; }

        [XmlElement(ElementName = "CombatBonusVsLargerCiv")]
        public string CombatBonusVsLargerCiv { get; set; }

        [XmlElement(ElementName = "RazeSpeedModifier")]
        public string RazeSpeedModifier { get; set; }

        [XmlElement(ElementName = "DOFGreatPersonModifier")]
        public string DOFGreatPersonModifier { get; set; }

        [XmlElement(ElementName = "LuxuryHappinessRetention")]
        public string LuxuryHappinessRetention { get; set; }

        [XmlElement(ElementName = "ExtraSpies")]
        public string ExtraSpies { get; set; }

        [XmlElement(ElementName = "UnresearchedTechBonusFromKills")]
        public string UnresearchedTechBonusFromKills { get; set; }

        [XmlElement(ElementName = "ExtraFoundedCityTerritoryClaimRange")]
        public string ExtraFoundedCityTerritoryClaimRange { get; set; }

        [XmlElement(ElementName = "FreeSocialPoliciesPerEra")]
        public string FreeSocialPoliciesPerEra { get; set; }

        [XmlElement(ElementName = "NumTradeRoutesModifier")]
        public string NumTradeRoutesModifier { get; set; }

        [XmlElement(ElementName = "TradeRouteResourceModifier")]
        public string TradeRouteResourceModifier { get; set; }

        [XmlElement(ElementName = "UniqueLuxuryCities")]
        public string UniqueLuxuryCities { get; set; }

        [XmlElement(ElementName = "UniqueLuxuryQuantity")]
        public string UniqueLuxuryQuantity { get; set; }

        [XmlElement(ElementName = "WorkerSpeedModifier")]
        public string WorkerSpeedModifier { get; set; }

        [XmlElement(ElementName = "AfraidMinorPerTurnInfluence")]
        public string AfraidMinorPerTurnInfluence { get; set; }

        [XmlElement(ElementName = "LandTradeRouteRangeBonus")]
        public string LandTradeRouteRangeBonus { get; set; }

        [XmlElement(ElementName = "TradeReligionModifier")]
        public string TradeReligionModifier { get; set; }

        [XmlElement(ElementName = "TradeBuildingModifier")]
        public string TradeBuildingModifier { get; set; }

        [XmlElement(ElementName = "FightWellDamaged")]
        public string FightWellDamaged { get; set; }

        [XmlElement(ElementName = "MoveFriendlyWoodsAsRoad")]
        public string MoveFriendlyWoodsAsRoad { get; set; }

        [XmlElement(ElementName = "FasterAlongRiver")]
        public string FasterAlongRiver { get; set; }

        [XmlElement(ElementName = "FasterInHills")]
        public string FasterInHills { get; set; }

        [XmlElement(ElementName = "EmbarkedAllWater")]
        public string EmbarkedAllWater { get; set; }

        [XmlElement(ElementName = "EmbarkedToLandFlatCost")]
        public string EmbarkedToLandFlatCost { get; set; }

        [XmlElement(ElementName = "NoHillsImprovementMaintenance")]
        public string NoHillsImprovementMaintenance { get; set; }

        [XmlElement(ElementName = "TechBoostFromCapitalScienceBuildings")]
        public string TechBoostFromCapitalScienceBuildings { get; set; }

        [XmlElement(ElementName = "StaysAliveZeroCities")]
        public string StaysAliveZeroCities { get; set; }

        [XmlElement(ElementName = "FaithFromUnimprovedForest")]
        public string FaithFromUnimprovedForest { get; set; }

        [XmlElement(ElementName = "BonusReligiousBelief")]
        public string BonusReligiousBelief { get; set; }

        [XmlElement(ElementName = "AbleToAnnexCityStates")]
        public string AbleToAnnexCityStates { get; set; }

        [XmlElement(ElementName = "CrossesMountainsAfterGreatGeneral")]
        public string CrossesMountainsAfterGreatGeneral { get; set; }

        [XmlElement(ElementName = "MayaCalendarBonuses")]
        public string MayaCalendarBonuses { get; set; }

        [XmlElement(ElementName = "NoAnnexing")]
        public string NoAnnexing { get; set; }

        [XmlElement(ElementName = "TechFromCityConquer")]
        public string TechFromCityConquer { get; set; }

        [XmlElement(ElementName = "UniqueLuxuryRequiresNewArea")]
        public string UniqueLuxuryRequiresNewArea { get; set; }

        [XmlElement(ElementName = "RiverTradeRoad")]
        public string RiverTradeRoad { get; set; }

        [XmlElement(ElementName = "AngerFreeIntrusionOfCityStates")]
        public string AngerFreeIntrusionOfCityStates { get; set; }

        [XmlElement(ElementName = "FreeUnit")] public string FreeUnit { get; set; }

        [XmlElement(ElementName = "FreeUnitPrereqTech")]
        public string FreeUnitPrereqTech { get; set; }

        [XmlElement(ElementName = "CombatBonusImprovement")]
        public string CombatBonusImprovement { get; set; }

        [XmlElement(ElementName = "FreeBuilding")]
        public string FreeBuilding { get; set; }

        [XmlElement(ElementName = "FreeBuildingOnConquest")]
        public string FreeBuildingOnConquest { get; set; }

        [XmlElement(ElementName = "ObsoleteTech")]
        public string ObsoleteTech { get; set; }

        [XmlElement(ElementName = "PrereqTech")]
        public string PrereqTech { get; set; }
    }
}
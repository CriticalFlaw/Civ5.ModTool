using CivModTool.Models.XML.Trait.ResourceQuantityModifiers;
using CivModTool.Models.XML.Trait.YieldChangesStrategicResources;
using System.Xml.Serialization;

namespace CivModTool.Models.XML.Trait
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

    [XmlRoot(ElementName = "Traits", Namespace = "Trait")]
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
        public int LevelExperienceModifier { get; set; }

        [XmlElement(ElementName = "GreatPeopleRateModifier")]
        public int GreatPeopleRateModifier { get; set; }

        [XmlElement(ElementName = "GreatScientistRateModifier")]
        public int GreatScientistRateModifier { get; set; }

        [XmlElement(ElementName = "GreatGeneralRateModifier")]
        public int GreatGeneralRateModifier { get; set; }

        [XmlElement(ElementName = "GreatGeneralExtraBonus")]
        public int GreatGeneralExtraBonus { get; set; }

        [XmlElement(ElementName = "GreatPersonGiftInfluence")]
        public int GreatPersonGiftInfluence { get; set; }

        [XmlElement(ElementName = "MaxGlobalBuildingProductionModifier")]
        public int MaxGlobalBuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "MaxTeamBuildingProductionModifier")]
        public int MaxTeamBuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "MaxPlayerBuildingProductionModifier")]
        public int MaxPlayerBuildingProductionModifier { get; set; }

        [XmlElement(ElementName = "CityUnhappinessModifier")]
        public int CityUnhappinessModifier { get; set; }

        [XmlElement(ElementName = "PopulationUnhappinessModifier")]
        public int PopulationUnhappinessModifier { get; set; }

        [XmlElement(ElementName = "CityStateBonusModifier")]
        public int CityStateBonusModifier { get; set; }

        [XmlElement(ElementName = "CityStateFriendshipModifier")]
        public int CityStateFriendshipModifier { get; set; }

        [XmlElement(ElementName = "CityStateCombatModifier")]
        public int CityStateCombatModifier { get; set; }

        [XmlElement(ElementName = "LandBarbarianConversionPercent")]
        public int LandBarbarianConversionPercent { get; set; }

        [XmlElement(ElementName = "LandBarbarianConversionExtraUnits")]
        public int LandBarbarianConversionExtraUnits { get; set; }

        [XmlElement(ElementName = "SeaBarbarianConversionPercent")]
        public int SeaBarbarianConversionPercent { get; set; }

        [XmlElement(ElementName = "LandUnitMaintenanceModifier")]
        public int LandUnitMaintenanceModifier { get; set; }

        [XmlElement(ElementName = "NavalUnitMaintenanceModifier")]
        public int NavalUnitMaintenanceModifier { get; set; }

        [XmlElement(ElementName = "CapitalBuildingModifier")]
        public int CapitalBuildingModifier { get; set; }

        [XmlElement(ElementName = "PlotBuyCostModifier")]
        public int PlotBuyCostModifier { get; set; }

        [XmlElement(ElementName = "PlotCultureCostModifier")]
        public int PlotCultureCostModifier { get; set; }

        [XmlElement(ElementName = "CultureFromKills")]
        public int CultureFromKills { get; set; }

        [XmlElement(ElementName = "CityCultureBonus")]
        public int CityCultureBonus { get; set; }

        [XmlElement(ElementName = "CapitalThemingBonusModifier")]
        public int CapitalThemingBonusModifier { get; set; }

        [XmlElement(ElementName = "PolicyCostModifier")]
        public int PolicyCostModifier { get; set; }

        [XmlElement(ElementName = "CityConnectionTradeRouteChange")]
        public int CityConnectionTradeRouteChange { get; set; }

        [XmlElement(ElementName = "WonderProductionModifier")]
        public int WonderProductionModifier { get; set; }

        [XmlElement(ElementName = "PlunderModifier")]
        public int PlunderModifier { get; set; }

        [XmlElement(ElementName = "ImprovementMaintenanceModifier")]
        public int ImprovementMaintenanceModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeDurationModifier")]
        public int GoldenAgeDurationModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeMoveChange")]
        public int GoldenAgeMoveChange { get; set; }

        [XmlElement(ElementName = "GoldenAgeCombatModifier")]
        public int GoldenAgeCombatModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeTourismModifier")]
        public int GoldenAgeTourismModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeGreatArtistRateModifier")]
        public int GoldenAgeGreatArtistRateModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeGreatMusicianRateModifier")]
        public int GoldenAgeGreatMusicianRateModifier { get; set; }

        [XmlElement(ElementName = "GoldenAgeGreatWriterRateModifier")]
        public int GoldenAgeGreatWriterRateModifier { get; set; }

        [XmlElement(ElementName = "ExtraEmbarkMoves")]
        public int ExtraEmbarkMoves { get; set; }

        [XmlElement(ElementName = "NaturalWonderFirstFinderGold")]
        public int NaturalWonderFirstFinderGold { get; set; }

        [XmlElement(ElementName = "NaturalWonderSubsequentFinderGold")]
        public int NaturalWonderSubsequentFinderGold { get; set; }

        [XmlElement(ElementName = "NaturalWonderYieldModifier")]
        public int NaturalWonderYieldModifier { get; set; }

        [XmlElement(ElementName = "NaturalWonderHappinessModifier")]
        public int NaturalWonderHappinessModifier { get; set; }

        [XmlElement(ElementName = "NearbyImprovementCombatBonus")]
        public int NearbyImprovementCombatBonus { get; set; }

        [XmlElement(ElementName = "NearbyImprovementBonusRange")]
        public int NearbyImprovementBonusRange { get; set; }

        [XmlElement(ElementName = "CultureBuildingYieldChange")]
        public int CultureBuildingYieldChange { get; set; }

        [XmlElement(ElementName = "CombatBonusVsHigherTech")]
        public int CombatBonusVsHigherTech { get; set; }

        [XmlElement(ElementName = "CombatBonusVsLargerCiv")]
        public int CombatBonusVsLargerCiv { get; set; }

        [XmlElement(ElementName = "RazeSpeedModifier")]
        public int RazeSpeedModifier { get; set; }

        [XmlElement(ElementName = "DOFGreatPersonModifier")]
        public int DofGreatPersonModifier { get; set; }

        [XmlElement(ElementName = "LuxuryHappinessRetention")]
        public int LuxuryHappinessRetention { get; set; }

        [XmlElement(ElementName = "ExtraSpies")]
        public int ExtraSpies { get; set; }

        [XmlElement(ElementName = "UnresearchedTechBonusFromKills")]
        public int UnresearchedTechBonusFromKills { get; set; }

        [XmlElement(ElementName = "ExtraFoundedCityTerritoryClaimRange")]
        public int ExtraFoundedCityTerritoryClaimRange { get; set; }

        [XmlElement(ElementName = "FreeSocialPoliciesPerEra")]
        public int FreeSocialPoliciesPerEra { get; set; }

        [XmlElement(ElementName = "NumTradeRoutesModifier")]
        public int NumTradeRoutesModifier { get; set; }

        [XmlElement(ElementName = "TradeRouteResourceModifier")]
        public int TradeRouteResourceModifier { get; set; }

        [XmlElement(ElementName = "UniqueLuxuryCities")]
        public int UniqueLuxuryCities { get; set; }

        [XmlElement(ElementName = "UniqueLuxuryQuantity")]
        public int UniqueLuxuryQuantity { get; set; }

        [XmlElement(ElementName = "WorkerSpeedModifier")]
        public int WorkerSpeedModifier { get; set; }

        [XmlElement(ElementName = "AfraidMinorPerTurnInfluence")]
        public int AfraidMinorPerTurnInfluence { get; set; }

        [XmlElement(ElementName = "LandTradeRouteRangeBonus")]
        public int LandTradeRouteRangeBonus { get; set; }

        [XmlElement(ElementName = "TradeReligionModifier")]
        public int TradeReligionModifier { get; set; }

        [XmlElement(ElementName = "TradeBuildingModifier")]
        public int TradeBuildingModifier { get; set; }

        [XmlElement(ElementName = "FightWellDamaged")]
        public int FightWellDamaged { get; set; }

        [XmlElement(ElementName = "MoveFriendlyWoodsAsRoad")]
        public int MoveFriendlyWoodsAsRoad { get; set; }

        [XmlElement(ElementName = "FasterAlongRiver")]
        public int FasterAlongRiver { get; set; }

        [XmlElement(ElementName = "FasterInHills")]
        public int FasterInHills { get; set; }

        [XmlElement(ElementName = "EmbarkedAllWater")]
        public int EmbarkedAllWater { get; set; }

        [XmlElement(ElementName = "EmbarkedToLandFlatCost")]
        public int EmbarkedToLandFlatCost { get; set; }

        [XmlElement(ElementName = "NoHillsImprovementMaintenance")]
        public int NoHillsImprovementMaintenance { get; set; }

        [XmlElement(ElementName = "TechBoostFromCapitalScienceBuildings")]
        public int TechBoostFromCapitalScienceBuildings { get; set; }

        [XmlElement(ElementName = "StaysAliveZeroCities")]
        public int StaysAliveZeroCities { get; set; }

        [XmlElement(ElementName = "FaithFromUnimprovedForest")]
        public int FaithFromUnimprovedForest { get; set; }

        [XmlElement(ElementName = "BonusReligiousBelief")]
        public int BonusReligiousBelief { get; set; }

        [XmlElement(ElementName = "AbleToAnnexCityStates")]
        public int AbleToAnnexCityStates { get; set; }

        [XmlElement(ElementName = "CrossesMountainsAfterGreatGeneral")]
        public int CrossesMountainsAfterGreatGeneral { get; set; }

        [XmlElement(ElementName = "MayaCalendarBonuses")]
        public int MayaCalendarBonuses { get; set; }

        [XmlElement(ElementName = "NoAnnexing")]
        public int NoAnnexing { get; set; }

        [XmlElement(ElementName = "TechFromCityConquer")]
        public int TechFromCityConquer { get; set; }

        [XmlElement(ElementName = "UniqueLuxuryRequiresNewArea")]
        public int UniqueLuxuryRequiresNewArea { get; set; }

        [XmlElement(ElementName = "RiverTradeRoad")]
        public int RiverTradeRoad { get; set; }

        [XmlElement(ElementName = "AngerFreeIntrusionOfCityStates")]
        public int AngerFreeIntrusionOfCityStates { get; set; }

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
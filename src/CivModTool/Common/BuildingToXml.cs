using System;
using System.Collections.Generic;
using CivModTool.Models;
using CivModTool.Models.XML.Buildings;
using CivModTool.Models.XML.Buildings.Flavors;
using CivModTool.Models.XML.Buildings.YieldChanges;
using CivModTool.Models.XML.Buildings.YieldModifiers;
using CivModTool.Resources;
using Buildings = CivModTool.Models.XML.Buildings.Buildings;
using Row = CivModTool.Models.XML.Buildings.Row;

namespace CivModTool.Common
{
    internal class BuildingToXml
    {
        internal static bool GenerateBuildingsXml(Building data)
        {
            try
            {
                var gameData = new GameData
                {
                    Buildings = new Buildings
                    {
                        Row = new Row
                        {
                            Type = data.Type,
                            Description = data.Description,
                            Civilopedia = data.Civilopedia,
                            Strategy = data.Strategy,
                            Help = data.Help,
                            BuildingClass = data.BuildingClass,
                            ArtDefineTag = data.ArtDefineTag,
                            FreeStartEra = data.FreeStartEra,
                            PrereqTech = data.PrereqTech,
                            IconAtlas = data.IconAtlas,
                            ThemingBonusHelp = data.ThemingBonusHelp,
                            Quote = data.Quote,
                            GoldMaintenance = data.GoldMaintenance,
                            MutuallyExclusiveGroup = data.MutuallyExclusiveGroup,
                            TeamShare = Convert.ToInt32(data.TeamShare),
                            Water = Convert.ToInt32(data.Water),
                            River = Convert.ToInt32(data.River),
                            FreshWater = Convert.ToInt32(data.FreshWater),
                            Mountain = Convert.ToInt32(data.Mountain),
                            NearbyMountainRequired = Convert.ToInt32(data.NearbyMountainRequired),
                            Hill = Convert.ToInt32(data.Hill),
                            Flat = Convert.ToInt32(data.Flat),
                            FoundsReligion = Convert.ToInt32(data.FoundsReligion),
                            IsReligious = Convert.ToInt32(data.IsReligious),
                            BorderObstacle = Convert.ToInt32(data.BorderObstacle),
                            PlayerBorderObstacle = Convert.ToInt32(data.PlayerBorderObstacle),
                            Capital = Convert.ToInt32(data.Capital),
                            GoldenAge = Convert.ToInt32(data.GoldenAge),
                            MapCentering = Convert.ToInt32(data.MapCentering),
                            NeverCapture = Convert.ToInt32(data.NeverCapture),
                            NukeImmune = Convert.ToInt32(data.NukeImmune),
                            AllowsWaterRoutes = Convert.ToInt32(data.AllowsWaterRoutes),
                            ExtraLuxuries = Convert.ToInt32(data.ExtraLuxuries),
                            DiplomaticVoting = Convert.ToInt32(data.DiplomaticVoting),
                            AffectSpiesNow = Convert.ToInt32(data.AffectSpiesNow),
                            NullifyInfluenceModifier = Convert.ToInt32(data.NullifyInfluenceModifier),
                            Cost = data.Cost,
                            FaithCost = data.FaithCost,
                            LeagueCost = data.LeagueCost,
                            UnlockedByBelief = data.UnlockedByBelief,
                            UnlockedByLeague = data.UnlockedByLeague,
                            HolyCity = data.HolyCity,
                            NumCityCostMod = data.NumCityCostMod,
                            HurryCostModifier = data.HurryCostModifier,
                            MinAreaSize = data.MinAreaSize,
                            ConquestProb = data.ConquestProb,
                            CitiesPrereq = data.CitiesPrereq,
                            LevelPrereq = data.LevelPrereq,
                            CultureRateModifier = data.CultureRateModifier,
                            GlobalCultureRateModifier = data.GlobalCultureRateModifier,
                            GreatPeopleRateModifier = data.GreatPeopleRateModifier,
                            GlobalGreatPeopleRateModifier = data.GlobalGreatPeopleRateModifier,
                            GreatGeneralRateModifier = data.GreatGeneralRateModifier,
                            GreatPersonExpendGold = data.GreatPersonExpendGold,
                            GoldenAgeModifier = data.GoldenAgeModifier,
                            UnitUpgradeCostMod = data.UnitUpgradeCostMod,
                            Experience = data.Experience,
                            GlobalExperience = data.GlobalExperience,
                            FoodKept = data.FoodKept,
                            Airlift = data.Airlift,
                            AirModifier = data.AirModifier,
                            NukeModifier = data.NukeModifier,
                            NukeExplosionRand = data.NukeExplosionRand,
                            HealRateChange = data.HealRateChange,
                            Happiness = data.Happiness,
                            UnmoddedHappiness = data.UnmoddedHappiness,
                            UnhappinessModifier = data.UnhappinessModifier,
                            HappinessPerCity = data.HappinessPerCity,
                            HappinessPerXPolicies = data.HappinessPerXPolicies,
                            CityCountUnhappinessMod = data.CityCountUnhappinessMod,
                            NoOccupiedUnhappiness = Convert.ToInt32(data.NoOccupiedUnhappiness),
                            WorkerSpeedModifier = data.WorkerSpeedModifier,
                            MilitaryProductionModifier = data.MilitaryProductionModifier,
                            SpaceProductionModifier = data.SpaceProductionModifier,
                            GlobalSpaceProductionModifier = data.GlobalSpaceProductionModifier,
                            BuildingProductionModifier = data.BuildingProductionModifier,
                            WonderProductionModifier = data.WonderProductionModifier,
                            CityConnectionTradeRouteModifier = data.CityConnectionTradeRouteModifier,
                            CapturePlunderModifier = data.CapturePlunderModifier,
                            PolicyCostModifier = data.PolicyCostModifier,
                            PlotCultureCostModifier = data.PlotCultureCostModifier,
                            GlobalPlotCultureCostModifier = data.GlobalPlotCultureCostModifier,
                            PlotBuyCostModifier = data.PlotBuyCostModifier,
                            GlobalPlotBuyCostModifier = data.GlobalPlotBuyCostModifier,
                            GlobalPopulationChange = data.GlobalPopulationChange,
                            TechShare = data.TechShare,
                            FreeTechs = data.FreeTechs,
                            FreePolicies = data.FreePolicies,
                            FreeGreatPeople = data.FreeGreatPeople,
                            MedianTechPercentChange = data.MedianTechPercentChange,
                            Gold = data.Gold,
                            AllowsRangeStrike = Convert.ToInt32(data.AllowsRangeStrike),
                            Espionage = Convert.ToInt32(data.Espionage),
                            AllowsFoodTradeRoutes = Convert.ToInt32(data.AllowsFoodTradeRoutes),
                            AllowsProductionTradeRoutes = Convert.ToInt32(data.AllowsProductionTradeRoutes),
                            Defense = data.Defense,
                            ExtraCityHitPoints = data.ExtraCityHitPoints,
                            GlobalDefenseMod = data.GlobalDefenseMod,
                            MinorFriendshipChange = data.MinorFriendshipChange,
                            VictoryPoints = data.VictoryPoints,
                            ExtraMissionarySpreads = data.ExtraMissionarySpreads,
                            ReligiousPressureModifier = data.ReligiousPressureModifier,
                            EspionageModifier = data.EspionageModifier,
                            GlobalEspionageModifier = data.GlobalEspionageModifier,
                            ExtraSpies = data.ExtraSpies,
                            SpyRankChange = data.SpyRankChange,
                            InstantSpyRankChange = data.InstantSpyRankChange,
                            TradeRouteRecipientBonus = data.TradeRouteRecipientBonus,
                            TradeRouteTargetBonus = data.TradeRouteTargetBonus,
                            NumTradeRouteBonus = data.NumTradeRouteBonus,
                            LandmarksTourismPercent = data.LandmarksTourismPercent,
                            InstantMilitaryIncrease = data.InstantMilitaryIncrease,
                            GreatWorksTourismModifier = data.GreatWorksTourismModifier,
                            XBuiltTriggersIdeologyChoice = data.XBuiltTriggersIdeologyChoice,
                            TradeRouteSeaDistanceModifier = data.TradeRouteSeaDistanceModifier,
                            TradeRouteSeaGoldBonus = data.TradeRouteSeaGoldBonus,
                            TradeRouteLandDistanceModifier = data.TradeRouteLandDistanceModifier,
                            TradeRouteLandGoldBonus = data.TradeRouteLandGoldBonus,
                            CityStateTradeRouteProductionModifier = data.CityStateTradeRouteProductionModifier,
                            GreatScientistBeakerModifier = data.GreatScientistBeakerModifier,
                            NearbyTerrainRequired = data.NearbyTerrainRequired,
                            ProhibitedCityTerrain = data.ProhibitedCityTerrain,
                            VictoryPrereq = data.VictoryPrereq,
                            MaxStartEra = data.MaxStartEra,
                            ObsoleteTech = data.ObsoleteTech,
                            EnhancedYieldTech = data.EnhancedYieldTech,
                            TechEnhancedTourism = data.TechEnhancedTourism,
                            FreeBuilding = data.FreeBuilding,
                            FreeBuildingThisCity = data.FreeBuildingThisCity,
                            FreePromotion = data.FreePromotion,
                            TrainedFreePromotion = data.TrainedFreePromotion,
                            FreePromotionRemoved = data.FreePromotionRemoved,
                            ReplacementBuildingClass = data.ReplacementBuildingClass,
                            PolicyBranchType = data.PolicyBranchType,
                            SpecialistType = data.SpecialistType,
                            SpecialistCount = data.SpecialistCount,
                            GreatWorkSlotType = data.GreatWorkSlotType,
                            FreeGreatWork = data.FreeGreatWork,
                            GreatWorkCount = data.GreatWorkCount,
                            SpecialistExtraCulture = data.SpecialistExtraCulture,
                            GreatPeopleRateChange = data.GreatPeopleRateChange,
                            ExtraLeagueVotes = data.ExtraLeagueVotes,
                            CityWall = Convert.ToInt32(data.CityWall),
                            DisplayPosition = data.DisplayPosition,
                            PortraitIndex = data.PortraitIndex.ToString(),
                            WonderSplashImage = data.WonderSplashImage,
                            WonderSplashAnchor = data.WonderSplashAnchor,
                            WonderSplashAudio = data.WonderSplashAudio,
                            ArtInfoCulturalVariation = Convert.ToInt32(data.ArtInfoCulturalVariation),
                            ArtInfoEraVariation = Convert.ToInt32(data.ArtInfoEraVariation),
                            ArtInfoRandomVariation = Convert.ToInt32(data.ArtInfoRandomVariation)
                        }
                    },

                    Building_Flavors = new Building_Flavors
                    {
                        Row = new List<Models.XML.Buildings.Flavors.Row>()
                    },

                    Building_YieldChanges = new Building_YieldChanges
                    {
                        Row = new Models.XML.Buildings.YieldChanges.Row
                        {
                            BuildingType = data.Type,
                            YieldType = data.YieldChanges[0].YieldType,
                            Yield = data.YieldChanges[0].Yield.ToString()
                        }
                    },

                    Building_YieldModifiers = new Building_YieldModifiers
                    {
                        Row = new Models.XML.Buildings.YieldModifiers.Row
                        {
                            BuildingType = data.Type,
                            YieldType = data.YieldModifiers[0].YieldType,
                            Yield = data.YieldModifiers[0].Yield.ToString()
                        }
                    }
                };

                var flavor = new Models.XML.Buildings.Flavors.Row
                {
                    BuildingType = data.Type,
                    FlavorType = string.Format(Properties.Resources.txt_flavor, ResourceList.Gold.ToString().ToUpper()),
                    Flavor = "25"
                };
                gameData.Building_Flavors.Row.Add(flavor);

                XmlController.SerializeXml(gameData, FileCategories.Buildings.ToString());
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }
    }
}
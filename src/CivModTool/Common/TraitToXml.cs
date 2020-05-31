using System;
using System.Collections.Generic;
using CivModTool.Models;
using CivModTool.Models.XML.Trait;
using CivModTool.Models.XML.Trait.ResourceQuantityModifiers;
using CivModTool.Models.XML.Trait.YieldChangesStrategicResources;
using CivModTool.Resources;
using Row = CivModTool.Models.XML.Trait.Row;

namespace CivModTool.Common
{
    internal class TraitToXml
    {
        internal static bool GenerateTraitXml(Trait data)
        {
            try
            {
                var gameData = new GameData
                {
                    Traits = new Traits
                    {
                        Row = new Row
                        {
                            Type = data.Type,
                            ShortDescription = data.ShortDescription,
                            Description = data.Description,
                            LevelExperienceModifier = data.LevelExperienceModifier,
                            GreatPeopleRateModifier = data.GreatPeopleRateModifier,
                            GreatScientistRateModifier = data.GreatScientistRateModifier,
                            GreatGeneralRateModifier = data.GreatScientistRateModifier,
                            GreatGeneralExtraBonus = data.GreatGeneralExtraBonus,
                            GreatPersonGiftInfluence = data.GreatPersonGiftInfluence,
                            MaxGlobalBuildingProductionModifier = data.MaxGlobalBuildingProductionModifier,
                            MaxTeamBuildingProductionModifier = data.MaxTeamBuildingProductionModifier,
                            MaxPlayerBuildingProductionModifier = data.MaxPlayerBuildingProductionModifier,
                            CityUnhappinessModifier = data.CityUnhappinessModifier,
                            PopulationUnhappinessModifier = data.PopulationUnhappinessModifier,
                            CityStateBonusModifier = data.CityStateBonusModifier,
                            CityStateFriendshipModifier = data.CityStateFriendshipModifier,
                            CityStateCombatModifier = data.CityStateCombatModifier,
                            LandBarbarianConversionPercent = data.LandBarbarianConversionPercent,
                            LandBarbarianConversionExtraUnits = data.LandBarbarianConversionExtraUnits,
                            SeaBarbarianConversionPercent = data.SeaBarbarianConversionPercent,
                            LandUnitMaintenanceModifier = data.LandUnitMaintenanceModifier,
                            NavalUnitMaintenanceModifier = data.NavalUnitMaintenanceModifier,
                            CapitalBuildingModifier = data.CapitalBuildingModifier,
                            PlotBuyCostModifier = data.PlotBuyCostModifier,
                            PlotCultureCostModifier = data.PlotCultureCostModifier,
                            CultureFromKills = data.CultureFromKills,
                            CityCultureBonus = data.CityCultureBonus,
                            CapitalThemingBonusModifier = data.CapitalThemingBonusModifier,
                            PolicyCostModifier = data.PolicyCostModifier,
                            CityConnectionTradeRouteChange = data.CityConnectionTradeRouteChange,
                            WonderProductionModifier = data.WonderProductionModifier,
                            PlunderModifier = data.PlunderModifier,
                            ImprovementMaintenanceModifier = data.ImprovementMaintenanceModifier,
                            GoldenAgeDurationModifier = data.GoldenAgeDurationModifier,
                            GoldenAgeMoveChange = data.GoldenAgeMoveChange,
                            GoldenAgeCombatModifier = data.GoldenAgeCombatModifier,
                            GoldenAgeTourismModifier = data.GoldenAgeTourismModifier,
                            GoldenAgeGreatArtistRateModifier = data.GoldenAgeGreatArtistRateModifier,
                            GoldenAgeGreatMusicianRateModifier = data.GoldenAgeGreatMusicianRateModifier,
                            GoldenAgeGreatWriterRateModifier = data.GoldenAgeGreatWriterRateModifier,
                            ExtraEmbarkMoves = data.ExtraEmbarkMoves,
                            NaturalWonderFirstFinderGold = data.NaturalWonderFirstFinderGold,
                            NaturalWonderSubsequentFinderGold = data.NaturalWonderSubsequentFinderGold,
                            NaturalWonderYieldModifier = data.NaturalWonderYieldModifier,
                            NaturalWonderHappinessModifier = data.NaturalWonderHappinessModifier,
                            NearbyImprovementCombatBonus = data.NearbyImprovementCombatBonus,
                            NearbyImprovementBonusRange = data.NearbyImprovementBonusRange,
                            CultureBuildingYieldChange = data.CultureBuildingYieldChange,
                            CombatBonusVsHigherTech = data.CombatBonusVsHigherTech,
                            CombatBonusVsLargerCiv = data.CombatBonusVsLargerCiv,
                            RazeSpeedModifier = data.RazeSpeedModifier,
                            DofGreatPersonModifier = data.DofGreatPersonModifier,
                            LuxuryHappinessRetention = data.LuxuryHappinessRetention,
                            ExtraSpies = data.ExtraSpies,
                            UnresearchedTechBonusFromKills = data.UnresearchedTechBonusFromKills,
                            ExtraFoundedCityTerritoryClaimRange = data.ExtraFoundedCityTerritoryClaimRange,
                            FreeSocialPoliciesPerEra = data.FreeSocialPoliciesPerEra,
                            NumTradeRoutesModifier = data.NumTradeRoutesModifier,
                            TradeRouteResourceModifier = data.TradeRouteResourceModifier,
                            UniqueLuxuryCities = data.UniqueLuxuryCities,
                            UniqueLuxuryQuantity = data.UniqueLuxuryQuantity,
                            WorkerSpeedModifier = data.WorkerSpeedModifier,
                            AfraidMinorPerTurnInfluence = data.AfraidMinorPerTurnInfluence,
                            LandTradeRouteRangeBonus = data.LandTradeRouteRangeBonus,
                            TradeReligionModifier = data.TradeReligionModifier,
                            TradeBuildingModifier = data.TradeBuildingModifier,
                            FightWellDamaged = Convert.ToInt32(data.FightWellDamaged),
                            MoveFriendlyWoodsAsRoad = Convert.ToInt32(data.MoveFriendlyWoodsAsRoad),
                            FasterAlongRiver = Convert.ToInt32(data.FasterAlongRiver),
                            FasterInHills = data.FasterInHills,
                            EmbarkedAllWater = data.EmbarkedAllWater,
                            EmbarkedToLandFlatCost = data.EmbarkedToLandFlatCost,
                            NoHillsImprovementMaintenance = data.NoHillsImprovementMaintenance,
                            TechBoostFromCapitalScienceBuildings = data.TechBoostFromCapitalScienceBuildings,
                            StaysAliveZeroCities = data.StaysAliveZeroCities,
                            FaithFromUnimprovedForest = data.FaithFromUnimprovedForest,
                            BonusReligiousBelief = data.BonusReligiousBelief,
                            AbleToAnnexCityStates = data.AbleToAnnexCityStates,
                            CrossesMountainsAfterGreatGeneral = data.CrossesMountainsAfterGreatGeneral,
                            MayaCalendarBonuses = data.MayaCalendarBonuses,
                            NoAnnexing = data.NoAnnexing,
                            TechFromCityConquer = data.TechFromCityConquer,
                            UniqueLuxuryRequiresNewArea = data.UniqueLuxuryRequiresNewArea,
                            RiverTradeRoad = data.RiverTradeRoad,
                            AngerFreeIntrusionOfCityStates = data.AngerFreeIntrusionOfCityStates,
                            FreeUnit = data.FreeUnit,
                            FreeUnitPrereqTech = data.FreeUnitPrereqTech,
                            CombatBonusImprovement = data.CombatBonusImprovement,
                            FreeBuilding = data.FreeBuilding,
                            FreeBuildingOnConquest = data.FreeBuildingOnConquest,
                            ObsoleteTech = data.ObsoleteTech,
                            PrereqTech = data.PrereqTech
                        }
                    },

                    Trait_YieldChangesStrategicResources = new Trait_YieldChangesStrategicResources
                    {
                        Row = new List<Models.XML.Trait.YieldChangesStrategicResources.Row>()
                    },

                    Trait_ResourceQuantityModifiers = new Trait_ResourceQuantityModifiers
                    {
                        Row = new List<Models.XML.Trait.ResourceQuantityModifiers.Row>()
                    }
                };

                foreach (var resource in data.YieldChangesStrategicResources)
                {
                    var row = new Models.XML.Trait.YieldChangesStrategicResources.Row
                    {
                        TraitType = data.Type,
                        YieldType = resource.YieldType,
                        Yield = resource.Yield
                    };
                    gameData.Trait_YieldChangesStrategicResources.Row.Add(row);
                }

                foreach (var modifier in data.ResourceQuantityModifiers)
                {
                    var row = new Models.XML.Trait.ResourceQuantityModifiers.Row
                    {
                        TraitType = data.Type,
                        ResourceType = modifier.ResourceType,
                        ResourceQuantityModifier = modifier.ResourceQuantityModifier
                    };
                    gameData.Trait_ResourceQuantityModifiers.Row.Add(row);
                }

                XmlController.SerializeXml(gameData, FileCategories.Trait.ToString());
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
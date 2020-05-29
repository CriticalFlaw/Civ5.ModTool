using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualBasic;
using System.Xml.Serialization;
using AutoUpdaterDotNET;
using CivModTool.Models.Buildings;
using CivModTool.Models.Buildings.Flavors;
using CivModTool.Models.Buildings.YieldChangesPerPop;
using CivModTool.Models.Civilization;
using CivModTool.Models.Civilization.BuildingClassOverrides;
using CivModTool.Models.Civilization.CityNames;
using CivModTool.Models.Civilization.FreeBuildingClasses;
using CivModTool.Models.Civilization.FreeTechs;
using CivModTool.Models.Civilization.FreeUnits;
using CivModTool.Models.Civilization.Leaders;
using CivModTool.Models.Civilization.Religions;
using CivModTool.Models.Civilization.SpyNames;
using CivModTool.Models.GameText;
using CivModTool.Models.IconAtlas;
using CivModTool.Models.Leader;
using CivModTool.Models.Leader.Flavors;
using CivModTool.Models.Leader.MajorCivApproachBiases;
using CivModTool.Models.Leader.MinorCivApproachBiases;
using CivModTool.Models.Leader.Traits;
using CivModTool.Models.PlayerColor;
using CivModTool.Models.Trait;
using CivModTool.Models.Trait.ResourceQuantityModifiers;
using CivModTool.Models.Trait.YieldChangesStrategicResources;
using CivModTool.Properties;
using log4net;
using log4net.Config;
using Xceed.Wpf.Toolkit;
using Colors = CivModTool.Models.PlayerColor.Color.Colors;
using GameData = CivModTool.Models.Civilization.GameData;
using MessageBox = System.Windows.MessageBox;
using Row = CivModTool.Models.Civilization.Row;
using CivModTool.Resources;
using CivModTool.Models.Buildings.YieldChanges;
using CivModTool.Models.Buildings.YieldModifiers;

namespace CivModTool
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _outputPath = Directory.GetCurrentDirectory() + "\\XML";

        public MainWindow()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            Logger.Info("INITIALIZING...");
            InitializeComponent();
            LoadGuiElements();
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.Start(Properties.Resources.txt_app_update);
        }

        private void btnGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            btnGenerateXML.IsEnabled = false;
            if (!SaveValuesToConfig()) return;
            if (!GenerateCivilizationXml()) return;
            if (!GeneratePlayerColorXml()) return;
            if (!GenerateLeaderXml()) return;
            if (!GenerateTraitXml()) return;
            if (!GenerateBuildingsXml()) return;
            if (!GenerateUnitsXml()) return;
            if (!GenerateIconAtlasXml()) return;
            GenerateGameTextXml();
            btnGenerateXML.IsEnabled = true;
        }

        private bool GenerateCivilizationXml()
        {
            try
            {
                if (!ValidationForm(FileCategories.Civilization)) return false;
                var settings = Settings.Default;
                var civType = string.Format(Properties.Resources.txt_civ, settings.civ_name);
                Enum.TryParse(cbFreeUnit.SelectedValue.ToString(), out Units unit);
                var gameData = new GameData
                {
                    Civilizations = new Civilizations
                    {
                        Row = new Row
                        {
                            Type = civType,
                            DerivativeCiv = string.Format(Properties.Resources.txt_civ, cbDerivative.SelectedValue.ToString().ToUpper()),
                            Description = string.Format(Properties.Resources.key_civ_desc, tbType.Text),
                            ShortDescription = string.Format(Properties.Resources.key_civ_desc_short, tbType.Text),
                            Adjective = string.Format(Properties.Resources.key_civ_adjective, tbType.Text),
                            Civilopedia = string.Format(Properties.Resources.key_civ_pedia_header, tbType.Text),
                            CivilopediaTag = string.Format(Properties.Resources.key_civ_pedia_text, tbType.Text),
                            DefaultPlayerColor = string.Format(Properties.Resources.txt_civ_color, tbType.Text),
                            ArtDefineTag = string.Format(Properties.Resources.txt_civ_art_def, cbDerivative.SelectedValue.ToString().ToUpper()),
                            ArtStyleType = string.Format(Properties.Resources.txt_civ_art_style, cbArtStyle.SelectedValue.ToString().ToUpper()),
                            ArtStyleSuffix = GetArtPrefix((ArtStyles)Enum.Parse(typeof(ArtStyles), cbArtStyle.SelectedValue.ToString())),
                            ArtStylePrefix = cbArtStyle.SelectedValue.ToString().ToUpper(),
                            PortraitIndex = intCivPortraitIndex.Value.ToString(),
                            IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, tbType.Text),
                            AlphaIconAtlas = string.Format(Properties.Resources.txt_civ_atlas_alpha, tbType.Text),
                            SoundtrackTag = cbSoundtrack.SelectedValue.ToString(),
                            MapImage = string.Format(Properties.Resources.txt_civ_map, tbType.Text),
                            DawnOfManQuote = string.Format(Properties.Resources.key_civ_dom_text, tbType.Text),
                            DawnOfManImage = string.Format(Properties.Resources.txt_civ_dom_image, tbLeaderType.Text)
                        }
                    },

                    Civilization_Leaders = new Civilization_Leaders
                    {
                        Row = new Models.Civilization.Leaders.Row
                        {
                            CivilizationType = civType,
                            LeaderheadType = string.Format(Properties.Resources.txt_leader, tbLeaderType.Text)
                        }
                    },

                    Civilization_CityNames = new Civilization_CityNames
                    {
                        Row = new List<Models.Civilization.CityNames.Row>()
                    },

                    Civilization_SpyNames = new Civilization_SpyNames
                    {
                        Row = new List<Models.Civilization.SpyNames.Row>()
                    },

                    Civilization_FreeBuildingClasses = new Civilization_FreeBuildingClasses
                    {
                        Row = new Models.Civilization.FreeBuildingClasses.Row
                        {
                            CivilizationType = civType,
                            BuildingClassType = string.Format(Properties.Resources.txt_building_class, cbFreeBuilding.SelectedValue.ToString().ToUpper())
                        }
                    },

                    Civilization_FreeTechs = new Civilization_FreeTechs
                    {
                        Row = new Models.Civilization.FreeTechs.Row
                        {
                            CivilizationType = civType,
                            TechType = string.Format(Properties.Resources.txt_tech, cbFreeTech.SelectedValue.ToString().ToUpper())
                        }
                    },

                    Civilization_FreeUnits = new Civilization_FreeUnits
                    {
                        Row = new Models.Civilization.FreeUnits.Row
                        {
                            CivilizationType = civType,
                            UnitClassType = string.Format(Properties.Resources.txt_unit_class, cbFreeUnit.SelectedValue.ToString().ToUpper()),
                            UnitAIType = string.Format(Properties.Resources.txt_unit_ai, Dictionaries.UnitDictionary[unit].Item2.ToString().ToUpper()),
                            Count = "1"
                        }
                    },

                    Civilization_Religions = new Civilization_Religions
                    {
                        Row = new Models.Civilization.Religions.Row
                        {
                            CivilizationType = civType,
                            ReligionType = string.Format(Properties.Resources.txt_religion, cbReligion.SelectedValue.ToString().ToUpper())
                        }
                    },

                    Civilization_BuildingClassOverrides = new Civilization_BuildingClassOverrides
                    {
                        Row = new List<Models.Civilization.BuildingClassOverrides.Row>()
                    }
                };

                foreach (var x in lbCityNames.Items)
                {
                    var name = x.ToString().ToUpper();
                    var city = new Models.Civilization.CityNames.Row
                    {
                        CivilizationType = civType,
                        CityName = name
                    };
                    gameData.Civilization_CityNames.Row.Add(city);
                }

                foreach (var x in lbSpyNames.Items)
                {
                    var name = x.ToString();
                    var spy = new Models.Civilization.SpyNames.Row
                    {
                        CivilizationType = civType,
                        SpyName = name
                    };
                    gameData.Civilization_SpyNames.Row.Add(spy);
                }

                var building = new Models.Civilization.BuildingClassOverrides.Row
                {
                    CivilizationType = civType,
                    BuildingClassType = string.Format(Properties.Resources.txt_building_class, cbBuildingOverride.SelectedValue.ToString().ToUpper()),
                    BuildingType = string.Format(Properties.Resources.txt_building, settings.civ_name, settings.building_name)
                };
                gameData.Civilization_BuildingClassOverrides.Row.Add(building);

                // TO-DO: Add Unit Override

                SerializeXml(gameData, nameof(FileCategories.Civilization));
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GenerateLeaderXml()
        {
            try
            {
                if (!ValidationForm(FileCategories.Leader)) return false;
                var settings = Settings.Default;
                var leaderType = string.Format(Properties.Resources.txt_leader, settings.leader_name);
                var gameData = new Models.Leader.GameData
                {
                    Leaders = new Leaders
                    {
                        Row = new Models.Leader.Row
                        {
                            Type = leaderType,
                            Description = string.Format(Properties.Resources.key_leader, tbLeaderType.Text),
                            Civilopedia = string.Format(Properties.Resources.key_leader_pedia, tbLeaderType.Text),
                            CivilopediaTag = string.Format(Properties.Resources.key_leader_pedia, tbLeaderType.Text),
                            ArtDefineTag = string.Format(Properties.Resources.txt_leader_scene, tbLeaderType.Text),
                            VictoryCompetitiveness = intCompVictory.Text,
                            WonderCompetitiveness = intCompWonder.Text,
                            MinorCivCompetitiveness = intCompMinor.Text,
                            Boldness = intBoldness.Text,
                            DiploBalance = intDiploBalance.Text,
                            WarmongerHate = intWarmongerHate.Text,
                            WorkAgainstWillingness = intWorkAgainstWill.Text,
                            WorkWithWillingness = intWorkWithWill.Text,
                            DenounceWillingness = intDenounceWill.Text,
                            Loyalty = intLoyalty.Text,
                            Neediness = intNeediness.Text,
                            Forgiveness = intForgiveness.Text,
                            Chattiness = intChattiness.Text,
                            Meanness = intMeanness.Text,
                            PortraitIndex = intLeaderPortraitIndex.Text,
                            IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, tbType.Text)
                        }
                    },

                    Leader_Traits = new Leader_Traits
                    {
                        Row = new Models.Leader.Traits.Row
                        {
                            LeaderType = leaderType,
                            TraitType = string.Format(Properties.Resources.txt_trait, settings.trait_name)
                        }
                    },

                    Leader_MajorCivApproachBiases = new Leader_MajorCivApproachBiases
                    {
                        Row = new List<Models.Leader.MajorCivApproachBiases.Row>()
                    },

                    Leader_MinorCivApproachBiases = new Leader_MinorCivApproachBiases
                    {
                        Row = new List<Models.Leader.MinorCivApproachBiases.Row>()
                    },

                    Leader_Flavors = new Leader_Flavors
                    {
                        Row = new List<Models.Leader.Flavors.Row>()
                    }
                };

                var major = new Models.Leader.MajorCivApproachBiases.Row
                {
                    LeaderType = leaderType,
                    MajorCivApproachType = string.Format(Properties.Resources.txt_major_approach, "WAR"),
                    Bias = "4"
                };
                gameData.Leader_MajorCivApproachBiases.Row.Add(major);

                var minor = new Models.Leader.MinorCivApproachBiases.Row
                {
                    LeaderType = leaderType,
                    MinorCivApproachType = string.Format(Properties.Resources.txt_minor_approach, "IGNORE"),
                    Bias = "6"
                };
                gameData.Leader_MinorCivApproachBiases.Row.Add(minor);

                var flavor = new Models.Leader.Flavors.Row
                {
                    LeaderType = leaderType,
                    FlavorType = string.Format(Properties.Resources.txt_flavor, "OFFENSE"),
                    Flavor = "6"
                };
                gameData.Leader_Flavors.Row.Add(flavor);

                SerializeXml(gameData, FileCategories.Leader.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GenerateTraitXml()
        {
            try
            {
                var settings = Settings.Default;
                var traitType = string.Format(Properties.Resources.txt_trait, settings.trait_name);
                var gameData = new Models.Trait.GameData
                {
                    Traits = new Traits
                    {
                        Row = new Models.Trait.Row
                        {
                            Type = traitType,
                            ShortDescription = string.Format(Properties.Resources.key_trait, tbTraitType.Text),
                            Description = string.Format(Properties.Resources.key_trait_desc, tbTraitType.Text),
                            LevelExperienceModifier = "0",
                            GreatPeopleRateModifier = "0",
                            GreatScientistRateModifier = "0",
                            GreatGeneralRateModifier = "0",
                            GreatGeneralExtraBonus = "0",
                            GreatPersonGiftInfluence = "0",
                            MaxGlobalBuildingProductionModifier = "0",
                            MaxTeamBuildingProductionModifier = "0",
                            MaxPlayerBuildingProductionModifier = "0",
                            CityUnhappinessModifier = "0",
                            PopulationUnhappinessModifier = "0",
                            CityStateBonusModifier = "0",
                            CityStateFriendshipModifier = "0",
                            CityStateCombatModifier = "0",
                            LandBarbarianConversionPercent = "0",
                            LandBarbarianConversionExtraUnits = "0",
                            SeaBarbarianConversionPercent = "0",
                            LandUnitMaintenanceModifier = "0",
                            NavalUnitMaintenanceModifier = "0",
                            CapitalBuildingModifier = "0",
                            PlotBuyCostModifier = "-50",
                            PlotCultureCostModifier = "0",
                            CultureFromKills = "0",
                            CityCultureBonus = "0",
                            CapitalThemingBonusModifier = "0",
                            PolicyCostModifier = "0",
                            CityConnectionTradeRouteChange = "0",
                            WonderProductionModifier = "0",
                            PlunderModifier = "0",
                            ImprovementMaintenanceModifier = "0",
                            GoldenAgeDurationModifier = "0",
                            GoldenAgeMoveChange = "0",
                            GoldenAgeCombatModifier = "0",
                            GoldenAgeTourismModifier = "0",
                            GoldenAgeGreatArtistRateModifier = "0",
                            GoldenAgeGreatMusicianRateModifier = "0",
                            GoldenAgeGreatWriterRateModifier = "0",
                            ExtraEmbarkMoves = "0",
                            NaturalWonderFirstFinderGold = "0",
                            NaturalWonderSubsequentFinderGold = "0",
                            NaturalWonderYieldModifier = "0",
                            NaturalWonderHappinessModifier = "0",
                            NearbyImprovementCombatBonus = "0",
                            NearbyImprovementBonusRange = "0",
                            CultureBuildingYieldChange = "0",
                            CombatBonusVsHigherTech = "0",
                            CombatBonusVsLargerCiv = "0",
                            RazeSpeedModifier = "0",
                            DOFGreatPersonModifier = "0",
                            LuxuryHappinessRetention = "0",
                            ExtraSpies = "0",
                            UnresearchedTechBonusFromKills = "0",
                            ExtraFoundedCityTerritoryClaimRange = "0",
                            FreeSocialPoliciesPerEra = "0",
                            NumTradeRoutesModifier = "0",
                            TradeRouteResourceModifier = "0",
                            UniqueLuxuryCities = "0",
                            UniqueLuxuryQuantity = "0",
                            WorkerSpeedModifier = "0",
                            AfraidMinorPerTurnInfluence = "0",
                            LandTradeRouteRangeBonus = "0",
                            TradeReligionModifier = "0",
                            TradeBuildingModifier = "0",
                            FightWellDamaged = "0",
                            MoveFriendlyWoodsAsRoad = "0",
                            FasterAlongRiver = "0",
                            FasterInHills = "0",
                            EmbarkedAllWater = "0",
                            EmbarkedToLandFlatCost = "0",
                            NoHillsImprovementMaintenance = "0",
                            TechBoostFromCapitalScienceBuildings = "0",
                            StaysAliveZeroCities = "0",
                            FaithFromUnimprovedForest = "0",
                            BonusReligiousBelief = "0",
                            AbleToAnnexCityStates = "0",
                            CrossesMountainsAfterGreatGeneral = "0",
                            MayaCalendarBonuses = "0",
                            NoAnnexing = "0",
                            TechFromCityConquer = "0",
                            UniqueLuxuryRequiresNewArea = "0",
                            RiverTradeRoad = "0",
                            AngerFreeIntrusionOfCityStates = "0",
                            FreeUnit = " ",
                            FreeUnitPrereqTech = " ",
                            CombatBonusImprovement = " ",
                            FreeBuilding = " ",
                            FreeBuildingOnConquest = " ",
                            ObsoleteTech = " ",
                            PrereqTech = " "
                        }
                    },

                    Trait_YieldChangesStrategicResources = new Trait_YieldChangesStrategicResources
                    {
                        Row = new Models.Trait.YieldChangesStrategicResources.Row
                        {
                            TraitType = traitType,
                            YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                            Yield = "3"
                        }
                    },

                    Trait_ResourceQuantityModifiers = new Trait_ResourceQuantityModifiers
                    {
                        Row = new List<Models.Trait.ResourceQuantityModifiers.Row>()
                    }
                };

                var resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = traitType,
                    ResourceType = string.Format(Properties.Resources.txt_resource, Resource.Iron.ToString().ToUpper()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = traitType,
                    ResourceType = string.Format(Properties.Resources.txt_resource, Resource.Coal.ToString().ToUpper()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = traitType,
                    ResourceType = string.Format(Properties.Resources.txt_resource, Resource.Oil.ToString().ToUpper()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                SerializeXml(gameData, FileCategories.Trait.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GeneratePlayerColorXml()
        {
            try
            {
                var gameData = new Models.PlayerColor.GameData
                {
                    PlayerColors = new PlayerColors
                    {
                        Row = new Models.PlayerColor.Row
                        {
                            Type = string.Format(Properties.Resources.txt_civ_color, tbType.Text),
                            PrimaryColor = string.Format(Properties.Resources.txt_civ_color_primary, tbType.Text),
                            SecondaryColor = string.Format(Properties.Resources.txt_civ_color_secondary, tbType.Text),
                            TextColor = string.Format(Properties.Resources.txt_civ_color_text, tbType.Text)
                        }
                    },

                    Colors = new List<Colors>()
                };

                var colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color_primary, tbType.Text),
                        Red = FormatColorSelection(cpPrimaryColor.SelectedColor.Value.R.ToString()),
                        Green = FormatColorSelection(cpPrimaryColor.SelectedColor.Value.G.ToString()),
                        Blue = FormatColorSelection(cpPrimaryColor.SelectedColor.Value.B.ToString()),
                        Alpha = FormatColorSelection(cpPrimaryColor.SelectedColor.Value.A.ToString())
                    }
                };
                gameData.Colors.Add(colorList);

                colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color_secondary, tbType.Text),
                        Red = FormatColorSelection(cpSecondaryColor.SelectedColor.Value.R.ToString()),
                        Green = FormatColorSelection(cpSecondaryColor.SelectedColor.Value.G.ToString()),
                        Blue = FormatColorSelection(cpSecondaryColor.SelectedColor.Value.B.ToString()),
                        Alpha = FormatColorSelection(cpSecondaryColor.SelectedColor.Value.A.ToString())
                    }
                };
                gameData.Colors.Add(colorList);

                colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color_text, tbType.Text),
                        Red = FormatColorSelection(cpTextColor.SelectedColor.Value.R.ToString()),
                        Green = FormatColorSelection(cpTextColor.SelectedColor.Value.G.ToString()),
                        Blue = FormatColorSelection(cpTextColor.SelectedColor.Value.B.ToString()),
                        Alpha = FormatColorSelection(cpTextColor.SelectedColor.Value.A.ToString())
                    }
                };
                gameData.Colors.Add(colorList);

                SerializeXml(gameData, FileCategories.PlayerColor.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GenerateBuildingsXml()
        {
            try
            {
                var settings = Settings.Default;
                var buildingType = string.Format(Properties.Resources.txt_building, settings.civ_name, settings.building_name);
                var gameData = new Models.Buildings.GameData
                {
                    Buildings = new Buildings
                    {
                        Row = new Models.Buildings.Row
                        {
                            Type = buildingType,
                            Description = string.Format(Properties.Resources.key_building_desc, tbType.Text, settings.building_name),
                            Civilopedia = string.Format(Properties.Resources.key_building_pedia, tbType.Text, settings.building_name),
                            Strategy = string.Format(Properties.Resources.key_building_strategy, tbType.Text, settings.building_name),
                            Help = string.Format(Properties.Resources.key_building_help, tbType.Text, settings.building_name),
                            BuildingClass = string.Format(Properties.Resources.txt_building_class, cbBuildingOverride.SelectedValue.ToString().ToUpper()),
                            ArtDefineTag = string.Format(Properties.Resources.txt_building_art_def, cbBuildingOverride.SelectedValue.ToString().ToUpper()),
                            FreeStartEra = string.Format(Properties.Resources.txt_era, cbBuildingStartEra.SelectedValue.ToString().ToUpper()),
                            PrereqTech = string.Format(Properties.Resources.txt_tech, cbBuildingReqTech.SelectedValue.ToString().ToUpper()),
                            IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, tbType.Text),
                            ThemingBonusHelp = "",
                            Quote = "",
                            GoldMaintenance = "0",
                            MutuallyExclusiveGroup = "-1",
                            TeamShare = "0",
                            Water = "0",
                            River = "0",
                            FreshWater = "0",
                            Mountain = "0",
                            NearbyMountainRequired = "0",
                            Hill = "0",
                            Flat = "0",
                            FoundsReligion = "0",
                            IsReligious = "0",
                            BorderObstacle = "0",
                            PlayerBorderObstacle = "0",
                            Capital = "0",
                            GoldenAge = "0",
                            MapCentering = "0",
                            NeverCapture = "0",
                            NukeImmune = "0",
                            AllowsWaterRoutes = "0",
                            ExtraLuxuries = "0",
                            DiplomaticVoting = "0",
                            AffectSpiesNow = "0",
                            NullifyInfluenceModifier = "0",
                            Cost = "100",
                            FaithCost = "0",
                            LeagueCost = "0",
                            UnlockedByBelief = "0",
                            UnlockedByLeague = "0",
                            HolyCity = "0",
                            NumCityCostMod = "0",
                            HurryCostModifier = "25",
                            MinAreaSize = "-1",
                            ConquestProb = "66",
                            CitiesPrereq = "0",
                            LevelPrereq = "0",
                            CultureRateModifier = "0",
                            GlobalCultureRateModifier = "0",
                            GreatPeopleRateModifier = "0",
                            GlobalGreatPeopleRateModifier = "0",
                            GreatGeneralRateModifier = "0",
                            GreatPersonExpendGold = "0",
                            GoldenAgeModifier = "0",
                            UnitUpgradeCostMod = "0",
                            Experience = "0",
                            GlobalExperience = "0",
                            FoodKept = "0",
                            Airlift = "0",
                            AirModifier = "0",
                            NukeModifier = "0",
                            NukeExplosionRand = "0",
                            HealRateChange = "0",
                            Happiness = "0",
                            UnmoddedHappiness = "0",
                            UnhappinessModifier = "0",
                            HappinessPerCity = "0",
                            HappinessPerXPolicies = "0",
                            CityCountUnhappinessMod = "0",
                            NoOccupiedUnhappiness = "0",
                            WorkerSpeedModifier = "0",
                            MilitaryProductionModifier = "0",
                            SpaceProductionModifier = "0",
                            GlobalSpaceProductionModifier = "0",
                            BuildingProductionModifier = "0",
                            WonderProductionModifier = "0",
                            CityConnectionTradeRouteModifier = "0",
                            CapturePlunderModifier = "0",
                            PolicyCostModifier = "0",
                            PlotCultureCostModifier = "0",
                            GlobalPlotCultureCostModifier = "0",
                            PlotBuyCostModifier = "0",
                            GlobalPlotBuyCostModifier = "0",
                            GlobalPopulationChange = "0",
                            TechShare = "0",
                            FreeTechs = "0",
                            FreePolicies = "0",
                            FreeGreatPeople = "0",
                            MedianTechPercentChange = "0",
                            Gold = "0",
                            AllowsRangeStrike = "0",
                            Espionage = "0",
                            AllowsFoodTradeRoutes = "0",
                            AllowsProductionTradeRoutes = "0",
                            Defense = "0",
                            ExtraCityHitPoints = "0",
                            GlobalDefenseMod = "0",
                            MinorFriendshipChange = "0",
                            VictoryPoints = "0",
                            ExtraMissionarySpreads = "0",
                            ReligiousPressureModifier = "0",
                            EspionageModifier = "0",
                            GlobalEspionageModifier = "0",
                            ExtraSpies = "0",
                            SpyRankChange = "0",
                            InstantSpyRankChange = "0",
                            TradeRouteRecipientBonus = "1",
                            TradeRouteTargetBonus = "1",
                            NumTradeRouteBonus = "0",
                            LandmarksTourismPercent = "0",
                            InstantMilitaryIncrease = "0",
                            GreatWorksTourismModifier = "0",
                            XBuiltTriggersIdeologyChoice = "0",
                            TradeRouteSeaDistanceModifier = "0",
                            TradeRouteSeaGoldBonus = "0",
                            TradeRouteLandDistanceModifier = "0",
                            TradeRouteLandGoldBonus = "0",
                            CityStateTradeRouteProductionModifier = "0",
                            GreatScientistBeakerModifier = "0",
                            NearbyTerrainRequired = "",
                            ProhibitedCityTerrain = "",
                            VictoryPrereq = "",
                            MaxStartEra = "",
                            ObsoleteTech = "",
                            EnhancedYieldTech = "",
                            TechEnhancedTourism = "0",
                            FreeBuilding = "",
                            FreeBuildingThisCity = "",
                            FreePromotion = "",
                            TrainedFreePromotion = "",
                            FreePromotionRemoved = "",
                            ReplacementBuildingClass = "",
                            PolicyBranchType = "",
                            SpecialistType = string.Format(Properties.Resources.txt_specialist, Units.Merchant.ToString().ToUpper()),
                            SpecialistCount = "1",
                            GreatWorkSlotType = "",
                            FreeGreatWork = "",
                            GreatWorkCount = "0",
                            SpecialistExtraCulture = "0",
                            GreatPeopleRateChange = "0",
                            ExtraLeagueVotes = "0",
                            CityWall = "0",
                            DisplayPosition = "0",
                            PortraitIndex = intBuildingPortraitIndex.Text,
                            WonderSplashImage = "",
                            WonderSplashAnchor = "R,T",
                            WonderSplashAudio = "",
                            ArtInfoCulturalVariation = "0",
                            ArtInfoEraVariation = "0",
                            ArtInfoRandomVariation = "0"
                        }
                    },

                    Building_Flavors = new Building_Flavors
                    {
                        Row = new List<Models.Buildings.Flavors.Row>()
                    },

                    Building_YieldChanges = new Building_YieldChanges
                    {
                        Row = new Models.Buildings.YieldChanges.Row
                        {
                            BuildingType = buildingType,
                            YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                            Yield = "5"
                        }
                    },

                    Building_YieldModifiers = new Building_YieldModifiers
                    {
                        Row = new Models.Buildings.YieldModifiers.Row
                        {
                            BuildingType = buildingType,
                            YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                            Yield = "25"
                        }
                    }
                };

                var flavor = new Models.Buildings.Flavors.Row
                {
                    BuildingType = buildingType,
                    FlavorType = string.Format(Properties.Resources.txt_flavor, Resource.Gold.ToString().ToUpper()),
                    Flavor = "25"
                };
                gameData.Building_Flavors.Row.Add(flavor);

                SerializeXml(gameData, FileCategories.Buildings.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GenerateUnitsXml()
        {
            try
            {
                var gameData = new Models.Units.GameData();

                SerializeXml(gameData, FileCategories.Units.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GenerateIconAtlasXml()
        {
            try
            {
                var gameData = new Models.IconAtlas.GameData
                {
                    IconTextureAtlases = new IconTextureAtlases
                    {
                        Row = new List<Models.IconAtlas.Row>()
                    }
                };

                var image = new Models.IconAtlas.Row
                {
                    Atlas = string.Format(Properties.Resources.txt_civ_atlas_alpha, tbType.Text),
                    IconSize = "128",
                    Filename = string.Format(Properties.Resources.txt_civ_atlas_alpha_file, tbType.Text, "128"),
                    IconsPerRow = "1",
                    IconsPerColumn = "1"
                };
                gameData.IconTextureAtlases.Row.Add(image);

                SerializeXml(gameData, FileCategories.IconAtlas.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool GenerateGameTextXml()
        {
            try
            {
                var gameData = new Models.GameText.GameData
                {
                    Language_en_US = new Language_en_US
                    {
                        Row = new List<Models.GameText.Row>()
                    }
                };

                var text = new Models.GameText.Row
                {
                    Tag = string.Format(Properties.Resources.key_civ_adjective, tbType.Text),
                    Text = "Mann Co."
                };
                gameData.Language_en_US.Row.Add(text);

                SerializeXml(gameData, FileCategories.GameText.ToString());
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool SaveValuesToConfig()
        {
            try
            {
                var settings = Settings.Default;
                settings.civ_name = tbType.Text;
                settings.leader_name = tbLeaderType.Text;
                settings.trait_name = tbTraitType.Text;
                settings.building_name = tbBuildingType.Text;
                settings.unit_name = tbBuildingType.Text;
                settings.Save();
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private bool ValidationForm(FileCategories civilization)
        {
            var result = true;
            switch (civilization)
            {
                case FileCategories.Civilization:
                    if (string.IsNullOrWhiteSpace(tbType.Text))
                    {
                        MessageBox.Show("Invalid Civilization Name", "Invalid Civilization Name", MessageBoxButton.OK, MessageBoxImage.Error);
                        TabControls.SelectedIndex = 0;
                        result = false;
                    }

                    break;

                case FileCategories.Leader:
                    if (string.IsNullOrWhiteSpace(tbLeaderType.Text))
                    {
                        MessageBox.Show("Invalid Leader Name", "Invalid Leader Name", MessageBoxButton.OK, MessageBoxImage.Error);
                        TabControls.SelectedIndex = 1;
                        result = false;
                    }

                    break;

                case FileCategories.Trait:
                    if (string.IsNullOrWhiteSpace(tbTraitType.Text))
                    {
                        MessageBox.Show("Invalid Trait Name", "Invalid Trait Name", MessageBoxButton.OK, MessageBoxImage.Error);
                        TabControls.SelectedIndex = 2;
                        result = false;
                    }

                    break;
            }

            return result;
        }

        private void SerializeXml<T>(T gameData, string fileName)
        {
            if (!CheckDirectory()) return;
            var writer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var path = $"{_outputPath}\\{fileName}.xml";
            var file = File.Create(path);
            writer.Serialize(file, gameData, ns);
            file.Close();
        }

        private bool CheckDirectory()
        {
            try
            {
                if (!Directory.Exists(_outputPath))
                    Directory.CreateDirectory(_outputPath);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private void LoadGuiElements()
        {
            // Civilization
            tbType.Text = Settings.Default.civ_name.Replace($"CIVILIZATION_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbDerivative.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(ArtStyles)))
                cbArtStyle.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbSoundtrack.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Building)))
                cbFreeBuilding.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Units)))
                cbFreeUnit.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Technologies)))
                cbFreeTech.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Religions)))
                cbReligion.Items.Add(item.ToString());

            // Leader
            tbLeaderType.Text = Settings.Default.leader_name.Replace($"LEADER_", string.Empty);

            // Trait
            tbTraitType.Text = Settings.Default.trait_name.Replace($"TRAIT_", string.Empty);

            // Building
            tbBuildingType.Text = Settings.Default.building_name.Replace($"BUILDING_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(Building)))
                cbBuildingOverride.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Eras)))
                cbBuildingStartEra.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Technologies)))
                cbBuildingReqTech.Items.Add(item.ToString());

            // Unit
            tbUnitType.Text = Settings.Default.unit_name.Replace($"UNIT_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(Units)))
                cbUnitOverride.Items.Add(item.ToString());
        }

        private string FormatColorSelection(string value)
        {
            var color = Convert.ToDouble(value);
            return Math.Round(color / 255, 3).ToString(CultureInfo.InvariantCulture);
        }

        private string GetStringKey(string text, FileCategories category = FileCategories.GameText)
        {
            var settings = Settings.Default;
            text = text.Replace(' ', '_').ToUpper();
            switch (category)
            {
                case FileCategories.Buildings:
                    return $"BUILDING_{settings.civ_name}_{text}";

                case FileCategories.Civilization:
                    return $"CIVILIZATION_{text}";

                case FileCategories.GameText:
                    return text;

                case FileCategories.IconAtlas:
                    return $"CIV_{settings.civ_name}_{text}_ATLAS";

                case FileCategories.Leader:
                    return $"LEADER_{settings.civ_name}";

                case FileCategories.PlayerColor:
                    return $"PLAYERCOLOR_{settings.civ_name}_{text}";

                case FileCategories.Trait:
                    return $"TRAIT_{text}";

                case FileCategories.Units:
                    return $"UNIT_{settings.civ_name}_{text}";
            }

            return string.Empty;
        }

        private string GetArtPrefix(ArtStyles style)
        {
            switch (style)
            {
                case ArtStyles.African:
                    return "_AFRI";

                case ArtStyles.American:
                    return "_AMER";

                case ArtStyles.Asian:
                    return "_ASIA";

                case ArtStyles.European:
                    return "_EURO";

                default:
                    return "_MED";
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            intCompVictory.Text = random.Next(1, 10).ToString();
            intCompWonder.Text = random.Next(1, 10).ToString();
            intCompMinor.Text = random.Next(1, 10).ToString();
            intBoldness.Text = random.Next(1, 10).ToString();
            intDiploBalance.Text = random.Next(1, 10).ToString();
            intWarmongerHate.Text = random.Next(1, 10).ToString();
            intWorkAgainstWill.Text = random.Next(1, 10).ToString();
            intWorkWithWill.Text = random.Next(1, 10).ToString();
            intDenounceWill.Text = random.Next(1, 10).ToString();
            intLoyalty.Text = random.Next(1, 10).ToString();
            intNeediness.Text = random.Next(1, 10).ToString();
            intForgiveness.Text = random.Next(1, 10).ToString();
            intChattiness.Text = random.Next(1, 10).ToString();
            intMeanness.Text = random.Next(1, 10).ToString();
            intWar.Text = random.Next(1, 10).ToString();
            intHostile.Text = random.Next(1, 10).ToString();
            intDeceptive.Text = random.Next(1, 10).ToString();
            intGuarded.Text = random.Next(1, 10).ToString();
            intAfraid.Text = random.Next(1, 10).ToString();
            intFriendlyMajor.Text = random.Next(1, 10).ToString();
            intNeutral.Text = random.Next(1, 10).ToString();
            intIgnore.Text = random.Next(1, 10).ToString();
            intFriendlyMinor.Text = random.Next(1, 10).ToString();
            intProtective.Text = random.Next(1, 10).ToString();
            intConquest.Text = random.Next(1, 10).ToString();
            intBully.Text = random.Next(1, 10).ToString();
            intOffense.Text = random.Next(1, 10).ToString();
            intDefense.Text = random.Next(1, 10).ToString();
            intExpansion.Text = random.Next(1, 10).ToString();
            intGrowth.Text = random.Next(1, 10).ToString();
            intTileImprove.Text = random.Next(1, 10).ToString();
            intInfrastructure.Text = random.Next(1, 10).ToString();
            intProduction.Text = random.Next(1, 10).ToString();
            intGold.Text = random.Next(1, 10).ToString();
            intScience.Text = random.Next(1, 10).ToString();
            intCulture.Text = random.Next(1, 10).ToString();
            intHappiness.Text = random.Next(1, 10).ToString();
            intGreatPeople.Text = random.Next(1, 10).ToString();
            intGreatWonders.Text = random.Next(1, 10).ToString();
            intReligions.Text = random.Next(1, 10).ToString();
            intDiplomacy.Text = random.Next(1, 10).ToString();
            intSpaceship.Text = random.Next(1, 10).ToString();
            intWaterConnection.Text = random.Next(1, 10).ToString();
            intNuke.Text = random.Next(1, 10).ToString();
            intUseNuke.Text = random.Next(1, 10).ToString();
            intEspionage.Text = random.Next(1, 10).ToString();
            intAntiAir.Text = random.Next(1, 10).ToString();
            intAirCarrier.Text = random.Next(1, 10).ToString();
            intArchaeology.Text = random.Next(1, 10).ToString();
            intLandTradeRoutes.Text = random.Next(1, 10).ToString();
            intSeaTradeRoutes.Text = random.Next(1, 10).ToString();
            intTradeOrigin.Text = random.Next(1, 10).ToString();
            intTradeDestination.Text = random.Next(1, 10).ToString();
            intAirList.Text = random.Next(1, 10).ToString();
        }

        private void BAddCity_OnClick(object sender, RoutedEventArgs e)
        {
            var input = Interaction.InputBox("Please input a new city name:", "Add City Name", "");
            lbCityNames.Items.Add(input);
        }

        private void BRemoveCity_OnClick(object sender, RoutedEventArgs e)
        {
            if (lbCityNames.SelectedItem == null) return;
            lbCityNames.Items.RemoveAt(lbCityNames.Items.IndexOf(lbCityNames.SelectedItem));
        }

        private void BClearCity_OnClick(object sender, RoutedEventArgs e)
        {
            lbCityNames.Items.Clear();
        }

        private void bAddSpy_Click(object sender, RoutedEventArgs e)
        {
            var input = Interaction.InputBox("Please input a new spy name:", "Add Spy Name", "");
            lbSpyNames.Items.Add(input);
        }

        private void bRemoveSpy_Click(object sender, RoutedEventArgs e)
        {
            if (lbSpyNames.SelectedItem == null) return;
            lbSpyNames.Items.RemoveAt(lbSpyNames.Items.IndexOf(lbSpyNames.SelectedItem));
        }

        private void bClearSpy_Click(object sender, RoutedEventArgs e)
        {
            lbSpyNames.Items.Clear();
        }
    }
}
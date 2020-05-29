using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
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
using CivModTool.Models.PlayerColor.Color;
using CivModTool.Models.Trait;
using CivModTool.Models.Trait.ResourceQuantityModifiers;
using CivModTool.Models.Trait.YieldChangesStrategicResources;
using CivModTool.Properties;
using CivModTool.Resources.EnumTypes;
using log4net;
using log4net.Config;
using GameData = CivModTool.Models.Civilization.GameData;
using Row = CivModTool.Models.Civilization.Row;

namespace CivModTool
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static readonly Dictionary<Civs, Tuple<int, string, ArtStyles>> CivDictionary =
            new Dictionary<Civs, Tuple<int, string, ArtStyles>>
            {
                {Civs.America, new Tuple<int, string, ArtStyles>(1, "American", ArtStyles.American)},
                {Civs.Arabia, new Tuple<int, string, ArtStyles>(2, "Arabian", ArtStyles.African)},
                {Civs.Assyria, new Tuple<int, string, ArtStyles>(3, "Assyrian", ArtStyles.Mediterranean)},
                {Civs.Austria, new Tuple<int, string, ArtStyles>(4, "Austrian", ArtStyles.European)},
                {Civs.Aztec, new Tuple<int, string, ArtStyles>(5, "Aztec", ArtStyles.American)},
                {Civs.Babylon, new Tuple<int, string, ArtStyles>(6, "Babylonian", ArtStyles.Mediterranean)},
                {Civs.Brazil, new Tuple<int, string, ArtStyles>(7, "Brazilian", ArtStyles.American)},
                {Civs.Byzantium, new Tuple<int, string, ArtStyles>(8, "Byzantine", ArtStyles.Mediterranean)},
                {Civs.Carthage, new Tuple<int, string, ArtStyles>(9, "Carthaginian", ArtStyles.Mediterranean)},
                {Civs.Celts, new Tuple<int, string, ArtStyles>(10, "Celts", ArtStyles.European)},
                {Civs.China, new Tuple<int, string, ArtStyles>(11, "Chinese", ArtStyles.Asian)},
                {Civs.Denmark, new Tuple<int, string, ArtStyles>(12, "Dutch", ArtStyles.European)},
                {Civs.Egypt, new Tuple<int, string, ArtStyles>(13, "Egyptian", ArtStyles.African)},
                {Civs.England, new Tuple<int, string, ArtStyles>(14, "English", ArtStyles.European)},
                {Civs.Ethiopia, new Tuple<int, string, ArtStyles>(15, "Ethiopian", ArtStyles.African)},
                {Civs.France, new Tuple<int, string, ArtStyles>(16, "French", ArtStyles.American)},
                {Civs.Germany, new Tuple<int, string, ArtStyles>(17, "German", ArtStyles.European)},
                {Civs.Greece, new Tuple<int, string, ArtStyles>(18, "Greek", ArtStyles.Mediterranean)},
                {Civs.Huns, new Tuple<int, string, ArtStyles>(19, "Hunnic", ArtStyles.Asian)},
                {Civs.Inca, new Tuple<int, string, ArtStyles>(20, "Incan", ArtStyles.American)},
                {Civs.India, new Tuple<int, string, ArtStyles>(21, "Indian", ArtStyles.Asian)},
                {Civs.Indonesia, new Tuple<int, string, ArtStyles>(22, "Indonesian", ArtStyles.Asian)},
                {Civs.Iroquois, new Tuple<int, string, ArtStyles>(23, "Iroquois", ArtStyles.American)},
                {Civs.Japan, new Tuple<int, string, ArtStyles>(24, "Japanese", ArtStyles.Asian)},
                {Civs.Korea, new Tuple<int, string, ArtStyles>(25, "Korean", ArtStyles.Asian)},
                {Civs.Maya, new Tuple<int, string, ArtStyles>(26, "Mayan", ArtStyles.American)},
                {Civs.Mongol, new Tuple<int, string, ArtStyles>(27, "Mongolian", ArtStyles.Asian)},
                {Civs.Morocco, new Tuple<int, string, ArtStyles>(28, "Moroccan", ArtStyles.African)},
                {Civs.Netherlands, new Tuple<int, string, ArtStyles>(29, "Dutch", ArtStyles.European)},
                {Civs.Ottoman, new Tuple<int, string, ArtStyles>(30, "Ottoman", ArtStyles.African)},
                {Civs.Persia, new Tuple<int, string, ArtStyles>(31, "Persian", ArtStyles.African)},
                {Civs.Poland, new Tuple<int, string, ArtStyles>(32, "Polish", ArtStyles.European)},
                {Civs.Polynesia, new Tuple<int, string, ArtStyles>(33, "Polynesian", ArtStyles.Asian)},
                {Civs.Portugal, new Tuple<int, string, ArtStyles>(34, "Portuguese", ArtStyles.European)},
                {Civs.Rome, new Tuple<int, string, ArtStyles>(35, "Roman", ArtStyles.Mediterranean)},
                {Civs.Russia, new Tuple<int, string, ArtStyles>(36, "Russian", ArtStyles.European)},
                {Civs.Shoshone, new Tuple<int, string, ArtStyles>(37, "Shoshone", ArtStyles.American)},
                {Civs.Siam, new Tuple<int, string, ArtStyles>(38, "Siamese", ArtStyles.Asian)},
                {Civs.Songhai, new Tuple<int, string, ArtStyles>(39, "Songhai", ArtStyles.African)},
                {Civs.Spain, new Tuple<int, string, ArtStyles>(40, "Spanish", ArtStyles.European)},
                {Civs.Sweden, new Tuple<int, string, ArtStyles>(41, "Swedish", ArtStyles.European)},
                {Civs.Venice, new Tuple<int, string, ArtStyles>(42, "Venetian", ArtStyles.Mediterranean)},
                {Civs.Zulu, new Tuple<int, string, ArtStyles>(43, "Zulu", ArtStyles.African)}
            };

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
            AutoUpdater.Start(Properties.Resources.app_update);
        }

        private void btnGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            if (!GenerateCivilizationXml()) return;
            if (!GenerateLeaderXml()) return;
            if (!GenerateTraitXml()) return;
            if (!GeneratePlayerColorXml()) return;
            if (!GenerateIconAtlasXml()) return;
            if (!GenerateGameTextXml()) return;
            if (!GenerateBuildingsXml()) return;
            GenerateUnitsXml();
        }

        private bool GenerateCivilizationXml()
        {
            try
            {
                if (!ValidationForm(FileCategories.Civilization)) return false;
                var settings = Settings.Default;
                var derivative = GetStringKey(cbDerivative.SelectedValue.ToString(), FileCategories.Civilization);
                var artStyle =
                    GetArtPrefix((ArtStyles) Enum.Parse(typeof(ArtStyles), cbArtStyle.SelectedValue.ToString()));
                var gameData = new GameData
                {
                    Civilizations = new Civilizations
                    {
                        Row = new Row
                        {
                            Type = settings.civ_name,
                            DerivativeCiv = derivative,
                            Description = string.Format(Properties.Resources.key_civ_desc, tbType.Text),
                            ShortDescription = string.Format(Properties.Resources.key_civ_desc_short, tbType.Text),
                            Adjective = string.Format(Properties.Resources.key_civ_adjective, tbType.Text),
                            Civilopedia = string.Format(Properties.Resources.key_civ_pedia_header, tbType.Text),
                            CivilopediaTag = string.Format(Properties.Resources.key_civ_pedia_text, tbType.Text),
                            DefaultPlayerColor = string.Format(Properties.Resources.key_civ_color, tbType.Text),
                            ArtDefineTag = string.Format(Properties.Resources.key_civ_art_def, derivative),
                            ArtStyleType = string.Format(Properties.Resources.key_civ_art_style, cbArtStyle.SelectedValue.ToString().ToUpper()),
                            ArtStyleSuffix = artStyle,
                            ArtStylePrefix = cbArtStyle.SelectedValue.ToString().ToUpper(),
                            PortraitIndex = intCivPortraitIndex.Value.ToString(),
                            IconAtlas = string.Format(Properties.Resources.key_civ_atlas_icon, tbType.Text),
                            AlphaIconAtlas = string.Format(Properties.Resources.key_civ_atlas_alpha, tbType.Text),
                            SoundtrackTag = cbSoundtrack.SelectedValue.ToString(),
                            MapImage = string.Format(Properties.Resources.key_civ_map, tbType.Text),
                            DawnOfManQuote = string.Format(Properties.Resources.key_civ_dom_text, tbType.Text),
                            DawnOfManImage = string.Format(Properties.Resources.key_civ_dom_image, tbLeaderType.Text)
                        }
                    },

                    Civilization_Leaders = new Civilization_Leaders
                    {
                        Row = new Models.Civilization.Leaders.Row
                        {
                            CivilizationType = settings.civ_name,
                            LeaderheadType = string.Format(Properties.Resources.key_civ_leader, tbLeaderType.Text)
                        }
                    },

                    Civilization_CityNames = new Civilization_CityNames
                    {
                        Row = new List<Models.Civilization.CityNames.Row>()
                    },

                    Civilization_FreeBuildingClasses = new Civilization_FreeBuildingClasses
                    {
                        Row = new Models.Civilization.FreeBuildingClasses.Row
                        {
                            CivilizationType = settings.civ_name,
                            BuildingClassType = string.Format(Properties.Resources.key_building_class, Building.Palace)
                        }
                    },

                    Civilization_FreeTechs = new Civilization_FreeTechs
                    {
                        Row = new Models.Civilization.FreeTechs.Row
                        {
                            CivilizationType = settings.civ_name,
                            TechType = string.Format(Properties.Resources.key_tech, Technologies.Agriculture)
                        }
                    },

                    Civilization_FreeUnits = new Civilization_FreeUnits
                    {
                        Row = new Models.Civilization.FreeUnits.Row
                        {
                            CivilizationType = settings.civ_name,
                            UnitClassType = string.Format(Properties.Resources.key_tech, Technologies.Agriculture),
                            UnitAIType = string.Format(Properties.Resources.key_tech, Units.Settler),
                            Count = "1"
                        }
                    },

                    Civilization_Religions = new Civilization_Religions
                    {
                        Row = new Models.Civilization.Religions.Row
                        {
                            CivilizationType = settings.civ_name,
                            ReligionType = string.Format(Properties.Resources.key_tech, Religions.Buddhism)
                        }
                    },

                    Civilization_BuildingClassOverrides = new Civilization_BuildingClassOverrides
                    {
                        Row = new List<Models.Civilization.BuildingClassOverrides.Row>()
                    },

                    Civilization_SpyNames = new Civilization_SpyNames
                    {
                        Row = new List<Models.Civilization.SpyNames.Row>()
                    }
                };

                var city = new Models.Civilization.CityNames.Row
                {
                    CivilizationType = settings.civ_name,
                    CityName = string.Format(Properties.Resources.key_city_name, "BADLANDS")
                };
                gameData.Civilization_CityNames.Row.Add(city);

                var building = new Models.Civilization.BuildingClassOverrides.Row
                {
                    CivilizationType = settings.civ_name,
                    BuildingClassType = string.Format(Properties.Resources.key_building_class, Building.Market),
                    BuildingType = string.Format(Properties.Resources.key_building, "MANNCO_STORE")
                };
                gameData.Civilization_BuildingClassOverrides.Row.Add(building);

                var spy = new Models.Civilization.SpyNames.Row
                {
                    CivilizationType = settings.civ_name,
                    SpyName = string.Format(Properties.Resources.key_spy_name, "MANNCO", "1")
                };
                gameData.Civilization_SpyNames.Row.Add(spy);

                SerializeXml(gameData, FileCategories.Civilization.ToString());
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
                var gameData = new Models.Leader.GameData
                {
                    Leaders = new Leaders
                    {
                        Row = new Models.Leader.Row
                        {
                            Type = settings.leader_name,
                            Description = string.Format(Properties.Resources.key_civ_leader, tbLeaderType.Text),
                            Civilopedia = string.Format(Properties.Resources.key_leader_pedia, tbLeaderType.Text),
                            CivilopediaTag = string.Format(Properties.Resources.key_leader_pedia, tbLeaderType.Text),
                            ArtDefineTag = string.Format(Properties.Resources.key_leader_scene, tbLeaderType.Text),
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
                            IconAtlas = string.Format(Properties.Resources.key_civ_atlas_icon, tbType.Text)
                        }
                    },

                    Leader_Traits = new Leader_Traits
                    {
                        Row = new Models.Leader.Traits.Row
                        {
                            LeaderType = settings.leader_name,
                            TraitType = settings.trait_name
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
                    LeaderType = settings.leader_name,
                    MajorCivApproachType = "MAJOR_CIV_APPROACH_WAR",
                    Bias = "4"
                };
                gameData.Leader_MajorCivApproachBiases.Row.Add(major);

                var minor = new Models.Leader.MinorCivApproachBiases.Row
                {
                    LeaderType = settings.leader_name,
                    MinorCivApproachType = "MINOR_CIV_APPROACH_IGNORE",
                    Bias = "6"
                };
                gameData.Leader_MinorCivApproachBiases.Row.Add(minor);

                var flavor = new Models.Leader.Flavors.Row
                {
                    LeaderType = settings.leader_name,
                    FlavorType = "FLAVOR_OFFENSE",
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
                var gameData = new Models.Trait.GameData
                {
                    Traits = new Traits
                    {
                        Row = new Models.Trait.Row
                        {
                            Type = settings.trait_name,
                            ShortDescription = string.Format(Properties.Resources.key_trait, "MANNCONOMY"),
                            Description = string.Format(Properties.Resources.key_trait_desc, "MANNCONOMY"),
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
                            TraitType = settings.trait_name,
                            YieldType = string.Format(Properties.Resources.key_yield, Resource.Gold.ToString()),
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
                    TraitType = settings.trait_name,
                    ResourceType = string.Format(Properties.Resources.key_resource, Resource.Iron.ToString()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = settings.trait_name,
                    ResourceType = string.Format(Properties.Resources.key_resource, Resource.Coal.ToString()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = settings.trait_name,
                    ResourceType = string.Format(Properties.Resources.key_resource, Resource.Oil.ToString()),
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
                            Type = string.Format(Properties.Resources.key_civ_color, tbType.Text),
                            PrimaryColor = string.Format(Properties.Resources.key_civ_color_primary, tbType.Text),
                            SecondaryColor = string.Format(Properties.Resources.key_civ_color_secondary, tbType.Text),
                            TextColor = string.Format(Properties.Resources.key_civ_color_text, tbType.Text)
                        }
                    },

                    Colors = new List<Colors>()
                };

                var colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = string.Format(Properties.Resources.key_civ_color_primary, tbType.Text),
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
                        Type = string.Format(Properties.Resources.key_civ_color_secondary, tbType.Text),
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
                        Type = string.Format(Properties.Resources.key_civ_color_text, tbType.Text),
                        Red = FormatColorSelection(cpTextColor.SelectedColor.Value.R.ToString()),
                        Green = FormatColorSelection(cpTextColor.SelectedColor.Value.G.ToString()),
                        Blue = FormatColorSelection(cpTextColor.SelectedColor.Value.B.ToString()),
                        Alpha = FormatColorSelection(cpTextColor.SelectedColor.Value.A.ToString())
                    }
                };
                gameData.Colors.Add(colorList);

                SerializeXml(gameData, FileCategories.PlayerCount.ToString());
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
                    Atlas = string.Format(Properties.Resources.key_civ_atlas_alpha, tbType.Text),
                    IconSize = "128",
                    Filename = string.Format(Properties.Resources.key_civ_atlas_alpha, tbType.Text, "128"),
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

        private bool GenerateBuildingsXml()
        {
            try
            {
                var gameData = new Models.Buildings.GameData
                {
                    Buildings = new Buildings
                    {
                        Row = new Models.Buildings.Row
                        {
                            Type = "BUILDING_MANNCO_MANOR",
                            Description = "TXT_KEY_BUILDING_MANNCO_MANOR_DESC",
                            Civilopedia = "TXT_KEY_BUILDING_MANNCO_MANOR_TEXT",
                            Strategy = "TXT_KEY_BUILDING_MANNCO_MANOR_STRATEGY",
                            Help = "TXT_KEY_BUILDING_MANNCO_MANOR_HELP",
                            ThemingBonusHelp = "",
                            Quote = "",
                            GoldMaintenance = "1",
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
                            Cost = "75",
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
                            TradeRouteRecipientBonus = "0",
                            TradeRouteTargetBonus = "0",
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
                            BuildingClass = "BUILDINGCLASS_LIBRARY",
                            ArtDefineTag = "ART_DEF_BUILDING_LIBRARY",
                            NearbyTerrainRequired = "",
                            ProhibitedCityTerrain = "",
                            VictoryPrereq = "",
                            FreeStartEra = "ERA_INDUSTRIAL",
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
                            PrereqTech = "TECH_WRITING",
                            PolicyBranchType = "",
                            SpecialistType = "",
                            SpecialistCount = "0",
                            GreatWorkSlotType = "",
                            FreeGreatWork = "",
                            GreatWorkCount = "0",
                            SpecialistExtraCulture = "0",
                            GreatPeopleRateChange = "0",
                            ExtraLeagueVotes = "0",
                            CityWall = "0",
                            DisplayPosition = "0",
                            PortraitIndex = "2",
                            WonderSplashImage = "",
                            WonderSplashAnchor = "R,T",
                            WonderSplashAudio = "",
                            IconAtlas = "CIV_MANNCO_ICON_ATLAS",
                            ArtInfoCulturalVariation = "0",
                            ArtInfoEraVariation = "0",
                            ArtInfoRandomVariation = "0"
                        }
                    },

                    Building_Flavors = new Building_Flavors
                    {
                        Row = new List<Models.Buildings.Flavors.Row>()
                    },

                    Building_YieldChangesPerPop = new Building_YieldChangesPerPop
                    {
                        Row = new Models.Buildings.YieldChangesPerPop.Row
                        {
                            BuildingType = "BUILDING_MANNCO_MANOR",
                            YieldType = "YIELD_SCIENCE",
                            Yield = "50"
                        }
                    }
                };

                var flavor = new Models.Buildings.Flavors.Row
                {
                    BuildingType = "BUILDING_MANNCO_MANOR",
                    FlavorType = "FLAVOR_SCIENCE",
                    Flavor = "40"
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

        private bool ValidationForm(FileCategories civilization)
        {
            var result = true;
            switch (civilization)
            {
                case FileCategories.Civilization:
                    if (string.IsNullOrWhiteSpace(tbType.Text))
                    {
                        MessageBox.Show("Invalid Civilization Name", "Invalid Civ Name", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        TabControls.SelectedIndex = 0;
                        result = false;
                    }

                    break;

                case FileCategories.Leader:
                    if (string.IsNullOrWhiteSpace(tbLeaderType.Text))
                    {
                        MessageBox.Show("Invalid Leader Name", "Invalid Leader Name", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        TabControls.SelectedIndex = 1;
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
            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbDerivative.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(ArtStyles)))
                cbArtStyle.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbSoundtrack.Items.Add(item.ToString());
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

                case FileCategories.PlayerCount:
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

        private void TbType_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var settings = Settings.Default;
            settings.civ_name = GetStringKey(tbType.Text, FileCategories.Civilization);
            settings.Save();
        }

        private void TbLeaderType_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var settings = Settings.Default;
            settings.leader_name = GetStringKey(tbLeaderType.Text, FileCategories.Leader);
            settings.Save();

            //var settings = Settings.Default;
            //settings.trait_name = GetStringKey(tbLeaderType.Text, FileCategories.Trait);
            //settings.Save();
        }
    }
}
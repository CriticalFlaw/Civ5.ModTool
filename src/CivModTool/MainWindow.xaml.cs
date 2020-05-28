using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public static readonly Dictionary<Civs, Tuple<int, int>> civilizations = new Dictionary<Civs, Tuple<int, int>>
        {
            {Civs.America, new Tuple<int, int>(102, 99)},
            {Civs.Arabia, new Tuple<int, int>(103, 100)},
            {Civs.Assyria, new Tuple<int, int>(100, 96)},
            {Civs.Austria, new Tuple<int, int>(84, 100)},
            {Civs.Aztec, new Tuple<int, int>(84, 100)},
            {Civs.Babylon, new Tuple<int, int>(99, 99)},
            {Civs.Brazil, new Tuple<int, int>(100, 96)},
            {Civs.Byzantium, new Tuple<int, int>(100, 97)},
            {Civs.Carthage, new Tuple<int, int>(100, 97)},
            {Civs.Celts, new Tuple<int, int>(100, 97)},
            {Civs.China, new Tuple<int, int>(100, 97)},
            {Civs.Denmark, new Tuple<int, int>(108, 99)},
            {Civs.Egypt, new Tuple<int, int>(108, 99)},
            {Civs.England, new Tuple<int, int>(108, 99)},
            {Civs.Ethiopia, new Tuple<int, int>(108, 99)},
            {Civs.France, new Tuple<int, int>(108, 99)},
            {Civs.Germany, new Tuple<int, int>(108, 99)},
            {Civs.Greece, new Tuple<int, int>(108, 99)},
            {Civs.Huns, new Tuple<int, int>(108, 99)},
            {Civs.Inca, new Tuple<int, int>(108, 99)},
            {Civs.India, new Tuple<int, int>(108, 99)},
            {Civs.Indonesia, new Tuple<int, int>(108, 99)},
            {Civs.Iroquois, new Tuple<int, int>(108, 99)},
            {Civs.Japan, new Tuple<int, int>(108, 99)},
            {Civs.Korea, new Tuple<int, int>(108, 99)},
            {Civs.Maya, new Tuple<int, int>(108, 99)},
            {Civs.Mongol, new Tuple<int, int>(108, 99)},
            {Civs.Morocco, new Tuple<int, int>(108, 99)},
            {Civs.Netherlands, new Tuple<int, int>(108, 99)},
            {Civs.Ottoman, new Tuple<int, int>(108, 99)},
            {Civs.Persia, new Tuple<int, int>(108, 99)},
            {Civs.Poland, new Tuple<int, int>(108, 99)},
            {Civs.Polynesia, new Tuple<int, int>(108, 99)},
            {Civs.Portugal, new Tuple<int, int>(108, 99)},
            {Civs.Rome, new Tuple<int, int>(108, 99)},
            {Civs.Russia, new Tuple<int, int>(108, 99)},
            {Civs.Shoshone, new Tuple<int, int>(108, 99)},
            {Civs.Siam, new Tuple<int, int>(108, 99)},
            {Civs.Songhai, new Tuple<int, int>(108, 99)},
            {Civs.Spain, new Tuple<int, int>(108, 99)},
            {Civs.Sweden, new Tuple<int, int>(108, 99)},
            {Civs.Venice, new Tuple<int, int>(108, 99)},
            {Civs.Zulu, new Tuple<int, int>(108, 99)}
        };

        public readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string OutputPath = Directory.GetCurrentDirectory() + "\\XML";

        public MainWindow()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            Logger.Info("INITIALIZING...");
            InitializeComponent();
            LoadGUIElements();
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.Start(Properties.Resources.app_update);
        }

        private void btnGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            GenerateCivilizationXml();
            GenerateLeaderXml();
            GenerateTraitXml();
            GeneratePlayerColorXml();
            GenerateIconAtlasXml();
            GenerateGameTextXml();
            GenerateBuildingsXml();
            GenerateUnitsXml();
            //Process.Start(OutputPath);
            Application.Current.Shutdown();
        }

        private bool GenerateCivilizationXml()
        {
            try
            {
                var settings = Settings.Default;
                var gameData = new GameData
                {
                    Civilizations = new Civilizations
                    {
                        Row = new Row
                        {
                            Type = settings.civ_name,
                            DerivativeCiv = "CIVILIZATION_AMERICA",
                            Description = "TXT_KEY_CIV_MANNCO_DESC",
                            ShortDescription = "TXT_KEY_CIV_MANNCO_DESC_SHORT",
                            Adjective = "TXT_KEY_CIV_MANNCO_ADJECTIVE",
                            Civilopedia = "TXT_KEY_CIV_MANNCO_PEDIA_HEADER1",
                            CivilopediaTag = "TXT_KEY_CIV_MANNCO_PEDIA_TEXT1",
                            DefaultPlayerColor = "PLAYERCOLOR_MANNCO",
                            ArtDefineTag = "ART_DEF_CIVILIZATION_AMERICA",
                            ArtStyleType = "ARTSTYLE_AMERICAN",
                            ArtStyleSuffix = "_AMER",
                            ArtStylePrefix = "AMERICAN",
                            PortraitIndex = "0",
                            IconAtlas = "CIV_MANNCO_ICON_ATLAS",
                            AlphaIconAtlas = "CIV_MANNCO_ALPHA_ATLAS",
                            SoundtrackTag = "America",
                            MapImage = "MannCo_Map_512",
                            DawnOfManQuote = "TXT_KEY_CIV_MANNCO_DOM",
                            DawnOfManImage = "Saxton_DOM.dds"
                        }
                    },

                    Civilization_Leaders = new Civilization_Leaders
                    {
                        Row = new Models.Civilization.Leaders.Row
                        {
                            CivilizationType = settings.civ_name,
                            LeaderheadType = "LEADER_SAXTON"
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
                            BuildingClassType = "BUILDINGCLASS_PALACE"
                        }
                    },

                    Civilization_FreeTechs = new Civilization_FreeTechs
                    {
                        Row = new Models.Civilization.FreeTechs.Row
                        {
                            CivilizationType = settings.civ_name,
                            TechType = "TECH_AGRICULTURE"
                        }
                    },

                    Civilization_FreeUnits = new Civilization_FreeUnits
                    {
                        Row = new Models.Civilization.FreeUnits.Row
                        {
                            CivilizationType = settings.civ_name,
                            UnitClassType = "TECH_AGRICULTURE",
                            UnitAIType = "UNITAI_SETTLE",
                            Count = "1"
                        }
                    },

                    Civilization_Religions = new Civilization_Religions
                    {
                        Row = new Models.Civilization.Religions.Row
                        {
                            CivilizationType = settings.civ_name,
                            ReligionType = "RELIGION_BUDDHISM"
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
                    CityName = "TXT_KEY_CITY_NAME_BADLANDS"
                };
                gameData.Civilization_CityNames.Row.Add(city);

                var building = new Models.Civilization.BuildingClassOverrides.Row
                {
                    CivilizationType = settings.civ_name,
                    BuildingClassType = "BUILDINGCLASS_MARKET",
                    BuildingType = "BUILDING_MANNCO_STORE"
                };
                gameData.Civilization_BuildingClassOverrides.Row.Add(building);

                var spy = new Models.Civilization.SpyNames.Row
                {
                    CivilizationType = settings.civ_name,
                    SpyName = "TXT_KEY_SPY_NAME_MANNCO_1"
                };
                gameData.Civilization_SpyNames.Row.Add(spy);

                SerializeXml(gameData, "Civilization");
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
                var gameData = new Models.Leader.GameData
                {
                    Leaders = new Leaders
                    {
                        Row = new Models.Leader.Row
                        {
                            Type = "LEADER_SAXTON",
                            Description = "TXT_KEY_LEADER_SAXTON",
                            Civilopedia = "TXT_KEY_LEADER_SAXTON_PEDIA",
                            CivilopediaTag = "TXT_KEY_LEADER_SAXTON_PEDIA",
                            ArtDefineTag = "Saxton_Scene.xml",
                            VictoryCompetitiveness = "4",
                            WonderCompetitiveness = "3",
                            MinorCivCompetitiveness = "5",
                            Boldness = "7",
                            DiploBalance = "6",
                            WarmongerHate = "7",
                            WorkAgainstWillingness = "0",
                            WorkWithWillingness = "0",
                            DenounceWillingness = "4",
                            DoFWillingness = "6",
                            Loyalty = "6",
                            Neediness = "7",
                            Forgiveness = "7",
                            Chattiness = "5",
                            Meanness = "4",
                            PortraitIndex = "1",
                            IconAtlas = "CIV_MANNCO_ICON_ATLAS"
                        }
                    },

                    Leader_Traits = new Leader_Traits
                    {
                        Row = new Models.Leader.Traits.Row
                        {
                            LeaderType = "LEADER_SAXTON",
                            TraitType = "TRAIT_MANNCONOMY"
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
                    LeaderType = "LEADER_SAXTON",
                    MajorCivApproachType = "MAJOR_CIV_APPROACH_WAR",
                    Bias = "4"
                };
                gameData.Leader_MajorCivApproachBiases.Row.Add(major);

                var minor = new Models.Leader.MinorCivApproachBiases.Row
                {
                    LeaderType = "LEADER_SAXTON",
                    MinorCivApproachType = "MINOR_CIV_APPROACH_IGNORE",
                    Bias = "6"
                };
                gameData.Leader_MinorCivApproachBiases.Row.Add(minor);

                var flavor = new Models.Leader.Flavors.Row
                {
                    LeaderType = "LEADER_SAXTON",
                    FlavorType = "FLAVOR_OFFENSE",
                    Flavor = "6"
                };
                gameData.Leader_Flavors.Row.Add(flavor);

                SerializeXml(gameData, "Leader");
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
                var gameData = new Models.Trait.GameData
                {
                    Traits = new Traits
                    {
                        Row = new Models.Trait.Row
                        {
                            Type = "TRAIT_MANNCONOMY",
                            ShortDescription = "TXT_KEY_TRAIT_MANNCONOMY",
                            Description = "TXT_KEY_TRAIT_MANNCONOMY_DESC",
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
                            TraitType = "TRAIT_MANNCONOMY",
                            YieldType = "YIELD_GOLD",
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
                    TraitType = "TRAIT_MANNCONOMY",
                    ResourceType = "RESOURCE_IRON",
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = "TRAIT_MANNCONOMY",
                    ResourceType = "RESOURCE_COAL",
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = "TRAIT_MANNCONOMY",
                    ResourceType = "RESOURCE_OIL",
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                SerializeXml(gameData, "Trait");
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
                            Type = "PLAYERCOLOR_MANNCO",
                            PrimaryColor = "PLAYERCOLOR_MANNCO_PRIMARY",
                            SecondaryColor = "PLAYERCOLOR_MANNCO_SECONDARY",
                            TextColor = "PLAYERCOLOR_MANNCO_TEXT"
                        }
                    },

                    Colors = new List<Colors>()
                };

                var colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = "PLAYERCOLOR_MANNCO_PRIMARY",
                        Red = "0.615",
                        Green = "0.325",
                        Blue = "0.133",
                        Alpha = "1.0"
                    }
                };
                gameData.Colors.Add(colorList);

                colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = "PLAYERCOLOR_MANNCO_SECONDARY",
                        Red = "0.149",
                        Green = "0.141",
                        Blue = "0.145",
                        Alpha = "1.0"
                    }
                };
                gameData.Colors.Add(colorList);

                colorList = new Colors
                {
                    Row = new Models.PlayerColor.Color.Row
                    {
                        Type = "PLAYERCOLOR_MANNCO_TEXT",
                        Red = "1.0",
                        Green = "1.0",
                        Blue = "1.0",
                        Alpha = "1.0"
                    }
                };
                gameData.Colors.Add(colorList);

                SerializeXml(gameData, "PlayerColor");
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
                    Atlas = "CIV_MANNCO_ALPHA_ATLAS",
                    IconSize = "128",
                    Filename = "MannCo_AlphaAtlas_128.dds",
                    IconsPerRow = "1",
                    IconsPerColumn = "1"
                };
                gameData.IconTextureAtlases.Row.Add(image);

                SerializeXml(gameData, "IconAtlas");
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
                    Tag = "TXT_KEY_CIV_MANNCO_ADJECTIVE",
                    Text = "Mann Co."
                };
                gameData.Language_en_US.Row.Add(text);

                SerializeXml(gameData, "GameText");
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

                SerializeXml(gameData, "Buildings");
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

                SerializeXml(gameData, "Units");
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private void SerializeXml<T>(T gameData, string fileName)
        {
            if (!CheckDirectory()) return;
            var writer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var path = $"{OutputPath}\\{fileName}.xml";
            var file = File.Create(path);
            writer.Serialize(file, gameData, ns);
            file.Close();
        }

        private bool CheckDirectory()
        {
            try
            {
                if (!Directory.Exists(OutputPath))
                    Directory.CreateDirectory(OutputPath);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private void LoadGUIElements()
        {
            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbDerivative.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(ArtStyles)))
                cbArtStyle.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbSoundtrack.Items.Add(item.ToString());
        }

        private double FormatColorSelection(double value)
        {
            return Math.Round(value / 255, 3);
        }

        private string GetStringKey(string text, FileCategory category = FileCategory.GameText)
        {
            var settings = Settings.Default;
            text = text.Replace(' ', '_').ToUpper();
            switch (category)
            {
                case FileCategory.Buildings:
                    return $"BUILDING_{settings.civ_name}_{text}";
                case FileCategory.Civilization:
                    return $"CIVILIZATION_{(string.IsNullOrWhiteSpace(text) ? settings.civ_name : text)}";
                case FileCategory.GameText:
                    return $"TXT_KEY_{settings.civ_name}_{text}";
                case FileCategory.IconAtlas:
                    return $"CIV_{settings.civ_name}_{text}_ATLAS";
                case FileCategory.Leader:
                    return $"LEADER_{settings.civ_name}";
                case FileCategory.PlayerCount:
                    return $"PLAYERCOLOR_{settings.civ_name}_{text}";
                case FileCategory.Trait:
                    return $"TRAIT_{text}";
                case FileCategory.Units:
                    return $"UNIT_{settings.civ_name}_{text}";
            }

            return string.Empty;
        }

        private void TbType_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var settings = Settings.Default;
            settings.civ_name = GetStringKey(tbType.Text, FileCategory.Civilization);
            settings.Save();
        }
    }
}
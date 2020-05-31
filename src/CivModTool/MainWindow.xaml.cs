using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AutoUpdaterDotNET;
using CivModTool.Common;
using CivModTool.Models;
using CivModTool.Properties;
using CivModTool.Resources;
using log4net;
using log4net.Config;
using Microsoft.VisualBasic;

namespace CivModTool
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
            if (!CheckDirectory()) return;
            if (!SaveValues()) return;
            if (!GenerateBuildingsXml()) return;
            if (!GenerateCivilizationXml()) return;
            if (!GeneratePlayerColorXml()) return;
            if (!GenerateLeaderXml()) return;
            if (!GenerateTraitXml()) return;
            if (!GenerateBuildingsXml()) return;
            if (!GenerateUnitsXml()) return;
            if (!GenerateIconAtlasXml()) return;
            if (!GenerateGameTextXml()) return;
        }

        private bool SaveValues()
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

        public bool ValidationForm(FileCategories civilization)
        {
            var result = true;
            switch (civilization)
            {
                case FileCategories.Civilization:
                    if (string.IsNullOrWhiteSpace(tbType.Text))
                    {
                        MessageBox.Show("Invalid Civilization Name", "Invalid Civilization Name", MessageBoxButton.OK,
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

                case FileCategories.Trait:
                    if (string.IsNullOrWhiteSpace(tbTraitType.Text))
                    {
                        MessageBox.Show("Invalid Trait Name", "Invalid Trait Name", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        TabControls.SelectedIndex = 2;
                        result = false;
                    }

                    break;
            }

            return result;
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
            tbType.Text = Settings.Default.civ_name.Replace("CIVILIZATION_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(ArtStyles)))
                cbArtStyle.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Civs)))
                cbSoundtrack.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Buildings)))
                cbFreeBuilding.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Units)))
                cbFreeUnit.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Technologies)))
                cbFreeTech.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Religions)))
                cbReligion.Items.Add(item.ToString());

            // Leader
            tbLeaderType.Text = Settings.Default.leader_name.Replace("LEADER_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(MajorBiases)))
                cbMajorBias.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(MinorBiases)))
                cbMinorBias.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Flavors)))
                cbFlavors.Items.Add(item.ToString());

            // Trait
            tbTraitType.Text = Settings.Default.trait_name.Replace("TRAIT_", string.Empty);

            // Building
            tbBuildingType.Text = Settings.Default.building_name.Replace("BUILDING_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(Buildings)))
                cbBuildingOverride.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Eras)))
                cbBuildingStartEra.Items.Add(item.ToString());

            foreach (var item in Enum.GetValues(typeof(Technologies)))
                cbBuildingReqTech.Items.Add(item.ToString());

            // Unit
            tbUnitType.Text = Settings.Default.unit_name.Replace("UNIT_", string.Empty);

            foreach (var item in Enum.GetValues(typeof(Units)))
                cbUnitOverride.Items.Add(item.ToString());
        }

        #region CLICK_EVENTS

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
        }

        private void BAddCity_OnClick(object sender, RoutedEventArgs e)
        {
            var input = Interaction.InputBox("Please input a new city name:", "Add City Name");
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
            var input = Interaction.InputBox("Please input a new spy name:", "Add Spy Name");
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

        private void BtnAddMajorBias_OnClick(object sender, RoutedEventArgs e)
        {
            lbMajorBias.Items.Add($"{cbMajorBias.Text}-{intMajorBiasCount.Value}");
            cbMajorBias.Items.RemoveAt(cbMajorBias.SelectedIndex);
            cbMajorBias.SelectedIndex = 0;

            if (cbMajorBias.Items.Count > 0) return;
            cbMajorBias.IsEnabled = false;
            intMajorBiasCount.IsEnabled = false;
            btnAddMajorBias.IsEnabled = false;
        }

        private void BtnAddMinorBias_OnClick(object sender, RoutedEventArgs e)
        {
            lbMinorBias.Items.Add($"{cbMinorBias.Text}-{intMinorBiasCount.Value}");
            cbMinorBias.Items.RemoveAt(cbMinorBias.SelectedIndex);
            cbMinorBias.SelectedIndex = 0;

            if (cbMinorBias.Items.Count > 0) return;
            cbMinorBias.IsEnabled = false;
            intMinorBiasCount.IsEnabled = false;
            btnAddMinorBias.IsEnabled = false;
        }

        private void BtnAddFlavor_OnClick(object sender, RoutedEventArgs e)
        {
            lbFlavors.Items.Add($"{cbFlavors.Text}-{intFlavorCount.Value}");
            cbFlavors.Items.RemoveAt(cbFlavors.SelectedIndex);
            cbFlavors.SelectedIndex = 0;

            if (cbFlavors.Items.Count > 0) return;
            cbFlavors.IsEnabled = false;
            intFlavorCount.IsEnabled = false;
            btnAddFlavor.IsEnabled = false;
        }

        #endregion CLICK_EVENTS

        #region CREATE_XML

        private bool GenerateCivilizationXml()
        {
            if (!ValidationForm(FileCategories.Civilization)) return false;
            var settings = Settings.Default;
            Enum.TryParse(cbFreeUnit.SelectedValue.ToString(), out Units unit);
            var value = Dictionaries.UnitDictionary[unit].Item2.ToString().ToUpper();

            var gameData = new Civilization
            {
                Type = string.Format(Properties.Resources.txt_civ, settings.civ_name),
                Description = string.Format(Properties.Resources.key_civ_desc, tbType.Text),
                CivilopediaTag = string.Format(Properties.Resources.key_civ_pedia_text, tbType.Text),
                ShortDescription = string.Format(Properties.Resources.key_civ_desc_short, tbType.Text),
                Adjective = string.Format(Properties.Resources.key_civ_adjective, tbType.Text),
                DefaultPlayerColor = string.Format(Properties.Resources.txt_civ_color, tbType.Text),
                ArtStyleType = string.Format(Properties.Resources.txt_civ_art_style,  cbArtStyle.SelectedValue.ToString().ToUpper()),
                ArtStyleSuffix = XmlController.GetArtPrefix((ArtStyles)Enum.Parse(typeof(ArtStyles), cbArtStyle.SelectedValue.ToString())),
                ArtStylePrefix = cbArtStyle.SelectedValue.ToString().ToUpper(),
                PortraitIndex = intCivPortraitIndex.Value ?? default,
                IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, tbType.Text),
                AlphaIconAtlas = string.Format(Properties.Resources.txt_civ_atlas_alpha, tbType.Text),
                MapImage = string.Format(Properties.Resources.txt_civ_map, tbType.Text),
                DawnOfManQuote = string.Format(Properties.Resources.key_civ_dom_text, tbType.Text),
                DawnOfManImage = string.Format(Properties.Resources.txt_civ_dom_image, tbLeaderType.Text),
                DawnOfManAudio = cbSoundtrack.SelectedValue.ToString(),
                LeaderheadType = string.Format(Properties.Resources.txt_leader, tbLeaderType.Text),
                FreeBuilding = string.Format(Properties.Resources.txt_building_class, cbFreeBuilding.SelectedValue.ToString().ToUpper()),
                FreeTech = string.Format(Properties.Resources.txt_tech, cbFreeTech.SelectedValue.ToString().ToUpper()),
                FreeUnit = string.Format(Properties.Resources.txt_unit_class,  cbFreeUnit.SelectedValue.ToString().ToUpper()),
                FreeUnitAi = string.Format(Properties.Resources.txt_unit_ai, value),
                Religion = string.Format(Properties.Resources.txt_religion,  cbReligion.SelectedValue.ToString().ToUpper()),
                UniqueBuilding = new BuildingOverride
                {
                    BuildingClassType = string.Format(Properties.Resources.txt_building_class,
                        cbBuildingOverride.SelectedValue.ToString().ToUpper()),
                    BuildingType = string.Format(Properties.Resources.txt_building, settings.civ_name,
                        settings.building_name)
                },
                Cities = new List<string>(),
                Spies = new List<string>()

                // TO-DO: Add UnitOverride
            };

            foreach (var x in lbCityNames.Items)
                gameData.Cities.Add(x.ToString().ToUpper());

            foreach (var x in lbSpyNames.Items)
                gameData.Spies.Add(x.ToString());

            return XmlController.GenerateCivilizationXml(gameData);
        }

        private bool GenerateLeaderXml()
        {
            if (!ValidationForm(FileCategories.Leader)) return false;
            var settings = Settings.Default;
            var gameData = new Leader
            {
                Type = string.Format(Properties.Resources.txt_leader, settings.leader_name),
                Description = string.Format(Properties.Resources.key_leader, tbLeaderType.Text),
                Civilopedia = string.Format(Properties.Resources.key_leader_pedia, tbLeaderType.Text),
                CivilopediaTag = string.Format(Properties.Resources.key_leader_pedia, tbLeaderType.Text),
                ArtDefineTag = string.Format(Properties.Resources.txt_leader_scene, tbLeaderType.Text),
                VictoryCompetitiveness = intCompVictory.Value ?? default,
                WonderCompetitiveness = intCompWonder.Value ?? default,
                MinorCivCompetitiveness = intCompMinor.Value ?? default,
                Boldness = intBoldness.Value ?? default,
                DiploBalance = intDiploBalance.Value ?? default,
                WarmongerHate = intWarmongerHate.Value ?? default,
                WorkAgainstWillingness = intWorkAgainstWill.Value ?? default,
                WorkWithWillingness = intWorkWithWill.Value ?? default,
                DenounceWillingness = intDenounceWill.Value ?? default,
                Loyalty = intLoyalty.Value ?? default,
                Neediness = intNeediness.Value ?? default,
                Forgiveness = intForgiveness.Value ?? default,
                Chattiness = intChattiness.Value ?? default,
                Meanness = intMeanness.Value ?? default,
                PortraitIndex = intLeaderPortraitIndex.Value ?? default,
                IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, tbType.Text),
                TraitType = string.Format(Properties.Resources.txt_trait, settings.trait_name),
                MajorBiases = new List<ApproachBias>(),
                MinorBiases = new List<ApproachBias>(),
                Flavors = new List<Flavor>()
            };

            foreach (var item in lbMajorBias.Items)
            {
                var split = item.ToString().Split('-');
                var row = new ApproachBias
                {
                    CivApproachType = string.Format(Properties.Resources.txt_major_approach, split[0].ToUpper()),
                    Bias = Convert.ToInt32(split[1])
                };
                gameData.MajorBiases.Add(row);
            }

            foreach (var item in lbMinorBias.Items)
            {
                var split = item.ToString().Split('-');
                var row = new ApproachBias
                {
                    CivApproachType = string.Format(Properties.Resources.txt_minor_approach, split[0].ToUpper()),
                    Bias = Convert.ToInt32(split[1])
                };
                gameData.MinorBiases.Add(row);
            }

            foreach (var item in lbFlavors.Items)
            {
                var split = item.ToString().Split('-');
                var row = new Flavor
                {
                    FlavorType = string.Format(Properties.Resources.txt_flavor, split[0].ToUpper()),
                    Count = Convert.ToInt32(split[1])
                };
                gameData.Flavors.Add(row);
            }

            return XmlController.GenerateLeaderXml(gameData);
        }

        private bool GenerateTraitXml()
        {
            var gameData = new Trait
            {
                Type = string.Format(Properties.Resources.txt_trait, Settings.Default.trait_name),
                ShortDescription = string.Format(Properties.Resources.key_trait, tbTraitType.Text),
                Description = string.Format(Properties.Resources.key_trait_desc, tbTraitType.Text),
                LevelExperienceModifier = 0,
                GreatPeopleRateModifier = 0,
                GreatScientistRateModifier = 0,
                GreatGeneralRateModifier = 0,
                GreatGeneralExtraBonus = 0,
                GreatPersonGiftInfluence = 0,
                MaxGlobalBuildingProductionModifier = 0,
                MaxTeamBuildingProductionModifier = 0,
                MaxPlayerBuildingProductionModifier = 0,
                CityUnhappinessModifier = 0,
                PopulationUnhappinessModifier = 0,
                CityStateBonusModifier = 0,
                CityStateFriendshipModifier = 0,
                CityStateCombatModifier = 0,
                LandBarbarianConversionPercent = 0,
                LandBarbarianConversionExtraUnits = 0,
                SeaBarbarianConversionPercent = 0,
                LandUnitMaintenanceModifier = 0,
                NavalUnitMaintenanceModifier = 0,
                CapitalBuildingModifier = 0,
                PlotBuyCostModifier = -50,
                PlotCultureCostModifier = 0,
                CultureFromKills = 0,
                CityCultureBonus = 0,
                CapitalThemingBonusModifier = 0,
                PolicyCostModifier = 0,
                CityConnectionTradeRouteChange = 0,
                WonderProductionModifier = 0,
                PlunderModifier = 0,
                ImprovementMaintenanceModifier = 0,
                GoldenAgeDurationModifier = 0,
                GoldenAgeMoveChange = 0,
                GoldenAgeCombatModifier = 0,
                GoldenAgeTourismModifier = 0,
                GoldenAgeGreatArtistRateModifier = 0,
                GoldenAgeGreatMusicianRateModifier = 0,
                GoldenAgeGreatWriterRateModifier = 0,
                ExtraEmbarkMoves = 0,
                NaturalWonderFirstFinderGold = 0,
                NaturalWonderSubsequentFinderGold = 0,
                NaturalWonderYieldModifier = 0,
                NaturalWonderHappinessModifier = 0,
                NearbyImprovementCombatBonus = 0,
                NearbyImprovementBonusRange = 0,
                CultureBuildingYieldChange = 0,
                CombatBonusVsHigherTech = 0,
                CombatBonusVsLargerCiv = 0,
                RazeSpeedModifier = 0,
                DofGreatPersonModifier = 0,
                LuxuryHappinessRetention = 0,
                ExtraSpies = 0,
                UnresearchedTechBonusFromKills = 0,
                ExtraFoundedCityTerritoryClaimRange = 0,
                FreeSocialPoliciesPerEra = 0,
                NumTradeRoutesModifier = 0,
                TradeRouteResourceModifier = 0,
                UniqueLuxuryCities = 0,
                UniqueLuxuryQuantity = 0,
                WorkerSpeedModifier = 0,
                AfraidMinorPerTurnInfluence = 0,
                LandTradeRouteRangeBonus = 0,
                TradeReligionModifier = 0,
                TradeBuildingModifier = 0,
                FightWellDamaged = false,
                MoveFriendlyWoodsAsRoad = false,
                FasterAlongRiver = false,
                FasterInHills = 0,
                EmbarkedAllWater = 0,
                EmbarkedToLandFlatCost = 0,
                NoHillsImprovementMaintenance = 0,
                TechBoostFromCapitalScienceBuildings = 0,
                StaysAliveZeroCities = 0,
                FaithFromUnimprovedForest = 0,
                BonusReligiousBelief = 0,
                AbleToAnnexCityStates = 0,
                CrossesMountainsAfterGreatGeneral = 0,
                MayaCalendarBonuses = 0,
                NoAnnexing = 0,
                TechFromCityConquer = 0,
                UniqueLuxuryRequiresNewArea = 0,
                RiverTradeRoad = 0,
                AngerFreeIntrusionOfCityStates = 0,
                FreeUnit = " ",
                FreeUnitPrereqTech = " ",
                CombatBonusImprovement = " ",
                FreeBuilding = " ",
                FreeBuildingOnConquest = " ",
                ObsoleteTech = " ",
                PrereqTech = " ",
                YieldChangesStrategicResources = new List<YieldChangesStrategicResources>(),
                ResourceQuantityModifiers = new List<ResourceQuantityModifiers>()
            };

            var yieldChangeStrategicResource = new YieldChangesStrategicResources
            {
                YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                Yield = 3
            };
            gameData.YieldChangesStrategicResources.Add(yieldChangeStrategicResource);

            var resourceQuantityModifier = new ResourceQuantityModifiers
            {
                ResourceType = string.Format(Properties.Resources.txt_resource, ResourceList.Iron.ToString().ToUpper()),
                ResourceQuantityModifier = 100
            };
            gameData.ResourceQuantityModifiers.Add(resourceQuantityModifier);

            resourceQuantityModifier = new ResourceQuantityModifiers
            {
                ResourceType = string.Format(Properties.Resources.txt_resource, ResourceList.Coal.ToString().ToUpper()),
                ResourceQuantityModifier = 100
            };
            gameData.ResourceQuantityModifiers.Add(resourceQuantityModifier);

            resourceQuantityModifier = new ResourceQuantityModifiers
            {
                ResourceType = string.Format(Properties.Resources.txt_resource, ResourceList.Oil.ToString().ToUpper()),
                ResourceQuantityModifier = 100
            };
            gameData.ResourceQuantityModifiers.Add(resourceQuantityModifier);

            return XmlController.GenerateTraitXml(gameData);
        }

        private bool GeneratePlayerColorXml()
        {
            var gameData = new List<PlayerColor>();

            var color = new PlayerColor
            {
                Type = string.Format(Properties.Resources.txt_civ_color_primary, tbType.Text),
                Red = cpTextColor.SelectedColor.Value.R,
                Green = cpTextColor.SelectedColor.Value.G,
                Blue = cpTextColor.SelectedColor.Value.B,
                Alpha = cpTextColor.SelectedColor.Value.A
            };
            gameData.Add(color);

            color = new PlayerColor
            {
                Type = string.Format(Properties.Resources.txt_civ_color_secondary, tbType.Text),
                Red = cpTextColor.SelectedColor.Value.R,
                Green = cpTextColor.SelectedColor.Value.G,
                Blue = cpTextColor.SelectedColor.Value.B,
                Alpha = cpTextColor.SelectedColor.Value.A
            };
            gameData.Add(color);

            color = new PlayerColor
            {
                Type = string.Format(Properties.Resources.txt_civ_color_text, tbType.Text),
                Red = cpTextColor.SelectedColor.Value.R,
                Green = cpTextColor.SelectedColor.Value.G,
                Blue = cpTextColor.SelectedColor.Value.B,
                Alpha = cpTextColor.SelectedColor.Value.A
            };
            gameData.Add(color);

            return XmlController.GeneratePlayerColorXml(gameData, tbType.Text);
        }

        private bool GenerateBuildingsXml()
        {
            var settings = Settings.Default;
            var buildingType =
                string.Format(Properties.Resources.txt_building, settings.civ_name, settings.building_name);
            var gameData = new Building
            {
                Type = buildingType,
                Description =
                    string.Format(Properties.Resources.key_building_desc, tbType.Text, settings.building_name),
                Civilopedia = string.Format(Properties.Resources.key_building_pedia, tbType.Text,
                    settings.building_name),
                Strategy = string.Format(Properties.Resources.key_building_strategy, tbType.Text,
                    settings.building_name),
                Help = string.Format(Properties.Resources.key_building_help, tbType.Text, settings.building_name),
                BuildingClass = string.Format(Properties.Resources.txt_building_class,
                    cbBuildingOverride.SelectedValue.ToString().ToUpper()),
                ArtDefineTag = string.Format(Properties.Resources.txt_building_art_def,
                    cbBuildingOverride.SelectedValue.ToString().ToUpper()),
                FreeStartEra = string.Format(Properties.Resources.txt_era,
                    cbBuildingStartEra.SelectedValue.ToString().ToUpper()),
                PrereqTech = string.Format(Properties.Resources.txt_tech,
                    cbBuildingReqTech.SelectedValue.ToString().ToUpper()),
                IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, tbType.Text),
                ThemingBonusHelp = "",
                Quote = "",
                GoldMaintenance = 0,
                MutuallyExclusiveGroup = -1,
                TeamShare = false,
                Water = false,
                River = false,
                FreshWater = false,
                Mountain = false,
                NearbyMountainRequired = false,
                Hill = false,
                Flat = false,
                FoundsReligion = false,
                IsReligious = false,
                BorderObstacle = false,
                PlayerBorderObstacle = false,
                Capital = false,
                GoldenAge = false,
                MapCentering = false,
                NeverCapture = false,
                NukeImmune = false,
                AllowsWaterRoutes = false,
                ExtraLuxuries = false,
                DiplomaticVoting = false,
                AffectSpiesNow = false,
                NullifyInfluenceModifier = false,
                Cost = 100,
                FaithCost = 0,
                LeagueCost = 0,
                UnlockedByBelief = 0,
                UnlockedByLeague = 0,
                HolyCity = 0,
                NumCityCostMod = 0,
                HurryCostModifier = 25,
                MinAreaSize = -1,
                ConquestProb = 66,
                CitiesPrereq = 0,
                LevelPrereq = 0,
                CultureRateModifier = 0,
                GlobalCultureRateModifier = 0,
                GreatPeopleRateModifier = 0,
                GlobalGreatPeopleRateModifier = 0,
                GreatGeneralRateModifier = 0,
                GreatPersonExpendGold = 0,
                GoldenAgeModifier = 0,
                UnitUpgradeCostMod = 0,
                Experience = 0,
                GlobalExperience = 0,
                FoodKept = 0,
                Airlift = 0,
                AirModifier = 0,
                NukeModifier = 0,
                NukeExplosionRand = 0,
                HealRateChange = 0,
                Happiness = 0,
                UnmoddedHappiness = 0,
                UnhappinessModifier = 0,
                HappinessPerCity = 0,
                HappinessPerXPolicies = 0,
                CityCountUnhappinessMod = 0,
                NoOccupiedUnhappiness = false,
                WorkerSpeedModifier = 0,
                MilitaryProductionModifier = 0,
                SpaceProductionModifier = 0,
                GlobalSpaceProductionModifier = 0,
                BuildingProductionModifier = 0,
                WonderProductionModifier = 0,
                CityConnectionTradeRouteModifier = 0,
                CapturePlunderModifier = 0,
                PolicyCostModifier = 0,
                PlotCultureCostModifier = 0,
                GlobalPlotCultureCostModifier = 0,
                PlotBuyCostModifier = 0,
                GlobalPlotBuyCostModifier = 0,
                GlobalPopulationChange = 0,
                TechShare = 0,
                FreeTechs = 0,
                FreePolicies = 0,
                FreeGreatPeople = 0,
                MedianTechPercentChange = 0,
                Gold = 0,
                AllowsRangeStrike = false,
                Espionage = false,
                AllowsFoodTradeRoutes = false,
                AllowsProductionTradeRoutes = false,
                Defense = 0,
                ExtraCityHitPoints = 0,
                GlobalDefenseMod = 0,
                MinorFriendshipChange = 0,
                VictoryPoints = 0,
                ExtraMissionarySpreads = 0,
                ReligiousPressureModifier = 0,
                EspionageModifier = 0,
                GlobalEspionageModifier = 0,
                ExtraSpies = 0,
                SpyRankChange = 0,
                InstantSpyRankChange = 0,
                TradeRouteRecipientBonus = 1,
                TradeRouteTargetBonus = 1,
                NumTradeRouteBonus = 0,
                LandmarksTourismPercent = 0,
                InstantMilitaryIncrease = 0,
                GreatWorksTourismModifier = 0,
                XBuiltTriggersIdeologyChoice = 0,
                TradeRouteSeaDistanceModifier = 0,
                TradeRouteSeaGoldBonus = 0,
                TradeRouteLandDistanceModifier = 0,
                TradeRouteLandGoldBonus = 0,
                CityStateTradeRouteProductionModifier = 0,
                GreatScientistBeakerModifier = 0,
                NearbyTerrainRequired = "",
                ProhibitedCityTerrain = "",
                VictoryPrereq = "",
                MaxStartEra = "",
                ObsoleteTech = "",
                EnhancedYieldTech = "",
                TechEnhancedTourism = 0,
                FreeBuilding = "",
                FreeBuildingThisCity = "",
                FreePromotion = "",
                TrainedFreePromotion = "",
                FreePromotionRemoved = "",
                ReplacementBuildingClass = "",
                PolicyBranchType = "",
                SpecialistType =
                    string.Format(Properties.Resources.txt_specialist, Units.Merchant.ToString().ToUpper()),
                SpecialistCount = 1,
                GreatWorkSlotType = "",
                FreeGreatWork = "",
                GreatWorkCount = 0,
                SpecialistExtraCulture = 0,
                GreatPeopleRateChange = 0,
                ExtraLeagueVotes = 0,
                CityWall = false,
                DisplayPosition = 0,
                PortraitIndex = intBuildingPortraitIndex.Value ?? default,
                WonderSplashImage = "",
                WonderSplashAnchor = "R,T",
                WonderSplashAudio = "",
                ArtInfoCulturalVariation = false,
                ArtInfoEraVariation = false,
                ArtInfoRandomVariation = false,
                YieldChanges = new List<YieldChanges>(),
                YieldModifiers = new List<YieldChanges>()
            };

            var yieldChange = new YieldChanges
            {
                YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                Yield = 5
            };
            gameData.YieldChanges.Add(yieldChange);

            var yieldModifier = new YieldChanges
            {
                YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                Yield = 25
            };
            gameData.YieldModifiers.Add(yieldModifier);

            return XmlController.GenerateBuildingsXml(gameData);
        }

        private bool GenerateUnitsXml()
        {
            //var gameData = new List<Models.Units.Row>();
            //return XMLController.GenerateUnitsXml(gameData);
            return true;
        }

        private bool GenerateIconAtlasXml()
        {
            var gameData = new List<IconAtlas>();
            var image = new IconAtlas
            {
                Atlas = string.Format(Properties.Resources.txt_civ_atlas_alpha, tbType.Text),
                IconSize = 128,
                Filename = string.Format(Properties.Resources.txt_civ_atlas_alpha_file, tbType.Text, "128"),
                IconsPerRow = 1,
                IconsPerColumn = 1
            };
            gameData.Add(image);
            return XmlController.GenerateIconAtlasXml(gameData);
        }

        private bool GenerateGameTextXml()
        {
            var gameData = new List<GameText>();
            var text = new GameText
            {
                Tag = string.Format(Properties.Resources.key_civ_adjective, tbType.Text),
                Text = "Mann Co."
            };
            gameData.Add(text);
            return XmlController.GenerateGameTextXml(gameData);
        }

        #endregion CREATE_XML
    }
}
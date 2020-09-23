using AutoUpdaterDotNET;
using CivModTool.Common;
using CivModTool.Models.Civilization;
using CivModTool.Models.Civilization.CityNames;
using CivModTool.Models.Civilization.FreeBuildingClasses;
using CivModTool.Models.Civilization.FreeTechs;
using CivModTool.Models.Civilization.FreeUnits;
using CivModTool.Models.Civilization.Religions;
using CivModTool.Models.Civilization.SpyNames;
using CivModTool.Models.Leader;
using CivModTool.Models.Leader.MajorCivApproachBiases;
using CivModTool.Models.Leader.MinorCivApproachBiases;
using CivModTool.Properties;
using CivModTool.Resources;
using ImageMagick;
using log4net;
using log4net.Config;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CivModTool.Models.Building;
using CivModTool.Models.Building.YieldChanges;
using CivModTool.Models.GameText;
using Buildings = CivModTool.Resources.Buildings;

namespace CivModTool
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _outputPath = Directory.GetCurrentDirectory();

        public MainWindow()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            Logger.Info("INITIALIZING...");
            InitializeComponent();
            InitializeApplication();
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.Start(Properties.Resources.txt_app_update);
        }

        private void InitializeApplication()
        {
            if (!Directory.Exists(_outputPath + "\\XML"))
                Directory.CreateDirectory(_outputPath + "\\XML");

            using (var image = new MagickImage(_outputPath + "\\Art\\IconAtlas256.psd"))
                image.Write("IconAtlas256.jpg");

            // Civilization
            TbType.Text = Settings.Default.civ_name.Replace("CIVILIZATION_", string.Empty);

            foreach (Enum item in Enum.GetValues(typeof(ArtStyles)))
                CbArtStyle.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Civs)))
                CbSoundtrack.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Buildings)))
                CbFreeBuilding.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Units)))
                CbFreeUnit.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Technologies)))
                CbFreeTech.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Religions)))
                CbReligion.Items.Add(GetStringValue(item));

            // Leader
            TbLeaderType.Text = Settings.Default.leader_name.Replace("LEADER_", string.Empty);

            foreach (Enum item in Enum.GetValues(typeof(Flavors)))
                CbFlavors.Items.Add(GetStringValue(item));

            // Trait
            TbTraitType.Text = Settings.Default.trait_name.Replace("TRAIT_", string.Empty);

            foreach (Enum item in Enum.GetValues(typeof(TraitAttributes)))
                CbTraitAttributes.Items.Add(GetStringValue(item));

            // Building
            TbBuildingType.Text = Settings.Default.building_name.Replace("BUILDING_", string.Empty);

            foreach (Enum item in Enum.GetValues(typeof(Buildings)))
                CbBuildingOverride.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Eras)))
                CbBuildingStartEra.Items.Add(GetStringValue(item));

            foreach (Enum item in Enum.GetValues(typeof(Technologies)))
                CbBuildingReqTech.Items.Add(GetStringValue(item));
        }

        private bool PrepareForExport()
        {
            try
            {
                var settings = Settings.Default;
                settings.civ_name = TbType.Text;
                settings.leader_name = TbLeaderType.Text;
                settings.trait_name = TbTraitType.Text;
                settings.building_name = TbBuildingType.Text;
                settings.unit_name = TbBuildingType.Text;
                settings.Save();
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        public bool ValidateForm(FileCategories civilization)
        {
            var result = true;
            switch (civilization)
            {
                case FileCategories.Civilization:
                    if (string.IsNullOrWhiteSpace(TbType.Text))
                    {
                        MessageBox.Show("Invalid Civilization Name", "Invalid Civilization Name", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        TabControls.SelectedIndex = 0;
                        result = false;
                    }

                    break;

                case FileCategories.Leader:
                    if (string.IsNullOrWhiteSpace(TbLeaderType.Text))
                    {
                        MessageBox.Show("Invalid Leader Name", "Invalid Leader Name", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        TabControls.SelectedIndex = 1;
                        result = false;
                    }

                    break;

                case FileCategories.Trait:
                    if (string.IsNullOrWhiteSpace(TbTraitType.Text))
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

        private bool ProcessImages(string filePath, string fileName, int width, int height, bool alpha = false)
        {
            try
            {
                int[] iconSizes;
                if (alpha)
                    iconSizes = new[] { 128, 80, 64, 48, 45, 32, 24, 16 };
                else
                    iconSizes = new[] { 256, 128, 80, 64, 45, 32 };
                var size = new MagickGeometry(width * 2, height * 2);
                for (var x = 0; x <= iconSizes.Length; x++)
                {
                    using (var image = new MagickImage(filePath))
                    {
                        size = new MagickGeometry(width / 2, height / 2);
                        image.Resize(size);
                        image.Write(string.Format("{0}\\Art\\{1}{2}.psd", _outputPath, fileName, iconSizes[x]));
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        public string GetStringValue(Enum value)
        {
            // Get the type, FieldInfo for this type and StringValue attributes
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match, or enum value if no match
            return attribs.Length > 0 ? attribs[0].StringValue : value.ToString();
        }

        private static string FormatColorSelection(byte value)
        {
            var color = Convert.ToDouble(value);
            return Math.Round(color / 255, 3).ToString(CultureInfo.InvariantCulture);
        }

        #region CLICK_EVENTS

        private void BtnGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            if (!PrepareForExport()) return;
            if (!GenerateBuildingsXml()) return;
            if (!GenerateCivilizationXml()) return;
            if (!GeneratePlayerColorXml()) return;
            if (!GenerateLeaderXml()) return;
            if (!GenerateTraitXml()) return;
            if (!GenerateBuildingsXml()) return;
            if (!GenerateIconAtlasXml()) return;
            if (!GenerateGameTextXml()) return;
            Process.Start(_outputPath + "\\XML");
        }

        private void BtnReadFromXML_Click(object sender, RoutedEventArgs e)
        {
            using (var browser = new System.Windows.Forms.FolderBrowserDialog { SelectedPath = _outputPath })
            {
                if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var gameText = XmlController.ReadGameTextXml(Directory.GetFiles(browser.SelectedPath, "GameText.xml").FirstOrDefault());

                    foreach (var file in Directory.GetFiles(browser.SelectedPath))
                    {
                        if (file.Contains("Civilization.xml"))
                        {
                            ReadCivilizationXml(file);
                        }
                    }
                }
            }
        }

        private void BtnResetForm_Click(object sender, RoutedEventArgs e)
        {
            TabControls.Items.Refresh();
        }

        private void BtnRandomizeStats_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            IntCompVictory.Text = random.Next(1, 10).ToString();
            IntCompWonder.Text = random.Next(1, 10).ToString();
            IntCompMinor.Text = random.Next(1, 10).ToString();
            IntBoldness.Text = random.Next(1, 10).ToString();
            IntDiplomacy.Text = random.Next(1, 10).ToString();
            IntWarmongerHate.Text = random.Next(1, 10).ToString();
            IntWorkAgainstWill.Text = random.Next(1, 10).ToString();
            IntWorkWithWill.Text = random.Next(1, 10).ToString();
            IntDenounceWill.Text = random.Next(1, 10).ToString();
            IntLoyalty.Text = random.Next(1, 10).ToString();
            IntNeediness.Text = random.Next(1, 10).ToString();
            IntForgiveness.Text = random.Next(1, 10).ToString();
            IntChattiness.Text = random.Next(1, 10).ToString();
            IntMeanness.Text = random.Next(1, 10).ToString();
            IntWarBias.Text = random.Next(1, 10).ToString();
            IntHostileBias.Text = random.Next(1, 10).ToString();
            IntDeceptiveBias.Text = random.Next(1, 10).ToString();
            IntGuardedBias.Text = random.Next(1, 10).ToString();
            IntAfraidBias.Text = random.Next(1, 10).ToString();
            IntFriendlyBias.Text = random.Next(1, 10).ToString();
            IntNeutralBias.Text = random.Next(1, 10).ToString();
            IntIgnoreApproach.Text = random.Next(1, 10).ToString();
            IntFriendlyApproach.Text = random.Next(1, 10).ToString();
            IntProtectiveApproach.Text = random.Next(1, 10).ToString();
            IntConquestApproach.Text = random.Next(1, 10).ToString();
        }

        private void BtnAddCity_OnClick(object sender, RoutedEventArgs e)
        {
            var input = Interaction.InputBox("Please input a new city name:", "Add City Name");
            LbCityNames.Items.Add(input.TrimEnd());
        }

        private void BtnRemoveCity_OnClick(object sender, RoutedEventArgs e)
        {
            if (LbCityNames.SelectedItem == null) return;
            LbCityNames.Items.RemoveAt(LbCityNames.Items.IndexOf(LbCityNames.SelectedItem));
        }

        private void BtnClearCity_OnClick(object sender, RoutedEventArgs e)
        {
            LbCityNames.Items.Clear();
        }

        private void BtnAddSpy_Click(object sender, RoutedEventArgs e)
        {
            var input = Interaction.InputBox("Please input a new spy name:", "Add Spy Name");
            LbSpyNames.Items.Add(input.TrimEnd());
        }

        private void BtnRemoveSpy_Click(object sender, RoutedEventArgs e)
        {
            if (LbSpyNames.SelectedItem == null) return;
            LbSpyNames.Items.RemoveAt(LbSpyNames.Items.IndexOf(LbSpyNames.SelectedItem));
        }

        private void BtnClearSpy_Click(object sender, RoutedEventArgs e)
        {
            LbSpyNames.Items.Clear();
        }

        private void BtnAddFlavor_OnClick(object sender, RoutedEventArgs e)
        {
            LbFlavors.Items.Add($"{CbFlavors.Text}-{IntFlavorCount.Value}");
            CbFlavors.Items.RemoveAt(CbFlavors.SelectedIndex);
            CbFlavors.SelectedIndex = 0;

            if (CbFlavors.Items.Count > 0) return;
            CbFlavors.IsEnabled = false;
            IntFlavorCount.IsEnabled = false;
            BtnAddFlavor.IsEnabled = false;
        }

        private void BtnRemoveFlavors_Click(object sender, RoutedEventArgs e)
        {
            if (LbFlavors.SelectedItem == null) return;
            LbFlavors.Items.RemoveAt(LbFlavors.Items.IndexOf(LbFlavors.SelectedItem));
        }

        private void BtnClearFlavors_Click(object sender, RoutedEventArgs e)
        {
            LbFlavors.Items.Clear();
            CbFlavors.Items.Clear();

            foreach (Enum item in Enum.GetValues(typeof(Flavors)))
                CbFlavors.Items.Add(GetStringValue(item));

            CbFlavors.SelectedIndex = 0;
        }

        private void BtnAddAttribute_Click(object sender, RoutedEventArgs e)
        {
            LbTraitAttributes.Items.Add($"{CbTraitAttributes.Text}-{IntAttributeValue.Value}");
            CbTraitAttributes.Items.RemoveAt(CbTraitAttributes.SelectedIndex);
            CbTraitAttributes.SelectedIndex = 0;

            if (CbTraitAttributes.Items.Count > 0) return;
            CbTraitAttributes.IsEnabled = false;
            IntAttributeValue.IsEnabled = false;
            BtnAddAttribute.IsEnabled = false;
        }

        private void BtnRemoveAttribute_Click(object sender, RoutedEventArgs e)
        {
            if (LbTraitAttributes.SelectedItem == null) return;
            LbTraitAttributes.Items.RemoveAt(LbTraitAttributes.Items.IndexOf(LbTraitAttributes.SelectedItem));
        }

        private void BtnClearAttributes_Click(object sender, RoutedEventArgs e)
        {
            LbTraitAttributes.Items.Clear();
            CbTraitAttributes.Items.Clear();

            foreach (Enum item in Enum.GetValues(typeof(TraitAttributes)))
                CbTraitAttributes.Items.Add(GetStringValue(item));

            CbTraitAttributes.SelectedIndex = 0;
        }

        private void BtnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                InitialDirectory = _outputPath,
                DefaultExt = ".psd", // Required file extension
                Filter = "PhotoShop files (.psd)|*.psd" // Optional file extensions
            };

            if (fileDialog.ShowDialog() == true)
            {
                using (var image = new MagickImage(fileDialog.FileName))
                {
                    image.Write(_outputPath + "\\IconAtlas256.jpg");
                }

                lblImagePath.Text = fileDialog.FileName;

                var dynamicImage = new Image
                {
                    Width = 1024,
                    Height = 512
                };

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(_outputPath + "\\IconAtlas256.jpg");
                bitmap.EndInit();

                dynamicImage.Source = bitmap;
                imgIconPreview.Source = bitmap;
            }
        }

        private void BtnUploadAlpha_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                InitialDirectory = _outputPath,
                DefaultExt = ".psd", // Required file extension
                Filter = "PhotoShop files (.psd)|*.psd" // Optional file extensions
            };

            if (fileDialog.ShowDialog() == true)
            {
                using (var image = new MagickImage(fileDialog.FileName))
                {
                    image.Write(_outputPath + "\\AlphaAtlas128.jpg");
                }

                lblAlphaPath.Text = fileDialog.FileName;

                var dynamicImage = new Image
                {
                    Width = 128,
                    Height = 128
                };

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(_outputPath + "\\AlphaAtlas128.jpg");
                bitmap.EndInit();

                dynamicImage.Source = bitmap;
                imgAlphaPreview.Source = bitmap;
            }
        }

        private void BtnGetTemplate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(_outputPath + "\\Art");
        }

        #endregion CLICK_EVENTS

        #region CREATE_XML

        private bool GenerateCivilizationXml()
        {
            if (!ValidateForm(FileCategories.Civilization)) return false;

            var settings = Settings.Default;

            var gameData = new CivModTool.Models.Civilization.GameData()
            {
                Civilizations = new Civilizations
                {
                    Row = new Civilization
                    {
                        PortraitIndex = 0,
                        Type = string.Format(Properties.Resources.txt_civ, settings.civ_name),
                        Description = string.Format(Properties.Resources.key_civ_desc, TbType.Text),
                        CivilopediaTag = string.Format(Properties.Resources.key_civ_pedia_text, TbType.Text),
                        ShortDescription = string.Format(Properties.Resources.key_civ_desc_short, TbType.Text),
                        Adjective = string.Format(Properties.Resources.key_civ_adjective, TbType.Text),
                        DefaultPlayerColor = string.Format(Properties.Resources.txt_civ_color, TbType.Text),
                        ArtStyleType = string.Format(Properties.Resources.txt_civ_art_style, CbArtStyle.SelectedValue.ToString().ToUpper()),
                        ArtStyleSuffix = XmlController.GetArtPrefix((ArtStyles)Enum.Parse(typeof(ArtStyles), CbArtStyle.SelectedValue.ToString())),
                        ArtStylePrefix = CbArtStyle.SelectedValue.ToString().ToUpper(),
                        IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, TbType.Text),
                        AlphaIconAtlas = string.Format(Properties.Resources.txt_civ_atlas_alpha, TbType.Text),
                        MapImage = string.Format(Properties.Resources.txt_civ_map, TbType.Text),
                        DawnOfManQuote = string.Format(Properties.Resources.key_civ_dom_text, TbType.Text),
                        DawnOfManImage = string.Format(Properties.Resources.txt_civ_dom_image, TbLeaderType.Text)
                        //DawnOfManAudio = CbSoundtrack.SelectedValue.ToString()
                    }
                }
            };

            foreach (var x in LbCityNames.Items)
            {
                var city = new CityNames
                {
                    CityName = (string.Format(Properties.Resources.key_city_name, settings.civ_name,
                    x.ToString().Replace(' ', '_').ToUpper())),
                    CivilizationType = gameData.Civilizations.Row.Type
                };

                gameData.Civilization_CityNames.Row.Add(city);
            }

            foreach (var x in LbSpyNames.Items)
            {
                var spy = new SpyNames
                {
                    SpyName = (string.Format(Properties.Resources.key_spy_name, settings.civ_name, x.ToString().Replace(' ', '_').ToUpper())),
                    CivilizationType = gameData.Civilizations.Row.Type
                };

                gameData.Civilization_SpyNames.Row.Add(spy);
            }

            Enum.TryParse(CbFreeUnit.SelectedValue.ToString(), out Units unit);

            gameData.Civilization_Leaders.Row = new Models.Civilization.Leaders.Leader
            {
                LeaderheadType = string.Format(Properties.Resources.txt_leader, TbLeaderType.Text),
                CivilizationType = gameData.Civilizations.Row.Type
            };

            gameData.Civilization_FreeBuildingClasses.Row = new FreeBuildingClasses
            {
                BuildingClassType = string.Format(Properties.Resources.txt_building_class, CbFreeBuilding.SelectedValue.ToString().ToUpper()),
                CivilizationType = gameData.Civilizations.Row.Type
            };

            gameData.Civilization_FreeTechs.Row = new FreeTechs
            {
                TechType = string.Format(Properties.Resources.txt_tech, CbFreeTech.SelectedValue.ToString().ToUpper()),
                CivilizationType = gameData.Civilizations.Row.Type
            };

            gameData.Civilization_FreeUnits.Row = new FreeUnits
            {
                UnitClassType = string.Format(Properties.Resources.txt_unit_class, CbFreeUnit.SelectedValue.ToString().ToUpper()),
                UnitAiType = string.Format(Properties.Resources.txt_unit_ai, Dictionaries.UnitDictionary[unit].Item2.ToString().ToUpper()),
                Count = 1,
                CivilizationType = gameData.Civilizations.Row.Type
            };

            gameData.Civilization_Religions.Row = new Religion
            {
                ReligionType = string.Format(Properties.Resources.txt_religion, CbReligion.SelectedValue.ToString().ToUpper()),
                CivilizationType = gameData.Civilizations.Row.Type
            };

            return XmlController.GenerateCivilizationXml(gameData);
        }

        private bool GenerateLeaderXml()
        {
            if (!ValidateForm(FileCategories.Leader)) return false;

            var settings = Settings.Default;

            var gameData = new CivModTool.Models.Leader.GameData
            {
                Leaders = new Leaders
                {
                    Row = new Models.Leader.Leader
                    {
                        PortraitIndex = 1,
                        Type = string.Format(Properties.Resources.txt_leader, settings.leader_name),
                        Description = string.Format(Properties.Resources.key_leader, TbLeaderType.Text),
                        Civilopedia = string.Format(Properties.Resources.key_leader_pedia, TbLeaderType.Text),
                        CivilopediaTag = string.Format(Properties.Resources.key_leader_pedia_tag, TbLeaderType.Text),
                        ArtDefineTag = string.Format(Properties.Resources.txt_leader_scene, TbLeaderType.Text),
                        VictoryCompetitiveness = IntCompVictory.Value ?? default,
                        WonderCompetitiveness = IntCompWonder.Value ?? default,
                        MinorCivCompetitiveness = IntCompMinor.Value ?? default,
                        Boldness = IntBoldness.Value ?? default,
                        DiploBalance = IntDiplomacy.Value ?? default,
                        WarmongerHate = IntWarmongerHate.Value ?? default,
                        WorkAgainstWillingness = IntWorkAgainstWill.Value ?? default,
                        WorkWithWillingness = IntWorkWithWill.Value ?? default,
                        DenounceWillingness = IntDenounceWill.Value ?? default,
                        Loyalty = IntLoyalty.Value ?? default,
                        Neediness = IntNeediness.Value ?? default,
                        Forgiveness = IntForgiveness.Value ?? default,
                        Chattiness = IntChattiness.Value ?? default,
                        Meanness = IntMeanness.Value ?? default,
                        IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, TbType.Text)
                    }
                }
            };

            gameData.Leader_Traits.Row = new Models.Leader.Traits.Traits
            {
                TraitType = string.Format(Properties.Resources.txt_trait, settings.trait_name),
                LeaderType = gameData.Leaders.Row.Type
            };

            Tuple<string, int?>[] majorApproaches =
            {
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "WAR"),
                    IntWarBias.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "HOSTILE"),
                    IntHostileBias.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "DECEPTIVE"),
                    IntDeceptiveBias.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "GUARDED"),
                    IntGuardedBias.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "AFRAID"),
                    IntAfraidBias.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "FRIENDLY"),
                    IntFriendlyBias.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_major_approach, "NEUTRAL"),
                    IntNeutralBias.Value ?? default)
            };

            foreach (var x in majorApproaches)
            {
                var major = new MajorCivApproachBiases
                {
                    MajorCivApproachType = x.Item1,
                    Bias = x.Item2 ?? default,
                    LeaderType = gameData.Leaders.Row.Type
                };

                gameData.Leader_MajorCivApproachBiases.Row.Add(major);
            }

            Tuple<string, int?>[] minorApproaches =
            {
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_minor_approach, "IGNORE"),
                    IntIgnoreApproach.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_minor_approach, "FRIENDLY"),
                    IntFriendlyApproach.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_minor_approach, "PROTECTIVE"),
                    IntProtectiveApproach.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_minor_approach, "CONQUEST"),
                    IntConquestApproach.Value ?? default)
            };

            foreach (var x in minorApproaches)
            {
                var minor = new MinorCivApproachBiases
                {
                    MinorCivApproachType = x.Item1,
                    Bias = x.Item2 ?? default,
                    LeaderType = gameData.Leaders.Row.Type
                };

                gameData.Leader_MinorCivApproachBiases.Row.Add(minor);
            }

            return XmlController.GenerateLeaderXml(gameData);
        }

        private bool GenerateTraitXml()
        {
            var gameData = new CivModTool.Models.Trait.GameData
            {
                Traits = new Models.Trait.Traits
                {
                    Row = new Models.Trait.Trait
                    {
                        Type = string.Format(Properties.Resources.txt_trait, Settings.Default.trait_name),
                        Description = string.Format(Properties.Resources.key_trait_desc, TbTraitType.Text),
                        ShortDescription = string.Format(Properties.Resources.key_trait, TbTraitType.Text),
                        CombatBonusImprovement = " ",
                        FreeBuilding = " ",
                        FreeBuildingOnConquest = " ",
                        FreeUnit = " ",
                        FreeUnitPrereqTech = " ",
                        ObsoleteTech = " ",
                        PrereqTech = " ",
                        //EmbarkedNotCivilian = false,
                        //FasterAlongRiver = false,
                        //FightWellDamaged = false,
                        //MoveFriendlyWoodsAsRoad = false,
                        //YieldChangesStrategicResources = new List<YieldChangesStrategicResources>(),
                        //ResourceQuantityModifiers = new List<ResourceQuantityModifiers>()
                    }
                }
            };

            //foreach (var x in LbTraitAttributes.Items)
            //{
            //    var split = x.ToString().Split('-');
            //    gameData.GetType().GetField(split[0]).SetValue(gameData, int.Parse(split[1]));
            //}

            gameData.Trait_YieldChangesStrategicResources.Row.Add(new Models.Trait.YieldChangesStrategicResources.YieldChangesStrategicResources
            {
                YieldType = string.Format(Properties.Resources.txt_yield, nameof(Yields.Gold).ToUpper()),
                Yield = 3
            });

            gameData.Trait_ResourceQuantityModifiers.Row.Add(new Models.Trait.ResourceQuantityModifiers.ResourceQuantityModifiers
            {
                ResourceType = string.Format(Properties.Resources.txt_resource, nameof(ResourceList.Iron).ToUpper()),
                ResourceQuantityModifier = 100
            });

            gameData.Trait_ResourceQuantityModifiers.Row.Add(new Models.Trait.ResourceQuantityModifiers.ResourceQuantityModifiers
            {
                ResourceType = string.Format(Properties.Resources.txt_resource, nameof(ResourceList.Coal).ToUpper()),
                ResourceQuantityModifier = 100
            });

            gameData.Trait_ResourceQuantityModifiers.Row.Add(new Models.Trait.ResourceQuantityModifiers.ResourceQuantityModifiers
            {
                ResourceType = string.Format(Properties.Resources.txt_resource, nameof(ResourceList.Oil).ToUpper()),
                ResourceQuantityModifier = 100
            });

            return XmlController.GenerateTraitXml(gameData);
        }

        private bool GeneratePlayerColorXml()
        {
            var gameData = new CivModTool.Models.PlayerColor.GameData
            {
                PlayerColors = new Models.PlayerColor.PlayerColors(),
                Colors = new List<Models.PlayerColor.Colors>()
            };

            gameData.PlayerColors.Row = new Models.PlayerColor.PlayerColor
            {
                PrimaryColor = CpPrimaryColor.SelectedColor.Value.ToString(),
                SecondaryColor = CpSecondaryColor.SelectedColor.Value.ToString(),
                TextColor = CpTextColor.SelectedColor.Value.ToString(),
                Type = string.Format(Properties.Resources.txt_civ_color_primary, TbType.Text)
            };

            gameData.Colors.Add(new Models.PlayerColor.Colors
            {
                Row = new Models.PlayerColor.Color
                {
                    Type = gameData.PlayerColors.Row.Type,
                    Red = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.R),
                    Green = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.G),
                    Blue = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.B),
                    Alpha = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.A)
                }
            });

            return XmlController.GeneratePlayerColorXml(gameData);
        }

        private bool GenerateBuildingsXml()
        {
            var settings = Settings.Default;
            var buildingType = string.Format(Properties.Resources.txt_building, settings.civ_name, settings.building_name);

            var gameData = new CivModTool.Models.Building.GameData
            {
                Buildings = new Models.Building.Buildings
                {
                    Row = new Models.Building.Building
                    {
                        PortraitIndex = 3,
                        Type = buildingType,
                        Description = string.Format(Properties.Resources.key_building_desc, TbType.Text, settings.building_name),
                        Civilopedia = string.Format(Properties.Resources.key_building_pedia, TbType.Text, settings.building_name),
                        Strategy = string.Format(Properties.Resources.key_building_strategy, TbType.Text, settings.building_name),
                        Help = string.Format(Properties.Resources.key_building_help, TbType.Text, settings.building_name),
                        BuildingClass = string.Format(Properties.Resources.txt_building_class, CbBuildingOverride.SelectedValue.ToString().ToUpper()),
                        ArtDefineTag = string.Format(Properties.Resources.txt_building_art_def, CbBuildingOverride.SelectedValue.ToString().ToUpper()),
                        FreeStartEra = string.Format(Properties.Resources.txt_era, CbBuildingStartEra.SelectedValue.ToString().ToUpper()),
                        PrereqTech = string.Format(Properties.Resources.txt_tech, CbBuildingReqTech.SelectedValue.ToString().ToUpper()),
                        IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, TbType.Text),
                        ThemingBonusHelp = "",
                        Quote = "",
                        GoldMaintenance = 0,
                        MutuallyExclusiveGroup = -1,
                        //TeamShare = false,
                        //Water = false,
                        //River = false,
                        //FreshWater = false,
                        //Mountain = false,
                        //NearbyMountainRequired = false,
                        //Hill = false,
                        //Flat = false,
                        //FoundsReligion = false,
                        //IsReligious = false,
                        //BorderObstacle = false,
                        //PlayerBorderObstacle = false,
                        //Capital = false,
                        //GoldenAge = false,
                        //MapCentering = false,
                        //NeverCapture = false,
                        //NukeImmune = false,
                        //AllowsWaterRoutes = false,
                        //ExtraLuxuries = false,
                        //DiplomaticVoting = false,
                        //AffectSpiesNow = false,
                        //NullifyInfluenceModifier = false,
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
                        //NoOccupiedUnhappiness = false,
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
                        //AllowsRangeStrike = false,
                        //Espionage = false,
                        //AllowsFoodTradeRoutes = false,
                        //AllowsProductionTradeRoutes = false,
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
                        SpecialistType = string.Format(Properties.Resources.txt_specialist, nameof(Units.Merchant).ToUpper()),
                        SpecialistCount = 1,
                        GreatWorkSlotType = "",
                        FreeGreatWork = "",
                        GreatWorkCount = 0,
                        SpecialistExtraCulture = 0,
                        GreatPeopleRateChange = 0,
                        ExtraLeagueVotes = 0,
                        //CityWall = false,
                        DisplayPosition = 0,
                        WonderSplashImage = "",
                        WonderSplashAnchor = "R,T",
                        WonderSplashAudio = "",
                        //ArtInfoCulturalVariation = false,
                        //ArtInfoEraVariation = false,
                        //ArtInfoRandomVariation = false
                    }
                }
            };

            gameData.Building_YieldChanges.Row = new Models.Building.YieldChanges.YieldChange
            {
                YieldType = string.Format(Properties.Resources.txt_yield, nameof(Yields.Gold).ToUpper()),
                Yield = 5
            };

            gameData.Building_YieldModifiers.Row = new Models.Building.YieldModifiers.YieldModifier
            {
                YieldType = string.Format(Properties.Resources.txt_yield, nameof(Yields.Gold).ToUpper()),
                Yield = 25
            };

            return XmlController.GenerateBuildingsXml(gameData);
        }

        private bool GenerateIconAtlasXml()
        {
            if (!string.IsNullOrEmpty(lblImagePath.Text))
                ProcessImages(lblImagePath.Text, "IconAtlas", 1024, 512);

            if (!string.IsNullOrEmpty(lblAlphaPath.Text))
                ProcessImages(lblAlphaPath.Text, "AlphaAtlas", 128, 128, true);

            var gameData = new CivModTool.Models.IconAtlas.GameData();

            foreach (var x in Directory.GetFiles(_outputPath + "\\Art").ToList())
            {
                var isAlpha = x.Contains("AlphaAtlas");
                var key = isAlpha ? "AlphaAtlas" : "IconAtlas";
                var pFrom = x.IndexOf(key) + key.Length;
                var pTo = x.LastIndexOf(".psd");
                var size = x.Substring(pFrom, pTo - pFrom);

                var image = new Models.IconAtlas.IconTexture
                {
                    Atlas = string.Format(
                        isAlpha ? Properties.Resources.txt_civ_atlas_alpha : Properties.Resources.txt_civ_atlas_icon,
                        TbType.Text),
                    IconSize = int.Parse(size),
                    Filename = string.Format(
                        isAlpha
                            ? Properties.Resources.txt_civ_atlas_alpha_file
                            : Properties.Resources.txt_civ_atlas_icon_file, TbType.Text, size),
                    IconsPerRow = isAlpha ? 1 : 4,
                    IconsPerColumn = isAlpha ? 1 : 2
                };
                gameData.IconTextureAtlases.Row.Add(image);
            }

            return XmlController.GenerateIconAtlasXml(gameData);
        }

        private bool GenerateGameTextXml()
        {
            var settings = Settings.Default;

            var gameData = new CivModTool.Models.GameText.GameData();

            var gameText = new List<CivModTool.Models.GameText.Row>()
            {
                // Civilization
                new Row
                    {Tag = string.Format(Properties.Resources.key_civ_adjective, TbType.Text), Text = TbAdjective.Text},
                new Row
                    {Tag = string.Format(Properties.Resources.key_civ_desc, TbType.Text), Text = TbDescription.Text},
                new Row
                    { Tag = string.Format(Properties.Resources.key_civ_pedia_header, TbType.Text), Text = TbCivilopedia.Text },
                new Row
                    {Tag = string.Format(Properties.Resources.key_civ_dom_text, TbType.Text), Text = TbDOMQuote.Text},
                // Leader
                new Row
                    { Tag = string.Format(Properties.Resources.key_leader, TbLeaderType.Text), Text = TbLeaderDescription.Text },
                new Row
                    { Tag = string.Format(Properties.Resources.key_leader_pedia, TbLeaderType.Text), Text = TbLeaderCivilopedia.Text },
                new Row
                    { Tag = string.Format(Properties.Resources.key_leader_pedia_tag, TbLeaderType.Text), Text = TbLeaderType.Text },
                // Trait
                new Row
                    { Tag = string.Format(Properties.Resources.key_trait, TbTraitType.Text), Text = TbTraitDescription.Text },
                new Row
                    { Tag = string.Format(Properties.Resources.key_trait_desc, TbTraitType.Text), Text = TbTraitDescriptionShort.Text },
                //// Building
                new Row
                    { Tag = string.Format(Properties.Resources.key_building_desc, TbType.Text, TbBuildingType.Text), Text = TbBuildingDesc.Text },
                new Row
                    { Tag = string.Format(Properties.Resources.key_building_pedia, TbType.Text, TbBuildingType.Text), Text = TbBuildingPedia.Text },
                new Row
                    { Tag = string.Format(Properties.Resources.key_building_strategy, TbType.Text, TbBuildingType.Text), Text = TbBuildingStrat.Text },
                new Row
                    { Tag = string.Format(Properties.Resources.key_building_help, TbType.Text, TbBuildingType.Text), Text = TbBuildingHelp.Text }
            };

            foreach (var x in gameText)
                gameData.Language_en_US.Row.Add(x);

            foreach (var x in LbCityNames.Items)
                gameData.Language_en_US.Row.Add(new Row
                {
                    Tag = string.Format(Properties.Resources.key_city_name, settings.civ_name,
                        x.ToString().Replace(' ', '_').ToUpper()),
                    Text = x.ToString()
                });

            foreach (var x in LbSpyNames.Items)
                gameData.Language_en_US.Row.Add(new Row
                {
                    Tag = string.Format(Properties.Resources.key_spy_name, settings.civ_name,
                        x.ToString().Replace(' ', '_').ToUpper()),
                    Text = x.ToString()
                });

            return XmlController.GenerateGameTextXml(gameData);
        }

        #endregion CREATE_XML

        #region READ_XML

        private bool ReadCivilizationXml(string path)
        {
            try
            {
                var gameData = XmlController.ReadCivilizationXml(path);

                if (gameData is null) return false;

                TbType.Text = FormatString(gameData.Civilizations.Row.Type, Properties.Resources.txt_civ);
                TbAdjective.Text = gameData.Civilizations.Row.Adjective;
                TbDescription.Text = gameData.Civilizations.Row.Description;
                TbCivilopedia.Text = gameData.Civilizations.Row.Civilopedia;
                CbArtStyle.SelectedValue = gameData.Civilizations.Row.ArtStyleType;
                CbFreeBuilding.SelectedValue = gameData.Civilization_FreeBuildingClasses.Row.CivilizationType;
                CbFreeUnit.SelectedValue = gameData.Civilization_FreeUnits.Row.UnitClassType;
                CbFreeTech.SelectedValue = gameData.Civilization_FreeTechs.Row.TechType;
                CbReligion.SelectedValue = gameData.Civilization_Religions.Row.ReligionType;
                CbSoundtrack.SelectedValue = gameData.Civilizations.Row.SoundtrackTag;
                TbDOMQuote.Text = gameData.Civilizations.Row.DawnOfManQuote;
                foreach (var city in gameData.Civilization_CityNames.Row)
                    LbCityNames.Items.Add(city.CityName);
                foreach (var spy in gameData.Civilization_SpyNames.Row)
                    LbSpyNames.Items.Add(spy.SpyName);

                //Models.PlayerColor.GameData colors = XmlController.ReadPlayerColorXml(path);
                //if (colors.PlayerColors is null) return true;
                //var cc = new ColorConverter();
                //CpPrimaryColor.SelectedColor = (Color)cc.ConvertFrom(colors.PlayerColors.Row.PrimaryColor);
                //CpSecondaryColor.SelectedColor = (Color)cc.ConvertFrom(colors.PlayerColors.Row.SecondaryColor);
                //CpTextColor.SelectedColor = (Color)cc.ConvertFrom(colors.PlayerColors.Row.TextColor);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        private string FormatString(string value, string remove)
        {
            remove = remove.Replace("{0}", string.Empty);
            return value.Replace(remove, string.Empty);
        }

        #endregion READ_XML
    }
}
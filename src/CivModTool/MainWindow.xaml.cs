using AutoUpdaterDotNET;
using CivModTool.Common;
using CivModTool.Models.Civilization;
using CivModTool.Models.GameText;
using CivModTool.Models.IconAtlas;
using CivModTool.Models.Leader;
using CivModTool.Models.PlayerColor;
using CivModTool.Properties;
using ImageMagick;
using log4net;
using log4net.Config;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Buildings = CivModTool.Common.Buildings;
using Color = CivModTool.Models.PlayerColor.Color;
using Colors = CivModTool.Models.PlayerColor.Colors;
using Flavor = CivModTool.Models.Leader.Flavor;
using Flavors = CivModTool.Common.Flavors;
using GameData = CivModTool.Models.Civilization.GameData;
using Leader = CivModTool.Models.Civilization.Leader;
using Leaders = CivModTool.Models.Leader.Leaders;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Religions = CivModTool.Common.Religions;
using Trait = CivModTool.Models.Leader.Trait;

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

        /// <summary>
        ///     Perform tasks while initializing the application
        /// </summary>
        private void InitializeApplication()
        {
            // Create the XML directory if it doesn't already exist
            if (!Directory.Exists(_outputPath + "\\XML"))
                Directory.CreateDirectory(_outputPath + "\\XML");

            // Format the icon atlas template to JPG
            using (var image = new MagickImage(_outputPath + "\\Art\\IconAtlas256.psd"))
                image.Write("IconAtlas256.jpg");

            // Load user settings and all the combo-boxes with descriptive enumerations
            LoadUserSettings();

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

            foreach (Enum item in Enum.GetValues(typeof(Flavors)))
                CbFlavors.Items.Add(GetStringValue(item));
        }

        /// <summary>
        ///     Validate a given page before it is exported to XML
        /// </summary>
        public bool ValidateForm(Categories civilization)
        {
            var result = true;
            switch (civilization)
            {
                case Categories.Civilization:
                    if (string.IsNullOrWhiteSpace(TbType.Text))
                    {
                        MessageBox.Show("Please enter a valid civilization name", "Invalid Civilization Name", MessageBoxButton.OK, MessageBoxImage.Error);
                        TabControls.SelectedIndex = 0;
                        result = false;
                    }
                    else if (LbCityNames.Items.Count < 2)
                    {
                        MessageBox.Show("You must name at least two cities", "Insufficient City Names", MessageBoxButton.OK, MessageBoxImage.Error);
                        TabControls.SelectedIndex = 0;
                        result = false;
                    }
                    else if (LbSpyNames.Items.Count < 2)
                    {
                        MessageBox.Show("You must name at least two spies", "Insufficient Spy Names", MessageBoxButton.OK, MessageBoxImage.Error);
                        TabControls.SelectedIndex = 0;
                        result = false;
                    }
                    break;

                case Categories.Leader:
                    if (string.IsNullOrWhiteSpace(TbLeaderType.Text))
                    {
                        MessageBox.Show("Please enter a valid leader name", "Invalid Leader Name", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        TabControls.SelectedIndex = 1;
                        result = false;
                    }

                    break;

                case Categories.Trait:
                case Categories.Buildings:
                case Categories.GameText:
                case Categories.IconAtlas:
                case Categories.PlayerColor:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(civilization), civilization, null);
            }

            return result;
        }

        /// <summary>
        ///     Convert a given image to different sizes using MagickImage
        /// </summary>
        private void ProcessImages(string filePath, string fileName, int width, int height, bool alpha = false)
        {
            try
            {
                var iconSizes = alpha ? new[] { 128, 80, 64, 48, 45, 32, 24, 16 } : new[] { 256, 128, 80, 64, 45, 32 };
                for (var x = 0; x <= iconSizes.Length; x++)
                {
                    using (var image = new MagickImage(filePath))
                    {
                        var size = new MagickGeometry(width / 2, height / 2);
                        image.Resize(size);
                        image.Write($"{_outputPath}\\Art\\{fileName}{iconSizes[x]}.psd");
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }

        /// <summary>
        ///     Process the uploaded Alpha of Icon atlas image
        /// </summary>
        private BitmapImage ProcessUpload(bool alpha = false)
        {
            var fileDialog = new OpenFileDialog
            {
                InitialDirectory = _outputPath,
                DefaultExt = ".psd", // Required file extension
                Filter = "PhotoShop files (.psd)|*.psd" // Optional file extensions
            };

            if (fileDialog.ShowDialog() != true) return null;

            using (var image = new MagickImage(fileDialog.FileName))
            {
                image.Write(_outputPath + (alpha ? "\\AlphaAtlas128.jpg" : "\\IconAtlas256.jpg"));
            }

            if (alpha)
                LblAlphaPath.Text = fileDialog.FileName;
            else
                LblImagePath.Text = fileDialog.FileName;

            var dynamicImage = new Image
            {
                Width = 1024,
                Height = 512
            };

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(_outputPath + (alpha ? "\\AlphaAtlas128.jpg" : "\\IconAtlas256.jpg"));
            bitmap.EndInit();
            dynamicImage.Source = bitmap;

            return bitmap;
        }

        /// <summary>
        ///     Convert the enumeration name to a user-friendly string value
        /// </summary>
        public string GetStringValue(Enum value)
        {
            // Get the type, FieldInfo for this type and StringValue attributes
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match, or enum value if no match
            return attributes.Length > 0 ? attributes[0].StringValue : value.ToString();
        }

        /// <summary>
        ///     Convert the color value to a user-friendly string value
        /// </summary>
        private static string FormatColorSelection(byte value)
        {
            var color = Convert.ToDouble(value);
            return Math.Round(color / 255, 3).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Apply the correct art style suffix
        /// </summary>
        internal static string GetArtSuffix(ArtStyles style)
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

                case ArtStyles.Mediterranean:
                    return "_MED";

                default:
                    throw new ArgumentOutOfRangeException(nameof(style), style, null);
            }
        }

        #region SAVE-LOAD

        /// <summary>
        ///     Save user settings to file
        /// </summary>
        private bool SaveUserSettings()
        {
            try
            {
                var settings = Settings.Default;
                settings.civ_name = TbType.Text;
                settings.civ_adjective = TbAdjective.Text;
                settings.civ_art_style = CbArtStyle.SelectedIndex;
                settings.civ_free_building = CbFreeBuilding.SelectedIndex;
                settings.civ_free_unit = CbFreeUnit.SelectedIndex;
                settings.civ_free_tech = CbFreeTech.SelectedIndex;
                settings.civ_religion = CbReligion.SelectedIndex;
                settings.civ_soundtrack = CbSoundtrack.SelectedIndex;
                settings.color_primary = CpPrimaryColor.SelectedColor?.ToString();
                settings.color_primary = CpPrimaryColor.SelectedColor?.ToString();
                settings.color_secondary = CpSecondaryColor.SelectedColor?.ToString();
                settings.color_text = CpTextColor.SelectedColor?.ToString();
                settings.civ_description = TbDescription.Text;
                settings.civ_civilopedia = TbCivilopedia.Text;
                settings.civ_cities = LbCityNames.Items.OfType<string>().ToArray();
                settings.civ_spies = LbSpyNames.Items.OfType<string>().ToArray();
                settings.leader_name = TbLeaderType.Text;
                settings.leader_civilopedia = TbLeaderCivilopedia.Text;
                settings.leader_description = TbLeaderDescription.Text;
                settings.leader_dom_quote = TbDomQuote.Text;
                settings.leader_flavors = LbFlavors.Items.OfType<string>().ToArray();
                settings.leader_victory = IntCompVictory.Value ?? 1;
                settings.leader_wonder = IntCompWonder.Value ?? 1;
                settings.leader_minor = IntCompMinor.Value ?? 1;
                settings.leader_hate = IntWarmongerHate.Value ?? 1;
                settings.leader_work_vs = IntWorkAgainstWill.Value ?? 1;
                settings.leader_work_with = IntWorkWithWill.Value ?? 1;
                settings.leader_denounce = IntDenounceWill.Value ?? 1;
                settings.leader_diplomacy = IntDiplomacy.Value ?? 1;
                settings.leader_boldness = IntBoldness.Value ?? 1;
                settings.leader_loyalty = IntLoyalty.Value ?? 1;
                settings.leader_neediness = IntNeediness.Value ?? 1;
                settings.leader_forgiveness = IntForgiveness.Value ?? 1;
                settings.leader_chattiness = IntChattiness.Value ?? 1;
                settings.leader_meanness = IntMeanness.Value ?? 1;
                settings.leader_civ_war = IntWarBias.Value ?? 1;
                settings.leader_civ_hostile = IntHostileBias.Value ?? 1;
                settings.leader_civ_deceptive = IntDeceptiveBias.Value ?? 1;
                settings.leader_civ_guarded = IntGuardedBias.Value ?? 1;
                settings.leader_civ_afraid = IntAfraidBias.Value ?? 1;
                settings.leader_civ_friendly = IntFriendlyBias.Value ?? 1;
                settings.leader_civ_neutral = IntNeutralBias.Value ?? 1;
                settings.leader_city_ignore = IntIgnoreApproach.Value ?? 1;
                settings.leader_city_friendly = IntProtectiveApproach.Value ?? 1;
                settings.leader_city_protect = IntProtectiveApproach.Value ?? 1;
                settings.leader_city_conquest = IntConquestApproach.Value ?? 1;
                settings.leader_city_bully = IntBullyApproach.Value ?? 1;
                settings.Save();
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }

        /// <summary>
        ///     Load user settings from file
        /// </summary>
        public void LoadUserSettings()
        {
            try
            {
                var settings = Settings.Default;
                //var cc = new ColorConverter();
                TbType.Text = settings.civ_name.Replace("CIVILIZATION_", string.Empty);
                TbAdjective.Text = settings.civ_adjective;
                CbArtStyle.SelectedIndex = settings.civ_art_style;
                CbFreeBuilding.SelectedIndex = settings.civ_free_building;
                CbFreeUnit.SelectedIndex = settings.civ_free_unit;
                CbFreeTech.SelectedIndex = settings.civ_free_tech;
                CbReligion.SelectedIndex = settings.civ_religion;
                CbSoundtrack.SelectedIndex = settings.civ_soundtrack;
                //CpPrimaryColor.SelectedColor = (Color)cc.ConvertFrom(settings.color_primary);
                //CpSecondaryColor.SelectedColor = (Color)cc.ConvertFrom(settings.color_secondary);
                //CpTextColor.SelectedColor = (Color)cc.ConvertFrom(settings.color_text);
                TbDescription.Text = settings.civ_description;
                TbCivilopedia.Text = settings.civ_civilopedia;
                TbLeaderType.Text = settings.leader_name.Replace("LEADER_", string.Empty);
                TbLeaderCivilopedia.Text = settings.leader_civilopedia;
                TbLeaderDescription.Text = settings.leader_description;
                TbDomQuote.Text = settings.leader_dom_quote;
                IntCompVictory.Value = settings.leader_victory;
                IntCompWonder.Value = settings.leader_wonder;
                IntCompMinor.Value = settings.leader_minor;
                IntWarmongerHate.Value = settings.leader_hate;
                IntWorkAgainstWill.Value = settings.leader_work_vs;
                IntWorkWithWill.Value = settings.leader_work_with;
                IntDenounceWill.Value = settings.leader_denounce;
                IntDiplomacy.Value = settings.leader_diplomacy;
                IntBoldness.Value = settings.leader_boldness;
                IntLoyalty.Value = settings.leader_loyalty;
                IntNeediness.Value = settings.leader_neediness;
                IntForgiveness.Value = settings.leader_forgiveness;
                IntChattiness.Value = settings.leader_chattiness;
                IntMeanness.Value = settings.leader_meanness;
                IntWarBias.Value = settings.leader_civ_war;
                IntHostileBias.Value = settings.leader_civ_hostile;
                IntDeceptiveBias.Value = settings.leader_civ_deceptive;
                IntGuardedBias.Value = settings.leader_civ_guarded;
                IntAfraidBias.Value = settings.leader_civ_afraid;
                IntFriendlyBias.Value = settings.leader_civ_friendly;
                IntNeutralBias.Value = settings.leader_civ_neutral;
                IntIgnoreApproach.Value = settings.leader_city_ignore;
                IntProtectiveApproach.Value = settings.leader_city_friendly;
                IntProtectiveApproach.Value = settings.leader_city_protect;
                IntConquestApproach.Value = settings.leader_city_conquest;
                IntBullyApproach.Value = settings.leader_city_bully;

                if (settings.civ_cities != null)
                    foreach (var city in settings.civ_cities)
                        LbCityNames.Items.Add(city);

                if (settings.civ_spies != null)
                    foreach (var spy in settings.civ_spies)
                        LbSpyNames.Items.Add(spy);

                if (settings.leader_flavors != null)
                    foreach (var flavor in settings.leader_flavors)
                        LbFlavors.Items.Add(flavor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion SAVE-LOAD

        #region CLICK_EVENTS

        private void BtnGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            if (!SaveUserSettings()) return;
            if (!GenerateCivilizationXml()) return;
            if (!GeneratePlayerColorXml()) return;
            if (!GenerateLeaderXml()) return;
            //if (!GenerateTraitXml()) return;
            //if (!GenerateBuildingsXml()) return;
            if (!GenerateIconAtlasXml()) return;
            if (!GenerateGameTextXml()) return;
            Process.Start(_outputPath + "\\XML");
        }

        private void BtnReadFromXML_Click(object sender, RoutedEventArgs e)
        {
            using (var browser = new FolderBrowserDialog { SelectedPath = _outputPath })
            {
                if (browser.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                //var gameText = XmlController.ReadGameTextXml(Directory.GetFiles(browser.SelectedPath, "GameText.xml").FirstOrDefault());
                foreach (var file in Directory.GetFiles(browser.SelectedPath))
                    if (file.Contains("Civilization.xml"))
                        ReadCivilizationXml(file);
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
            IntBullyApproach.Text = random.Next(1, 10).ToString();
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

        private void BtnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            ImgIconPreview.Source = ProcessUpload();
        }

        private void BtnUploadAlpha_Click(object sender, RoutedEventArgs e)
        {
            ImgAlphaPreview.Source = ProcessUpload(true);
        }

        private void BtnGetTemplate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(_outputPath + "\\Art");
        }

        #endregion CLICK_EVENTS

        #region CREATE_XML

        private bool GenerateCivilizationXml()
        {
            if (!ValidateForm(Categories.Civilization)) return false;

            var civType = string.Format(Properties.Resources.txt_civ, Settings.Default.civ_name);

            var gameData = new GameData
            {
                Civilizations = new Civilizations
                {
                    Row = new Civilization
                    {
                        PortraitIndex = 0,
                        Type = civType,
                        DerivativeCiv = string.Format(Properties.Resources.txt_civ, CbSoundtrack.SelectedValue.ToString().ToUpper()),
                        Description = string.Format(Properties.Resources.key_civ_desc, TbType.Text),
                        Civilopedia = "TXT_KEY_CIV_MANNCO_PEDIA_HEADER1",   // TO-DO
                        CivilopediaTag = string.Format(Properties.Resources.key_civ_pedia_text, TbType.Text),
                        ShortDescription = string.Format(Properties.Resources.key_civ_desc_short, TbType.Text),
                        Adjective = string.Format(Properties.Resources.key_civ_adjective, TbType.Text),
                        DefaultPlayerColor = string.Format(Properties.Resources.txt_civ_color, TbType.Text),
                        ArtDefineTag = string.Format(Properties.Resources.txt_civ_art_def,
                            CbSoundtrack.SelectedValue.ToString().ToUpper()),
                        ArtStyleType = string.Format(Properties.Resources.txt_civ_art_style,
                            CbArtStyle.SelectedValue.ToString().ToUpper()),
                        ArtStyleSuffix = GetArtSuffix((ArtStyles)Enum.Parse(typeof(ArtStyles),
                            CbArtStyle.SelectedValue.ToString())),
                        ArtStylePrefix = CbArtStyle.SelectedValue.ToString().ToUpper(),
                        IconAtlas = string.Format(Properties.Resources.txt_civ_atlas_icon, TbType.Text),
                        AlphaIconAtlas = string.Format(Properties.Resources.txt_civ_atlas_alpha, TbType.Text),
                        SoundtrackTag = CbSoundtrack.SelectedValue.ToString(),
                        MapImage = string.Format(Properties.Resources.txt_civ_map, TbType.Text),
                        DawnOfManQuote = string.Format(Properties.Resources.key_civ_dom_text, TbType.Text),
                        DawnOfManImage = string.Format(Properties.Resources.txt_civ_dom_image, TbLeaderType.Text)
                    }
                },
                CityNames = new CityNames
                {
                    Row = new List<CityName>()
                },
                SpyNames = new SpyNames
                {
                    Row = new List<SpyName>()
                },
                Leaders = new Models.Civilization.Leaders
                {
                    Row = new Leader
                    {
                        LeaderheadType = string.Format(Properties.Resources.txt_leader, TbLeaderType.Text),
                        CivilizationType = civType
                    }
                },
                FreeBuildingClasses = new FreeBuildingClasses
                {
                    Row = new FreeBuildingClass
                    {
                        BuildingClassType = string.Format(Properties.Resources.txt_building_class, CbFreeBuilding.SelectedValue.ToString().ToUpper()),
                        CivilizationType = civType
                    }
                },
                FreeTechs = new FreeTechs
                {
                    Row = new FreeTech
                    {
                        TechType = string.Format(Properties.Resources.txt_tech, CbFreeTech.SelectedValue.ToString().ToUpper()),
                        CivilizationType = civType
                    }
                },
                FreeUnits = new FreeUnits(),
                Religions = new Models.Civilization.Religions
                {
                    Row = new Religion
                    {
                        ReligionType = string.Format(Properties.Resources.txt_religion,
                            CbReligion.SelectedValue.ToString().ToUpper()),
                        CivilizationType = civType
                    }
                }
            };

            foreach (var x in LbCityNames.Items)
            {
                var city = new CityName
                {
                    Name = string.Format(Properties.Resources.key_city_name, Settings.Default.civ_name,
                        x.ToString().Replace(' ', '_').ToUpper()),
                    CivilizationType = civType
                };

                gameData.CityNames.Row.Add(city);
            }

            foreach (var x in LbSpyNames.Items)
            {
                var spy = new SpyName
                {
                    Name = string.Format(Properties.Resources.key_spy_name, Settings.Default.civ_name,
                        x.ToString().Replace(' ', '_').ToUpper()),
                    CivilizationType = civType
                };

                gameData.SpyNames.Row.Add(spy);
            }

            Enum.TryParse(CbFreeUnit.SelectedValue.ToString(), out Units unit);
            gameData.FreeUnits.Row = new FreeUnit
            {
                UnitClassType = string.Format(Properties.Resources.txt_unit_class,
                    CbFreeUnit.SelectedValue.ToString().ToUpper()),
                UnitAiType = string.Format(Properties.Resources.txt_unit_ai,
                    Dictionaries.UnitDictionary[unit].Item2.ToString().ToUpper()),
                Count = 1,
                CivilizationType = civType
            };

            return XmlController.GenerateCivilizationXml(gameData);
        }

        private bool GenerateLeaderXml()
        {
            if (!ValidateForm(Categories.Leader)) return false;

            var gameData = new Models.Leader.GameData
            {
                Leaders = new Leaders
                {
                    Row = new Models.Leader.Leader
                    {
                        PortraitIndex = 1,
                        Type = string.Format(Properties.Resources.txt_leader, Settings.Default.leader_name),
                        Description = string.Format(Properties.Resources.key_leader, TbLeaderType.Text),
                        Civilopedia = string.Format(Properties.Resources.key_leader_pedia, TbLeaderType.Text),
                        CivilopediaTag = string.Format(Properties.Resources.key_leader_pedia, TbLeaderType.Text),
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
                },
                Traits = new Traits
                {
                    Row = new Trait
                    {
                        TraitType = string.Format(Properties.Resources.txt_trait, "TRAIT"),
                        LeaderType = string.Format(Properties.Resources.txt_leader, Settings.Default.leader_name)
                    }
                },
                MajorCivApproachBiases = new MajorCivApproachBiases
                {
                    Row = new List<MajorCivApproachBias>()
                },
                MinorCivApproachBiases = new MinorCivApproachBiases
                {
                    Row = new List<MinorCivApproachBias>()
                },
                Flavors = new Models.Leader.Flavors
                {
                    Row = new List<Flavor>()
                }
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

            foreach (var (approach, bias) in majorApproaches)
            {
                var major = new MajorCivApproachBias
                {
                    MajorCivApproachType = approach,
                    Bias = bias ?? default,
                    LeaderType = gameData.Leaders.Row.Type
                };

                gameData.MajorCivApproachBiases.Row.Add(major);
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
                    IntConquestApproach.Value ?? default),
                new Tuple<string, int?>(string.Format(Properties.Resources.txt_minor_approach, "BULLY"),
                    IntBullyApproach.Value ?? default)
            };

            foreach (var (approach, bias) in minorApproaches)
            {
                var minor = new MinorCivApproachBias
                {
                    MinorCivApproachType = approach,
                    Bias = bias ?? default,
                    LeaderType = gameData.Leaders.Row.Type
                };

                gameData.MinorCivApproachBiases.Row.Add(minor);
            }

            foreach (var leaderFlavor in LbFlavors.Items)
            {
                var value = leaderFlavor.ToString().Split('-');
                var flavor = new Flavor
                {
                    FlavorType = $"FLAVOR{Regex.Replace(value[0], @"(?<!_)([A-Z])", "_$1").ToUpper()}",
                    Value = int.Parse(value[1]),
                    LeaderType = gameData.Leaders.Row.Type
                };

                gameData.Flavors.Row.Add(flavor);
            }

            return XmlController.GenerateLeaderXml(gameData);
        }

        private bool GeneratePlayerColorXml()
        {
            var gameData = new Models.PlayerColor.GameData
            {
                PlayerColors = new PlayerColors
                {
                    Row = new PlayerColor
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color, TbType.Text),
                        PrimaryColor = string.Format(Properties.Resources.txt_civ_color_primary, TbType.Text),
                        SecondaryColor = string.Format(Properties.Resources.txt_civ_color_secondary, TbType.Text),
                        TextColor = string.Format(Properties.Resources.txt_civ_color_text, TbType.Text)
                    }
                },
                Colors = new List<Colors>()
            };

            // Primary Color
            if (CpPrimaryColor.SelectedColor != null)
            {
                gameData.Colors.Add(new Colors
                {
                    Row = new Color
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color_primary, TbType.Text),
                        Red = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.R),
                        Green = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.G),
                        Blue = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.B),
                        Alpha = FormatColorSelection(CpPrimaryColor.SelectedColor.Value.A)
                    }
                });
            }

            // Secondary Color
            if (CpSecondaryColor.SelectedColor != null)
            {
                gameData.Colors.Add(new Colors
                {
                    Row = new Color
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color_secondary, TbType.Text),
                        Red = FormatColorSelection(CpSecondaryColor.SelectedColor.Value.R),
                        Green = FormatColorSelection(CpSecondaryColor.SelectedColor.Value.G),
                        Blue = FormatColorSelection(CpSecondaryColor.SelectedColor.Value.B),
                        Alpha = FormatColorSelection(CpSecondaryColor.SelectedColor.Value.A)
                    }
                });
            }

            // Text Color
            if (CpTextColor.SelectedColor != null)
            {
                gameData.Colors.Add(new Colors
                {
                    Row = new Color
                    {
                        Type = string.Format(Properties.Resources.txt_civ_color_text, TbType.Text),
                        Red = FormatColorSelection(CpTextColor.SelectedColor.Value.R),
                        Green = FormatColorSelection(CpTextColor.SelectedColor.Value.G),
                        Blue = FormatColorSelection(CpTextColor.SelectedColor.Value.B),
                        Alpha = FormatColorSelection(CpTextColor.SelectedColor.Value.A)
                    }
                });
            }

            return XmlController.GeneratePlayerColorXml(gameData);
        }

        private bool GenerateIconAtlasXml()
        {
            if (!string.IsNullOrEmpty(LblImagePath.Text))
                ProcessImages(LblImagePath.Text, "IconAtlas", 1024, 512);

            if (!string.IsNullOrEmpty(LblAlphaPath.Text))
                ProcessImages(LblAlphaPath.Text, "AlphaAtlas", 128, 128, true);

            var gameData = new Models.IconAtlas.GameData
            {
                IconTextureAtlases = new IconTextureAtlases
                {
                    Row = new List<IconTexture>()
                }
            };

            foreach (var x in Directory.GetFiles(_outputPath + "\\Art").ToList())
            {
                var isAlpha = x.Contains("AlphaAtlas");
                var key = isAlpha ? "AlphaAtlas" : "IconAtlas";
                var pFrom = x.IndexOf(key, StringComparison.Ordinal) + key.Length;
                var pTo = x.LastIndexOf(".psd", StringComparison.Ordinal);
                var size = x.Substring(pFrom, pTo - pFrom);

                var image = new IconTexture
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
            var gameData = new Models.GameText.GameData
            {
                Text = new Text
                {
                    Row = new List<Row>()
                }
            };

            var gameText = new List<Row>
            {
                // Civilization
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_civ_adjective, TbType.Text),
                    Text = TbAdjective.Text
                },
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_civ_desc, TbType.Text),
                    Text = TbDescription.Text
                },
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_civ_pedia_header, TbType.Text),
                    Text = TbCivilopedia.Text
                },
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_civ_dom_text, TbType.Text),
                    Text = TbDomQuote.Text
                },
                // Leader
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_leader, TbLeaderType.Text),
                    Text = TbLeaderDescription.Text
                },
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_leader_pedia, TbLeaderType.Text),
                    Text = TbLeaderCivilopedia.Text
                },
                new Row
                {
                    Tag = string.Format(Properties.Resources.key_leader_pedia_tag, TbLeaderType.Text),
                    Text = TbLeaderType.Text
                }
            };

            foreach (var x in gameText)
                gameData.Text.Row.Add(x);

            foreach (var x in LbCityNames.Items)
                gameData.Text.Row.Add(new Row
                {
                    Tag = string.Format(Properties.Resources.key_city_name, Settings.Default.civ_name, x.ToString().Replace(' ', '_').ToUpper()),
                    Text = x.ToString()
                });

            foreach (var x in LbSpyNames.Items)
                gameData.Text.Row.Add(new Row
                {
                    Tag = string.Format(Properties.Resources.key_spy_name, Settings.Default.civ_name, x.ToString().Replace(' ', '_').ToUpper()),
                    Text = x.ToString()
                });

            return XmlController.GenerateGameTextXml(gameData);
        }

        #endregion CREATE_XML

        #region READ_XML

        private void ReadCivilizationXml(string path)
        {
            try
            {
                var gameData = XmlController.ReadCivilizationXml(path);

                if (gameData is null) return;

                TbType.Text = FormatString(gameData.Civilizations.Row.Type, Properties.Resources.txt_civ);
                TbAdjective.Text = gameData.Civilizations.Row.Adjective;
                TbDescription.Text = gameData.Civilizations.Row.Description;
                TbCivilopedia.Text = gameData.Civilizations.Row.Civilopedia;
                CbArtStyle.SelectedValue = gameData.Civilizations.Row.ArtStyleType;
                CbFreeBuilding.SelectedValue = gameData.FreeBuildingClasses.Row.CivilizationType;
                CbFreeUnit.SelectedValue = gameData.FreeUnits.Row.UnitClassType;
                CbFreeTech.SelectedValue = gameData.FreeTechs.Row.TechType;
                CbReligion.SelectedValue = gameData.Religions.Row.ReligionType;
                CbSoundtrack.SelectedValue = gameData.Civilizations.Row.SoundtrackTag;
                TbDomQuote.Text = gameData.Civilizations.Row.DawnOfManQuote;
                foreach (var city in gameData.CityNames.Row)
                    LbCityNames.Items.Add(city.Name);
                foreach (var spy in gameData.SpyNames.Row)
                    LbSpyNames.Items.Add(spy.Name);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }

        private static string FormatString(string value, string remove)
        {
            remove = remove.Replace("{0}", string.Empty);
            return value.Replace(remove, string.Empty);
        }

        #endregion READ_XML
    }
}
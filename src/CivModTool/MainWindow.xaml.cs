using System.IO;
using System.Reflection;
using System.Windows;
using System.Xml.Serialization;
using AutoUpdaterDotNET;
using CivModTool.Models.Civilization;
using log4net;
using log4net.Config;

namespace CivModTool
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            Logger.Info("INITIALIZING...");
            InitializeComponent();
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.Start(Properties.Resources.app_update);
        }

        private void btnGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            var gameData = new GameData
            {
                Civilizations = new Civilizations
                {
                    Row = new Row
                    {
                        Type = "CIVILIZATION_MANNCO",
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
                }
            };
            SerializeXML(gameData);
        }

        private void SerializeXML<T>(T gameData)
        {
            var writer = new XmlSerializer(typeof(GameData));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var path = Directory.GetCurrentDirectory() + "//Civilization.xml";
            var file = File.Create(path);
            writer.Serialize(file, gameData, ns);
            file.Close();
        }
    }
}
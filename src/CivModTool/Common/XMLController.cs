using CivModTool.Models.Building;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CivModTool.Common
{
    internal static class XmlController
    {
        #region WRITE_XML

        public static bool GenerateBuildingsXml(GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.Building));
        }

        public static bool GenerateCivilizationXml(Models.Civilization.GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.Civilization));
        }

        public static bool GenerateGameTextXml(Models.GameText.GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.GameText));
        }

        public static bool GenerateIconAtlasXml(Models.IconAtlas.GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.IconAtlas));
        }

        public static bool GeneratePlayerColorXml(Models.PlayerColor.GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.PlayerColor));
        }

        public static bool GenerateLeaderXml(Models.Leader.GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.Leader));
        }

        public static bool GenerateTraitXml(Models.Trait.GameData gameData)
        {
            return SerializeXml(gameData, nameof(Categories.Trait));
        }

        #endregion WRITE_XML

        #region READ_XML

        public static Models.Civilization.GameData ReadCivilizationXml(string path)
        {
            return DeserializeXml<Models.Civilization.GameData>(nameof(Categories.Civilization), path);
        }

        public static Models.GameText.GameData ReadGameTextXml<T>(string path)
        {
            return DeserializeXml<Models.GameText.GameData>(nameof(Categories.GameText), path);
        }

        #endregion READ_XML

        internal static bool SerializeXml<T>(T gameData, string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "x");
                var path = string.Format(Properties.Resources.txt_output, Directory.GetCurrentDirectory(), fileName);
                var file = File.Create(path);
                serializer.Serialize(file, gameData, ns);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static T DeserializeXml<T>(string dataType, string path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T), dataType);
                var reader = new StreamReader(path);
                var gameData = (T)serializer.Deserialize(reader);
                reader.Close();
                return gameData;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return default;
            }
        }
    }
}
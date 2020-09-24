using CivModTool.Models.Building;
using System.IO;
using System.Xml.Serialization;

namespace CivModTool.Common
{
    internal static class XmlController
    {
        #region WRITE_XML

        public static bool GenerateBuildingsXml(GameData gameData)
        {
            return BuildingToXml.WriteBuildingsXml(gameData);
        }

        public static bool GenerateCivilizationXml(Models.Civilization.GameData gameData)
        {
            return CivilizationToXml.WriteCivilizationXml(gameData);
        }

        public static bool GenerateGameTextXml(Models.GameText.GameData gameData)
        {
            return MiscToXml.WriteGameTextXml(gameData);
        }

        public static bool GenerateIconAtlasXml(Models.IconAtlas.GameData gameData)
        {
            return MiscToXml.WriteIconAtlasXml(gameData);
        }

        public static bool GeneratePlayerColorXml(Models.PlayerColor.GameData gameData)
        {
            return MiscToXml.WritePlayerColorXml(gameData);
        }

        public static bool GenerateLeaderXml(Models.Leader.GameData gameData)
        {
            return LeaderToXml.WriteLeaderXml(gameData);
        }

        public static bool GenerateTraitXml(Models.Trait.GameData gameData)
        {
            return TraitToXml.WriteTraitXml(gameData);
        }

        #endregion WRITE_XML

        #region READ_XML

        public static Models.Civilization.GameData ReadCivilizationXml(string path)
        {
            return CivilizationToXml.ReadCivilizationXml(path);
        }

        public static Models.GameText.GameData ReadGameTextXml(string path)
        {
            return MiscToXml.ReadGameTextXml(path);
        }

        #endregion READ_XML

        internal static void SerializeXml<T>(T gameData, string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var path = string.Format(Properties.Resources.txt_output, Directory.GetCurrentDirectory(), fileName);
            var file = File.Create(path);
            serializer.Serialize(file, gameData, ns);
            file.Close();
        }
    }
}
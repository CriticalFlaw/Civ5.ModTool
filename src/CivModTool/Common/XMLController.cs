using CivModTool.Resources;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CivModTool.Common
{
    internal static class XmlController
    {
        #region WRITE_XML

        public static bool GenerateBuildingsXml(CivModTool.Models.Building.GameData gameData)
        {
            return BuildingToXml.GenerateBuildingsXml(gameData);
        }

        public static bool GenerateCivilizationXml(CivModTool.Models.Civilization.GameData gameData)
        {
            return CivilizationToXml.GenerateCivilizationXml(gameData);
        }

        public static bool GenerateGameTextXml(CivModTool.Models.GameText.GameData gameData)
        {
            return MiscToXml.GenerateGameTextXml(gameData);
        }

        public static bool GenerateIconAtlasXml(CivModTool.Models.IconAtlas.GameData gameData)
        {
            return MiscToXml.GenerateIconAtlasXml(gameData);
        }

        public static bool GeneratePlayerColorXml(CivModTool.Models.PlayerColor.GameData gameData)
        {
            return MiscToXml.GeneratePlayerColorXml(gameData);
        }

        public static bool GenerateLeaderXml(CivModTool.Models.Leader.GameData gameData)
        {
            return LeaderToXml.GenerateLeaderXml(gameData);
        }

        public static bool GenerateTraitXml(CivModTool.Models.Trait.GameData gameData)
        {
            return TraitToXml.GenerateTraitXml(gameData);
        }

        #endregion WRITE_XML

        #region READ_XML

        public static CivModTool.Models.Civilization.GameData ReadCivilizationXml(string path)
        {
            return CivilizationToXml.ReadCivilizationXml(path);
        }

        public static CivModTool.Models.GameText.GameData ReadGameTextXml(string path)
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

        internal static string GetArtPrefix(ArtStyles style)
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
    }
}
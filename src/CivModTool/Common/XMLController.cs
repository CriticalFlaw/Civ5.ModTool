using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CivModTool.Models;
using CivModTool.Properties;
using CivModTool.Resources;

namespace CivModTool.Common
{
    internal static class XmlController
    {
        public static bool GenerateBuildingsXml(Building gameData)
        {
            return BuildingToXml.GenerateBuildingsXml(gameData);
        }

        public static bool GenerateCivilizationXml(Civilization gameData)
        {
            return CivilizationToXml.GenerateCivilizationXml(gameData);
        }

        public static bool GenerateGameTextXml(List<GameText> gameData)
        {
            return MiscToXml.GenerateGameTextXml(gameData);
        }

        public static bool GenerateIconAtlasXml(List<IconAtlas> gameData)
        {
            return MiscToXml.GenerateIconAtlasXml(gameData);
        }

        public static bool GenerateLeaderXml(Leader gameData)
        {
            return LeaderToXml.GenerateLeaderXml(gameData);
        }

        public static bool GeneratePlayerColorXml(List<PlayerColor> gameData, string civ)
        {
            return MiscToXml.GeneratePlayerColorXml(gameData, civ);
        }

        public static bool GenerateTraitXml(Trait gameData)
        {
            return TraitToXml.GenerateTraitXml(gameData);
        }

        public static bool GenerateUnitsXml(Unit gameData)
        {
            return UnitToXml.GenerateUnitsXml(gameData);
        }

        internal static void SerializeXml<T>(T gameData, string fileName)
        {
            var writer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var path = string.Format(Properties.Resources.txt_output, Directory.GetCurrentDirectory(), fileName);
            var file = File.Create(path);
            writer.Serialize(file, gameData, ns);
            file.Close();
        }

        internal static string GetStringKey(string text, FileCategories category = FileCategories.GameText)
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
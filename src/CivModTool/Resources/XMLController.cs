using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CivModTool.Models.Buildings;
using CivModTool.Properties;
using CivModTool.Resources.Common;
using GameData = CivModTool.Models.Units.GameData;

namespace CivModTool.Resources
{
    internal static class XMLController
    {
        public static bool GenerateBuildingsXml(Row data)
        {
            var RequestHandler = new Common.Building();
            return RequestHandler.GenerateBuildingsXml(data);
        }

        public static bool GenerateCivilizationXml(Models.Civilization.Row data, Models.Civilization.Leaders.Row leader,
            List<Models.Civilization.CityNames.Row> cities, List<Models.Civilization.SpyNames.Row> spies,
            Models.Civilization.BuildingClassOverrides.Row building,
            Models.Civilization.FreeBuildingClasses.Row freeBuilding, Models.Civilization.FreeTechs.Row freeTech,
            Models.Civilization.FreeUnits.Row freeUnit, Models.Civilization.Religions.Row religion)
        {
            var RequestHandler = new Civilization();
            return RequestHandler.GenerateCivilizationXml(data, leader, cities, spies, building, freeBuilding, freeTech,
                freeUnit, religion);
        }

        public static bool GenerateGameTextXml(List<Models.GameText.Row> data)
        {
            var RequestHandler = new GameText();
            return RequestHandler.GenerateGameTextXml(data);
        }

        public static bool GenerateIconAtlasXml(List<Models.IconAtlas.Row> data)
        {
            var RequestHandler = new IconAtlas();
            return RequestHandler.GenerateIconAtlasXml(data);
        }

        public static bool GenerateLeaderXml(Models.Leader.Row data)
        {
            var RequestHandler = new Leader();
            return RequestHandler.GenerateLeaderXml(data);
        }

        public static bool GeneratePlayerColorXml(List<Models.PlayerColor.Color.Row> data, string civName)
        {
            var RequestHandler = new PlayerColor();
            return RequestHandler.GeneratePlayerColorXml(data, civName);
        }

        public static bool GenerateTraitXml(Models.Trait.Row data)
        {
            var RequestHandler = new Trait();
            return RequestHandler.GenerateTraitXml(data);
        }

        public static bool GenerateUnitsXml(GameData data)
        {
            var RequestHandler = new Unit();
            return RequestHandler.GenerateUnitsXml(data);
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
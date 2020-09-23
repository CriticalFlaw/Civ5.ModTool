using CivModTool.Models.Civilization;
using CivModTool.Resources;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CivModTool.Common
{
    internal static class CivilizationToXml
    {
        internal static bool GenerateCivilizationXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.Civilization));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static GameData ReadCivilizationXml(string path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(GameData), nameof(FileCategories.Civilization));
                var reader = new StreamReader(path);
                var gameData = (GameData)serializer.Deserialize(reader);
                reader.Close();
                return gameData;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return null;
            }
        }
    }
}
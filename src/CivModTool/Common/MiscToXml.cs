using CivModTool.Models.GameText;
using CivModTool.Resources;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CivModTool.Common
{
    internal static class MiscToXml
    {
        internal static bool GenerateGameTextXml(CivModTool.Models.GameText.GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.GameText));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static bool GenerateIconAtlasXml(CivModTool.Models.IconAtlas.GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.IconAtlas));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static bool GeneratePlayerColorXml(CivModTool.Models.PlayerColor.GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.PlayerColor));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static Models.GameText.GameData ReadGameTextXml(string path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(GameData), "GameText");
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

        internal static Models.IconAtlas.GameData ReadIconAtlasXml(string path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Models.IconAtlas.GameData), nameof(FileCategories.IconAtlas));
                var reader = new StreamReader(path);
                var gameData = (Models.IconAtlas.GameData)serializer.Deserialize(reader);
                reader.Close();
                return gameData;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return null;
            }
        }

        internal static Models.PlayerColor.GameData ReadPlayerColorXml(string path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Models.PlayerColor.GameData), nameof(FileCategories.PlayerColor));
                var reader = new StreamReader(path);
                var gameData = (Models.PlayerColor.GameData)serializer.Deserialize(reader);
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
using CivModTool.Models.GameText;
using CivModTool.Resources;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CivModTool.Common
{
    internal static class MiscToXml
    {
        internal static bool WriteGameTextXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(Categories.GameText));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static bool WriteIconAtlasXml(Models.IconAtlas.GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(Categories.IconAtlas));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static bool WritePlayerColorXml(Models.PlayerColor.GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(Categories.PlayerColor));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static GameData ReadGameTextXml(string path)
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
                var serializer = new XmlSerializer(typeof(Models.IconAtlas.GameData), nameof(Categories.IconAtlas));
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
                var serializer = new XmlSerializer(typeof(Models.PlayerColor.GameData),
                    nameof(Categories.PlayerColor));
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
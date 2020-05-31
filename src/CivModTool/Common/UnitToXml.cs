using System;
using CivModTool.Models;
using CivModTool.Models.XML.Units;
using CivModTool.Resources;

namespace CivModTool.Common
{
    internal class UnitToXml
    {
        internal static bool GenerateUnitsXml(Unit data)
        {
            try
            {
                var gameData = new GameData();

                XmlController.SerializeXml(gameData, FileCategories.Units.ToString());
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }
    }
}
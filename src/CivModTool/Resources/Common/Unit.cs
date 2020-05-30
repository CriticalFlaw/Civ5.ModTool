using System;
using CivModTool.Models.Units;

namespace CivModTool.Resources.Common
{
    internal class Unit
    {
        internal bool GenerateUnitsXml(GameData data)
        {
            try
            {
                var gameData = new GameData();

                XMLController.SerializeXml(gameData, FileCategories.Units.ToString());
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
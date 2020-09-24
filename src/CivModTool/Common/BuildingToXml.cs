using CivModTool.Models.Building;
using CivModTool.Resources;
using System;

namespace CivModTool.Common
{
    internal static class BuildingToXml
    {
        internal static bool WriteBuildingsXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(Categories.Building));
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
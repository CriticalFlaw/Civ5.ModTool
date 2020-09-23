using CivModTool.Models.Building;
using CivModTool.Resources;
using System;

namespace CivModTool.Common
{
    internal static class BuildingToXml
    {
        internal static bool GenerateBuildingsXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.Buildings));
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
using CivModTool.Models.Leader;
using CivModTool.Resources;
using System;

namespace CivModTool.Common
{
    internal static class LeaderToXml
    {
        internal static bool GenerateLeaderXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.Leader));
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
using CivModTool.Models.Leader;
using CivModTool.Resources;
using System;

namespace CivModTool.Common
{
    internal static class LeaderToXml
    {
        internal static bool WriteLeaderXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(Categories.Leader));
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
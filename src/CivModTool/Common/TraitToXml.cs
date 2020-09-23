using CivModTool.Models.Trait;
using CivModTool.Resources;
using System;

namespace CivModTool.Common
{
    internal static class TraitToXml
    {
        internal static bool GenerateTraitXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(FileCategories.Trait));
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
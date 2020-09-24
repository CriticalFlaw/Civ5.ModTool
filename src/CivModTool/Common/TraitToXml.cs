using CivModTool.Models.Trait;
using CivModTool.Resources;
using System;

namespace CivModTool.Common
{
    internal static class TraitToXml
    {
        internal static bool WriteTraitXml(GameData gameData)
        {
            try
            {
                XmlController.SerializeXml(gameData, nameof(Categories.Trait));
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
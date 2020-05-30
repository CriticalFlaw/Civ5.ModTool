using System;
using System.Collections.Generic;
using CivModTool.Models.IconAtlas;

namespace CivModTool.Resources.Common
{
    internal class IconAtlas
    {
        internal bool GenerateIconAtlasXml(List<Row> data)
        {
            try
            {
                var gameData = new GameData
                {
                    IconTextureAtlases = new IconTextureAtlases
                    {
                        Row = new List<Row>()
                    }
                };

                foreach (var image in data)
                {
                    var row = new Row
                    {
                        Atlas = image.Atlas,
                        IconSize = image.IconSize,
                        Filename = image.Filename,
                        IconsPerRow = image.IconsPerRow,
                        IconsPerColumn = image.IconsPerColumn
                    };
                    gameData.IconTextureAtlases.Row.Add(image);
                }

                XMLController.SerializeXml(gameData, FileCategories.IconAtlas.ToString());
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
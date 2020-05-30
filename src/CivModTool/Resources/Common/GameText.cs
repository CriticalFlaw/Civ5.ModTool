using System;
using System.Collections.Generic;
using CivModTool.Models.GameText;

namespace CivModTool.Resources.Common
{
    internal class GameText
    {
        internal bool GenerateGameTextXml(List<Row> data)
        {
            try
            {
                var gameData = new GameData
                {
                    Language_en_US = new Language_en_US
                    {
                        Row = new List<Row>()
                    }
                };

                foreach (var text in data)
                {
                    var row = new Row
                    {
                        Tag = text.Tag,
                        Text = text.Text
                    };
                    gameData.Language_en_US.Row.Add(row);
                }

                XMLController.SerializeXml(gameData, FileCategories.GameText.ToString());
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
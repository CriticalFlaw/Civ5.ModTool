using System;
using System.Collections.Generic;
using System.Globalization;
using CivModTool.Models.PlayerColor;
using CivModTool.Models.PlayerColor.Color;
using Row = CivModTool.Models.PlayerColor.Color.Row;

namespace CivModTool.Resources.Common
{
    internal class PlayerColor
    {
        internal bool GeneratePlayerColorXml(List<Row> data, string civName)
        {
            try
            {
                var gameData = new GameData
                {
                    PlayerColors = new PlayerColors
                    {
                        Row = new Models.PlayerColor.Row
                        {
                            Type = string.Format(Properties.Resources.txt_civ_color, civName),
                            PrimaryColor = string.Format(Properties.Resources.txt_civ_color_primary, civName),
                            SecondaryColor = string.Format(Properties.Resources.txt_civ_color_secondary, civName),
                            TextColor = string.Format(Properties.Resources.txt_civ_color_text, civName)
                        }
                    },

                    Colors = new List<Colors>()
                };

                foreach (var color in data)
                {
                    var colorList = new Colors
                    {
                        Row = new Row
                        {
                            Type = color.Type,
                            Red = FormatColorSelection(color.Red),
                            Green = FormatColorSelection(color.Green),
                            Blue = FormatColorSelection(color.Blue),
                            Alpha = FormatColorSelection(color.Alpha)
                        }
                    };
                    gameData.Colors.Add(colorList);
                }

                XMLController.SerializeXml(gameData, FileCategories.PlayerColor.ToString());
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        private string FormatColorSelection(string value)
        {
            var color = Convert.ToDouble(value);
            return Math.Round(color / 255, 3).ToString(CultureInfo.InvariantCulture);
        }
    }
}
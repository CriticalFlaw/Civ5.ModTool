using System;
using System.Collections.Generic;
using System.Globalization;
using CivModTool.Models;
using CivModTool.Models.XML.GameText;
using CivModTool.Models.XML.IconAtlas;
using CivModTool.Models.XML.PlayerColor;
using CivModTool.Models.XML.PlayerColor.Color;
using CivModTool.Properties;
using CivModTool.Resources;
using GameData = CivModTool.Models.XML.GameText.GameData;
using Row = CivModTool.Models.XML.GameText.Row;

namespace CivModTool.Common
{
    internal static class MiscToXml
    {
        internal static bool GenerateGameTextXml(List<GameText> data)
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
                    gameData.Language_en_US.Row.Add(new Row { Tag = text.Tag, Text = text.Text });

                XmlController.SerializeXml(gameData, nameof(FileCategories.GameText));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static bool GenerateIconAtlasXml(List<IconAtlas> data)
        {
            try
            {
                var gameData = new Models.XML.IconAtlas.GameData
                {
                    IconTextureAtlases = new IconTextureAtlases
                    {
                        Row = new List<Models.XML.IconAtlas.Row>()
                    }
                };

                foreach (var image in data)
                {
                    var row = new Models.XML.IconAtlas.Row
                    {
                        Atlas = image.Atlas,
                        IconSize = image.IconSize,
                        Filename = image.Filename,
                        IconsPerRow = image.IconsPerRow,
                        IconsPerColumn = image.IconsPerColumn
                    };
                    gameData.IconTextureAtlases.Row.Add(row);
                }

                XmlController.SerializeXml(gameData, nameof(FileCategories.IconAtlas));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        internal static bool GeneratePlayerColorXml(List<PlayerColor> data)
        {
            try
            {
                var civ_name = Settings.Default.civ_name;
                var gameData = new Models.XML.PlayerColor.GameData
                {
                    PlayerColors = new PlayerColors
                    {
                        Row = new Models.XML.PlayerColor.Row
                        {
                            Type = string.Format(Properties.Resources.txt_civ_color, civ_name),
                            PrimaryColor = string.Format(Properties.Resources.txt_civ_color_primary, civ_name),
                            SecondaryColor = string.Format(Properties.Resources.txt_civ_color_secondary, civ_name),
                            TextColor = string.Format(Properties.Resources.txt_civ_color_text, civ_name)
                        }
                    },

                    Colors = new List<Colors>()
                };

                foreach (var color in data)
                {
                    var colorList = new Colors
                    {
                        Row = new Models.XML.PlayerColor.Color.Row
                        {
                            Type = color.Type,
                            Red = FormatColorSelection(color.Color.R),
                            Green = FormatColorSelection(color.Color.G),
                            Blue = FormatColorSelection(color.Color.B),
                            Alpha = FormatColorSelection(color.Color.A)
                        }
                    };
                    gameData.Colors.Add(colorList);
                }

                XmlController.SerializeXml(gameData, nameof(FileCategories.PlayerColor));
                return true;
            }
            catch (Exception e)
            {
                MainWindow.Logger.Error(e.Message);
                return false;
            }
        }

        private static string FormatColorSelection(byte value)
        {
            var color = Convert.ToDouble(value);
            return Math.Round(color / 255, 3).ToString(CultureInfo.InvariantCulture);
        }
    }
}
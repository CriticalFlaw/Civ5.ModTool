using System;
using System.Collections.Generic;
using CivModTool.Models.Buildings;
using CivModTool.Models.Buildings.Flavors;
using CivModTool.Models.Buildings.YieldChanges;
using CivModTool.Models.Buildings.YieldModifiers;
using CivModTool.Properties;
using Row = CivModTool.Models.Buildings.Row;

namespace CivModTool.Resources.Common
{
    internal class Building
    {
        internal bool GenerateBuildingsXml(Row data)
        {
            try
            {
                var settings = Settings.Default;
                var buildingType = string.Format(Properties.Resources.txt_building, settings.civ_name,
                    settings.building_name);
                var gameData = new GameData
                {
                    Buildings = new Buildings
                    {
                        Row = data
                    },

                    Building_Flavors = new Building_Flavors
                    {
                        Row = new List<Models.Buildings.Flavors.Row>()
                    },

                    Building_YieldChanges = new Building_YieldChanges
                    {
                        Row = new Models.Buildings.YieldChanges.Row
                        {
                            BuildingType = buildingType,
                            YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                            Yield = "5"
                        }
                    },

                    Building_YieldModifiers = new Building_YieldModifiers
                    {
                        Row = new Models.Buildings.YieldModifiers.Row
                        {
                            BuildingType = buildingType,
                            YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                            Yield = "25"
                        }
                    }
                };

                var flavor = new Models.Buildings.Flavors.Row
                {
                    BuildingType = buildingType,
                    FlavorType = string.Format(Properties.Resources.txt_flavor, Resource.Gold.ToString().ToUpper()),
                    Flavor = "25"
                };
                gameData.Building_Flavors.Row.Add(flavor);

                XMLController.SerializeXml(gameData, FileCategories.Buildings.ToString());
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
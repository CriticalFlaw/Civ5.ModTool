using System;
using System.Collections.Generic;
using CivModTool.Models.Civilization;
using CivModTool.Models.Civilization.BuildingClassOverrides;
using CivModTool.Models.Civilization.CityNames;
using CivModTool.Models.Civilization.FreeBuildingClasses;
using CivModTool.Models.Civilization.FreeTechs;
using CivModTool.Models.Civilization.FreeUnits;
using CivModTool.Models.Civilization.Leaders;
using CivModTool.Models.Civilization.Religions;
using CivModTool.Models.Civilization.SpyNames;
using Row = CivModTool.Models.Civilization.Row;

namespace CivModTool.Resources.Common
{
    internal class Civilization
    {
        internal bool GenerateCivilizationXml(Row data, Models.Civilization.Leaders.Row leader,
            List<Models.Civilization.CityNames.Row> cities, List<Models.Civilization.SpyNames.Row> spies,
            Models.Civilization.BuildingClassOverrides.Row building,
            Models.Civilization.FreeBuildingClasses.Row freeBuilding, Models.Civilization.FreeTechs.Row freeTech,
            Models.Civilization.FreeUnits.Row freeUnit, Models.Civilization.Religions.Row religion)
        {
            try
            {
                var gameData = new GameData
                {
                    Civilizations = new Civilizations
                    {
                        Row = data
                    },

                    Civilization_Leaders = new Civilization_Leaders
                    {
                        Row = leader
                    },

                    Civilization_CityNames = new Civilization_CityNames
                    {
                        Row = cities
                    },

                    Civilization_SpyNames = new Civilization_SpyNames
                    {
                        Row = spies
                    },

                    Civilization_FreeBuildingClasses = new Civilization_FreeBuildingClasses
                    {
                        Row = freeBuilding
                    },

                    Civilization_FreeTechs = new Civilization_FreeTechs
                    {
                        Row = freeTech
                    },

                    Civilization_FreeUnits = new Civilization_FreeUnits
                    {
                        Row = freeUnit
                    },

                    Civilization_Religions = new Civilization_Religions
                    {
                        Row = religion
                    },

                    Civilization_BuildingClassOverrides = new Civilization_BuildingClassOverrides
                    {
                        Row = new List<Models.Civilization.BuildingClassOverrides.Row>()
                    }
                };

                gameData.Civilization_BuildingClassOverrides.Row.Add(building);

                XMLController.SerializeXml(gameData, nameof(FileCategories.Civilization));
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
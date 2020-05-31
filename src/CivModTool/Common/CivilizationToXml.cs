using System;
using System.Collections.Generic;
using CivModTool.Models;
using CivModTool.Models.XML.Civilization;
using CivModTool.Models.XML.Civilization.BuildingClassOverrides;
using CivModTool.Models.XML.Civilization.CityNames;
using CivModTool.Models.XML.Civilization.FreeBuildingClasses;
using CivModTool.Models.XML.Civilization.FreeTechs;
using CivModTool.Models.XML.Civilization.FreeUnits;
using CivModTool.Models.XML.Civilization.Leaders;
using CivModTool.Models.XML.Civilization.Religions;
using CivModTool.Models.XML.Civilization.SpyNames;
using CivModTool.Resources;
using Row = CivModTool.Models.XML.Civilization.Row;

namespace CivModTool.Common
{
    internal class CivilizationToXml
    {
        internal static bool GenerateCivilizationXml(Civilization data)
        {
            try
            {
                var gameData = new GameData
                {
                    Civilizations = new Civilizations
                    {
                        Row = new Row
                        {
                            Type = data.Type,
                            DerivativeCiv = data.DerivativeCiv,
                            Description = data.Description,
                            ShortDescription = data.ShortDescription,
                            Adjective = data.Adjective,
                            Civilopedia = data.Civilopedia,
                            CivilopediaTag = data.CivilopediaTag,
                            DefaultPlayerColor = data.DefaultPlayerColor,
                            ArtDefineTag = data.ArtDefineTag,
                            ArtStyleType = data.ArtStyleType,
                            ArtStyleSuffix = data.ArtStyleSuffix,
                            ArtStylePrefix = data.ArtStylePrefix,
                            PortraitIndex = data.PortraitIndex,
                            IconAtlas = data.IconAtlas,
                            AlphaIconAtlas = data.AlphaIconAtlas,
                            SoundtrackTag = data.DawnOfManAudio,
                            MapImage = data.MapImage,
                            DawnOfManQuote = data.DawnOfManQuote,
                            DawnOfManImage = data.DawnOfManImage
                        }
                    },

                    Civilization_Leaders = new Civilization_Leaders
                    {
                        Row = new Models.XML.Civilization.Leaders.Row
                        {
                            CivilizationType = data.Type,
                            LeaderheadType = data.LeaderheadType
                        }
                    },

                    Civilization_CityNames = new Civilization_CityNames
                    {
                        Row = new List<Models.XML.Civilization.CityNames.Row>()
                    },

                    Civilization_SpyNames = new Civilization_SpyNames
                    {
                        Row = new List<Models.XML.Civilization.SpyNames.Row>()
                    },

                    Civilization_FreeBuildingClasses = new Civilization_FreeBuildingClasses
                    {
                        Row = new Models.XML.Civilization.FreeBuildingClasses.Row
                        {
                            CivilizationType = data.Type,
                            BuildingClassType = data.FreeBuilding
                        }
                    },

                    Civilization_FreeTechs = new Civilization_FreeTechs
                    {
                        Row = new Models.XML.Civilization.FreeTechs.Row
                        {
                            CivilizationType = data.Type,
                            TechType = data.FreeTech
                        }
                    },

                    Civilization_FreeUnits = new Civilization_FreeUnits
                    {
                        Row = new Models.XML.Civilization.FreeUnits.Row
                        {
                            CivilizationType = data.Type,
                            UnitClassType = data.FreeUnit,
                            UnitAiType = data.FreeUnitAi,
                            Count = 1
                        }
                    },

                    Civilization_Religions = new Civilization_Religions
                    {
                        Row = new Models.XML.Civilization.Religions.Row
                        {
                            CivilizationType = data.Type,
                            ReligionType = data.Religion
                        }
                    },

                    Civilization_BuildingClassOverrides = new Civilization_BuildingClassOverrides
                    {
                        Row = new List<Models.XML.Civilization.BuildingClassOverrides.Row>()
                    }
                };

                foreach (var x in data.Cities)
                {
                    var name = x.ToUpper();
                    var city = new Models.XML.Civilization.CityNames.Row
                    {
                        CivilizationType = data.Type,
                        CityName = name
                    };
                    gameData.Civilization_CityNames.Row.Add(city);
                }

                foreach (var x in data.Spies)
                {
                    var name = x;
                    var spy = new Models.XML.Civilization.SpyNames.Row
                    {
                        CivilizationType = data.Type,
                        SpyName = name
                    };
                    gameData.Civilization_SpyNames.Row.Add(spy);
                }

                var building = new Models.XML.Civilization.BuildingClassOverrides.Row
                {
                    CivilizationType = data.Type,
                    BuildingClassType = data.UniqueBuilding.BuildingClassType,
                    BuildingType = data.UniqueBuilding.BuildingType
                };
                gameData.Civilization_BuildingClassOverrides.Row.Add(building);

                // TO-DO: Add Unit Override

                XmlController.SerializeXml(gameData, nameof(FileCategories.Civilization));
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
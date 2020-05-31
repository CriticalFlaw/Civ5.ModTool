using System;
using System.Collections.Generic;
using CivModTool.Models;
using CivModTool.Models.XML.Leader;
using CivModTool.Models.XML.Leader.Flavors;
using CivModTool.Models.XML.Leader.MajorCivApproachBiases;
using CivModTool.Models.XML.Leader.MinorCivApproachBiases;
using CivModTool.Models.XML.Leader.Traits;
using CivModTool.Properties;
using CivModTool.Resources;
using Row = CivModTool.Models.XML.Leader.Row;

namespace CivModTool.Common
{
    internal class LeaderToXml
    {
        internal static bool GenerateLeaderXml(Leader data)
        {
            try
            {
                var settings = Settings.Default;
                var gameData = new GameData
                {
                    Leaders = new Leaders
                    {
                        Row = new Row
                        {
                            Type = data.Type,
                            Description = data.Description,
                            Civilopedia = data.Civilopedia,
                            CivilopediaTag = data.CivilopediaTag,
                            ArtDefineTag = data.ArtDefineTag,
                            VictoryCompetitiveness = data.VictoryCompetitiveness,
                            WonderCompetitiveness = data.WonderCompetitiveness,
                            MinorCivCompetitiveness = data.MinorCivCompetitiveness,
                            Boldness = data.Boldness,
                            DiploBalance = data.DiploBalance,
                            WarmongerHate = data.WarmongerHate,
                            WorkAgainstWillingness = data.WorkAgainstWillingness,
                            WorkWithWillingness = data.WorkWithWillingness,
                            DenounceWillingness = data.DenounceWillingness,
                            Loyalty = data.Loyalty,
                            Neediness = data.Neediness,
                            Forgiveness = data.Forgiveness,
                            Chattiness = data.Chattiness,
                            Meanness = data.Meanness,
                            PortraitIndex = data.PortraitIndex,
                            IconAtlas = data.IconAtlas
                        }
                    },

                    Leader_Traits = new Leader_Traits
                    {
                        Row = new Models.XML.Leader.Traits.Row
                        {
                            LeaderType = data.Type,
                            TraitType = string.Format(Properties.Resources.txt_trait, settings.trait_name)
                        }
                    },

                    Leader_MajorCivApproachBiases = new Leader_MajorCivApproachBiases
                    {
                        Row = new List<Models.XML.Leader.MajorCivApproachBiases.Row>()
                    },

                    Leader_MinorCivApproachBiases = new Leader_MinorCivApproachBiases
                    {
                        Row = new List<Models.XML.Leader.MinorCivApproachBiases.Row>()
                    },

                    Leader_Flavors = new Leader_Flavors
                    {
                        Row = new List<Models.XML.Leader.Flavors.Row>()
                    }
                };

                foreach (var major in data.MajorBiases)
                {
                    var row = new Models.XML.Leader.MajorCivApproachBiases.Row
                    {
                        LeaderType = data.Type,
                        MajorCivApproachType = major.CivApproachType,
                        Bias = major.Bias
                    };
                    gameData.Leader_MajorCivApproachBiases.Row.Add(row);
                }

                foreach (var minor in data.MinorBiases)
                {
                    var row = new Models.XML.Leader.MinorCivApproachBiases.Row
                    {
                        LeaderType = data.Type,
                        MinorCivApproachType = minor.CivApproachType,
                        Bias = minor.Bias
                    };
                    gameData.Leader_MinorCivApproachBiases.Row.Add(row);
                }

                foreach (var flavor in data.Flavors)
                {
                    var row = new Models.XML.Leader.Flavors.Row
                    {
                        LeaderType = data.Type,
                        FlavorType = flavor.FlavorType,
                        Flavor = flavor.Count
                    };
                    gameData.Leader_Flavors.Row.Add(row);
                }

                XmlController.SerializeXml(gameData, FileCategories.Leader.ToString());
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
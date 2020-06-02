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
    internal static class LeaderToXml
    {
        internal static bool GenerateLeaderXml(Leader data)
        {
            try
            {
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
                            TraitType = string.Format(Properties.Resources.txt_trait, Settings.Default.trait_name)
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

                foreach (var x in data.MajorApproaches)
                    gameData.Leader_MajorCivApproachBiases.Row.Add(new Models.XML.Leader.MajorCivApproachBiases.Row { LeaderType = data.Type, MajorCivApproachType = x.Item1, Bias = x.Item2 ?? default });

                foreach (var x in data.MinorApproaches)
                    gameData.Leader_MinorCivApproachBiases.Row.Add(new Models.XML.Leader.MinorCivApproachBiases.Row { LeaderType = data.Type, MinorCivApproachType = x.Item1, Bias = x.Item2 ?? default });

                foreach (var x in data.Flavors)
                    gameData.Leader_Flavors.Row.Add(new Models.XML.Leader.Flavors.Row { LeaderType = data.Type, FlavorType = x.FlavorType, Flavor = x.Count });

                XmlController.SerializeXml(gameData, nameof(FileCategories.Leader));
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
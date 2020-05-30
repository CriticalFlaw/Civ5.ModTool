using System;
using System.Collections.Generic;
using CivModTool.Models.Leader;
using CivModTool.Models.Leader.Flavors;
using CivModTool.Models.Leader.MajorCivApproachBiases;
using CivModTool.Models.Leader.MinorCivApproachBiases;
using CivModTool.Models.Leader.Traits;
using CivModTool.Properties;
using Row = CivModTool.Models.Leader.Row;

namespace CivModTool.Resources.Common
{
    internal class Leader
    {
        internal bool GenerateLeaderXml(Row data)
        {
            try
            {
                var settings = Settings.Default;
                var leaderType = string.Format(Properties.Resources.txt_leader, settings.leader_name);
                var gameData = new GameData
                {
                    Leaders = new Leaders
                    {
                        Row = data
                    },

                    Leader_Traits = new Leader_Traits
                    {
                        Row = new Models.Leader.Traits.Row
                        {
                            LeaderType = leaderType,
                            TraitType = string.Format(Properties.Resources.txt_trait, settings.trait_name)
                        }
                    },

                    Leader_MajorCivApproachBiases = new Leader_MajorCivApproachBiases
                    {
                        Row = new List<Models.Leader.MajorCivApproachBiases.Row>()
                    },

                    Leader_MinorCivApproachBiases = new Leader_MinorCivApproachBiases
                    {
                        Row = new List<Models.Leader.MinorCivApproachBiases.Row>()
                    },

                    Leader_Flavors = new Leader_Flavors
                    {
                        Row = new List<Models.Leader.Flavors.Row>()
                    }
                };

                var major = new Models.Leader.MajorCivApproachBiases.Row
                {
                    LeaderType = leaderType,
                    MajorCivApproachType = string.Format(Properties.Resources.txt_major_approach, "WAR"),
                    Bias = "4"
                };
                gameData.Leader_MajorCivApproachBiases.Row.Add(major);

                var minor = new Models.Leader.MinorCivApproachBiases.Row
                {
                    LeaderType = leaderType,
                    MinorCivApproachType = string.Format(Properties.Resources.txt_minor_approach, "IGNORE"),
                    Bias = "6"
                };
                gameData.Leader_MinorCivApproachBiases.Row.Add(minor);

                var flavor = new Models.Leader.Flavors.Row
                {
                    LeaderType = leaderType,
                    FlavorType = string.Format(Properties.Resources.txt_flavor, "OFFENSE"),
                    Flavor = "6"
                };
                gameData.Leader_Flavors.Row.Add(flavor);

                XMLController.SerializeXml(gameData, FileCategories.Leader.ToString());
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
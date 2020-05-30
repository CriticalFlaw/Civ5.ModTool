using System;
using System.Collections.Generic;
using CivModTool.Models.Trait;
using CivModTool.Models.Trait.ResourceQuantityModifiers;
using CivModTool.Models.Trait.YieldChangesStrategicResources;
using CivModTool.Properties;
using Row = CivModTool.Models.Trait.Row;

namespace CivModTool.Resources.Common
{
    internal class Trait
    {
        internal bool GenerateTraitXml(Row data)
        {
            try
            {
                var settings = Settings.Default;
                var traitType = string.Format(Properties.Resources.txt_trait, settings.trait_name);
                var gameData = new GameData
                {
                    Traits = new Traits
                    {
                        Row = data
                    },

                    Trait_YieldChangesStrategicResources = new Trait_YieldChangesStrategicResources
                    {
                        Row = new Models.Trait.YieldChangesStrategicResources.Row
                        {
                            TraitType = traitType,
                            YieldType = string.Format(Properties.Resources.txt_yield, Yields.Gold.ToString().ToUpper()),
                            Yield = "3"
                        }
                    },

                    Trait_ResourceQuantityModifiers = new Trait_ResourceQuantityModifiers
                    {
                        Row = new List<Models.Trait.ResourceQuantityModifiers.Row>()
                    }
                };

                var resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = traitType,
                    ResourceType = string.Format(Properties.Resources.txt_resource, Resource.Iron.ToString().ToUpper()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = traitType,
                    ResourceType = string.Format(Properties.Resources.txt_resource, Resource.Coal.ToString().ToUpper()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                resModifier = new Models.Trait.ResourceQuantityModifiers.Row
                {
                    TraitType = traitType,
                    ResourceType = string.Format(Properties.Resources.txt_resource, Resource.Oil.ToString().ToUpper()),
                    ResourceQuantityModifier = "100"
                };
                gameData.Trait_ResourceQuantityModifiers.Row.Add(resModifier);

                XMLController.SerializeXml(gameData, FileCategories.Trait.ToString());
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
using System;
using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Leader
    {
        // UNUSED
        public string ArtDefineTag;
        public int Boldness;
        public int Chattiness;
        public string Civilopedia;
        public string CivilopediaTag;
        public int DenounceWillingness;
        public string Description;
        public int DiploBalance;
        public List<Flavor> Flavors;
        public int Forgiveness;
        public string IconAtlas;
        public int Loyalty;
        public Tuple<string, int?>[] MajorApproaches;
        public int Meanness;
        public Tuple<string, int?>[] MinorApproaches;
        public int MinorCivCompetitiveness;
        public int Neediness;
        public int PortraitIndex;

        public string TraitType;
        public string Type;
        public int VictoryCompetitiveness;
        public int WarmongerHate;
        public int WonderCompetitiveness;
        public int WorkAgainstWillingness;
        public int WorkWithWillingness;
    }

    internal class Flavor
    {
        public int Count;
        public string FlavorType;
    }
}
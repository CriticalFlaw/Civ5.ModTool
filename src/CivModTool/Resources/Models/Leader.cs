using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Leader
    {
        public string Type;
        public string Description;
        public string Civilopedia;
        public string CivilopediaTag;
        public int PortraitIndex;
        public int VictoryCompetitiveness;
        public int WonderCompetitiveness;
        public int MinorCivCompetitiveness;
        public int Boldness;
        public int DiploBalance;
        public int WarmongerHate;
        public int WorkWithWillingness;
        public int WorkAgainstWillingness;
        public int DenounceWillingness;
        public int Loyalty;
        public int Neediness;
        public int Forgiveness;
        public int Chattiness;
        public int Meanness;

        public List<ApproachBias> MajorBiases;
        public List<ApproachBias> MinorBiases;
        public List<Flavor> Flavors;

        public string TraitType;
        public string IconAtlas;

        // UNUSED
        public string ArtDefineTag;
    }

    internal class ApproachBias
    {
        public string CivApproachType;
        public int Bias;
    }

    internal class Flavor
    {
        public string FlavorType;
        public int Count;
    }
}
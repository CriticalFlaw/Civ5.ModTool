using System.Collections.Generic;

namespace CivModTool.Models
{
    internal class Leader
    {
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
        public string IconAtlas; //IconTextureAtlases
        public int Id;
        public int Loyalty;
        public List<ApproachBias> MajorBiases;
        public int Meanness;
        public List<ApproachBias> MinorBiases;
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

    internal class ApproachBias
    {
        public int Bias;
        public string CivApproachType;
        public string LeaderType;
    }

    internal class Flavor
    {
        public int Count;
        public string FlavorType;
    }
}
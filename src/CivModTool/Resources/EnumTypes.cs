using System.ComponentModel;

namespace CivModTool.Resources
{
    public enum Civs
    {
        America,
        Arabia,
        Assyria,
        Austria,
        Aztec,
        Babylon,
        Brazil,
        Byzantium,
        Carthage,
        Celts,
        China,
        Denmark,
        Egypt,
        England,
        Ethiopia,
        France,
        Germany,
        Greece,
        Huns,
        Inca,
        India,
        Indonesia,
        Iroquois,
        Japan,
        Korea,
        Maya,
        Mongol,
        Morocco,
        Netherlands,
        Ottoman,
        Persia,
        Poland,
        Polynesia,
        Portugal,
        Rome,
        Russia,
        Shoshone,
        Siam,
        Songhai,
        Spain,
        Sweden,
        Venice,
        Zulu
    }

    public enum ArtStyles
    {
        African,
        American,
        Asian,
        European,
        Mediterranean
    }

    public enum FileCategories
    {
        Buildings,
        Civilization,
        GameText,
        IconAtlas,
        Leader,
        PlayerColor,
        Trait,
        Units
    }

    public enum Religions
    {
        Buddhism,
        Christianity,
        Hinduism,
        Islam,
        Polytheism,
        Shintoism,
        Spiritualism,
        Zoroastrianism
    }

    public enum Eras
    {
        Ancient,
        Classical,
        Medieval,
        Renaissance,
        Industrial,
        Modern,
        Atomic,
        Information
    }

    public enum ResourceList
    {
        Aluminum,
        Bananas,
        Coal,
        Cotton,
        Cows,
        Deer,
        Dyes,
        Fish,
        Furs,
        Gems,
        Gold,
        Horses,
        Incense,
        Iron,
        Ivory,
        Marble,
        Oil,
        Pearls,
        Sheep,
        Silk,
        Silver,
        Spices,
        Stones,
        Sugar,
        Uranium,
        Whales,
        Wheat,
        Wine
    }

    public enum Yields // TO-DO: Complete the list
    {
        Gold,
        Science
    }

    public enum Buildings
    {
        // Unique
        Bazaar,

        [StringValue("Burial Tomb")]
        BurialTomb,

        Courthouse,

        [StringValue("Floating Gardens")]
        FloatingGardens,

        Krepost,
        Longhouse,

        [StringValue("Mud Pyramid Mosque")]
        MudPyramidMosque,

        [StringValue("Mughal Fort")]
        MughalFort,

        [StringValue("Paper Maker")]
        PaperMaker,

        [StringValue("Satraps Court")]
        SatrapsCourt,

        Wat,

        // Special
        Forge,

        Garden,

        [StringValue("Hydro Plant")]
        HydroPlant,

        Mint,
        Monastery,
        Observatory,
        Seaport,

        [StringValue("Solar Plant")]
        SolarPlant,

        Stable,
        Watermill,
        Windmill,
        Circus,

        // Normal
        Aqueduct,

        Armory,
        Arsenal,
        Bank,
        Barracks,

        [StringValue("Broadcasting Tower")]
        BroadcastingTower,

        Castle,
        Colosseum,
        Factory,
        Granary,
        Harbor,
        Hospital,
        Laboratory,
        Library,
        Lighthouse,
        Market,

        [StringValue("Medical Lab")]
        MedicalLab,

        [StringValue("Military Academy")]
        MilitaryAcademy,

        [StringValue("Military Base")]
        MilitaryBase,

        Monument,
        Museum,

        [StringValue("Nuclear Plant")]
        NuclearPlant,

        [StringValue("Opera House")]
        OperaHouse,

        [StringValue("Public School")]
        PublicSchool,

        [StringValue("Spaceship Factory")]
        SpaceshipFactory,

        Stadium,

        [StringValue("Stock Exchange")]
        StockExchange,

        [StringValue("Stone Works")]
        StoneWorks,

        Temple,
        Theatre,
        University,
        Walls,
        Workshop,

        // National Wonders
        [StringValue("Circus Maximus")]
        CircusMaximus,

        Hermitage,
        HeroicEpic,
        Ironworks,

        [StringValue("National College")]
        NationalCollege,

        [StringValue("National Epic")]
        NationalEpic,

        [StringValue("National Treasury")]
        NationalTreasury,

        [StringValue("Oxford University")]
        OxfordUniversity,

        Palace,

        // Wonders
        [StringValue("Angkor Wat")]
        AngkorWat,

        [StringValue("Big Ben")]
        BigBen,

        [StringValue("Brandenburg Gate")]
        BrandenburgGate,

        [StringValue("Chichen Itza")]
        ChichenItza,

        Colossus,

        [StringValue("Cristo Redentor")]
        CristoRedentor,

        [StringValue("Eiffel Tower")]
        EiffelTower,

        [StringValue("Forbidden Palace")]
        ForbiddenPalace,

        [StringValue("Great Library")]
        GreatLibrary,

        [StringValue("Great Lighthouse")]
        GreatLighthouse,

        [StringValue("Great Wall")]
        GreatWall,

        [StringValue("Hagia Sophia")]
        HagiaSophia,

        [StringValue("Hanging Garden")]
        HangingGarden,

        [StringValue("Himeji Castle")]
        HimejiCastle,

        Kremlin,
        Louvre,

        [StringValue("Machu Pichu")]
        MachuPichu,

        [StringValue("Notre Dam")]
        NotreDam,

        Oracle,
        Pentagon,

        [StringValue("Porcelain Tower")]
        PorcelainTower,

        Pyramid,

        [StringValue("Sistine Chapel")]
        SistineChapel,

        [StringValue("Statue of Liberty")]
        StatueOfLiberty,

        Stonehenge,

        [StringValue("Sydney Opera House")]
        SydneyOperaHouse,

        [StringValue("Taj Mahal")]
        TajMahal,

        [StringValue("United Nations")]
        UnitedNations
    }

    public enum Technologies
    {
        Agriculture,
        Pottery,

        [StringValue("Animal Husbandry")]
        AnimalHusbandry,

        Archery,
        Mining,
        Sailing,
        Calendar,
        Writing,
        Trapping,
        TheWheel,
        Masonry,

        [StringValue("Bronze Working")]
        BronzeWorking,

        Optics,
        Philosophy,

        [StringValue("Horseback Riding")]
        HorsebackRiding,

        Mathematics,
        Construction,

        [StringValue("Iron Working")]
        IronWorking,

        Theology,

        [StringValue("Civil Service")]
        CivilService,

        Currency,
        Engineering,

        [StringValue("Metal Casting")]
        MetalCasting,

        Compass,
        Education,
        Chivalry,
        Machinery,
        Physics,
        Steel,
        Astronomy,
        Acoustics,
        Banking,

        [StringValue("Printing Press")]
        PrintingPress,

        Gunpowder,
        Navigation,
        Economics,
        Chemistry,
        Metallurgy,
        Archaeology,

        [StringValue("Scientific Theory")]
        ScientificTheory,

        [StringValue("Military Science")]
        MilitaryScience,

        Fertilizer,
        Rifling,
        Biology,

        [StringValue("Steam Power")]
        SteamPower,

        Electricity,

        [StringValue("Replaceable Parts")]
        ReplaceableParts,

        Railroad,
        Dynamite,
        Refrigeration,
        Telegraph,
        Radio,
        Flight,
        Combustion,
        Plastic,
        Penicilin,
        Electronics,

        [StringValue("Mass Media")]
        MassMedia,

        Radar,

        [StringValue("Atomic Theory")]
        AtomicTheory,

        Ecology,
        Computers,
        Rocketry,
        Lasers,

        [StringValue("Nuclear Fission")]
        NuclearFission,

        Globalization,
        Robotics,
        Satellites,
        Stealth,

        [StringValue("Advanced Ballistics")]
        AdvancedBallistics,

        [StringValue("Particle Physics")]
        ParticlePhysics,

        Nanotechnology,

        [StringValue("Future Tech")]
        FutureTech
    }

    public enum Units
    {
        [StringValue("Anti-Aircraft Gun")]
        AntiAircraftGun,

        [StringValue("Anti-Tank Gun")]
        AntiTankGun,

        Archer,
        Artillery,

        [StringValue("Atomic Bomb")]
        AtomicBomb,

        Battleship,
        Bomber,

        [StringValue("Bomber (B17)")]
        Bomber_B17,

        Cannon,
        Caravel,
        Carrier,
        Catapult,

        [StringValue("Catapult (Ballista)")]
        Catapult_Ballista,

        Cavalry,
        Cavalry_Cossack,

        [StringValue("Chariot Archer")]
        ChariotArcher,

        [StringValue("Chariot Archer (War Chariot)")]
        ChariotArcher_WarChariot,

        [StringValue("Chariot Archer (Warelephant)")]
        ChariotArcher_Warelephant,

        Crossbowman,

        [StringValue("Crossbowman (Chukonu)")]
        Crossbowman_Chukonu,

        [StringValue("Crossbowman (Longbowman)")]
        Crossbowman_Longbowman,

        Destroyer,
        Fighter,

        [StringValue("Fighter (Japanese Zero)")]
        Fighter_JapaneseZero,

        Frigate,

        [StringValue("Frigate (Ship of the Line)")]
        Frigate_ShipOfTheLine,

        Galley,

        [StringValue("Guided Missle")]
        GuidedMissle,

        [StringValue("Helicopter Gunship")]
        HelicopterGunship,

        Horseman,

        [StringValue("Horseman (Companion Cavalry)")]
        Horseman_CompanionCavalry,

        Infantry,

        [StringValue("Infantry (Foreign Legion)")]
        Infantry_ForeignLegion,

        Ironclad,

        [StringValue("Jet Fighter")]
        JetFighter,

        Knight,

        [StringValue("Knight (Camelarcher)")]
        Knight_Camelarcher,

        [StringValue("Knight (Muslim Cavalry)")]
        Knight_MuslimCavalry,

        [StringValue("Knight (Warelephant)")]
        Knight_Warelephant,

        Lancer,

        [StringValue("Lancer (Sipahi)")]
        Lancer_Sipahi,

        Longswordman,

        [StringValue("Longswordman (Samurai)")]
        Longswordman_Samurai,

        Mech,

        [StringValue("Mechanized Infantry")]
        MechanizedInfantry,

        [StringValue("Missle Cruiser")]
        MissleCruiser,

        [StringValue("Mobile SAM")]
        MobileSAM,

        [StringValue("Modern Armor")]
        ModernArmor,

        Musketman,

        [StringValue("Musketman (Janissary)")]
        Musketman_Janissary,

        [StringValue("Musketman (Minuteman)")]
        Musketman_Minuteman,

        [StringValue("Musketman (Musketeer)")]
        Musketman_Musketeer,

        [StringValue("Nuclear Missle")]
        NuclearMissle,

        [StringValue("Nuclear Submarine")]
        NuclearSubmarine,

        Paratrooper,
        Pikeman,

        [StringValue("Pikeman (Landsknecht)")]
        Pikeman_Landsknecht,

        Rifleman,

        [StringValue("Rocket Artillery")]
        RocketArtillery,

        Scout,
        Settler,
        Spearman,

        [StringValue("Spearman (Hoplite)")]
        Spearman_Hoplite,

        [StringValue("Spearman (Immortal)")]
        Spearman_Immortal,

        [StringValue("Stealth Bomber")]
        StealthBomber,

        Submarine,
        Swordman,

        [StringValue("Swordman (Legion)")]
        Swordman_Legion,

        [StringValue("Swordman (Mohawk Warrior)")]
        Swordman_MohawkWarrior,

        Tank,

        [StringValue("Tank (Panzer)")]
        Tank_Panzer,

        Trebuchet,
        Trireme,
        Warrior,

        [StringValue("Warrior (Jaguar)")]
        Warrior_Jaguar,

        Workboat,
        Worker,

        // Barbarians
        [StringValue("Barbarian (Archer)")]
        Barbarian_Archer,

        [StringValue("Barbarian (Spearman)")]
        Barbarian_Spearman,

        [StringValue("Barbarian (Swordman)")]
        Barbarian_Swordman,

        [StringValue("Barbarian (Warrior)")]
        Barbarian_Warrior,

        // SpaceShip
        [StringValue("SpaceShip (Booster)")]
        SpaceShip_Booster,

        [StringValue("SpaceShip (Cockpit)")]
        SpaceShip_Cockpit,

        [StringValue("SpaceShip (Engine)")]
        SpaceShip_Engine,

        [StringValue("SpaceShip (Stasis Chamber)")]
        SpaceShip_StasisChamber,

        // Great Person

        Artist,
        Engineer,
        General,
        Merchant,
        Scientist
    }

    public enum AiTypes
    {
        Unknown,
        Settle,
        Worker,
        Attack,
        City_Bombard,
        Fast_Attack,
        Defense,
        Counter,
        Ranged,
        City_Special,
        Explore,
        Artist,
        Scientist,
        General,
        Merchant,
        Engineer,
        ICBM,
        Worker_Sea,
        Attack_Sea,
        Reserve_Sea,
        Escort_Sea,
        Explore_Sea,
        Assault_Sea,
        Settler_Sea,
        Carrier_Sea,
        Missle_Carrier_Sea,
        Pirate_Sea,
        Attack_Air,
        Defense_Air,
        Carrier_Air,
        Missle_Air,
        Paradrop,
        Spaceship_Part,
        Treasure,
        Prophet,
        Missionary,
        Inquisitor,
        Admiral
    }

    public enum MajorBiases
    {
        War,
        Hostile,
        Deceptive,
        Guarded,
        Afraid,
        Friendly,
        Neutral
    }

    public enum MinorBiases
    {
        Ignore,
        Friendly,
        Protective,
        Conquest
    }

    public enum Flavors
    {
        Offense,
        Defense,
        Military_Training,
        Recon,
        Ranged,
        Mobile,
        Naval,
        Naval_Recon,
        Naval_Growth,
        Naval_Tile_Improvement,
        Air,
        Expansion,
        Growth,
        Tile_Improvement,
        Infrastructure,
        Production,
        Gold,
        Science,
        Culture,
        Happiness,
        Great_People,
        Wonder,
        Religion,
        Diplomacy,
        Spaceship,
        Water_Connection,
        Nuke,
        Use_Nuke,
        Air_Carrier
    }

    public enum TraitAttributes
    {
        [StringValue("Able to Annex City States")]
        AbleToAnnexCityStates,

        [StringValue("Afraid Minor Per Turn Influence")]
        AfraidMinorPerTurnInfluence,

        [StringValue("Anger Free Intrusion of City States")]
        AngerFreeIntrusionOfCityStates,

        [StringValue("Bonus Religious Belief")]
        BonusReligiousBelief,

        [StringValue("Capital Building Modifier")]
        CapitalBuildingModifier,

        [StringValue("Capital Theming Bonus Modifier")]
        CapitalThemingBonusModifier,

        [StringValue("City Connection Trade Route Change")]
        CityConnectionTradeRouteChange,

        [StringValue("City Culture Bonus")]
        CityCultureBonus,

        [StringValue("City State Bonus Modifier")]
        CityStateBonusModifier,

        [StringValue("City State Combat Modifier")]
        CityStateCombatModifier,

        [StringValue("City State Friendship Modifier")]
        CityStateFriendshipModifier,

        [StringValue("City Unhappiness Modifier")]
        CityUnhappinessModifier,

        [StringValue("Combat Bonus vs. Higher Tech")]
        CombatBonusVsHigherTech,

        [StringValue("Combat Bonus vs. Larger Civilization")]
        CombatBonusVsLargerCiv,

        [StringValue("Crosses Mountains After Great General")]
        CrossesMountainsAfterGreatGeneral,

        [StringValue("Culture Building Yield Change")]
        CultureBuildingYieldChange,

        [StringValue("Culture From Kills")]
        CultureFromKills,

        [StringValue("Dof Great Person Modifier")]
        DofGreatPersonModifier,

        [StringValue("Embarked All Water")]
        EmbarkedAllWater,

        [StringValue("Embarked to Land Flat Cost")]
        EmbarkedToLandFlatCost,

        [StringValue("Extra Embark Moves")]
        ExtraEmbarkMoves,

        [StringValue("ExtraFoundedCityTerritoryClaimRange")]
        ExtraFoundedCityTerritoryClaimRange,

        [StringValue("Extra Spies")]
        ExtraSpies,

        [StringValue("Faith From Unimproved Forest")]
        FaithFromUnimprovedForest,

        [StringValue("Faster in Hills")]
        FasterInHills,

        [StringValue("Free Social Policies per Era")]
        FreeSocialPoliciesPerEra,

        [StringValue("Golden Age Combat Modifier")]
        GoldenAgeCombatModifier,

        [StringValue("Golden Age Duration Modifier")]
        GoldenAgeDurationModifier,

        [StringValue("Golden Age Great Artist Rate Modifier")]
        GoldenAgeGreatArtistRateModifier,

        [StringValue("Golden Age Great Musician Rate Modifier")]
        GoldenAgeGreatMusicianRateModifier,

        [StringValue("Golden Age Great Writer Rate Modifier")]
        GoldenAgeGreatWriterRateModifier,

        [StringValue("Golden Age Move Change")]
        GoldenAgeMoveChange,

        [StringValue("Golden Age Tourism Modifier")]
        GoldenAgeTourismModifier,

        [StringValue("Great General Extra Bonus")]
        GreatGeneralExtraBonus,

        [StringValue("Great General Rate Modifier")]
        GreatGeneralRateModifier,

        [StringValue("Great People Rate Modifier")]
        GreatPeopleRateModifier,

        [StringValue("Great Person Gift Influence")]
        GreatPersonGiftInfluence,

        [StringValue("Great Scientist Rate Modifier")]
        GreatScientistRateModifier,

        [StringValue("Improvement Maintenance Modifier")]
        ImprovementMaintenanceModifier,

        [StringValue("Land Barbarian Conversion Extra Units")]
        LandBarbarianConversionExtraUnits,

        [StringValue("Land Barbarian Conversion Percent")]
        LandBarbarianConversionPercent,

        [StringValue("Land Trade Route Range Bonus")]
        LandTradeRouteRangeBonus,

        [StringValue("Land Unit Maintenance Modifier")]
        LandUnitMaintenanceModifier,

        [StringValue("Level Experience Modifier")]
        LevelExperienceModifier,

        [StringValue("Luxury Happiness Retention")]
        LuxuryHappinessRetention,

        [StringValue("Max Global Building Production Modifier")]
        MaxGlobalBuildingProductionModifier,

        [StringValue("Max Player Building Production Modifier")]
        MaxPlayerBuildingProductionModifier,

        [StringValue("Max Team Building Production Modifier")]
        MaxTeamBuildingProductionModifier,

        [StringValue("Maya Calendar Bonuses")]
        MayaCalendarBonuses,

        [StringValue("Natural Wonder First Finder Gold")]
        NaturalWonderFirstFinderGold,

        [StringValue("Natural Wonder Happiness Modifier")]
        NaturalWonderHappinessModifier,

        [StringValue("Natural Wonder Subsequent Finder Gold")]
        NaturalWonderSubsequentFinderGold,

        [StringValue("Natural Wonder Yield Modifier")]
        NaturalWonderYieldModifier,

        [StringValue("Naval Unit Maintenance Modifier")]
        NavalUnitMaintenanceModifier,

        [StringValue("Nearby Improvement Bonus Range")]
        NearbyImprovementBonusRange,

        [StringValue("Nearby Improvement Combat Bonus")]
        NearbyImprovementCombatBonus,

        [StringValue("No Annexing")]
        NoAnnexing,

        [StringValue("No Hills Improvement Maintenance")]
        NoHillsImprovementMaintenance,

        [StringValue("Num Trade Routes Modifier")]
        NumTradeRoutesModifier,

        [StringValue("Plot Buy Cost Modifier")]
        PlotBuyCostModifier,

        [StringValue("Plot Culture Cost Modifier")]
        PlotCultureCostModifier,

        [StringValue("Plunder Modifier")]
        PlunderModifier,

        [StringValue("Policy Cost Modifier")]
        PolicyCostModifier,

        [StringValue("Population Unhappiness Modifier")]
        PopulationUnhappinessModifier,

        [StringValue("Raze Speed Modifier")]
        RazeSpeedModifier,

        [StringValue("River Trade Road")]
        RiverTradeRoad,

        [StringValue("Sea Barbarian Conversion Percent")]
        SeaBarbarianConversionPercent,

        [StringValue("Stays Alive Zero Cities")]
        StaysAliveZeroCities,

        [StringValue("Tech Boost From Capital Science Buildings")]
        TechBoostFromCapitalScienceBuildings,

        [StringValue("Tech From City Conquer")]
        TechFromCityConquer,

        [StringValue("Trade Building Modifier")]
        TradeBuildingModifier,

        [StringValue("Trade Religion Modifier")]
        TradeReligionModifier,

        [StringValue("Trade Route Change")]
        TradeRouteChange,

        [StringValue("Trade Route Resource Modifier")]
        TradeRouteResourceModifier,

        [StringValue("Unique Luxury Cities")]
        UniqueLuxuryCities,

        [StringValue("Unique Luxury Quantity")]
        UniqueLuxuryQuantity,

        [StringValue("Unique Luxury Requires New Area")]
        UniqueLuxuryRequiresNewArea,

        [StringValue("Unresearched Tech Bonus From Kills")]
        UnresearchedTechBonusFromKills,

        [StringValue("Wonder Production Modifier")]
        WonderProductionModifier,

        [StringValue("Worker Speed Modifier")]
        WorkerSpeedModifier
    }
}
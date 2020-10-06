namespace CivModTool.Common
{
    public enum Categories
    {
        Building,
        Civilization,
        GameText,
        IconAtlas,
        Leader,
        PlayerColor,
        Trait
    }

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
        BomberB17,

        Cannon,
        Caravel,
        Carrier,
        Catapult,

        [StringValue("Catapult (Ballista)")]
        CatapultBallista,

        Cavalry,
        CavalryCossack,

        [StringValue("Chariot Archer")]
        ChariotArcher,

        [StringValue("Chariot Archer (War Chariot)")]
        ChariotArcherWarChariot,

        [StringValue("Chariot Archer (Warelephant)")]
        ChariotArcherWarelephant,

        Crossbowman,

        [StringValue("Crossbowman (Chukonu)")]
        CrossbowmanChukonu,

        [StringValue("Crossbowman (Longbowman)")]
        CrossbowmanLongbowman,

        Destroyer,
        Fighter,

        [StringValue("Fighter (Japanese Zero)")]
        FighterJapaneseZero,

        Frigate,

        [StringValue("Frigate (Ship of the Line)")]
        FrigateShipOfTheLine,

        Galley,

        [StringValue("Guided Missle")]
        GuidedMissle,

        [StringValue("Helicopter Gunship")]
        HelicopterGunship,

        Horseman,

        [StringValue("Horseman (Companion Cavalry)")]
        HorsemanCompanionCavalry,

        Infantry,

        [StringValue("Infantry (Foreign Legion)")]
        InfantryForeignLegion,

        Ironclad,

        [StringValue("Jet Fighter")]
        JetFighter,

        Knight,

        [StringValue("Knight (Camelarcher)")]
        KnightCamelarcher,

        [StringValue("Knight (Muslim Cavalry)")]
        KnightMuslimCavalry,

        [StringValue("Knight (Warelephant)")]
        KnightWarelephant,

        Lancer,

        [StringValue("Lancer (Sipahi)")]
        LancerSipahi,

        Longswordman,

        [StringValue("Longswordman (Samurai)")]
        LongswordmanSamurai,

        Mech,

        [StringValue("Mechanized Infantry")]
        MechanizedInfantry,

        [StringValue("Missle Cruiser")]
        MissleCruiser,

        [StringValue("Mobile SAM")]
        MobileSam,

        [StringValue("Modern Armor")]
        ModernArmor,

        Musketman,

        [StringValue("Musketman (Janissary)")]
        MusketmanJanissary,

        [StringValue("Musketman (Minuteman)")]
        MusketmanMinuteman,

        [StringValue("Musketman (Musketeer)")]
        MusketmanMusketeer,

        [StringValue("Nuclear Missle")]
        NuclearMissle,

        [StringValue("Nuclear Submarine")]
        NuclearSubmarine,

        Paratrooper,
        Pikeman,

        [StringValue("Pikeman (Landsknecht)")]
        PikemanLandsknecht,

        Rifleman,

        [StringValue("Rocket Artillery")]
        RocketArtillery,

        Scout,
        Settler,
        Spearman,

        [StringValue("Spearman (Hoplite)")]
        SpearmanHoplite,

        [StringValue("Spearman (Immortal)")]
        SpearmanImmortal,

        [StringValue("Stealth Bomber")]
        StealthBomber,

        Submarine,
        Swordman,

        [StringValue("Swordman (Legion)")]
        SwordmanLegion,

        [StringValue("Swordman (Mohawk Warrior)")]
        SwordmanMohawkWarrior,

        Tank,

        [StringValue("Tank (Panzer)")]
        TankPanzer,

        Trebuchet,
        Trireme,
        Warrior,

        [StringValue("Warrior (Jaguar)")]
        WarriorJaguar,

        Workboat,
        Worker,

        // Barbarians
        [StringValue("Barbarian (Archer)")]
        BarbarianArcher,

        [StringValue("Barbarian (Spearman)")]
        BarbarianSpearman,

        [StringValue("Barbarian (Swordman)")]
        BarbarianSwordman,

        [StringValue("Barbarian (Warrior)")]
        BarbarianWarrior,

        // SpaceShip
        [StringValue("SpaceShip (Booster)")]
        SpaceShipBooster,

        [StringValue("SpaceShip (Cockpit)")]
        SpaceShipCockpit,

        [StringValue("SpaceShip (Engine)")]
        SpaceShipEngine,

        [StringValue("SpaceShip (Stasis Chamber)")]
        SpaceShipStasisChamber,

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
        CityBombard,
        FastAttack,
        Defense,
        Counter,
        Ranged,
        CitySpecial,
        Explore,
        Artist,
        Scientist,
        General,
        Merchant,
        Engineer,
        Icbm,
        SeaWorker,
        SeaAttack,
        SeaReserve,
        SeaEscort,
        SeaExplore,
        SeaAssault,
        SeaSettler,
        SeaCarrier,
        SeaMissleCarrier,
        SeaPirate,
        AirAttack,
        AirDefense,
        AirCarrier,
        AirMissle,
        Paradrop,
        SpaceshipPart,
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
        CityDefense,
        MilitaryTraining,
        Recon,
        Ranged,
        Mobile,
        Naval,
        NavalRecon,
        NavalGrowth,
        NavalTileImprovement,
        Air,
        Expansion,
        Growth,
        TileImprovement,
        Infrastructure,
        Production,
        Gold,
        Science,
        Culture,
        Happiness,
        GreatPeople,
        Wonder,
        Religion,
        Diplomacy,
        Spaceship,
        WaterConnection,
        Nuke,
        UseNuke,
        Espionage,
        Antiair,
        AirCarrier,
        Archaeology,
        ILandTradeRoute,
        ISeaTradeRoute,
        ITradeOrigin,
        ITradeDestination,
        Airlift
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
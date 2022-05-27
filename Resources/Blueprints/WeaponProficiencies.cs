using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

using Microsoftenator.Wotr.Common.Blueprints;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string TridentProficiency = "f9565a97342ac594e9b6a495368c1a57";
            public const string HandaxeProficiency = "c59205a5d18930d4b88b74d2acda2f49";
            public const string KukriProficiency = "a7e822a8507e44b0a981ca55586dfad9";
            public const string LightHammerProficiency = "8a43b4c0a59f7bb479d2af66d9a43ac5";
            public const string LightPickProficiency = "9aca88a627afc724bb167b05aba2f6a4";
            public const string ShortswordProficiency = "9e828934974f0fc4bbf7542eb0446e45";
            public const string StarknifeProficiency = "7818ba3db79ac064e88fa14a2478b24b";
            public const string BattleaxeProficiency = "5d1fb7b0c7a8b634b9d7903d9264895d";
            public const string FlailProficiency = "6d273f46bce2e0f47a0958810dc4c7d9";
            public const string HeavyPickProficiency = "aeac272bf357c1247a51e9c56af7193b";
            public const string LongswordProficiency = "62e27ffd9d53e14479f73da29760f64e";
            public const string RapierProficiency = "292d51f3d6a331644a8c29be0614f671";
            public const string ScimitarProficiency = "75146ee0b32e5424ab77902bf86f91ee";
            public const string WarhammerProficiency = "aba1be1d113ea4049b99ea92165e91dc";
            public const string FalchionProficiency = "caff2f50d06e4069ab18dc05cc97a966";
            public const string GlaiveProficiency = "38d4d143e7f293249b72694ddb1e0a32";
            public const string GreataxeProficiency = "70ab8880eaf6c0640887ae586556a652";
            public const string GreatswordProficiency = "f35e15b1fdff0c54087746c2da80a053";
            public const string HeavyFlailProficiency = "a22e30bd35fbb704cab2d7e3c00717c1";
            public const string ScytheProficiency = "96c174b0ebca7b246b82d4bc4aac4574";
            public const string ShortbowProficiency = "e8096942d950c8843857c2545f8dc18f";
            public const string LongbowProficiency = "0978f630fc5d6a6409ac641137bf6659";
            public const string ThrowingAxeProficiency = "579ab5b0c5bbce445a5a9bee1b1fe057";
            public const string KamaProficiency = "403740e8112651141a12f0d73d793dbc";
            public const string NunchakuProficiency = "097c1ceaf18f9a045b5969bad82b1fa4";
            public const string SaiProficiency = "a9a692792f6668d4dbe32c9c4f023800";
            public const string BastardSwordProficiency = "57299a78b2256604dadf1ab9a42e2873";
            public const string DuelingSwordProficiency = "9c37279588fd9e34e9c4cb234857492c";
            public const string DwarvenWaraxeProficiency = "bd0d7feca087d2247b12965c1467790c";
            public const string EstocProficiency = "9dc64f0b9161a354c9471a631318e16c";
            public const string FalcataProficiency = "91fe4440ac82dbf4383c872c065c6661";
            public const string TongiProficiency = "8a81cd5caec059147ba5fbb74043b8f3";
            public const string ElvenCurvedBladeProficiency = "0fca9259e370cd049a1dd50bede687f7";
            public const string FauchardProficiency = "b3f41cd91571ba54e8c3b0c5da4a7071";
            public const string SlingStaffProficiency = "a0be067e11f4d8345a8b57a92e52a301";
            public const string DoubleSwordProficiency = "716c2d518bb9ecd49a32bef96a3f431b";
            public const string DoubleAxeProficiency = "0ea5cf20b69aea44793043e1926e9057";
            public const string UrgroshProficiency = "d24f7545b1aa3b34e8216f8cb3140563";
            public const string HookedHammerProficiency = "38691cbdccbbf4b42928a5ea39e42db8";

            //public const string EarthBreakerProficiency = "cb96b756bec5433f8b427501959e4eb6";
            //public const string BardicheProficiency = "8cbaabb4d3264f3493ecb13ac0373782";
        }

        public static readonly IEnumerable<OwlcatBlueprint<BlueprintFeature>> WeaponProficienciesStock =
            new List<OwlcatBlueprint<BlueprintFeature>>()
        {
            new OwlcatBlueprint<BlueprintFeature>(Guids.TridentProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.HandaxeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.KukriProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.LightHammerProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.LightPickProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.ShortswordProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.StarknifeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.BattleaxeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.FlailProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.HeavyPickProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.LongswordProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.RapierProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.ScimitarProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.WarhammerProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.FalchionProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.GlaiveProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.GreataxeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.GreatswordProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.HeavyFlailProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.ScytheProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.ShortbowProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.LongbowProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.ThrowingAxeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.KamaProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.NunchakuProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.SaiProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.BastardSwordProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.DuelingSwordProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.DwarvenWaraxeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.EstocProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.FalcataProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.TongiProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.ElvenCurvedBladeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.FauchardProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.SlingStaffProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.DoubleSwordProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.DoubleAxeProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.UrgroshProficiency),
            new OwlcatBlueprint<BlueprintFeature>(Guids.HookedHammerProficiency),
        };
    }
}

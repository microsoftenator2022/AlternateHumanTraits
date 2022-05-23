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

            public const string EarthBreakerProficiency = "cb96b756bec5433f8b427501959e4eb6";
            public const string BardicheProficiency = "8cbaabb4d3264f3493ecb13ac0373782";
        }

        public static readonly IEnumerable<BlueprintInfo<BlueprintFeature>> WeaponProficiencies = new List<BlueprintInfo<BlueprintFeature>>()
        {
            new BlueprintInfo<BlueprintFeature>(guid: Guids.TridentProficiency, name: nameof(Guids.TridentProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.HandaxeProficiency, name: nameof(Guids.HandaxeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.KukriProficiency, name: nameof(Guids.KukriProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.LightHammerProficiency, name: nameof(Guids.LightHammerProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.LightPickProficiency, name: nameof(Guids.LightPickProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.ShortswordProficiency, name: nameof(Guids.ShortswordProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.StarknifeProficiency, name: nameof(Guids.StarknifeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.BattleaxeProficiency, name: nameof(Guids.BattleaxeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.FlailProficiency, name: nameof(Guids.FlailProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.HeavyPickProficiency, name: nameof(Guids.HeavyPickProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.LongswordProficiency, name: nameof(Guids.LongswordProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.RapierProficiency, name: nameof(Guids.RapierProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.ScimitarProficiency, name: nameof(Guids.ScimitarProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.WarhammerProficiency, name: nameof(Guids.WarhammerProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.FalchionProficiency, name: nameof(Guids.FalchionProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.GlaiveProficiency, name: nameof(Guids.GlaiveProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.GreataxeProficiency, name: nameof(Guids.GreataxeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.GreatswordProficiency, name: nameof(Guids.GreatswordProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.HeavyFlailProficiency, name: nameof(Guids.HeavyFlailProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.ScytheProficiency, name: nameof(Guids.ScytheProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.ShortbowProficiency, name: nameof(Guids.ShortbowProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.LongbowProficiency, name: nameof(Guids.LongbowProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.ThrowingAxeProficiency, name: nameof(Guids.ThrowingAxeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.KamaProficiency, name: nameof(Guids.KamaProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.NunchakuProficiency, name: nameof(Guids.NunchakuProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.SaiProficiency, name: nameof(Guids.SaiProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.BastardSwordProficiency, name: nameof(Guids.BastardSwordProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.DuelingSwordProficiency, name: nameof(Guids.DuelingSwordProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.DwarvenWaraxeProficiency, name: nameof(Guids.DwarvenWaraxeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.EstocProficiency, name: nameof(Guids.EstocProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.FalcataProficiency, name: nameof(Guids.FalcataProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.TongiProficiency, name: nameof(Guids.TongiProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.ElvenCurvedBladeProficiency, name: nameof(Guids.ElvenCurvedBladeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.FauchardProficiency, name: nameof(Guids.FauchardProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.SlingStaffProficiency, name: nameof(Guids.SlingStaffProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.DoubleSwordProficiency, name: nameof(Guids.DoubleSwordProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.DoubleAxeProficiency, name: nameof(Guids.DoubleAxeProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.UrgroshProficiency, name: nameof(Guids.UrgroshProficiency), displayName: null, description: null),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.HookedHammerProficiency, name: nameof(Guids.HookedHammerProficiency), displayName: null, description: null),

            new BlueprintInfo<BlueprintFeature>(guid: Guids.EarthBreakerProficiency, name: nameof(Guids.EarthBreakerProficiency), displayName: "Weapon Proficiency (Earth Breaker)", description: "You become proficient with earth breakers and can use them as a weapon."),
            new BlueprintInfo<BlueprintFeature>(guid: Guids.BardicheProficiency, name: nameof(Guids.BardicheProficiency), displayName: "Weapon Proficiency (Bardiche)", description: "You become proficient with bardiches and can use them as a weapon."),
        };
    }
}

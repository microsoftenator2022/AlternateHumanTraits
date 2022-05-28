using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string BasicFeatSelection = "247a4068296e8be42890143f451b4b45";
            public const string DwarvenWeaponFamiliarity = "a1619e8d27fe97c40ba443f6f8ab1763";
            public const string ElvenWeaponFamiliarity = "03fd1e043fc678a4baf73fe67c3780ce";
            public const string GnomeRace = "ef35a22c9a27da345a4528f0d5889157";
            public const string HalflingRace = "b0c3ef2729c498f47970bb50fa1acd30";
            public const string HistoryOfTerrors = "9e4c7d08f67f4496ba42c2cdb00609a7";
            public const string HumanRace = "0a5d473ead98b0646b94495af250fdc4";
            public const string HumanSkilled = "3adf9274a210b164cb68f472dc1e4544";
            public const string MartialWeaponProficiency = "203992ef5b35c864390b4e4a1e200629";
            public const string OrcWeaponFamiliarity = "6ab6c271d1558344cbc746350243d17d";
            public const string SkillFocusAcrobatics = "52dd89af385466c499338b7297896ded";
            public const string SkillFocusDiplomacy = "1621be43793c5bb43be55493e9c45924";
            public const string SkillFocusPerception = "f74c6bdf5c5f5374fb9302ecdc1f7d64";
            public const string SkillFocusSelection = "c9629ef9eebb88b479b2fbc5e836656a";
            public const string SkillFocusStealth = "3a8d34905eae4a74892aae37df3352b9";
            public const string WeaponFocusBite = "b97edcf55321a814ea6b7807d246726c";
            public const string WeaponFocusLongbow = "f641e7c569328614c87e0270ac5325dd";
        }

        public static readonly OwlcatBlueprint<BlueprintFeatureSelection> BasicFeatSelection = new(guid: Guids.BasicFeatSelection);
        public static readonly OwlcatBlueprint<BlueprintFeature> DwarvenWeaponFamiliarity = new(guid: Guids.DwarvenWeaponFamiliarity);
        public static readonly OwlcatBlueprint<BlueprintFeature> ElvenWeaponFamiliarity = new(guid: Guids.ElvenWeaponFamiliarity);
        public static readonly OwlcatBlueprint<BlueprintRace> GnomeRace = new(guid: Guids.GnomeRace);
        public static readonly OwlcatBlueprint<BlueprintRace> HalflingRace = new(guid: Guids.HalflingRace);
        public static readonly OwlcatBlueprint<BlueprintFeature> HistoryOfTerrors = new(guid: Guids.HistoryOfTerrors);
        public static readonly OwlcatBlueprint<BlueprintRace> HumanRace = new(guid: Guids.HumanRace);
        public static readonly OwlcatBlueprint<BlueprintFeature> HumanSkilled = new(guid: Guids.HumanSkilled);
        public static readonly OwlcatBlueprint<BlueprintFeature> MartialWeaponProficiency = new(guid: Guids.MartialWeaponProficiency);
        public static readonly OwlcatBlueprint<BlueprintFeature> OrcWeaponFamiliarity = new(guid: Guids.OrcWeaponFamiliarity);
        public static readonly OwlcatBlueprint<BlueprintFeature> SkillFocusAcrobatics = new(guid: Guids.SkillFocusAcrobatics);
        public static readonly OwlcatBlueprint<BlueprintFeature> SkillFocusDiplomacy = new(guid: Guids.SkillFocusDiplomacy);
        public static readonly OwlcatBlueprint<BlueprintFeature> SkillFocusPerception = new(guid: Guids.SkillFocusPerception);
        public static readonly OwlcatBlueprint<BlueprintFeatureSelection> SkillFocusSelection = new(guid: Guids.SkillFocusSelection);
        public static readonly OwlcatBlueprint<BlueprintFeature> SkillFocusStealth = new(guid: Guids.SkillFocusStealth);
        public static readonly OwlcatBlueprint<BlueprintFeature> WeaponFocusBite = new(guid: Guids.WeaponFocusBite);
        public static readonly OwlcatBlueprint<BlueprintFeature> WeaponFocusLongbow = new(guid: Guids.WeaponFocusLongbow);
    }
}

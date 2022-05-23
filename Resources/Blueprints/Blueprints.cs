using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;

namespace AlternateHumanTraits
{
    public static class Guids
    {
        //public const string HumanRace = "0a5d473ead98b0646b94495af250fdc4";
        //public const string BasicFeatSelection = "247a4068296e8be42890143f451b4b45";
        //public const string HumanSkilled = "3adf9274a210b164cb68f472dc1e4544";
        //public const string HistoryOfTerrors = "9e4c7d08f67f4496ba42c2cdb00609a7";
        public const string ElvenWeaponFamiliarity = "03fd1e043fc678a4baf73fe67c3780ce";
        public const string OrcWeaponFamiliarity = "6ab6c271d1558344cbc746350243d17d";
        public const string DwarvenWeaponFamiliarity = "a1619e8d27fe97c40ba443f6f8ab1763";
        public const string SkillFocusDiplomacy = "1621be43793c5bb43be55493e9c45924";
        public const string SkillFocusPerception = "f74c6bdf5c5f5374fb9302ecdc1f7d64";
        public const string SkillFocusStealth = "3a8d34905eae4a74892aae37df3352b9";
        public const string SkillFocusAcrobatics = "52dd89af385466c499338b7297896ded";
        public const string WeaponFocusLongbow = "f641e7c569328614c87e0270ac5325dd";
        public const string WeaponFocusBite = "b97edcf55321a814ea6b7807d246726c";

        // New blueprints
        public const string Awareness = "edc1383bf9304cd7a45ee22dd3468fc8";

        public const string AdoptiveParentageSelection = "dcdb71d16c624423a33b0129bfd46ef3";
        public const string AdoptiveParentageElf = "63fc06a0236f43e0babceaffc98511eb";
        public const string AdoptiveParentageOrc = "91aacae6527c4d8fa436dea9ed34260a";
        public const string AdoptiveParentageDwarf = "dce0abdfef85490699b51ef9514d0f56";
        public const string AdoptiveParentageGnome = "1c8f130e8c76496d80a0966f22e04d36";
        public const string AdoptiveParentageHalfling = "b0f8d1e049b04ae9a8e6d9d202ca776f";
        public const string AdoptiveParentageAasimar = "61ff76cd605c476f9c2476b58cab2054";
        public const string AdoptiveParentageTiefling = "c6c59659d8254c40bbf30f65180ef5a6";
        public const string AdoptiveParentageOread = "df4121690d6a4e02bc7694141cc3ff9d";
        public const string AdoptiveParentageKitsune = "a619783385d242e9ac96248e27c9f0c3";
        public const string AdoptiveParentageDhampir = "d6d22c99ebb64a47bcba3f0292cee70b";

        //public const string BasicFeatSelectionDummy = "771f9b2efd8842c7af7f3d1887a0dd55";

        //public const string DualTalent = "05efd0a9ec2f4cd5841d1b30d5adf312";
        //public const string DualTalentStrength = "ca578029d10a491ead3d5d7568d36ba6";
        //public const string DualTalentDexterity = "c175ca538fcc4d86b1ba568207a22b9d";
        //public const string DualTalentConstitution = "0d293f67cd92486db7b1133ce89444a8";
        //public const string DualTalentIntelligence = "84ec13278fca472e8e5816799b1c0ebd";
        //public const string DualTalentWisdom = "95ae6cff05604228ba7da7d5008565d5";
        //public const string DualTalentCharisma = "15df2403926d47d5bd6b78d56c46e270";

        public const string HistoryOfTerrorsTrait = "e0a373aeeab84ce996abd752fb9bccf6";

        //public const string HumanBonusFeat = "8a4a6f5ebe0c416a8fdb7dd98a9ab1b4";

        //public const string HumanFeatureSelection = "837e8b4205284cbbaa1ae8227870be93";

        public const string MilitaryTradition = "f44a1b342bd14ed585ec99be7d509320";

        public const string MilitaryTraditionSecondSelection = "2759047be8b143e1819766a1e994f5b6";

        //public const string NoAdditionaHumanTraits = "591db97195294968a081b7e5354bc090";

        public const string UnstoppableMagic = "051d05e970df4929a6d39d61adac1fc8";

        public const string GiantAncestry = "e85ff5a3484f46a4aead3857b2eff9c3";

        public const string ComprehensiveEducation = "07bc62abb0d94662968ce5374c1325ef";
    }

    public static class FeatureBlueprints
    {
        private static readonly IReadOnlyDictionary<string, (string name, string? displayName, string? description)> BlueprintInfoCollection =
            new Dictionary<string, (string name, string? displayName, string? description)>()
            {
                //{ Guids.HumanRace, (name: nameof(Guids.HumanRace), displayName: null, description: null) },
                //{ Guids.BasicFeatSelection, (name: nameof(Guids.BasicFeatSelection), displayName: null, description: null) },
                //{ Guids.HumanSkilled, (name: nameof(Guids.HumanSkilled), displayName: null, description: null) },
                //{ Guids.HistoryOfTerrors, (name: nameof(Guids.HistoryOfTerrors), displayName: null, description: null) },
                { Guids.ElvenWeaponFamiliarity, (name: nameof(Guids.ElvenWeaponFamiliarity), displayName: null, description: null) },
                { Guids.OrcWeaponFamiliarity, (name: nameof(Guids.OrcWeaponFamiliarity), displayName: null, description: null) },
                { Guids.DwarvenWeaponFamiliarity, (name: nameof(Guids.DwarvenWeaponFamiliarity), displayName: null, description: null) },
                { Guids.SkillFocusDiplomacy, (name: nameof(Guids.SkillFocusDiplomacy), displayName: null, description: null) },
                { Guids.SkillFocusPerception, (name: nameof(Guids.SkillFocusPerception), displayName: null, description: null) },
                { Guids.SkillFocusStealth, (name: nameof(Guids.SkillFocusStealth), displayName: null, description: null) },
                { Guids.SkillFocusAcrobatics, (name: nameof(Guids.SkillFocusAcrobatics), displayName: null, description: null) },
                { Guids.WeaponFocusLongbow, (name: nameof(Guids.WeaponFocusLongbow), displayName: null, description: null) },
                { Guids.WeaponFocusBite, (name: nameof(Guids.WeaponFocusBite), displayName: null, description: null) },

                { Guids.Awareness,
                    (name: nameof(Guids.Awareness),
                    displayName: "Awareness",
                    description: "Humans raised within monastic traditions or communities that encourage mindfulness seem to shrug off many dangers more easily than other humans. They gain a +1 racial bonus on all saving throws and concentration checks. This racial trait replaces humans’ bonus feat.") },

                //{ Guids.BasicFeatSelectionDummy, (name: nameof(Guids.BasicFeatSelectionDummy), displayName: null, description: null) },

                //{ Guids.DualTalent,
                //    (name: nameof(Guids.DualTalent),
                //    displayName: "Dual Talent",
                //    description: "Some humans are uniquely skilled at maximizing their natural gifts. These humans pick two ability scores and gain a +2 racial bonus in each of those scores. This racial trait replaces the +2 bonus to any one ability score, the bonus feat, and the skilled traits.") },
                //{ Guids.DualTalentStrength, (name: nameof(Guids.DualTalentStrength), displayName: null, description: null) },
                //{ Guids.DualTalentDexterity, (name: nameof(Guids.DualTalentDexterity), displayName: null, description: null) },
                //{ Guids.DualTalentConstitution, (name: nameof(Guids.DualTalentConstitution), displayName: null, description: null) },
                //{ Guids.DualTalentIntelligence, (name: nameof(Guids.DualTalentIntelligence), displayName: null, description: null) },
                //{ Guids.DualTalentWisdom, (name: nameof(Guids.DualTalentWisdom), displayName: null, description: null) },
                //{ Guids.DualTalentCharisma, (name: nameof(Guids.DualTalentCharisma), displayName: null, description: null) },

                { Guids.GiantAncestry,
                    (name: nameof(Guids.GiantAncestry),
                    displayName: "Giant Ancestry",
                    description: "Humans with ogre or troll ancestry end up having hulking builds and asymmetrical features. Such humans gain a +1 bonus on combat maneuver checks and to CMD, but a –2 penalty on Stealth checks. This racial trait replaces skilled.") },

                { Guids.HistoryOfTerrorsTrait, (name: nameof(Guids.HistoryOfTerrorsTrait), displayName: null, description: null) },

                //{ Guids.HumanBonusFeat,
                //    (name: nameof(Guids.HumanBonusFeat),
                //    displayName: "Bonus Feat",
                //    description: "Humans gain an extra feat at first level") },

                //{ Guids.HumanFeatureSelection,
                //    (name: nameof(Guids.HumanFeatureSelection),
                //    displayName: "Alternate Racial Traits",
                //    description: "The following alternate traits are available") },

                //{ Guids.NoAdditionaHumanTraits,
                //    (name: nameof(Guids.NoAdditionaHumanTraits),
                //    displayName: "None",
                //    description: "No alternate trait") },

                { Guids.UnstoppableMagic,
                    (name: nameof(Guids.UnstoppableMagic),
                    displayName: "Unstoppable Magic",
                    description: "Humans from civilizations built upon advanced magic are educated in a variety of ways to accomplish their magical goals. They gain a +2 racial bonus on caster level checks against spell resistance. This racial trait replaces the bonus feat trait.") },

                { Guids.MilitaryTradition,
                    (name: nameof(Guids.MilitaryTradition),
                    displayName: "Military Tradition",
                    description: "Several human cultures raise all children (or all children of a certain social class) to serve in the military or defend themselves with force of arms. They gain proficiency with up to two martial or exotic weapons appropriate to their culture. This racial trait replaces the bonus feat trait.") },
                { Guids.MilitaryTraditionSecondSelection,
                    (name: nameof(Guids.MilitaryTraditionSecondSelection),
                    displayName: "Military Tradition",
                    description: "Several human cultures raise all children (or all children of a certain social class) to serve in the military or defend themselves with force of arms. They gain proficiency with up to two martial or exotic weapons appropriate to their culture. This racial trait replaces the bonus feat trait.") },

                { Guids.AdoptiveParentageSelection,
                    (name: nameof(Guids.AdoptiveParentageSelection),
                    displayName: "Adoptive Parentage",
                    description: "Humans are sometimes orphaned and adopted by other races. Choose one humanoid race without the human subtype. You gain that race’s weapon familiarity racial trait. If the race does not have weapon familiarity, you gain either Skill Focus or Weapon Focus as a bonus feat that is appropriate for that race instead. This racial trait replaces the bonus feat trait.")},
                { Guids.AdoptiveParentageElf,
                    (name: nameof(Guids.AdoptiveParentageElf),
                    displayName: "Elf Parentage",
                    description: null)},
                { Guids.AdoptiveParentageOrc,
                    (name: nameof(Guids.AdoptiveParentageOrc),
                    displayName: "Orc Parentage",
                    description: null)},
                { Guids.AdoptiveParentageDwarf,
                    (name: nameof(Guids.AdoptiveParentageDwarf),
                    displayName: "Dwarf Parentage",
                    description: null)},
                { Guids.AdoptiveParentageGnome,
                    (name: nameof(Guids.AdoptiveParentageGnome),
                    displayName: "Gnome Parentage",
                    description: null)},
                { Guids.AdoptiveParentageHalfling,
                    (name: nameof(Guids.AdoptiveParentageHalfling),
                    displayName: "Halfling Parentage",
                    description: null)},
                { Guids.AdoptiveParentageAasimar,
                    (name: nameof(Guids.AdoptiveParentageAasimar),
                    displayName: "Aasimar Parentage",
                    description: null)},
                { Guids.AdoptiveParentageTiefling,
                    (name: nameof(Guids.AdoptiveParentageTiefling),
                    displayName: "Tiefling Parentage",
                    description: null)},
                { Guids.AdoptiveParentageOread,
                    (name: nameof(Guids.AdoptiveParentageOread),
                    displayName: "Oread Parentage",
                    description: null)},
                { Guids.AdoptiveParentageKitsune,
                    (name: nameof(Guids.AdoptiveParentageKitsune),
                    displayName: "Kitsune Parentage",
                    description: null)},
                { Guids.AdoptiveParentageDhampir,
                    (name: nameof(Guids.AdoptiveParentageDhampir),
                    displayName: "Dhampir Parentage",
                    description: null)},
                { Guids.ComprehensiveEducation,
                    (name: nameof(Guids.ComprehensiveEducation),
                    displayName: "Comprehensive Eduction",
                    description: "Humans raised with skilled teachers draw upon vast swathes of knowledge gained over centuries of civilization. They gain all Knowledge skills as class skills, and they gain a +1 racial bonus on skill checks for each Knowledge skill that they gain as a class skill from their class levels. This racial trait replaces skilled.") },
            };

        //public static Microsoftenator.Wotr.Common.Blueprints.Blueprints BlueprintData
        //    = new(BlueprintInfoCollection.Select(i => new BlueprintInfo<BlueprintScriptableObject>(i.Key, i.Value)));

        public static BlueprintInfo<TBlueprint> GetBlueprintInfo<TBlueprint>(string guid) where TBlueprint : BlueprintScriptableObject
            => new(guid, BlueprintInfoCollection[guid]);

        //--Game Blueprints--//
        //public static BlueprintInfo<BlueprintRace> HumanRace
        //    => GetBlueprintInfo<BlueprintRace>(Guids.HumanRace);
        //public static BlueprintInfo<BlueprintFeature> HumanSkilled
        //    => GetBlueprintInfo<BlueprintFeature>(Guids.HumanSkilled);
        //public static BlueprintInfo<BlueprintFeatureSelection> BasicFeatSelection
        //    => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.BasicFeatSelection);
        //public static BlueprintInfo<BlueprintFeature> HistoryOfTerrorsFeat
        //    => GetBlueprintInfo<BlueprintFeature>(Guids.HistoryOfTerrors);
        public static BlueprintInfo<BlueprintFeature> ElvenWeaponFamiliarity
            => GetBlueprintInfo<BlueprintFeature>(Guids.ElvenWeaponFamiliarity);
        public static BlueprintInfo<BlueprintFeature> OrcWeaponFamiliarity
            => GetBlueprintInfo<BlueprintFeature>(Guids.OrcWeaponFamiliarity);
        public static BlueprintInfo<BlueprintFeature> DwarvenWeaponFamiliarity
            => GetBlueprintInfo<BlueprintFeature>(Guids.DwarvenWeaponFamiliarity);
        public static BlueprintInfo<BlueprintFeature> SkillFocusDiplomacy
            => GetBlueprintInfo<BlueprintFeature>(Guids.SkillFocusDiplomacy);
        public static BlueprintInfo<BlueprintFeature> SkillFocusPerception
            => GetBlueprintInfo<BlueprintFeature>(Guids.SkillFocusPerception);
        public static BlueprintInfo<BlueprintFeature> SkillFocusStealth
            => GetBlueprintInfo<BlueprintFeature>(Guids.SkillFocusStealth);
        public static BlueprintInfo<BlueprintFeature> SkillFocusAcrobatics
            => GetBlueprintInfo<BlueprintFeature>(Guids.SkillFocusAcrobatics);
        public static BlueprintInfo<BlueprintFeature> WeaponFocusLongbow
            => GetBlueprintInfo<BlueprintFeature>(Guids.WeaponFocusLongbow);
        public static BlueprintInfo<BlueprintFeature> WeaponFocusBite
            => GetBlueprintInfo<BlueprintFeature>(Guids.WeaponFocusBite);

        //--New Blueprints--//
        //public static BlueprintInfo<BlueprintFeature> BasicFeatSelectionDummy
        //    => GetBlueprintInfo<BlueprintFeature>(Guids.BasicFeatSelectionDummy);

        public static BlueprintInfo<BlueprintFeature> HistoryOfTerrorsTrait
            => GetBlueprintInfo<BlueprintFeature>(Guids.HistoryOfTerrorsTrait);
        public static BlueprintInfo<BlueprintFeature> GiantAncestry
            => GetBlueprintInfo<BlueprintFeature>(Guids.GiantAncestry);
        public static BlueprintInfo<BlueprintFeature> ComprehensiveEducation
            => GetBlueprintInfo<BlueprintFeature>(Guids.ComprehensiveEducation);
        public static BlueprintInfo<BlueprintFeature> Awareness
            => GetBlueprintInfo<BlueprintFeature>(Guids.Awareness);
        public static BlueprintInfo<BlueprintFeature> UnstoppableMagic
            => GetBlueprintInfo<BlueprintFeature>(Guids.UnstoppableMagic);
        //public static BlueprintInfo<BlueprintFeatureSelection> HumanBonusFeat
        //    => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.HumanBonusFeat);
        //public static BlueprintInfo<BlueprintFeature> NoAdditionalHumanTraits
        //    => GetBlueprintInfo<BlueprintFeature>(Guids.NoAdditionaHumanTraits);
        //public static BlueprintInfo<BlueprintFeatureSelection> HumanFeatureSelection
        //    => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.HumanFeatureSelection);
        //public static BlueprintInfo<BlueprintFeatureSelection> DualTalent
        //    => GetBlueprintInfo<BlueprintFeatureSelection>(Resources.BlueprintData.Guids.DualTalent);
        public static BlueprintInfo<BlueprintFeatureSelection> MilitaryTradition
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.MilitaryTradition);
        public static BlueprintInfo<BlueprintFeatureSelection> MilitaryTraditionSecondSelection
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.MilitaryTraditionSecondSelection);
        public static class AdoptiveParentage
        {
            public static BlueprintInfo<BlueprintFeatureSelection> AdoptiveParentageSelection
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageSelection);

            public static IReadOnlyDictionary<Race, BlueprintInfo<BlueprintFeatureSelection>> Selections
                = new Dictionary<Race, BlueprintInfo<BlueprintFeatureSelection>>()
                {
                    { Race.Elf, GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageElf) },
                    { Race.HalfOrc, GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageOrc) },
                    { Race.Dwarf, GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageDwarf) },
                    { Race.Gnome, GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageGnome) },
                    { Race.Halfling, GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageHalfling) },
                    { Race.Aasimar, GetBlueprintInfo<BlueprintFeatureSelection>(Guids.AdoptiveParentageAasimar) },
                    { Race.Tiefling, GetBlueprintInfo <BlueprintFeatureSelection>(Guids.AdoptiveParentageTiefling) },
                    { Race.Oread, GetBlueprintInfo <BlueprintFeatureSelection>(Guids.AdoptiveParentageOread) },
                    { Race.Kitsune, GetBlueprintInfo <BlueprintFeatureSelection>(Guids.AdoptiveParentageKitsune) },
                    { Race.Dhampir, GetBlueprintInfo <BlueprintFeatureSelection>(Guids.AdoptiveParentageDhampir) },
                };
        }
    }
}
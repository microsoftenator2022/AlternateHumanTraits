using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;

namespace AlternateHumanTraits
{
    public static class Blueprints
    {
        private static class Guids
        {
            public const string HumanRace               = "0a5d473ead98b0646b94495af250fdc4";
            public const string BasicFeatSelection      = "247a4068296e8be42890143f451b4b45";
            public const string HumanSkilled            = "3adf9274a210b164cb68f472dc1e4544";
            public const string HistoryOfTerrorsFeat    = "9e4c7d08f67f4496ba42c2cdb00609a7";

            // New blueprints
            public const string Awareness               = "edc1383bf9304cd7a45ee22dd3468fc8";

            public const string AdoptiveParentage       = "dcdb71d16c624423a33b0129bfd46ef3";

            public const string BasicFeatSelectionDummy = "771f9b2efd8842c7af7f3d1887a0dd55";

            public const string DualTalent              = "05efd0a9ec2f4cd5841d1b30d5adf312";
            public const string DualTalentStrength      = "ca578029d10a491ead3d5d7568d36ba6";
            public const string DualTalentDexterity     = "c175ca538fcc4d86b1ba568207a22b9d";
            public const string DualTalentConstitution  = "0d293f67cd92486db7b1133ce89444a8";
            public const string DualTalentIntelligence  = "84ec13278fca472e8e5816799b1c0ebd";
            public const string DualTalentWisdom        = "95ae6cff05604228ba7da7d5008565d5";
            public const string DualTalentCharisma      = "15df2403926d47d5bd6b78d56c46e270";

            public const string HistoryOfTerrorsTrait   = "e0a373aeeab84ce996abd752fb9bccf6";

            public const string HumanBonusFeat          = "8a4a6f5ebe0c416a8fdb7dd98a9ab1b4";

            public const string HumanFeatureSelection   = "837e8b4205284cbbaa1ae8227870be93";

            public const string MilitaryTradition       = "f44a1b342bd14ed585ec99be7d509320";

            public const string NoAdditionaHumanTraits  = "591db97195294968a081b7e5354bc090";

            public const string UnstoppableMagic        = "051d05e970df4929a6d39d61adac1fc8";

            public const string GiantAncestry           = "e85ff5a3484f46a4aead3857b2eff9c3";
        }

        private static readonly IReadOnlyDictionary<string, (string name, string? displayName, string? description)> BlueprintsInfo =
            new Dictionary<string, (string name, string? displayName, string? description)>()
            {
                { Guids.HumanRace, (name: nameof(Guids.HumanRace), displayName: null, description: null) },
                { Guids.BasicFeatSelection, (name: nameof(Guids.BasicFeatSelection), displayName: null, description: null) },
                { Guids.HumanSkilled, (name: nameof(Guids.HumanSkilled), displayName: null, description: null) },
                { Guids.HistoryOfTerrorsFeat, (name: nameof(Guids.HistoryOfTerrorsFeat), displayName: null, description: null) },

                { Guids.Awareness,
                    (name: nameof(Guids.Awareness),
                    displayName: "Awareness",
                    description: "Humans raised within monastic traditions or communities that encourage mindfulness seem to shrug off many dangers more easily than other humans. They gain a +1 racial bonus on all saving throws and concentration checks. This racial trait replaces humans’ bonus feat.") },

                { Guids.BasicFeatSelectionDummy, (name: nameof(Guids.BasicFeatSelectionDummy), displayName: null, description: null) },

                { Guids.DualTalent,
                    (name: nameof(Guids.DualTalent),
                    displayName: "Dual Talent",
                    description: "Some humans are uniquely skilled at maximizing their natural gifts. These humans pick two ability scores and gain a +2 racial bonus in each of those scores. This racial trait replaces the +2 bonus to any one ability score, the bonus feat, and the skilled traits.") },
                { Guids.DualTalentStrength, (name: nameof(Guids.DualTalentStrength), displayName: null, description: null) },
                { Guids.DualTalentDexterity, (name: nameof(Guids.DualTalentDexterity), displayName: null, description: null) },
                { Guids.DualTalentConstitution, (name: nameof(Guids.DualTalentConstitution), displayName: null, description: null) },
                { Guids.DualTalentIntelligence, (name: nameof(Guids.DualTalentIntelligence), displayName: null, description: null) },
                { Guids.DualTalentWisdom, (name: nameof(Guids.DualTalentWisdom), displayName: null, description: null) },
                { Guids.DualTalentCharisma, (name: nameof(Guids.DualTalentCharisma), displayName: null, description: null) },

                { Guids.GiantAncestry,
                    (name: nameof(Guids.GiantAncestry),
                    displayName: "Giant Ancestry",
                    description: "Humans with ogre or troll ancestry end up having hulking builds and asymmetrical features. Such humans gain a +1 bonus on combat maneuver checks and to CMD, but a –2 penalty on Stealth checks. This racial trait replaces skilled.") },

                { Guids.HistoryOfTerrorsTrait, (name: nameof(Guids.HistoryOfTerrorsTrait), displayName: null, description: null) },

                { Guids.HumanBonusFeat,
                    (name: nameof(Guids.HumanBonusFeat),
                    displayName: "Bonus Feat",
                    description: "Humans gain an extra feat at first level") },

                { Guids.HumanFeatureSelection,
                    (name: nameof(Guids.HumanFeatureSelection),
                    displayName: "Alternate Racial Traits",
                    description: "The following alternate traits are available") },

                { Guids.NoAdditionaHumanTraits,
                    (name: nameof(Guids.NoAdditionaHumanTraits),
                    displayName: "None",
                    description: "No alternate trait") },

                { Guids.UnstoppableMagic,
                    (name: nameof(Guids.UnstoppableMagic),
                    displayName: "Unstoppable Magic",
                    description: "Humans from civilizations built upon advanced magic are educated in a variety of ways to accomplish their magical goals. They gain a +2 racial bonus on caster level checks against spell resistance. This racial trait replaces the bonus feat trait.") },

                { Guids.MilitaryTradition,
                    (name: nameof(Guids.MilitaryTradition),
                    displayName: "Military Tradition",
                    description: "Several human cultures raise all children (or all children of a certain social class) to serve in the military or defend themselves with force of arms. They gain proficiency with up to two martial or exotic weapons appropriate to their culture. This racial trait replaces the bonus feat trait.") },
            };

        public static Microsoftenator.Wotr.Common.Blueprints.Blueprints BlueprintInfoCollection
            = new(BlueprintsInfo.Select(i => new BlueprintInfo<BlueprintScriptableObject>(i.Key, i.Value)));

        private static BlueprintInfo<TBlueprint> GetBlueprintInfo<TBlueprint>(string guid) where TBlueprint : BlueprintScriptableObject
            => new BlueprintInfo<TBlueprint>(guid, BlueprintsInfo[guid]);

        //--Game Blueprints--//
        public static BlueprintInfo<BlueprintRace> HumanRace
            => GetBlueprintInfo<BlueprintRace>(Guids.HumanRace);
        public static BlueprintInfo<BlueprintFeature> HumanSkilled
            => GetBlueprintInfo<BlueprintFeature>(Guids.HumanSkilled);
        public static BlueprintInfo<BlueprintFeatureSelection> BasicFeatSelection
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.BasicFeatSelection);
        public static BlueprintInfo<BlueprintFeature> HistoryOfTerrorsFeat
            => GetBlueprintInfo<BlueprintFeature>(Guids.HistoryOfTerrorsFeat);

        //--New Blueprints--//
        public static BlueprintInfo<BlueprintFeature> BasicFeatSelectionDummy
            => GetBlueprintInfo<BlueprintFeature>(Guids.BasicFeatSelectionDummy);

        public static BlueprintInfo<BlueprintFeature> HistoryOfTerrorsTrait
            => GetBlueprintInfo<BlueprintFeature>(Guids.HistoryOfTerrorsTrait);
        public static BlueprintInfo<BlueprintFeature> GiantAncestry
            => GetBlueprintInfo<BlueprintFeature>(Guids.GiantAncestry);

        public static BlueprintInfo<BlueprintFeature> Awareness
            => GetBlueprintInfo<BlueprintFeature>(Guids.Awareness);
        public static BlueprintInfo<BlueprintFeature> UnstoppableMagic
            => GetBlueprintInfo<BlueprintFeature>(Guids.UnstoppableMagic);
        public static BlueprintInfo<BlueprintFeatureSelection> HumanBonusFeat
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.HumanBonusFeat);
        public static BlueprintInfo<BlueprintFeature> NoAdditionalHumanTraits
            => GetBlueprintInfo<BlueprintFeature>(Guids.NoAdditionaHumanTraits);
        public static BlueprintInfo<BlueprintFeatureSelection> HumanFeatureSelection
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.HumanFeatureSelection);
        public static BlueprintInfo<BlueprintFeatureSelection> DualTalent
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.DualTalent);
        public static BlueprintInfo<BlueprintFeatureSelection> MilitaryTradition
            => GetBlueprintInfo<BlueprintFeatureSelection>(Guids.MilitaryTradition);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Encyclopedia;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string DualTalent = "05efd0a9ec2f4cd5841d1b30d5adf312";
            public const string DualTalentStrength = "ca578029d10a491ead3d5d7568d36ba6";
            public const string DualTalentDexterity = "c175ca538fcc4d86b1ba568207a22b9d";
            public const string DualTalentConstitution = "0d293f67cd92486db7b1133ce89444a8";
            public const string DualTalentIntelligence = "84ec13278fca472e8e5816799b1c0ebd";
            public const string DualTalentWisdom = "95ae6cff05604228ba7da7d5008565d5";
            public const string DualTalentCharisma = "15df2403926d47d5bd6b78d56c46e270";
        }

        [LocalizedString]
        public static readonly string DualTalentDisplayName = "Dual Talent";

        [LocalizedString]
        public static readonly string DualTalentDescription =
            "Some humans are uniquely skilled at maximizing their natural gifts. These humans pick two " +
            $"{new Link(Page.Ability_Scores, "ability scores")} and gain a +2 racial " +
            $"{new Link(Page.Bonus, "bonus")} in each of those scores. This racial trait replaces the +2 " +
            "bonus to any one ability score, the bonus feat trait and the Skilled trait.";

        public static readonly NewBlueprint<BlueprintFeatureSelection> DualTalentSelection =
            new (guidString: Guids.DualTalent, name: nameof(Guids.DualTalent));

        public static readonly IEnumerable<NewBlueprint<BlueprintFeature>> DualTalentFeatures
            = new List<NewBlueprint<BlueprintFeature>>()
            {
                new(guidString: Guids.DualTalentStrength, name: nameof(Guids.DualTalentStrength)),
                new(guidString: Guids.DualTalentDexterity, name: nameof(Guids.DualTalentDexterity)),
                new(guidString: Guids.DualTalentConstitution, name: nameof(Guids.DualTalentConstitution)),
                new(guidString: Guids.DualTalentIntelligence, name: nameof(Guids.DualTalentIntelligence)),
                new(guidString: Guids.DualTalentWisdom, name: nameof(Guids.DualTalentWisdom)),
                new(guidString: Guids.DualTalentCharisma, name: nameof(Guids.DualTalentCharisma)),
            };

    }
}

namespace AlternateHumanTraits.Features
{
    internal static class DualTalent
    {
        internal static void AddDualTalent()
        {
            Main.Log?.Debug($"{nameof(DualTalent)}.{nameof(AddDualTalent)}");

            var attributeStats = new[]
            {
                StatType.Strength,
                StatType.Dexterity,
                StatType.Constitution,
                StatType.Intelligence,
                StatType.Wisdom,
                StatType.Charisma
            };

            var dualTalentSelection = Helpers.Blueprint.CreateWith(BlueprintData.DualTalentSelection)(selection =>
            {
                selection.IsClassFeature = true;

                selection.SetDisplayName(LocalizedStrings.DualTalentDisplayName);
                selection.SetDescription(LocalizedStrings.DualTalentDescription);

                selection.Groups = new[] { FeatureGroup.Racial };

                foreach(var stat in attributeStats)
                {
                    var statName = Enum.GetName(typeof(StatType), stat);

                    var bpInfo = BlueprintData.DualTalentFeatures.First(i => i.Name == $"{selection.name}{statName}");

                    var statFeature = Helpers.Blueprint.CreateWith<BlueprintFeature>(bpInfo)(feat =>
                    {
                        feat.IsClassFeature = true;

                        feat.SetDisplayName(Localization.Default, $"{BlueprintData.DualTalentDisplayName} - {statName}");
                        feat.SetDescription(LocalizedStrings.DualTalentDescription);

                        feat.Groups = new[] { FeatureGroup.Racial };

                        feat.AddComponent(new AddStatBonus() 
                        {
                            Stat = stat,
                            Value = 2,
                            Descriptor = ModifierDescriptor.Racial
                        });
                    });

                    selection.AddFeature(statFeature);
                }
            });

            dualTalentSelection.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
            {
                prerequisite.HideInUI = true;
            }, removeOnApply: true);

            dualTalentSelection.AddPrerequisiteFeature(BlueprintData.HumanSkilled.GetBlueprint(), Functional.Ignore, removeOnApply: true);
        }
    }
}

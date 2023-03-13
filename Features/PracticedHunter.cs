using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
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
            public const string PracticedHunter = "6fcc8889f4984ec68fd2422fc59bc361";
        }

        [LocalizedString]
        public static readonly string PracticedHunterDisplayName = "Practiced Hunter";
        [LocalizedString]
        public static readonly string PracticedHunterDescription =
            "Members of some human cultures train from youth to find and follow the trails of vital game and " +
            "at the same time hide the evidence of their own passage. These humans gain a +2 racial " +
            $"{new Link(Page.Bonus, "bonus")} on Stealth and Lore (Nature) " +
            $"{new Link(Page.Check, "checks")}, and Stealth and Lore (Nature) are always class " +
            "skills for them. This racial trait replaces Skilled.";

        public static readonly NewBlueprint<BlueprintFeature> PracticedHunter =
            new (guidString: Guids.PracticedHunter, name: nameof(Guids.PracticedHunter))
            {
                Init = feat =>
                {
                    feat.SetDisplayName(LocalizedStrings.PracticedHunterDisplayName);
                    feat.SetDescription(LocalizedStrings.PracticedHunterDescription);

                    feat.SetIcon(Icons.Stealthy);

                    feat.Groups = new[] { FeatureGroup.Racial };

                    feat.AddComponent(new AddStatBonus()
                    {
                        Stat = StatType.SkillStealth,
                        Descriptor = ModifierDescriptor.Racial,
                        Value = 2
                    });

                    feat.AddComponent(new AddStatBonus()
                    {
                        Stat = StatType.SkillLoreNature,
                        Descriptor = ModifierDescriptor.Racial,
                        Value = 2
                    });

                    feat.AddComponent(new AddClassSkill()
                    {
                        Skill = StatType.SkillStealth
                    });

                    feat.AddComponent(new AddClassSkill()
                    {
                        Skill = StatType.SkillLoreNature
                    });
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class PracticedHunter
    {
        public static void AddPracticedHunter()
        {
            var practicedHunter = Helpers.Blueprint.CreateWith(BlueprintData.PracticedHunter)(feat =>
            {
                feat.AddPrerequisiteFeature(
                    prerequisiteFeature: BlueprintData.HumanSkilled.GetBlueprint(),
                    init: Functional.Ignore,
                    removeOnApply: true);
            });
        }
    }
}

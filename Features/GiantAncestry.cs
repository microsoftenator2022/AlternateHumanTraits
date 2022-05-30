using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Encyclopedia;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string GiantAncestry = "e85ff5a3484f46a4aead3857b2eff9c3";
        }        

        public static readonly NewUnitFact<BlueprintFeature> GiantAncestry =
            new
            (
                guid: Guids.GiantAncestry,
                name: nameof(Guids.GiantAncestry),
                strings: Localization.Default,
                displayName: "Giant Ancestry",
                description:
                    "Humans with ogre or troll ancestry end up having hulking builds and asymmetrical features. Such " +
                    $"humans gain a +1 {new Link(Page.Bonus, "bonus")} on " +
                    $"{new Link(Page.Combat_Maneuvers, "combat maneuver")} checks and to " +
                    $"{new Link(Page.CMD, "CMD")}, but a –2 {new Link(Page.Penalty, "penalty")} on " +
                    "Stealth checks. This racial trait replaces Skilled."
            )
            {
                Init = feat =>
                {
                    feat.SetIcon(Icons.IntimidatingProwess);

                    feat.Groups = new[] { FeatureGroup.Racial };

                    feat.AddComponent(new CMBBonus()
                    {
                        Value = 1,
                        Descriptor = ModifierDescriptor.Racial
                    });

                    feat.AddComponent(new CMDBonus()
                    {
                        Value = 1,
                        Descriptor = ModifierDescriptor.Racial
                    });

                    feat.AddComponent(new AddStatBonus()
                    {
                        Value = -2,
                        Stat = StatType.SkillStealth,
                        Descriptor = ModifierDescriptor.Racial
                    });
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class GiantAncestry
    {
        internal static void AddGiantAncestry()
        {
            Main.Log?.Debug($"{nameof(GiantAncestry)}.{nameof(AddGiantAncestry)}");
            
            var giantAncestry = Helpers.CreateBlueprint(BlueprintData.GiantAncestry, feat =>
            {
                feat.AddPrerequisiteFeature(BlueprintData.HumanSkilled.GetBlueprint(), Functional.Ignore, removeOnApply: true);
            });
        }
    }
}

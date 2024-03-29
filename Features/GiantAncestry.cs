﻿using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
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
            public const string GiantAncestry = "e85ff5a3484f46a4aead3857b2eff9c3";
        }

        [LocalizedString]
        public static readonly string GiantAncestryDisplayName = "Giant Ancestry";

        [LocalizedString]
        public static readonly string GiantAncestryDescription =
            "Humans with ogre or troll ancestry end up having hulking builds and asymmetrical features. Such " +
            $"humans gain a +1 {new Link(Page.Bonus, "bonus")} on " +
            $"{new Link(Page.Combat_Maneuvers, "combat maneuver")} checks and to " +
            $"{new Link(Page.CMD, "CMD")}, but a –2 {new Link(Page.Penalty, "penalty")} on " +
            "Stealth checks. This racial trait replaces Skilled.";

        public static readonly NewBlueprint<BlueprintFeature> GiantAncestry =
            new (guidString: Guids.GiantAncestry, name: nameof(Guids.GiantAncestry))
            {
                Init = feat =>
                {
                    feat.SetDisplayName(LocalizedStrings.GiantAncestryDisplayName);
                    feat.SetDescription(LocalizedStrings.GiantAncestryDescription);

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
            
            var giantAncestry = Helpers.Blueprint.CreateWith(BlueprintData.GiantAncestry)(feat =>
            {
                feat.AddPrerequisiteFeature(BlueprintData.HumanSkilled.GetBlueprint(), Functional.Ignore, removeOnApply: true);
            });
        }
    }
}

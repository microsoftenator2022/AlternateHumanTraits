using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class GiantAncestry
    {
        private const string name = "GiantAncestry";
        private const string displayName = "Giant Ancestry";
        private const string description = "Humans with ogre or troll ancestry end up having hulking builds and asymmetrical features. Such humans gain a +1 bonus on combat maneuver checks and to CMD, but a –2 penalty on Stealth checks. This racial trait replaces skilled.";

        internal static void AddGiantAncestry()
        {
            Main.Log?.Debug($"{nameof(GiantAncestry)}.{nameof(AddGiantAncestry)}");

            var guid = Guid.Parse(Guids.GiantAncestry);
            Main.Log?.Debug($"{guid}");

            var giantAncestry = Helpers.CreateBlueprint<BlueprintFeature>(name, guid, feat =>
            {
                feat.IsClassFeature = true;
                
                feat.SetDisplayName(displayName);
                feat.SetDescription(description);

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

                feat.AddPrerequisiteFeature(Blueprints.HumanSkilled, Functional.Ignore, removeOnApply: true);
            });
        }
    }
}

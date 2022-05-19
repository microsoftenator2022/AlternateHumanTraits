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
        internal static void AddGiantAncestry()
        {
            Main.Log?.Debug($"{nameof(GiantAncestry)}.{nameof(AddGiantAncestry)}");
            
            var giantAncestry = Helpers.CreateBlueprint(FeatureBlueprints.GiantAncestry, feat =>
            {
                feat.IsClassFeature = true;
                
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

                feat.AddPrerequisiteFeature(FeatureBlueprints.HumanSkilled.GetBlueprint(), Functional.Ignore, removeOnApply: true);
            });
        }
    }
}

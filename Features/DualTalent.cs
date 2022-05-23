using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

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

            var dualTalentSelection = Helpers.CreateBlueprint(BlueprintData.DualTalentSelection, selection =>
            {
                selection.IsClassFeature = true;

                selection.Groups = new[] { FeatureGroup.Racial };

                foreach(var stat in attributeStats)
                {
                    var statName = Enum.GetName(typeof(StatType), stat);

                    var bpInfo = BlueprintData.DualTalentFeatures.First(i => i.Name == $"{selection.name}{statName}");

                    var statFeature = Helpers.CreateBlueprint<BlueprintFeature>(bpInfo.Name, bpInfo.Guid, feat =>
                    {
                        feat.IsClassFeature = true;

                        feat.SetDisplayName($"{selection.Name} - {statName}");
                        feat.SetDescription(selection.Description);

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

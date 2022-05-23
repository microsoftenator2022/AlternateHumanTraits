using System;

using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class Awareness
    {
        internal static void AddAwarenessFeature()
        {
            Main.Log?.Debug($"{nameof(Awareness)}.{nameof(AddAwarenessFeature)}");

            var awareness = Helpers.CreateBlueprint(FeatureBlueprints.Awareness, feat =>
            {
                feat.IsClassFeature = true;

                feat.Groups = new[] { FeatureGroup.Racial };

                feat.AddComponent(new BuffAllSavesBonus()
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Value = 1
                });

                feat.AddComponent(new ConcentrationBonus()
                {
                    Value = 1
                });

                feat.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

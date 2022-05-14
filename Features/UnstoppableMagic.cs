using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class UnstoppableMagic
    {
        internal static void AddUnstoppableMagic()
        {
            Main.Log?.Debug($"{nameof(UnstoppableMagic)}.{nameof(AddUnstoppableMagic)}");


            var unstoppableMagic = Helpers.CreateBlueprint<BlueprintFeature>(Blueprints.UnstoppableMagic, feat =>
            {
                feat.IsClassFeature = true;

                feat.Groups = new[] { FeatureGroup.Racial };

                feat.AddComponent(new SpellPenetrationBonus() { Value = 2 });

                feat.AddPrerequisiteFeature(Blueprints.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

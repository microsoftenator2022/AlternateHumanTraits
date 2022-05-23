using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class HumanBonusFeat
    {
        internal static void AddHumanBonusFeat()
        {
            Main.Log?.Debug($"{nameof(HumanBonusFeat)}.{nameof(AddHumanBonusFeat)}");

            var humanBonusFeat = Helpers.CreateBlueprint(BlueprintData.HumanBonusFeat, selection =>
            {
                selection.IsClassFeature = true;

                selection.SetIcon(BlueprintData.BasicFeatSelection.GetBlueprint().Icon);

                selection.Groups = new[] { FeatureGroup.Racial };
                selection.Group = FeatureGroup.Feat;

                //selection.SetFeatures(Blueprints.BasicFeatSelection.GetBlueprint().Features, Blueprints.BasicFeatSelection.GetBlueprint().AllFeatures);
                selection.SetFeatures(new[] { BlueprintData.BasicFeatSelection.GetBlueprint().ToReference<BlueprintFeatureReference>() } );

                selection.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

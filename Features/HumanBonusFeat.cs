using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class HumanBonusFeat
    {
        private const string name = "HumanBonusFeat";
        private const string displayName = "Bonus Feat";
        private const string description = "Humans gain an extra feat at first level";

        internal static void AddHumanBonusFeat()
        {
            Main.Log?.Debug($"{nameof(HumanBonusFeat)}.{nameof(AddHumanBonusFeat)}");

            var humanBonusFeat = Helpers.CreateBlueprint<BlueprintFeatureSelection>(name,
                Guid.Parse(Guids.HumanBonusFeat), selection =>
            {
                selection.IsClassFeature = true;

                selection.SetDisplayName(displayName);
                selection.SetDescription(description);
                selection.SetIcon(Blueprints.BasicFeatSelection.Icon);

                selection.Groups = new[] { FeatureGroup.Racial };
                selection.Group = FeatureGroup.Feat;

                selection.SetFeatures(Blueprints.BasicFeatSelection.Features, Blueprints.BasicFeatSelection.AllFeatures);

                selection.AddPrerequisiteFeature(Blueprints.BasicFeatSelectionDummy, prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

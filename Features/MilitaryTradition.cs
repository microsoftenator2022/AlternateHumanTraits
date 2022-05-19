using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

using UnityEngine;

namespace AlternateHumanTraits.Features
{
    internal static class MilitaryTradition
    {
        internal static void AddMilitaryTradition()
        {
            var init = (BlueprintFeatureSelection selection) =>
            {
                selection.IsClassFeature = true;

                selection.Groups = new[] { FeatureGroup.Racial };

                //selection.SetIcon(ResourcesLibrary.TryGetResource<Sprite>(Resources.Guids.WeaponProficiencyIcon));

                foreach (var weaponProficiency in WeaponProficiencies.BlueprintData)
                {
                    selection.AddFeature(weaponProficiency.GetBlueprint().ToReference<BlueprintFeatureReference>());
                }
            };

            var militaryTradition = Helpers.CreateBlueprint(FeatureBlueprints.MilitaryTradition, init);
            militaryTradition.AddPrerequisiteFeature(FeatureBlueprints.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
            {
                prerequisite.HideInUI = true;
            }, removeOnApply: true);

            var militaryTradition2 = Helpers.CreateBlueprint(FeatureBlueprints.MilitaryTraditionSecondSelection, init);
            militaryTradition2.AddPrerequisiteFeature(militaryTradition, prerequisite =>
            {
                prerequisite.HideInUI = true;
            });
            militaryTradition2.AddPrerequisiteNoFeature(militaryTradition2, prerequisite =>
            {
                prerequisite.HideInUI = true;
            });
            militaryTradition2.HideNotAvailibleInUI = true;
        }
    }
}

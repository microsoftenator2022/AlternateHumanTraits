using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

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
            Main.Log?.Debug($"{nameof(MilitaryTradition)}.{nameof(AddMilitaryTradition)}");

            var init = (BlueprintFeatureSelection selection) =>
            {
                selection.IsClassFeature = true;

                selection.Groups = new[] { FeatureGroup.Racial };

                var icon = Resources.Icons.WeaponSpecialization;

                if(icon is null)
                    Main.Log?.Debug($"Null icon");

                selection.SetIcon(icon);

                foreach (var weaponProficiency in BlueprintData.WeaponProficiencies)
                {
                    selection.AddFeature(weaponProficiency.GetBlueprint().ToReference<BlueprintFeatureReference>());
                }
            };

            var militaryTradition = Helpers.CreateBlueprint(FeatureBlueprints.MilitaryTradition, init);
            militaryTradition.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
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


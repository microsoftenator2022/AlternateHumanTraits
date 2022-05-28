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

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string MilitaryTradition = "f44a1b342bd14ed585ec99be7d509320";
            public const string MilitaryTraditionSecondSelection = "2759047be8b143e1819766a1e994f5b6";
        }

        public static readonly NewUnitFact<BlueprintFeatureSelection> MilitaryTradition =
            new
            (
                guid: Guids.MilitaryTradition,
                name: nameof(Guids.MilitaryTradition),
                strings: Localization.Default,
                displayName: "Military Tradition",
                description: "Several human cultures raise all children (or all children of a certain social class) to serve in the military or defend themselves with force of arms. They gain proficiency with up to two martial or exotic weapons appropriate to their culture. This racial trait replaces the bonus feat trait."
            );

        public static readonly NewUnitFact<BlueprintFeatureSelection> MilitaryTraditionSecondSelection =
            new
            (
                guid: Guids.MilitaryTraditionSecondSelection,
                name: nameof(Guids.MilitaryTraditionSecondSelection)
            );
    }
}

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

                foreach (var weaponProficiency in 
                    BlueprintData.WeaponProficienciesStock
                        .Cast<BlueprintInfoAbstract<BlueprintFeature>>()
                        .Concat(BlueprintData.NewWeaponProficiencies))
                {
                    selection.AddFeature(weaponProficiency.GetBlueprint());
                }
            };

            var militaryTradition = Helpers.CreateBlueprint(BlueprintData.MilitaryTradition, init);
            militaryTradition.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
            {
                prerequisite.HideInUI = true;
            }, removeOnApply: true);

            var militaryTradition2 = Helpers.CreateBlueprint(BlueprintData.MilitaryTraditionSecondSelection, feat =>
            {
                feat.SetDisplayName(BlueprintData.MilitaryTradition.DisplayName);
                feat.SetDescription(BlueprintData.MilitaryTradition.Description);

                init(feat);
            });
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

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

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string HumanBonusFeat = "8a4a6f5ebe0c416a8fdb7dd98a9ab1b4";
        }

        public static readonly NewUnitFact<BlueprintFeatureSelection> HumanBonusFeat =
            new
            (
                guid: Guids.HumanBonusFeat,
                name: nameof(Guids.HumanBonusFeat),
                strings: Localization.Default,
                displayName: "Bonus Feat",
                description: "Humans select one extra feat at 1st level."
            )
            {
                Init = selection =>
                {
                    selection.IsClassFeature = true;

                    selection.Groups = new[] { FeatureGroup.Racial };
                    selection.Group = FeatureGroup.Feat;
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class HumanBonusFeat
    {
        internal static void AddHumanBonusFeat()
        {
            Main.Log?.Debug($"{nameof(HumanBonusFeat)}.{nameof(AddHumanBonusFeat)}");

            var humanBonusFeat = Helpers.CreateBlueprint(BlueprintData.HumanBonusFeat, selection =>
            {
                selection.SetIcon(BlueprintData.BasicFeatSelection.GetBlueprint().Icon);
                
                selection.AddFeature(BlueprintData.BasicFeatSelection.GetBlueprint().ToReference<BlueprintFeatureReference>());
                
                selection.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

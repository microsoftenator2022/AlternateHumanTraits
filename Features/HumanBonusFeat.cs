using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Encyclopedia;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string HumanBonusFeat = "8a4a6f5ebe0c416a8fdb7dd98a9ab1b4";
        }

        [LocalizedString]
        public static readonly string HumanBonusFeatDisplayName = "Bonus Feat";

        [LocalizedString]
        public static readonly string HumanBonusFeatDescription = $"Humans select one extra {new Link(Page.Feat, "feat")} at 1st level.";

        public static readonly NewBlueprint<BlueprintFeatureSelection> HumanBonusFeat =
            new (guidString: Guids.HumanBonusFeat, name: nameof(Guids.HumanBonusFeat))
            {
                Init = selection =>
                {
                    selection.IsClassFeature = true;

                    selection.SetDisplayName(LocalizedStrings.HumanBonusFeatDisplayName);
                    selection.SetDescription(LocalizedStrings.HumanBonusFeatDescription);

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

            var humanBonusFeat = Helpers.Blueprint.CreateWith(BlueprintData.HumanBonusFeat)(selection =>
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

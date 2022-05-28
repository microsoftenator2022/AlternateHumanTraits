using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string HistoryOfTerrorsTrait = "e0a373aeeab84ce996abd752fb9bccf6";
        }

        public static readonly NewBlueprint<BlueprintFeature> HistoryOfTerrorsTrait =
            new
            (
                guid: Guids.HistoryOfTerrorsTrait,
                name: nameof(Guids.HistoryOfTerrorsTrait)
            );
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class HistoryOfTerrors
    {
        private static void PatchHistoryOfTerrors()
        {
            Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(PatchHistoryOfTerrors)}");

            var historyOfTerrors = BlueprintData.HistoryOfTerrors;

            historyOfTerrors.GetBlueprint()
                .AddPrerequisiteNoFeature(BlueprintData.HistoryOfTerrorsTrait.GetBlueprint(), Functional.Ignore);
        }

        internal static void AddHistoryOfTerrorsTrait()
        {
            Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(AddHistoryOfTerrorsTrait)}");

            var original = BlueprintData.HistoryOfTerrors.GetBlueprint();

            var copy = original.Clone(BlueprintData.HistoryOfTerrorsTrait, feat =>
            {
                feat.SetDescription(strings: Localization.Default, text: $"{feat.Description} This racial trait replaces the skilled trait.");

                feat.Groups = new[] { FeatureGroup.Racial };

                feat.RemoveComponents(c => c is PrerequisiteFeature p && p.Feature == BlueprintData.HumanRace.GetBlueprint());

                feat.AddPrerequisiteFeature(BlueprintData.HumanSkilled.GetBlueprint(), Functional.Ignore, removeOnApply: true);
            });

            PatchHistoryOfTerrors();
        }
    }
}

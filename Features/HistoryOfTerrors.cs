using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;

using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class HistoryOfTerrors
    {
        private static void PatchHistoryOfTerrors()
        {
            Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(PatchHistoryOfTerrors)}");

            var historyOfTerrors = Blueprints.HistoryOfTerrorsFeat;

            historyOfTerrors.AddPrerequisiteNoFeature(Blueprints.HistoryOfTerrorsTrait, Functional.Ignore);
        }

        private const string name = "HistoryOfTerrorsTrait";

        internal static void AddHistoryOfTerrorsTrait()
        {
            Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(AddHistoryOfTerrorsTrait)}");

            var original = Blueprints.HistoryOfTerrorsFeat;

            var copy = original.CreateCopy(name, Guid.Parse(Guids.HistoryOfTerrorsTrait), feat =>
            {
                feat.SetDescription($"{feat.Description} This racial trait replaces the skilled trait.");

                feat.Groups = new[] { FeatureGroup.Racial };

                feat.RemoveComponents(c => c is PrerequisiteFeature p && p.Feature == Blueprints.HumanRace);

                feat.AddPrerequisiteFeature(Blueprints.HumanSkilled, Functional.Ignore, removeOnApply: true);
            });

            PatchHistoryOfTerrors();
        }
    }
}

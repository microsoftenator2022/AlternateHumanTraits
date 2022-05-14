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

            historyOfTerrors.GetBlueprint()
                .AddPrerequisiteNoFeature(Blueprints.HistoryOfTerrorsTrait.GetBlueprint(), Functional.Ignore);
        }

        internal static void AddHistoryOfTerrorsTrait()
        {
            Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(AddHistoryOfTerrorsTrait)}");

            var original = Blueprints.HistoryOfTerrorsFeat.GetBlueprint();

            var info = Blueprints.HistoryOfTerrorsTrait;

            var copy = original.CreateCopy(info.Name, info.Guid, feat =>
            {
                feat.SetDescription($"{feat.Description} This racial trait replaces the skilled trait.");

                feat.Groups = new[] { FeatureGroup.Racial };

                feat.RemoveComponents(c => c is PrerequisiteFeature p && p.Feature == Blueprints.HumanRace.GetBlueprint());

                feat.AddPrerequisiteFeature(Blueprints.HumanSkilled.GetBlueprint(), Functional.Ignore, removeOnApply: true);
            });

            PatchHistoryOfTerrors();
        }
    }
}

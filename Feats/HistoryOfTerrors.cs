using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Facts;

using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

using TabletopTweaks.Core.Utilities;

namespace AlternateHumanTraits.Feats
{
	internal static class HistoryOfTerrors
	{
		private static void PatchHistoryOfTerrors()
		{
			Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(PatchHistoryOfTerrors)}");

			var historyOfTerrors = Blueprints.HistoryOfTerrorsFeat;

			historyOfTerrors.AddPrerequisiteNoFeature(Blueprints.HistoryOfTerrorsTrait, Functional.Ignore);

			//historyOfTerrors.AddComponent(new PrerequisiteNoFeature()
			//{
			//	m_Feature = Blueprints.HistoryOfTerrorsTrait.ToReference<BlueprintFeatureReference>()
			//});
		}

		private const string name = "HistoryOfTerrorsTrait";

		internal static void AddHistoryOfTerrorsTrait()
		{
			Main.Log?.Debug($"{nameof(HistoryOfTerrors)}.{nameof(AddHistoryOfTerrorsTrait)}");

			var original = Blueprints.HistoryOfTerrorsFeat;
			
			var copy = original.CreateCopy(name, Guid.Parse(Guids.HistoryOfTerrorsTrait), feat =>
			{
				//feat.AssetGuid = new BlueprintGuid(Guid.Parse(Guids.HistoryOfTerrorsTrait));

				feat.SetDescription($"{feat.Description} This racial trait replaces the skilled trait.");

				feat.Groups = new[] { FeatureGroup.Racial };

				feat.RemoveComponents(c => c is PrerequisiteFeature p && p.Feature == Blueprints.HumanRace);

				feat.AddPrerequisiteFeature(Blueprints.HumanSkilled, Functional.Ignore, removeOnApply: true);
			});

			PatchHistoryOfTerrors();
		}
	}
}

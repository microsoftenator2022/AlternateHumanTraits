using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
	internal static class HumanFeatureSelection
	{
		private const string name = "HumanFeatSelection";
		private const string displayName = "Alternate Racial Traits";
		private const string description = "The following alternate traits are available";

		private const string noTraitsName = "NoAlternateHumanTraits";
		private const string noTraitsDisplayName = "None";
		private const string noTraitsDescription = "No alternate trait";

		internal static void AddBasicFeatSelectionDummy()
		{
			Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddBasicFeatSelectionDummy)}");

			Helpers.CreateBlueprint<BlueprintFeature>("BasicFeatSelectionDummy", Guid.Parse(Guids.BasicFeatSelectionDummy), feat =>
			{
				feat.IsClassFeature = true;

				feat.HideInUI = true;
				feat.HideInCharacterSheetAndLevelUp = true;

				feat.SetDisplayName(Blueprints.BasicFeatSelection.Name);
				feat.SetDescription(Blueprints.BasicFeatSelection.Description);
				feat.SetIcon(Blueprints.BasicFeatSelection.Icon);
			});
		}

		internal static void AddHumanFeatureSelection()
		{
			Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddHumanFeatureSelection)}");

			BlueprintFeature[] features = new[]
			{
				Blueprints.HumanBonusFeat,
				Blueprints.Awareness,
				Blueprints.UnstoppableMagic,

				Blueprints.HistoryOfTerrorsTrait,
				Blueprints.GiantAncestry,
			};

			var noAlternateTrait =
				Helpers.CreateBlueprint<BlueprintFeature>(noTraitsName, Guid.Parse(Guids.NoAdditionaHumanTraits), feat =>
			{
				feat.IsClassFeature = true;
				feat.HideInUI = true;
				feat.HideInCharacterSheetAndLevelUp = true;

				feat.SetDisplayName(noTraitsDisplayName);
				feat.SetDescription(noTraitsDescription);

				feat.Groups = new[] { FeatureGroup.Racial };
				
				feat.AddPrerequisiteNoFeature(Blueprints.BasicFeatSelectionDummy, prerequisite =>
				{
					prerequisite.HideInUI = true;
				});
			});

			

			var selection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(
				name, Guid.Parse(Guids.HumanFeatureSelection), selection =>
			{
				selection.IsClassFeature = true;

				selection.SetDisplayName(displayName);
				selection.SetDescription(description);

				selection.Groups = new[] { FeatureGroup.Racial };
				
				selection.Group = FeatureGroup.KitsuneHeritage;
			});

			Blueprints.HumanRace.SetFeatures(new BlueprintFeatureBaseReference[]
			{
				Blueprints.BasicFeatSelectionDummy.ToReference<BlueprintFeatureBaseReference>(),
				Blueprints.HumanSkilled.ToReference<BlueprintFeatureBaseReference>(),
				selection.ToReference<BlueprintFeatureBaseReference>(),
			});

			selection.AddFeature(noAlternateTrait);

			foreach(var f in features)
			{
				f.AddFeatureCallback(new AddAdditionalRacialFeatures()
				{
					Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() }
				});

				selection.AddFeature(f);
			}
		}
	}
}

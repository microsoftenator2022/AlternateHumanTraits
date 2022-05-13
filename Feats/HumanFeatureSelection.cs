using System;
using System.Collections.Generic;
using System.Linq;

using HarmonyLib;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UI.Common;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.FeatureSelector;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Feats
{
	internal static class HumanFeatureSelection
	{
		private const string name = "HumanFeatureSelection";
		private const string displayName = "Alternate Racial Traits";
		private const string description = "The following alternate traits are available";

		private const string noTraitsName = "NoAlternateHumanTraits";
		private const string noTraitsDisplayName = "None";
		private const string noTraitsDescription = "No alternate trait";

		private const string humanBonusFeatName = "HumanBonusFeat";
		private const string humanBonusFeatDisplayName = "Bonus Feat";

		internal static void AddHumanBonusFeat()
		{
			Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddHumanBonusFeat)}");

			var humanBonusFeat = Helpers.CreateBlueprint<BlueprintFeatureSelection>(humanBonusFeatName, Guid.Parse(Guids.HumanBonusFeat), bonusFeatSelection =>
			{
				bonusFeatSelection.IsClassFeature = true;
				bonusFeatSelection.SetDisplayName("Bonus Feat");

				bonusFeatSelection.Groups = Blueprints.BasicFeatSelection.Groups;
				bonusFeatSelection.Group = Blueprints.BasicFeatSelection.Group;

				bonusFeatSelection.SetFeatures(Blueprints.BasicFeatSelection.Features, Blueprints.BasicFeatSelection.AllFeatures);
			});
		}

		internal static void AddHumanFeatureSelection()
		{
			Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddHumanFeatureSelection)}");

			BlueprintFeature[] features = new[]
			{
				Blueprints.Awareness,
				Blueprints.HistoryOfTerrorsTrait,
				Blueprints.UnstoppableMagic,
			};

			var noAlternateTrait =
				Helpers.CreateBlueprint<BlueprintFeature>(noTraitsName, Guid.Parse(Guids.NoAdditionaHumanTraits), feat =>
			{
				//feat.AssetGuid = new BlueprintGuid(Guid.Parse(Guids.NoAdditionaHumanTraits));

				feat.IsClassFeature = true;
				feat.HideInUI = true;
				feat.HideInCharacterSheetAndLevelUp = true;

				feat.SetDisplayName(noTraitsDisplayName);
				feat.SetDescription(noTraitsDescription);

				feat.Groups = new[] { FeatureGroup.Racial };
			});

			var selection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(
				name, Guid.Parse(Guids.HumanFeatureSelection), selection =>
			{
				//selection.AssetGuid = new BlueprintGuid(Guid.Parse(Guids.HumanFeatureSelection));

				selection.IsClassFeature = true;

				selection.SetDisplayName(displayName);
				selection.SetDescription(description);

				selection.Groups = new[] { FeatureGroup.Racial };
				selection.Group = FeatureGroup.KitsuneHeritage;

			});

			Blueprints.HumanRace.SetFeatures(new[]
			{
				Blueprints.HumanBonusFeat.ToReference<BlueprintFeatureBaseReference>(),
				Blueprints.HumanSkilled.ToReference<BlueprintFeatureBaseReference>(),
				selection.ToReference<BlueprintFeatureBaseReference>()
			});

			selection.AddFeature(noAlternateTrait);

			foreach (var f in features)
			{
                f.AddSelectionCallback(selection);
				selection.AddFeature(f);
			}

			//var halfElfHeritageSelection = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>(BlueprintGuid.Parse("9df7b68d60544bcf8e5b56c0a4688e04"));
			//halfElfHeritageSelection.Features[1].AddSelectionCallback(halfElfHeritageSelection);
		}

		public static void AddSelectionCallback(this BlueprintFeature feature, BlueprintFeatureSelection selection)
		{
			feature.AddComponent(new AddAdditionalRacialFeatures()
			{
				Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() }
			});
		}
	}

	public class AddAdditionalRacialFeatures : UnitFactComponentDelegate
	{
		public BlueprintFeatureBaseReference[]? Features;

		protected override void OnActivate()
		{
			LevelUpController? controller = Kingmaker.Game.Instance?.LevelUpController;
			if (controller == null) { return; }
			if (controller.State.Mode == LevelUpState.CharBuildMode.Mythic) { return; }
			if (Owner.Descriptor.Progression.CharacterLevel > 1) { return; }
			LevelUpHelper.AddFeaturesFromProgression(controller.State, Owner, Features.Select(f => f.Get()).ToArray(), Owner.Progression.Race, 0);
		}

		[HarmonyPatch(
			typeof(CharGenFeatureSelectorPhaseVM),
			nameof(CharGenFeatureSelectorPhaseVM.OrderPriority),
			MethodType.Getter)]
		static class Background_OrderPriority_Patch
		{
			static void Postfix(ref int __result, CharGenFeatureSelectorPhaseVM __instance)
			{
				FeatureGroup featureGroup = UIUtilityUnit.GetFeatureGroup(__instance.FeatureSelectorStateVM?.Feature);
				if (featureGroup == FeatureGroup.BackgroundSelection) { __result += 500; }
			}
		}
	}
}

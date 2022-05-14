using AlternateHumanTraits.Features;

using HarmonyLib;

using Kingmaker.Blueprints.JsonSystem;

namespace AlternateHumanTraits.Patches
{
	[HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init))]
	internal class BlueprintsCache_Init_Patch
	{
		private static bool patched;

		static void Postfix()
		{
			if (patched) return;
			patched = true;

			Main.Log?.Debug($"{nameof(BlueprintsCache_Init_Patch)}.{nameof(Postfix)}");

			HumanFeatureSelection.AddBasicFeatSelectionDummy();

			HumanBonusFeat.AddHumanBonusFeat();
			Awareness.AddAwarenessFeature();
			UnstoppableMagic.AddUnstoppableMagic();

			HistoryOfTerrors.AddHistoryOfTerrorsTrait();
			GiantAncestry.AddGiantAncestry();

			HumanFeatureSelection.AddHumanFeatureSelection();
		}
	}
}

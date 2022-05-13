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

			Feats.HumanFeatureSelection.AddHumanBonusFeat();
			Feats.HistoryOfTerrors.AddHistoryOfTerrorsTrait();
			Feats.Awareness.AddAwarenessFeature();
			Feats.UnstoppableMagic.AddUnstoppableMagic();
			Feats.HumanFeatureSelection.AddHumanFeatureSelection();
		}
	}
}

using AlternateHumanTraits.Features;

using HarmonyLib;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UI.Common;
using Kingmaker.UI.MVVM._VM.CharGen.Phases.FeatureSelector;

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

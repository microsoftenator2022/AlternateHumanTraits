﻿using AlternateHumanTraits.Features;
using AlternateHumanTraits.Resources;

using HarmonyLib;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
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
            if (patched)
            {
                Main.Log?.Warning($"Duplicate call to {nameof(BlueprintsCache_Init_Patch)}.{nameof(Postfix)}");
                return;
            }
            patched = true;

            Main.Log?.Debug($"{nameof(BlueprintsCache_Init_Patch)}.{nameof(Postfix)}");

            HumanFeatureSelection.AddBasicFeatSelectionDummy();

            MissingWeaponProficiencies.AddMissingWeaponProficiencies();
            MilitaryTradition.AddMilitaryTradition();

            HumanBonusFeat.AddHumanBonusFeat();

            Awareness.AddAwarenessFeature();

            UnstoppableMagic.AddUnstoppableMagic();

            ComprehensiveEducation.AddComprehensiveEducation();

            HistoryOfTerrors.AddHistoryOfTerrorsTrait();

            GiantAncestry.AddGiantAncestry();

            DualTalent.AddDualTalent();

            WeaponFamiliarityMartialProficiencies.AddWeaponFamiliarityMartialProficiencies();
            AdoptiveParentageSelection.AddAdoptiveParentage();

            PracticedHunter.AddPracticedHunter();

            FocusedStudy.AddFocusedStudy();

            HumanFeatureSelection.AddHumanFeatureSelection();

            Localization.Default.LoadAll();

            LocalizationManager.CurrentPack.AddStrings(LocalizedStrings.GetLocalizationPack(LocalizationManager.CurrentLocale));
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

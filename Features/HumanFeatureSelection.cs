using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;

namespace AlternateHumanTraits.Features
{
    internal static class HumanFeatureSelection
    {
        internal static void AddBasicFeatSelectionDummy()
        {
            Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddBasicFeatSelectionDummy)}");

            Helpers.CreateBlueprint(Traits.BasicFeatSelectionDummy, feat =>
            {
                feat.IsClassFeature = true;

                var basicFeatSelection = Traits.BasicFeatSelection.GetBlueprint();

                feat.SetDisplayName(basicFeatSelection.Name);
                feat.SetDescription(basicFeatSelection.Description);
                feat.SetIcon(basicFeatSelection.Icon);
            });
        }

        internal static void AddHumanFeatureSelection()
        {
            Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddHumanFeatureSelection)}");

            var features = new List<BlueprintFeature>()
            {
                // For Pregen builds to work, HumanBonusFeat must be the first element, followed by noAlternateTraits
                Traits.HumanBonusFeat.GetBlueprint(),

                Traits.Awareness.GetBlueprint(),
                Traits.DualTalent.GetBlueprint(),
                Traits.GiantAncestry.GetBlueprint(),
                Traits.HistoryOfTerrorsTrait.GetBlueprint(),
                Traits.UnstoppableMagic.GetBlueprint(),
                Traits.MilitaryTradition.GetBlueprint(),
                Traits.MilitaryTraditionSecondSelection.GetBlueprint(),
            };

            var noAlternateTrait =
                Helpers.CreateBlueprint(Traits.NoAdditionalHumanTraits, feat =>
            {
                feat.IsClassFeature = true;
                feat.HideInUI = true;
                feat.HideInCharacterSheetAndLevelUp = true;

                feat.Groups = new[] { FeatureGroup.Racial };
                
                feat.AddPrerequisiteNoFeature(Traits.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                });
            });

            var selection = Helpers.CreateBlueprint(Traits.HumanFeatureSelection, selection =>
            {
                selection.IsClassFeature = true;

                selection.Groups = new[] { FeatureGroup.Racial };

                //selection.SetIcon(ResourcesLibrary.TryGetResource<Sprite>(Resources.Guids.HeritageSelectionIcon));
                
                selection.Group = FeatureGroup.KitsuneHeritage;
            });

            Traits.HumanRace.GetBlueprint().SetFeatures(new BlueprintFeatureBaseReference[]
            {
                Traits.BasicFeatSelectionDummy.GetBlueprint().ToReference<BlueprintFeatureBaseReference>(),
                Traits.HumanSkilled.GetBlueprint().ToReference<BlueprintFeatureBaseReference>(),
                selection.ToReference<BlueprintFeatureBaseReference>(),
            });

            foreach (var f in features)
            {
                f.AddFeatureCallback(new AddAdditionalRacialFeatures()
                {
                    Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() }
                });
            }

            features.Insert(1, noAlternateTrait);

            foreach (var f in features)
            {
                selection.AddFeature(f);
            }
        }
    }
}

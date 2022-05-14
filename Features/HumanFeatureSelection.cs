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
        internal static void AddBasicFeatSelectionDummy()
        {
            Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddBasicFeatSelectionDummy)}");

            Helpers.CreateBlueprint(Blueprints.BasicFeatSelectionDummy, feat =>
            {
                feat.IsClassFeature = true;

                var basicFeatSelection = Blueprints.BasicFeatSelection.GetBlueprint();

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
                Blueprints.HumanBonusFeat.GetBlueprint(),
                Blueprints.HistoryOfTerrorsTrait.GetBlueprint(),
                
                Blueprints.Awareness.GetBlueprint(),
                Blueprints.UnstoppableMagic.GetBlueprint(),
                Blueprints.GiantAncestry.GetBlueprint(),
                
                Blueprints.DualTalent.GetBlueprint(),
            };

            var noAlternateTrait =
                Helpers.CreateBlueprint(Blueprints.NoAdditionalHumanTraits, feat =>
            {
                feat.IsClassFeature = true;
                feat.HideInUI = true;
                feat.HideInCharacterSheetAndLevelUp = true;

                feat.Groups = new[] { FeatureGroup.Racial };
                
                feat.AddPrerequisiteNoFeature(Blueprints.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                });
            });


            var selection = Helpers.CreateBlueprint(Blueprints.HumanFeatureSelection, selection =>
            {
                selection.IsClassFeature = true;

                selection.Groups = new[] { FeatureGroup.Racial };
                
                selection.Group = FeatureGroup.KitsuneHeritage;
            });

            Blueprints.HumanRace.GetBlueprint().SetFeatures(new BlueprintFeatureBaseReference[]
            {
                Blueprints.BasicFeatSelectionDummy.GetBlueprint().ToReference<BlueprintFeatureBaseReference>(),
                Blueprints.HumanSkilled.GetBlueprint().ToReference<BlueprintFeatureBaseReference>(),
                selection.ToReference<BlueprintFeatureBaseReference>(),
            });

            foreach (var f in features)
            {
                f.AddFeatureCallback(new AddAdditionalRacialFeatures()
                {
                    Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() }
                });
            }

            // Hopefull this fixed pregen builds
            features.Insert(1, noAlternateTrait);

            foreach (var f in features)
            {
                selection.AddFeature(f);
            }
        }
    }
}

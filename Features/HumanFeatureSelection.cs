using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string BasicFeatSelectionDummy = "771f9b2efd8842c7af7f3d1887a0dd55";
            public const string HumanFeatureSelection = "837e8b4205284cbbaa1ae8227870be93";
            public const string NoAdditionaHumanTraits = "591db97195294968a081b7e5354bc090";
        }

        public static readonly NewBlueprint<BlueprintFeature> BasicFeatSelectionDummy =
            new(guidString: Guids.BasicFeatSelectionDummy, name: nameof(Guids.BasicFeatSelectionDummy));

        [LocalizedString]
        public static readonly string HumanFeatureSelectionDisplayName = "Alternate Racial Traits";
        [LocalizedString]
        public static readonly string HumanFeatureSelectionDescription = "The following alternate traits are available";

        public static readonly NewBlueprint<BlueprintFeatureSelection> HumanFeatureSelection = 
            new (guidString: Guids.HumanFeatureSelection, name: nameof(Guids.HumanFeatureSelection))
            {
                Init = selection =>
                {
                    selection.SetDisplayName(LocalizedStrings.HumanFeatureSelectionDisplayName);
                    selection.SetDescription(LocalizedStrings.HumanFeatureSelectionDescription);

                    selection.IsClassFeature = true;

                    selection.Groups = new[] { FeatureGroup.Racial };

                    selection.Group = FeatureGroup.KitsuneHeritage;
                }
            };

        [LocalizedString]
        public static readonly string NoAdditionalTraitsDisplayName = "None";
        [LocalizedString]
        public static readonly string NoAdditionalTraitsDescription = "No alternate trait";

        public static readonly NewBlueprint<BlueprintFeature> NoAdditionalHumanTraits =
            new (guidString: Guids.NoAdditionaHumanTraits, name: nameof(Guids.NoAdditionaHumanTraits))
            {
                Init = feat =>
                {
                    feat.SetDisplayName(LocalizedStrings.NoAdditionalTraitsDisplayName);
                    feat.SetDescription(LocalizedStrings.NoAdditionalTraitsDescription);

                    feat.IsClassFeature = true;
                    feat.HideInUI = true;
                    feat.HideInCharacterSheetAndLevelUp = true;

                    feat.Groups = new[] { FeatureGroup.Racial };
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class HumanFeatureSelection
    {
        internal static readonly List<BlueprintFeature> FeaturesToAdd = new();

        internal static void AddBasicFeatSelectionDummy()
        {
            Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddBasicFeatSelectionDummy)}");

            Helpers.Blueprint.CreateWith(BlueprintData.BasicFeatSelectionDummy)(feat =>
            {
                feat.IsClassFeature = true;

                var basicFeatSelection = BlueprintData.BasicFeatSelection.GetBlueprint();

                feat.SetDisplayName(basicFeatSelection.GetDisplayName());
                feat.SetDescription(basicFeatSelection.GetDescription());
                feat.SetIcon(basicFeatSelection.Icon);
            });
        }

        internal static void AddHumanFeatureSelection()
        {
            Main.Log?.Debug($"{nameof(HumanFeatureSelection)}.{nameof(AddHumanFeatureSelection)}");

            var noAlternateTrait = Helpers.Blueprint.CreateWith(BlueprintData.NoAdditionalHumanTraits)(feat =>
            {
                feat.AddPrerequisiteNoFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                });
            });

            var selection = Helpers.Blueprint.Create(BlueprintData.HumanFeatureSelection);
            selection.SetIcon(Icons.HeritageSelection);

            BlueprintData.HumanRace.GetBlueprint().SetFeatures(new BlueprintFeatureBaseReference[]
            {
                BlueprintData.BasicFeatSelectionDummy.GetBlueprint().ToReference<BlueprintFeatureBaseReference>(),
                BlueprintData.HumanSkilled.GetBlueprint().ToReference<BlueprintFeatureBaseReference>(),
                selection.ToReference<BlueprintFeatureBaseReference>(),
            });

            var features = new List<BlueprintFeature>()
            {
                // For Pregen builds to work, HumanBonusFeat must be the first element, followed by noAlternateTraits
                BlueprintData.HumanBonusFeat.GetBlueprint(),

                BlueprintData.AdoptiveParentageSelection.GetBlueprint(),
                BlueprintData.Awareness.GetBlueprint(),
                BlueprintData.ComprehensiveEducation.GetBlueprint(),
                BlueprintData.DualTalentSelection.GetBlueprint(),
                BlueprintData.GiantAncestry.GetBlueprint(),
                BlueprintData.HistoryOfTerrorsTrait.GetBlueprint(),
                BlueprintData.MilitaryTradition.GetBlueprint(),
                BlueprintData.MilitaryTraditionSecondSelection.GetBlueprint(),
                BlueprintData.UnstoppableMagic.GetBlueprint(),
                BlueprintData.PracticedHunter.GetBlueprint(),
                BlueprintData.FocusedStudyProgression.GetBlueprint(),
            };

            foreach (var f in features)
            {
                f.AddFeatureCallback(new Microsoftenator.Wotr.Common.AddAdditionalRacialFeatures()
                {
                    Features = new BlueprintFeatureBaseReference[] { selection.ToReference<BlueprintFeatureBaseReference>() }
                });
            }

            features.Insert(1, noAlternateTrait.ToReference<BlueprintFeatureReference>());

            foreach (var f in features)
            {
                selection.AddFeature(f);
            }
        }
    }
}

﻿using System;

using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Encyclopedia;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string Awareness = "edc1383bf9304cd7a45ee22dd3468fc8";
        }

        [LocalizedString]
        public static readonly string AwarenessDisplayName = "Awareness";

        [LocalizedString]
        public static readonly string AwarenessDescription =
            "Humans raised within monastic traditions or communities that encourage mindfulness seem to " +
            "shrug off many dangers more easily than other humans. They gain a +1 racial " +
            $"{new Link(Page.Bonus, "bonus")} on all " +
            $"{new Link(Page.Saving_Throw, "saving throws")} and " +
            $"{new Link(Page.Concentration, "concentration checks")}. This racial trait replaces " +
            "humans’ bonus feat.";

        public readonly static NewBlueprint<BlueprintFeature> Awareness =
            new (guidString: Guids.Awareness, name: nameof(Guids.Awareness))
            {
                Init = feat =>
                {
                    feat.SetDisplayName(LocalizedStrings.AwarenessDisplayName);
                    feat.SetDescription(LocalizedStrings.AwarenessDescription);

                    feat.SetIcon(Icons.Bravery);

                    feat.Groups = new[] { FeatureGroup.Racial };

                    feat.AddComponent(new BuffAllSavesBonus()
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Value = 1
                    });

                    feat.AddComponent(new ConcentrationBonus()
                    {
                        Value = 1
                    });
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class Awareness
    {
        internal static void AddAwarenessFeature()
        {
            Main.Log?.Debug($"{nameof(Awareness)}.{nameof(AddAwarenessFeature)}");

            var awareness = Helpers.Blueprint.Feature.CreateWith(BlueprintData.Awareness)(feat =>
            {
                feat.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

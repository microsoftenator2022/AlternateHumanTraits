using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string UnstoppableMagic = "051d05e970df4929a6d39d61adac1fc8";
        }

        public static readonly NewUnitFact<BlueprintFeature> UnstoppableMagic =
            new
            (
                guid: Guids.UnstoppableMagic,
                name: nameof(Guids.UnstoppableMagic),
                strings : Localization.Default,
                displayName: "Unstoppable Magic",
                description: "Humans from civilizations built upon advanced magic are educated in a variety of ways to accomplish their magical goals. They gain a +2 racial bonus on caster level checks against spell resistance. This racial trait replaces the bonus feat trait."
            )
            {
                Init = feat =>
                {
                    feat.IsClassFeature = true;

                    feat.Groups = new[] { FeatureGroup.Racial };

                    feat.AddComponent(new SpellPenetrationBonus() { Value = 2 });
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class UnstoppableMagic
    {
        internal static void AddUnstoppableMagic()
        {
            Main.Log?.Debug($"{nameof(UnstoppableMagic)}.{nameof(AddUnstoppableMagic)}");

            var unstoppableMagic = Helpers.CreateBlueprint<BlueprintFeature>(BlueprintData.UnstoppableMagic, feat =>
            {
                feat.SetIcon(Icons.ElvenMagic);
                feat.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
                {
                    prerequisite.HideInUI = true;
                }, removeOnApply: true);
            });
        }
    }
}

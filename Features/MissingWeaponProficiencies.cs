using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using BlueprintInfoSourceGenerator.Localization;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;

using UnityEngine;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string EarthBreakerProficiency = "cb96b756bec5433f8b427501959e4eb6";
            public const string BardicheProficiency = "8cbaabb4d3264f3493ecb13ac0373782";
        }

        [LocalizedString]
        public static readonly string EarthBreakerProficiencyDisplayName = "Weapon Proficiency (Earth Breaker)";
        [LocalizedString]
        public static readonly string EarthBreakerProficiencyDescription =
            "You become proficient with earth breakers and can use them as a weapon.";

        public static readonly NewBlueprint<BlueprintFeature> EarthBreakerProficiency =
            new (guidString : Guids.EarthBreakerProficiency, name: nameof(Guids.EarthBreakerProficiency))
            {
                Init = feature =>
                {
                    feature.SetDisplayName(LocalizedStrings.EarthBreakerProficiencyDisplayName);
                    feature.SetDescription(LocalizedStrings.EarthBreakerProficiencyDescription);

                    feature.IsClassFeature = true;

                    feature.SetIcon(Resources.Icons.WeaponProficiency);

                    feature.AddComponent(new AddProficiencies()
                    {
                        WeaponProficiencies = new[] { WeaponCategory.EarthBreaker }
                    });
                }
            };

        [LocalizedString]
        public static readonly string BardicheProficiencyDisplayName = "Weapon Proficiency (Bardiche)";
        [LocalizedString]
        public static readonly string BardicheProficiencyDeescription =
            "You become proficient with bardiches and can use them as a weapon.";

        public static readonly NewBlueprint<BlueprintFeature> BardicheProficiency =
            new (guidString: Guids.BardicheProficiency, name: nameof(Guids.BardicheProficiency))
            {
                Init = feature =>
                {
                    feature.SetDisplayName(LocalizedStrings.BardicheProficiencyDisplayName);
                    feature.SetDescription(LocalizedStrings.BardicheProficiencyDeescription);

                    feature.IsClassFeature = true;

                    feature.SetIcon(Resources.Icons.WeaponProficiency);

                    feature.AddComponent(new AddProficiencies()
                    {
                        WeaponProficiencies = new[] { WeaponCategory.Bardiche }
                    });
                }
            };

        public static readonly IEnumerable<NewBlueprint<BlueprintFeature>> NewWeaponProficiencies = new List<NewBlueprint<BlueprintFeature>>()
        {
            EarthBreakerProficiency,
            BardicheProficiency
        };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class MissingWeaponProficiencies
    {
        internal static void AddMissingWeaponProficiencies()
        {
            Main.Log?.Debug($"{nameof(MissingWeaponProficiencies)}.{nameof(AddMissingWeaponProficiencies)}");

            var earthBreakerProficiency = Helpers.Blueprint.Create(BlueprintData.EarthBreakerProficiency);

            var bardicheProficiency = Helpers.Blueprint.Create(BlueprintData.BardicheProficiency);
        }
    }
}

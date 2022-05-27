using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
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

        public static NewBlueprint<BlueprintFeature> EarthBreakerProficiency =
            new
            (
                guid : Guids.EarthBreakerProficiency,
                name: nameof(Guids.EarthBreakerProficiency),
                strings: Localization.Default,
                displayName: "Weapon Proficiency (Earth Breaker)",
                description: "You become proficient with earth breakers and can use them as a weapon."
            )
            {
                Init = feature =>
                {
                    feature.IsClassFeature = true;

                    feature.SetIcon(Resources.Icons.WeaponProficiency);

                    feature.AddComponent(new AddProficiencies()
                    {
                        WeaponProficiencies = new[] { WeaponCategory.EarthBreaker }
                    });
                }
            };

        public static NewBlueprint<BlueprintFeature> BardicheProficiency =
            new
            (
                guid: Guids.BardicheProficiency,
                name: nameof(Guids.BardicheProficiency),
                strings: Localization.Default,
                displayName: "Weapon Proficiency (Bardiche)",
                description: "You become proficient with bardiches and can use them as a weapon."
            )
            {
                Init = feature =>
                {
                    feature.IsClassFeature = true;

                    feature.SetIcon(Resources.Icons.WeaponProficiency);

                    feature.AddComponent(new AddProficiencies()
                    {
                        WeaponProficiencies = new[] { WeaponCategory.Bardiche }
                    });
                }
            };

        public static IEnumerable<NewBlueprint<BlueprintFeature>> NewWeaponProficiencies = new List<NewBlueprint<BlueprintFeature>>()
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

            var earthBreakerProficiency = Helpers.CreateBlueprint(BlueprintData.EarthBreakerProficiency);

            var bardicheProficiency = Helpers.CreateBlueprint(BlueprintData.BardicheProficiency);
        }
    }
}

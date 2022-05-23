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

namespace AlternateHumanTraits.Features
{
    internal static class MissingWeaponProficiencies
    {
        internal static void AddMissingWeaponProficiencies()
        {
            Main.Log?.Debug($"{nameof(MissingWeaponProficiencies)}.{nameof(AddMissingWeaponProficiencies)}");

            var wpebInfo =
                BlueprintData.WeaponProficiencies
                    .First(bp => bp.GuidString == BlueprintData.Guids.EarthBreakerProficiency);

            var earthBreakerProficiency = Helpers.CreateBlueprint(wpebInfo, init: feature =>
            {
                feature.IsClassFeature = true;

                feature.SetIcon(Resources.Icons.WeaponProficiency);

                feature.AddComponent(new AddProficiencies()
                {
                    WeaponProficiencies = new[] { WeaponCategory.EarthBreaker }
                });
            });

            var wpbInfo =
                BlueprintData.WeaponProficiencies
                    .First(bp => bp.GuidString == BlueprintData.Guids.BardicheProficiency);

            var bardicheProficiency = Helpers.CreateBlueprint(wpbInfo, feature =>
            {
                feature.IsClassFeature = true;

                feature.SetIcon(Resources.Icons.WeaponProficiency);

                feature.AddComponent(new AddProficiencies()
                {
                    WeaponProficiencies = new[] { WeaponCategory.Bardiche }
                });
            });
        }
    }
}

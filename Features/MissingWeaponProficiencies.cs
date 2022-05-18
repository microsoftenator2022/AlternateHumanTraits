using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;


namespace AlternateHumanTraits.Features
{
    internal static class MissingWeaponProficiencies
    {
        internal static void AddMissingWeaponProficiencies()
        {
            var wpebInfo =
                WeaponProficiencies.BlueprintData
                    .First(bp => bp.GuidString == WeaponProficiencies.Guids.EarthBreakerProficiency)
                    .Cast<BlueprintFeature>();

            var earthBreakerProficiency = Helpers.CreateBlueprint(wpebInfo, init: feature =>
            {
                feature.IsClassFeature = true;

                //var icon = ResourcesLibrary.TryGetResource<Sprite>("WeaponSpecialization");

                //feature.SetIcon((Sprite)icon);

                feature.AddComponent(new AddProficiencies()
                {
                    WeaponProficiencies = new[] { WeaponCategory.EarthBreaker }
                });
            });

            var wpbInfo =
                WeaponProficiencies.BlueprintData
                    .First(bp => bp.GuidString == WeaponProficiencies.Guids.BardicheProficiency)
                    .Cast<BlueprintFeature>();

            var bardicheProficiency = Helpers.CreateBlueprint(wpbInfo, feature =>
            {
                feature.IsClassFeature = true;

                //feature.SetIcon(ResourcesLibrary.TryGetResource<Sprite>(Resources.Guids.WeaponProficiencyIcon));

                feature.AddComponent(new AddProficiencies()
                {
                    WeaponProficiencies = new[] { WeaponCategory.Bardiche }
                });
            });


        }
    }
}

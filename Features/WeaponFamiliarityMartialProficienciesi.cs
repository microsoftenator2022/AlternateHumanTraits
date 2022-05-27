using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using HarmonyLib;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Extensions;

namespace AlternateHumanTraits.Features
{
    internal static class WeaponFamiliarityMartialProficiencies
    {
        internal static readonly IReadOnlyDictionary<Race, IEnumerable<BlueprintInfoAbstract<BlueprintFeature>>> weaponFamiliarities
            = new Dictionary<Race, IEnumerable<BlueprintInfoAbstract<BlueprintFeature>>>()
            {
                { Race.Elf, new[] { BlueprintData.ElvenWeaponFamiliarity } },
                { Race.HalfOrc, new[] { BlueprintData.OrcWeaponFamiliarity } },
                { Race.Dwarf, new[] { BlueprintData.DwarvenWeaponFamiliarity } },
            };

        internal static void AddWeaponFamiliarityMartialProficiencies()
        {
            var mwp = BlueprintData.MartialWeaponProficiency.GetBlueprint();

            foreach(var race in weaponFamiliarities.Keys)
            {
                var weaponCategories =
                    mwp.GetComponents<AddProficiencies>()
                       .Where(c => c.RaceRestriction is not null && c.RaceRestriction.RaceId == race)
                       .SelectMany(c => c.WeaponProficiencies);

                Action<UnitEntityData, BlueprintFeature> addProficiencies = (owner, wf) =>
                {
                    if (owner.HasFact(wf) && owner.HasFact(mwp))
                        foreach (var wc in weaponCategories)
                            owner.Proficiencies.Add(wc);
                };

                Action<UnitEntityData, BlueprintFeature> removeProficiencies = (owner, feature) =>
                {
                    if (owner.HasFact(feature))
                        foreach (var wc in weaponCategories)
                            owner.Proficiencies.Remove(wc);
                };

                foreach (var wf in weaponFamiliarities[race])
                {
                    mwp.AddComponent(new Events.UnitFact.TurnOn()
                    {
                        Callback = cb => addProficiencies(cb.GetOwner(), wf.GetBlueprintRef())
                    });

                    mwp.AddComponent(new Events.UnitFact.TurnOff()
                    {
                        Callback = cb => removeProficiencies(cb.GetOwner(), wf.GetBlueprintRef())
                    });

                    wf.GetBlueprintRef().Get().AddComponent(new Events.UnitFact.Activate()
                    {
                        Callback = cb => addProficiencies(cb.GetOwner(), wf.GetBlueprintRef())
                    });

                    wf.GetBlueprintRef().Get().AddComponent(new Events.UnitFact.Deactivate()
                    {
                        Callback = cb => removeProficiencies(cb.GetOwner(), mwp)
                    });
                }
            }
        }

        //[HarmonyPatch(
        //    typeof(AddProficiencies),
        //    methodName: (nameof(AddProficiencies.RaceRestriction)),
        //    methodType: MethodType.Getter)]
        //static class AddProficiency_get_RaceRestriction_Patch
        //{
        //    static BlueprintRace? Postfix(BlueprintRace raceRestriction, AddProficiencies __instance)
        //    {
        //        // If this unit has the same familiarity feat as the race restriction,
        //        // behaviour should be as if there's no race restriction
        //        if (raceRestriction is not null && weaponFamiliarities.ContainsKey(raceRestriction.RaceId))
        //        {
        //            if (weaponFamiliarities[raceRestriction.RaceId]
        //                .Any(wf => __instance.GetOwner().HasFact(wf.GetBlueprint())))
        //            {
        //                return __instance.GetOwner().Progression.Race;
        //            }
        //        }

        //        return raceRestriction;
        //    }
        //}
    }
}

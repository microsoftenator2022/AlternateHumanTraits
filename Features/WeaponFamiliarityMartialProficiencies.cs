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
using Microsoftenator.Wotr.Common.Encyclopedia;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string GnomishWeaponFamiliarity = "36e7997fcb494722aa5eee06caf86801";
            public const string HalflingWeaponFamiliarity = "dfcc0aa98c3d4826a7e60911cf588b45";
        }

        public static readonly NewUnitFact<BlueprintFeature> GnomishWeaponFamiliarity =
            new
            (
                guid: Guids.GnomishWeaponFamiliarity,
                name: nameof(Guids.GnomishWeaponFamiliarity),
                strings: Localization.Default,
                displayName: "Gnomish Weapon Familiarity",
                description: 
                    "Gnomes treat any weapon with the word \"Gnome\" in its name as a " +
                    $"{new Link(Page.Weapon_Proficiency, "martial weapon")}."
            )
            {
                Init = feat =>
                {
                    feat.SetIcon(Icons.GnomeHookedHammerHead);
                }
            };

        public static readonly NewUnitFact<BlueprintFeature> HalflingWeaponFamiliarity =
            new
            (
                guid: Guids.HalflingWeaponFamiliarity,
                name: nameof(Guids.HalflingWeaponFamiliarity),
                strings: Localization.Default,
                displayName: "Halfling Weapon Proficiency",
                description:
                    "Halflings treat sling staffs and any weapon with the word \"Halfling\" in its name as a " +
                    $"{new Link(Page.Weapon_Proficiency, "martial weapon")}."
            )
            {
                Init = feat =>
                {
                    feat.SetIcon(Icons.SlingStaff);
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class WeaponFamiliarityMartialProficiencies
    {
        internal static readonly IReadOnlyDictionary<Race, IEnumerable<BlueprintInfo<BlueprintFeature>>> weaponFamiliarities
            = new Dictionary<Race, IEnumerable<BlueprintInfo<BlueprintFeature>>>()
            {
                { Race.Elf, new[] { BlueprintData.ElvenWeaponFamiliarity } },
                { Race.HalfOrc, new[] { BlueprintData.OrcWeaponFamiliarity } },
                { Race.Dwarf, new[] { BlueprintData.DwarvenWeaponFamiliarity } },
                { Race.Gnome, new[] { BlueprintData.GnomishWeaponFamiliarity } },
                { Race.Halfling, new[] { BlueprintData.HalflingWeaponFamiliarity } },
            };

        internal static void AddGnomishWeaponFamiliarity()
        {
            var gwf = Helpers.CreateBlueprint(BlueprintData.GnomishWeaponFamiliarity, feature =>
            {
                
            });

            // BlueprintData.GnomeRace.GetBlueprint().AddFeature(gwf);
        }

        internal static void AddHalflingWeaponFamiliarity()
        {
            var hwf = Helpers.CreateBlueprint(BlueprintData.HalflingWeaponFamiliarity, feature =>
            {

            });

            // BlueprintData.HalflingRace.GetBlueprint().AddFeature(hwf);
        }

        internal static void AddWeaponFamiliarityMartialProficiencies()
        {
            AddGnomishWeaponFamiliarity();
            AddHalflingWeaponFamiliarity();

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
                        Callback = cb => addProficiencies(cb.GetOwner(), wf.GetBlueprint())
                    });

                    mwp.AddComponent(new Events.UnitFact.TurnOff()
                    {
                        Callback = cb => removeProficiencies(cb.GetOwner(), wf.GetBlueprint())
                    });

                    wf.GetBlueprint().AddComponent(new Events.UnitFact.Activate()
                    {
                        Callback = cb => addProficiencies(cb.GetOwner(), wf.GetBlueprint())
                    });

                    wf.GetBlueprint().AddComponent(new Events.UnitFact.Deactivate()
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

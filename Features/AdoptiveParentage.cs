using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources;
using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Encyclopedia;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string AdoptiveParentageSelection = "dcdb71d16c624423a33b0129bfd46ef3";
            public const string AdoptiveParentageElf = "63fc06a0236f43e0babceaffc98511eb";
            public const string AdoptiveParentageOrc = "91aacae6527c4d8fa436dea9ed34260a";
            public const string AdoptiveParentageDwarf = "dce0abdfef85490699b51ef9514d0f56";
            public const string AdoptiveParentageGnome = "1c8f130e8c76496d80a0966f22e04d36";
            public const string AdoptiveParentageHalfling = "b0f8d1e049b04ae9a8e6d9d202ca776f";
            public const string AdoptiveParentageAasimar = "61ff76cd605c476f9c2476b58cab2054";
            public const string AdoptiveParentageTiefling = "c6c59659d8254c40bbf30f65180ef5a6";
            public const string AdoptiveParentageOread = "df4121690d6a4e02bc7694141cc3ff9d";
            public const string AdoptiveParentageKitsune = "a619783385d242e9ac96248e27c9f0c3";
            public const string AdoptiveParentageDhampir = "d6d22c99ebb64a47bcba3f0292cee70b";
        }

        public static readonly NewUnitFact<BlueprintFeatureSelection> AdoptiveParentageSelection =
                new
                (
                    guidString: Guids.AdoptiveParentageSelection,
                    name: nameof(Guids.AdoptiveParentageSelection),
                    strings: Localization.Default,
                    displayName: "Adoptive Parentage",
                    description:
                        "Humans are sometimes orphaned and adopted by other races. Choose one humanoid " +
                        $"{new Link(Page.Race, "race")} without the human subtype. You gain that race’s " +
                        "weapon familiarity racial trait. If the race does not have weapon familiarity, you gain " +
                        $"either Skill Focus or Weapon Focus as a bonus {new Link(Page.Feat, "feat")} that " +
                        "is appropriate for that race instead. This racial trait replaces the bonus feat trait."
                )
                {
                    Init = selection =>
                    {
                        selection.Groups = new[] { FeatureGroup.Racial };
                    }
                };

        public static class AdoptiveParentage
        {
            public static IReadOnlyDictionary<Race, NewUnitFact<BlueprintFeatureSelection>> Selections
                = new Dictionary<Race, NewUnitFact<BlueprintFeatureSelection>>()
                {
                    { Race.Elf, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageElf, nameof(Guids.AdoptiveParentageElf)) },
                    { Race.HalfOrc, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageOrc, nameof(Guids.AdoptiveParentageOrc)) },
                    { Race.Dwarf, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageDwarf, nameof(Guids.AdoptiveParentageDwarf)) },
                    { Race.Gnome, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageGnome, nameof(Guids.AdoptiveParentageGnome)) },
                    { Race.Halfling, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageHalfling, nameof(Guids.AdoptiveParentageHalfling)) },
                    { Race.Aasimar, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageAasimar, nameof(Guids.AdoptiveParentageAasimar)) },
                    { Race.Tiefling, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageTiefling, nameof(Guids.AdoptiveParentageTiefling)) },
                    { Race.Oread, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageOread, nameof(Guids.AdoptiveParentageOread)) },
                    { Race.Kitsune, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageKitsune, nameof(Guids.AdoptiveParentageKitsune)) },
                    { Race.Dhampir, new NewUnitFact<BlueprintFeatureSelection>(Guids.AdoptiveParentageDhampir, nameof(Guids.AdoptiveParentageDhampir)) },
                };
        }
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class AdoptiveParentageSelection
    {
        internal static readonly IReadOnlyDictionary<Race, IEnumerable<BlueprintInfo<BlueprintFeature>>> parentageBonusFeatures
            = new Dictionary<Race, IEnumerable<BlueprintInfo<BlueprintFeature>>>()
            {
                { Race.Elf, new[] { BlueprintData.ElvenWeaponFamiliarity } },
                { Race.HalfOrc, new[] { BlueprintData.OrcWeaponFamiliarity } },
                { Race.Dwarf, new[] { BlueprintData.DwarvenWeaponFamiliarity } },
                { Race.Gnome, new[] { BlueprintData.GnomishWeaponFamiliarity } },
                { Race.Halfling, new[] { BlueprintData.HalflingWeaponFamiliarity } },
                { Race.Aasimar, new[] { BlueprintData.SkillFocusDiplomacy, BlueprintData.SkillFocusPerception } },
                { Race.Tiefling, new[] { BlueprintData.SkillFocusDiplomacy, BlueprintData.SkillFocusStealth } },
                { Race.Oread, new[] { BlueprintData.WeaponFocusLongbow, BlueprintData.SkillFocusDiplomacy } },
                { Race.Kitsune, new[] { BlueprintData.WeaponFocusBite, BlueprintData.SkillFocusAcrobatics } },
                { Race.Dhampir, new[]{ BlueprintData.SkillFocusDiplomacy, BlueprintData.SkillFocusPerception } },
            };

        private static BlueprintFeatureSelection CreateParentage(Race race, string displayName, string description)
        {
            var parentageFeature = Helpers.Blueprint.CreateWith(BlueprintData.AdoptiveParentage.Selections[race])(selection =>
            {
                Main.Log?.Debug($"{nameof(AdoptiveParentageSelection)}.{nameof(CreateParentage)}");

                selection.IsClassFeature = true;

                selection.SetDisplayName(Localization.Default, displayName);
                selection.SetDescription(Localization.Default, description);

                foreach (var f in parentageBonusFeatures[race])
                {
                    selection.AddFeature(f.GetBlueprint(), ignorePrerequisites: true);
                }

                selection.SetIcon(selection.Features.First().Icon);
            });

            return parentageFeature;
        }

        public static void AddAdoptiveParentage()
        {
            Main.Log?.Debug($"{nameof(AdoptiveParentageSelection)}.{nameof(AddAdoptiveParentage)}");

            //var parentageSelections = new []
            //{
            //    CreateParentage(Race.Elf),
            //    CreateParentage(Race.HalfOrc),
            //    CreateParentage(Race.Dwarf),
            //    CreateParentage(Race.Gnome),
            //    CreateParentage(Race.Halfling),
            //    CreateParentage(Race.Aasimar),
            //    CreateParentage(Race.Tiefling),
            //    CreateParentage(Race.Oread),
            //    CreateParentage(Race.Kitsune),
            //    CreateParentage(Race.Dhampir),
            //};

            var selection = Helpers.Blueprint.CreateWith(BlueprintData.AdoptiveParentageSelection)(selection =>
            {
                foreach(var r in parentageBonusFeatures.Keys)
                {
                    var raceName = r switch
                    {
                        Race.HalfOrc => "Orc",
                        _ => Enum.GetName(typeof(Race), r)
                    };

                    var feat = CreateParentage(r,
                        $"{selection.Name} - {raceName}",
                        selection.Description);

                    selection.AddFeature(feat);
                }
            });

            selection.AddPrerequisiteFeature(BlueprintData.BasicFeatSelectionDummy.GetBlueprint(), prerequisite =>
            {
                prerequisite.HideInUI = true;
            }, removeOnApply: true);
        }
    }
}

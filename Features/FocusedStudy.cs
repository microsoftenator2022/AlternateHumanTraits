using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

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
            public const string FocusedStudyProgression = "0073c8a521284e299d256f21833d3205";
        }

        public static readonly NewUnitFact<BlueprintProgression> FocusedStudyProgression =
            new
            (
                guidString: Guids.FocusedStudyProgression,
                name: nameof(Guids.FocusedStudyProgression),
                strings: Localization.Default,
                displayName: "Focused Study",
                description:
                    "All humans are skillful, but some, rather than being generalists, tend to specialize in a " +
                    $"handful of {new Link(Page.Skills, "skills")}. At 1st, 8th, and 16th level, such humans " +
                    "gain Skill Focus in a skill of their choice as a bonus feat. This racial trait replaces the " +
                    "bonus feat trait."

            )
            {
                Init = prog =>
                {
                    prog.SetIcon(Icons.SkillFocusSelection);
                    prog.Groups = new[] { FeatureGroup.Racial };
                }
            };
    }
}

namespace AlternateHumanTraits.Features
{
    internal static class FocusedStudy
    {
        internal static void AddFocusedStudy()
        {
            var focusedStudyProgression = Helpers.Blueprint.CreateWith(BlueprintData.FocusedStudyProgression)(prog =>
            {
                var levelEntries = new[]
                {
                    new LevelEntry() { Level = 1 }, 
                    new LevelEntry() { Level = 8 },
                    new LevelEntry() { Level = 16 }
                };

                foreach(var entry in levelEntries)
                {
                    entry.SetFeatures(Functional.Enumerable.Singleton(BlueprintData.SkillFocusSelection.GetBlueprint()));
                }

                prog.LevelEntries = levelEntries;

                //prog.ForAllOtherClasses = true;

                prog.AddPrerequisiteFeature(
                    prerequisiteFeature: BlueprintData.BasicFeatSelectionDummy.GetBlueprint(),
                    removeOnApply: true, init: prerequisite =>
                    {
                        prerequisite.HideInUI = true;
                    });
            });
        }
    }
}

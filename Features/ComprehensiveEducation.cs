using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string ComprehensiveEducation = "07bc62abb0d94662968ce5374c1325ef";
        }

        public static readonly NewUnitFact<BlueprintFeature> ComprehensiveEducation =
            new(guid: Guids.ComprehensiveEducation,
                name: nameof(Guids.ComprehensiveEducation),
                strings : Localization.Default,
                displayName: "Comprehensive Eduction",
                description: "Humans raised with skilled teachers draw upon vast swathes of knowledge gained over centuries of civilization. They gain all Knowledge skills as class skills, and they gain a +1 racial bonus on skill checks for each Knowledge skill that they gain as a class skill from their class levels. This racial trait replaces skilled.");
    }
}

namespace AlternateHumanTraits.Features
{
    
    internal static class ComprehensiveEducation
    {
        internal static void AddComprehensiveEducation()
        {
            var feature = Helpers.CreateBlueprint(BlueprintData.ComprehensiveEducation, feat =>
            {
                feat.IsClassFeature = true;

                feat.AddComponent(new AddBackgroundClassSkill()
                {
                    Skill = StatType.SkillKnowledgeArcana
                });
                feat.AddComponent(new AddBackgroundClassSkill()
                {
                    Skill = StatType.SkillKnowledgeWorld
                });
                feat.AddComponent(new AddBackgroundClassSkill()
                {
                    Skill = StatType.SkillLoreNature
                });
                feat.AddComponent(new AddBackgroundClassSkill()
                {
                    Skill = StatType.SkillLoreReligion
                });
                
                feat.AddPrerequisiteFeature(
                    BlueprintData.HumanSkilled.GetBlueprint(),
                    Functional.Ignore,
                    removeOnApply: true);
            });
        }
    }
}

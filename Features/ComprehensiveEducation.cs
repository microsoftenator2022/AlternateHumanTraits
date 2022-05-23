using System;
using System.Collections.Generic;
using System.Linq;

using AlternateHumanTraits.Resources.Blueprints;

using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
    internal static class ComprehensiveEducation
    {
        internal static void AddComprehensiveEducation()
        {
            var feature = Helpers.CreateBlueprint(FeatureBlueprints.ComprehensiveEducation, feat =>
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

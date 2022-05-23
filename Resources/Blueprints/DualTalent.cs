using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids 
        {
            public const string DualTalent = "05efd0a9ec2f4cd5841d1b30d5adf312";
            public const string DualTalentStrength = "ca578029d10a491ead3d5d7568d36ba6";
            public const string DualTalentDexterity = "c175ca538fcc4d86b1ba568207a22b9d";
            public const string DualTalentConstitution = "0d293f67cd92486db7b1133ce89444a8";
            public const string DualTalentIntelligence = "84ec13278fca472e8e5816799b1c0ebd";
            public const string DualTalentWisdom = "95ae6cff05604228ba7da7d5008565d5";
            public const string DualTalentCharisma = "15df2403926d47d5bd6b78d56c46e270";
        }

        public static readonly BlueprintInfo<BlueprintFeatureSelection> DualTalentSelection =
            new(guid: Guids.DualTalent,
                name: nameof(Guids.DualTalent),
                displayName: "Dual Talent",
                description: "Some humans are uniquely skilled at maximizing their natural gifts. These humans pick two ability scores and gain a +2 racial bonus in each of those scores. This racial trait replaces the +2 bonus to any one ability score, the bonus feat, and the skilled traits.");

        public static readonly IEnumerable<BlueprintInfo<BlueprintFeature>> DualTalentFeatures
            = new List<BlueprintInfo<BlueprintFeature>>()
            {
                new(guid: Guids.DualTalentStrength, name: nameof(Guids.DualTalentStrength), displayName: null, description: null),
                new(guid: Guids.DualTalentDexterity, name: nameof(Guids.DualTalentDexterity), displayName: null, description: null),
                new(guid: Guids.DualTalentConstitution, name: nameof(Guids.DualTalentConstitution), displayName: null, description: null),
                new(guid: Guids.DualTalentIntelligence, name: nameof(Guids.DualTalentIntelligence), displayName: null, description: null),
                new(guid: Guids.DualTalentWisdom, name: nameof(Guids.DualTalentWisdom), displayName: null, description: null),
                new(guid: Guids.DualTalentCharisma, name: nameof(Guids.DualTalentCharisma), displayName: null, description: null),
            };
        
    }
}

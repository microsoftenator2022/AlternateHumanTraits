using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

using Microsoftenator.Wotr.Common.Blueprints;

namespace AlternateHumanTraits.Resources.Blueprints
{
    public static partial class BlueprintData
    {
        public static partial class Guids
        {
            public const string HumanRace = "0a5d473ead98b0646b94495af250fdc4";
            public const string BasicFeatSelection = "247a4068296e8be42890143f451b4b45";
            public const string HumanSkilled = "3adf9274a210b164cb68f472dc1e4544";
            public const string HistoryOfTerrors = "9e4c7d08f67f4496ba42c2cdb00609a7";

            // New blueprints
            public const string BasicFeatSelectionDummy = "771f9b2efd8842c7af7f3d1887a0dd55";
            public const string HumanBonusFeat = "8a4a6f5ebe0c416a8fdb7dd98a9ab1b4";
            public const string HumanFeatureSelection = "837e8b4205284cbbaa1ae8227870be93";
            public const string NoAdditionaHumanTraits = "591db97195294968a081b7e5354bc090";
        }

        public static readonly BlueprintInfo<BlueprintRace> HumanRace =
            new(guid: Guids.HumanRace, name: nameof(Guids.HumanRace), displayName: null, description: null);

        public static readonly BlueprintInfo<BlueprintFeatureSelection> BasicFeatSelection =
            new(guid: Guids.BasicFeatSelection, name: nameof(Guids.BasicFeatSelection), displayName: null, description: null);

        public static readonly BlueprintInfo<BlueprintFeature> HumanSkilled =
            new(guid: Guids.HumanSkilled, name: nameof(Guids.HumanSkilled), displayName: null, description: null);

        public static readonly BlueprintInfo<BlueprintFeature> HistoryOfTerrors =
            new(guid: Guids.HistoryOfTerrors, name: nameof(Guids.HistoryOfTerrors), displayName: null, description: null);

        public static readonly BlueprintInfo<BlueprintFeature> BasicFeatSelectionDummy =
            new(guid: Guids.BasicFeatSelectionDummy, name: nameof(Guids.BasicFeatSelectionDummy), displayName: null, description: null);

        public static readonly BlueprintInfo<BlueprintFeatureSelection> HumanBonusFeat = new
        (
            guid: Guids.HumanBonusFeat,
            name: nameof(Guids.HumanBonusFeat),
            displayName: "Bonus Feat",
            description: "Humans gain an extra feat at first level"
        );

        public static readonly BlueprintInfo<BlueprintFeatureSelection> HumanFeatureSelection = new
        (
            guid: Guids.HumanFeatureSelection,
            name: nameof(Guids.HumanFeatureSelection),
            displayName: "Alternate Racial Traits",
            description: "The following alternate traits are available"
        );

        public static readonly BlueprintInfo<BlueprintFeature> NoAdditionalHumanTraits = new
        (
            guid: Guids.NoAdditionaHumanTraits,
            name: nameof(Guids.NoAdditionaHumanTraits),
            displayName: "None",
            description: "No alternate trait"
        );
    }
}

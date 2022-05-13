using System;
using System.Collections.Generic;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace AlternateHumanTraits
{ 
	internal class BlueprintInfo<T> where T : BlueprintScriptableObject
	{
		private readonly string GuidString;
		public Guid Guid => Guid.Parse(GuidString);
		public readonly string Name;
		public readonly string? DisplayName;
		public readonly string? Description;

		public BlueprintInfo(string guid, string name, string? displayName = null, string? description = null)
		{
			GuidString = guid;
			Name = name;
			DisplayName = displayName;
			Description = description;
		}

		public T? GetBlueprint() => ResourcesLibrary.TryGetBlueprint<T>(GuidString);
	}

	internal static class Blueprints
	{
		private static TBlueprint GetBlueprint<TBlueprint>(string guid) where TBlueprint : BlueprintScriptableObject
			=> ResourcesLibrary.TryGetBlueprint<TBlueprint>(guid);

		public static BlueprintRace HumanRace
			=> GetBlueprint<BlueprintRace>(Guids.HumanRace);
		public static BlueprintFeature HumanSkilled
			=> GetBlueprint<BlueprintFeature>(Guids.HumanSkilled);
		public static BlueprintFeatureSelection BasicFeatSelection
			=> GetBlueprint<BlueprintFeatureSelection>(Guids.BasicFeatSelection);
		public static BlueprintFeature HistoryOfTerrorsFeat
			=> GetBlueprint<BlueprintFeature>(Guids.HistoryOfTerrorsFeat);

		public static BlueprintFeature Awareness
			=> GetBlueprint<BlueprintFeature>(Guids.Awareness);
		public static BlueprintFeature HistoryOfTerrorsTrait
			=> GetBlueprint<BlueprintFeature>(Guids.HistoryOfTerrorsTrait);
		public static BlueprintFeature UnstoppableMagic
			=> GetBlueprint<BlueprintFeature>(Guids.UnstoppableMagic);
		public static BlueprintFeatureSelection HumanBonusFeat
			=> GetBlueprint<BlueprintFeatureSelection>(Guids.HumanBonusFeat);
	}
}
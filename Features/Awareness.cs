using System;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
	internal static class Awareness
	{
		private const string name = "Awareness";
		private const string displayName = "Awareness";
		private const string description = "Humans raised within monastic traditions or communities that encourage mindfulness seem to shrug off many dangers more easily than other humans. They gain a +1 racial bonus on all saving throws and concentration checks. This racial trait replaces humans’ bonus feat.";

		internal static void AddAwarenessFeature()
		{
			Main.Log?.Debug($"{nameof(Awareness)}.{nameof(AddAwarenessFeature)}");

			Guid guid = Guid.Parse(Guids.Awareness);
			Main.Log?.Debug($"{guid}");

			var awareness = Helpers.CreateBlueprint<BlueprintFeature>(name, Guid.Parse(Guids.Awareness), feat =>
			{
				feat.IsClassFeature = true;

				feat.SetDisplayName(displayName);
				feat.SetDescription(description);

				feat.Groups = new[] { FeatureGroup.Racial };

				feat.AddComponent(new BuffAllSavesBonus()
				{
					Descriptor = ModifierDescriptor.Racial,
					Value = 1
				});

				feat.AddComponent(new ConcentrationBonus()
				{
					Value = 1
				});

				feat.AddPrerequisiteFeature(Blueprints.BasicFeatSelectionDummy, prerequisite =>
				{
					prerequisite.HideInUI = true;
				}, removeOnApply: true);
<<<<<<< HEAD
=======

				//feat.AddFeatureCallback(new FeatureNeedsUpdate());
>>>>>>> 39ff1f0fc89ffd4726196207e32a90bcb96309cb
			});
		}
	}
}

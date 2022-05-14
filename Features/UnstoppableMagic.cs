using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;

using Microsoftenator.Wotr.Common;
using Microsoftenator.Wotr.Common.Blueprints;
using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace AlternateHumanTraits.Features
{
	internal static class UnstoppableMagic
	{
		private const string name = "UnstoppableMagic";
		private const string displayName = "Unstoppable Magic";
		private const string description = "Humans from civilizations built upon advanced magic are educated in a variety of ways to accomplish their magical goals. They gain a +2 racial bonus on caster level checks against spell resistance. This racial trait replaces the bonus feat trait.";

		internal static void AddUnstoppableMagic()
		{
			Main.Log?.Debug($"{nameof(UnstoppableMagic)}.{nameof(AddUnstoppableMagic)}");

			var guid = Guid.Parse(Guids.UnstoppableMagic);
			Main.Log?.Debug($"{guid}");

			var unstoppableMagic = Helpers.CreateBlueprint<BlueprintFeature>(name, guid, feat =>
			{
				feat.IsClassFeature = true;

				feat.SetDisplayName(displayName);
				feat.SetDescription(description);

				feat.Groups = new[] { FeatureGroup.Racial };

				feat.AddComponent(new SpellPenetrationBonus() { Value = 2 });

				feat.AddPrerequisiteFeature(Blueprints.BasicFeatSelectionDummy, prerequisite =>
				{
					prerequisite.HideInUI = true;
				}, removeOnApply: true);
			});
		}
	}
}

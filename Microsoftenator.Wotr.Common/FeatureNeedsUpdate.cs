using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;

namespace Microsoftenator.Wotr.Common
{
    //public class FeatureNeedsUpdate : UnitFactComponentDelegate
    //{
    //	public virtual bool NeedsUpdate { get; protected set; }

    //	public FeatureNeedsUpdate(bool needsUpdate = true)
    //	{
    //		NeedsUpdate = needsUpdate;
    //	}

    //	[HarmonyPatch(typeof(SelectFeature), nameof(SelectFeature.NeedUpdateUnitView), MethodType.Getter)]
    //	class SelectFeature_NeedUpdateUnitView_Patch
    //	{
    //		static bool Postfix(SelectFeature __instance, bool __result)
    //		{
    //			if (!__result)
    //				return __instance.m_ItemFeature.ComponentsArray.Any(c => c is FeatureNeedsUpdate a && a.NeedsUpdate);
    //			return __result;
    //		}
    //	}
    //}
}

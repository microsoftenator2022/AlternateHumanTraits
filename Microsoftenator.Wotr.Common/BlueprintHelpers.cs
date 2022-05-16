using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Components;

using Microsoftenator.Wotr.Common.Blueprints.Extensions;
using Microsoftenator.Wotr.Common.Localization;
using Microsoftenator.Wotr.Common.Util;

namespace Microsoftenator.Wotr.Common.Blueprints
{
    public static class Helpers
    {
        public static TBlueprint CreateBlueprint<TBlueprint>(string name, Guid guid, Action<TBlueprint> init)
            where TBlueprint : BlueprintScriptableObject, new()
        {
            var assetId = new BlueprintGuid(guid);

            if(ResourcesLibrary.TryGetBlueprint<TBlueprint>(assetId) is not null) throw new ArgumentException();

            TBlueprint bp = new()
            {
                AssetGuid = assetId,
                name = name
            };

            init(bp);

            ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(assetId, bp);

            return bp;
        }

        public static TBlueprint CreateBlueprint<TBlueprint>(string name, Guid guid)
            where TBlueprint : BlueprintScriptableObject, new()
            => CreateBlueprint<TBlueprint>(name, guid, Functional.Ignore);

        public static TBlueprint CreateBlueprint<TBlueprint>(BlueprintInfo<TBlueprint> bpInfo, Action<TBlueprint> init)
            where TBlueprint : BlueprintFeature, new()
        {
            return CreateBlueprint<TBlueprint>(bpInfo.Name, bpInfo.Guid, bp =>
            {
                if(bpInfo.DisplayName is not null)
                    bp.SetDisplayName(bpInfo.DisplayName);

                if(bpInfo.Description is not null)
                    bp.SetDescription(bpInfo.Description);

                init(bp);
            });
        }
    }
}

namespace Microsoftenator.Wotr.Common.Blueprints.Extensions
{
    public static class BlueprintExtensions
    {
        public static TBlueprint CreateCopy<TBlueprint>(this TBlueprint original, string name, Guid guid, Action<TBlueprint> init) where TBlueprint : BlueprintScriptableObject
        {
            TBlueprint copy = TTT_Utils.Clone(original);

            copy.name = name;
            copy.AssetGuid = new BlueprintGuid(guid);

            init(copy);

            ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(copy.AssetGuid, copy);

            return copy;
        }
    }

    public static class BlueprintFeatureExtensions
    {
        public static void SetIcon(this BlueprintFeature feature, UnityEngine.Sprite icon) => feature.m_Icon = icon;

        public static void AddComponent<TComponent>(this BlueprintFeature feat, TComponent component) where TComponent : BlueprintComponent
        {
            // Apparently components need a unique name
            if (String.IsNullOrEmpty(component.name))
                component.name = $"{feat.Name}${typeof(TComponent)}${component.GetHashCode():x}";

            feat.ComponentsArray = feat.ComponentsArray.Append(component).ToArray();
        }

        public static void RemoveComponents(this BlueprintFeature feat, Func<BlueprintComponent, bool> predicate)
            => feat.ComponentsArray = feat.ComponentsArray.Where(c => !predicate(c)).ToArray();

        public static void AddPrerequisite<TPrerequisite>(this BlueprintFeature feat, Action<TPrerequisite> init,
            Prerequisite.GroupType group = Prerequisite.GroupType.All)
            where TPrerequisite : Prerequisite, new()
        {
            TPrerequisite p = new()
            {
                Group = group
            };

            init(p);

            feat.AddComponent(p);
        }

        public static void RemoveFeatureOnApply(this BlueprintFeature feat, BlueprintFeature blueprintToRemove)
            => feat.AddComponent(new RemoveFeatureOnApply() { m_Feature = blueprintToRemove.ToReference<BlueprintUnitFactReference>() });

        public static void AddPrerequisiteFeature(this BlueprintFeature feat,
            BlueprintFeature prerequisiteFeature, Action<PrerequisiteFeature> init,
            Prerequisite.GroupType group = Prerequisite.GroupType.All, bool removeOnApply = false,
            bool addIsPrerequisiteFor = false)
        {
            feat.AddPrerequisite<PrerequisiteFeature>(p =>
            {
                p.m_Feature = prerequisiteFeature.ToReference<BlueprintFeatureReference>();

                init(p);
            }, group);

            if (addIsPrerequisiteFor)
            {
                if (prerequisiteFeature.IsPrerequisiteFor is null)
                    prerequisiteFeature.IsPrerequisiteFor = new();

                if (!prerequisiteFeature.IsPrerequisiteFor.Contains(feat.ToReference<BlueprintFeatureReference>()))
                    prerequisiteFeature.IsPrerequisiteFor.Add(feat.ToReference<BlueprintFeatureReference>());
            }

            if (removeOnApply)
                feat.RemoveFeatureOnApply(prerequisiteFeature);
        }

        public static void AddPrerequisiteNoFeature(this BlueprintFeature feat,
            BlueprintFeature prerequisiteFeature, Action<PrerequisiteNoFeature> init,
            Prerequisite.GroupType group = Prerequisite.GroupType.All)
            => feat.AddPrerequisite<PrerequisiteNoFeature>(p =>
            {
                p.m_Feature = prerequisiteFeature.ToReference<BlueprintFeatureReference>();

                init(p);
            }, group);

        public static void AddFeatureCallback<TDelegate>(this BlueprintFeature feature, TDelegate callback)
            where TDelegate : UnitFactComponentDelegate
            => feature.AddComponent(callback);
    }

    public static class BlueprintFeatureSelectionExtensions
    {
        public static void AddFeature(this BlueprintFeatureSelection selection, BlueprintFeature feature)
        {
            BlueprintFeatureReference[] featureRefs = selection.Features;

            var featureRef = feature.ToReference<BlueprintFeatureReference>();

            if (selection.m_Features.Contains(featureRef) || selection.m_AllFeatures.Contains(featureRef)) return;

            selection.m_Features = selection.m_Features.Append(featureRef).ToArray();

            selection.m_AllFeatures = selection.m_AllFeatures.Append(featureRef).ToArray();
        }

        public static void SetFeatures(this BlueprintFeatureSelection selection, BlueprintFeatureReference[] features, BlueprintFeatureReference[]? allFeatures = null)
        {
            selection.m_Features = features;

            selection.m_AllFeatures = allFeatures ?? features;
        }

        public static void RemoveFeature(this BlueprintFeatureSelection selection, BlueprintFeature feature)
        {
            selection.m_Features = selection.m_Features.SkipWhile(f => f.Get().AssetGuid == feature.AssetGuid).ToArray();
            selection.m_AllFeatures = selection.m_AllFeatures.SkipWhile(f => f.Get().AssetGuid == feature.AssetGuid).ToArray();
        }
    }

    public static class BlueprintRaceExtensions
    {
        public static void AddFeature(this BlueprintRace race, BlueprintFeatureBase feature)
            => race.m_Features = race.m_Features.Append(feature.ToReference<BlueprintFeatureBaseReference>()).ToArray();

        public static void AddFeatures(this BlueprintRace race, BlueprintFeatureBase[] features)
            => race.m_Features =
                race.m_Features
                    .Concat(features.Select(f => f.ToReference<BlueprintFeatureBaseReference>()))
                    .ToArray();

        public static void SetFeatures(this BlueprintRace race, BlueprintFeatureBaseReference[] features)
            => race.m_Features = features;

        public static void RemoveFeature(this BlueprintRace race, BlueprintFeatureBase feature)
        {
            var featureRef = feature.ToReference<BlueprintFeatureBaseReference>();

            race.m_Features = race.m_Features.SkipWhile(f => f.Get().AssetGuid == feature.AssetGuid).ToArray();
        }
    }

    public static class BlueprintUnitFactExtensions
    {
        public static void SetDisplayName(this BlueprintUnitFact bp, LocalizedString displayName)
            => bp.m_DisplayName = displayName;

        public static void SetDisplayName(this BlueprintUnitFact bp, string text)
            => bp.SetDisplayName(LocalizationHelpers.DefineString($"{bp.name}.Name", text));

        public static void SetDescription(this BlueprintUnitFact bp, LocalizedString description)
            => bp.m_Description = description;

        public static void SetDescription(this BlueprintUnitFact bp, string text)
            => bp.SetDescription(LocalizationHelpers.DefineString($"{bp.Name}", text));
    }

    public static class ContextRankConfigExtensions
    {
        public static ContextRankConfig CreateContextRankConfigFeatureList(BlueprintFeatureReference[] feats)
            => new()
            {
                m_BaseValueType = ContextRankBaseValueType.FeatureList,
                m_FeatureList = feats,
            };

        public static ContextRankConfig.CustomProgressionItem CreateProgressionItem(int baseValue, int progressionValue)
            => new() { BaseValue = baseValue, ProgressionValue = progressionValue };

        public static RecalculateOnFactsChange CreateRofcComponent(BlueprintUnitFactReference[] checkedFacts)
            => new() { m_CheckedFacts = checkedFacts };
        public static void SetCustomProgression(this ContextRankConfig crc,
            ContextRankConfig.CustomProgressionItem[] progressionItems)
        {
            crc.m_Progression = ContextRankProgression.Custom;
            crc.m_CustomProgression = progressionItems;
        }
    }
}
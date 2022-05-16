using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints;

using Microsoftenator.Wotr.Common.Util;

namespace Microsoftenator.Wotr.Common.Blueprints
{
    public class Blueprints
    {
        private class Comparer : IEqualityComparer<BlueprintInfo<BlueprintScriptableObject>>
        {
            public bool Equals(BlueprintInfo<BlueprintScriptableObject> x, BlueprintInfo<BlueprintScriptableObject> y)
                => x.Guid == y.Guid;
            public int GetHashCode(BlueprintInfo<BlueprintScriptableObject> obj)
                => obj.Guid.GetHashCode();
        }

        private readonly HashSet<BlueprintInfo<BlueprintScriptableObject>> blueprints
            = new(new Comparer());

        public IReadOnlyDictionary<string, BlueprintInfo<BlueprintScriptableObject>> GetBlueprintsInfo()
            => blueprints.ToDictionary(info => info.GuidString, Functional.Id);

        public Blueprints(IEnumerable<BlueprintInfo<BlueprintScriptableObject>> blueprints)
        {
            foreach(var bpi in blueprints)
                this.blueprints.Add(bpi);
        }
    }

    public class BlueprintInfo<T> where T : BlueprintScriptableObject
    {
        public readonly string GuidString;
        public readonly Guid Guid;
        public readonly string Name;
        public readonly string? DisplayName;
        public readonly string? Description;

        public BlueprintInfo(string guid, (string name, string? displayName, string? description) info)
            : this(guid, info.name, info.displayName, info.description) { }

        private BlueprintInfo(string? guid, string? name, string? displayName, string? description)
        {
            if (guid is null || name is null)
                throw new NullReferenceException();

            GuidString = guid;
            Guid = Guid.Parse(GuidString);
            Name = name;
            Description = description;
        }

        internal BlueprintInfo(BlueprintInfoJson bpj) : this(bpj.Guid, bpj.Name, bpj.DisplayName, bpj.Description) { }

        public T GetBlueprint() => ResourcesLibrary.TryGetBlueprint<T>(GuidString);
        public U? GetBlueprint<U>() where U : T => GetBlueprint() as U;
    }
}

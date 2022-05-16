using System;
using System.Collections.Generic;

using Kingmaker.Blueprints;

using Microsoftenator.Wotr.Common.Blueprints;

using Newtonsoft.Json;

namespace Microsoftenator.Wotr.Common
{
    [JsonObject]
    internal struct BlueprintInfoJson
    {
        [JsonProperty(Required = Required.Always)]
        public string? Guid;
        [JsonProperty(Required = Required.Always)]
        public string? Name;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? DisplayName;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Description;

        public static Func<string, IEnumerable<BlueprintInfoJson>> DeserializeAll
            = JsonConvert.DeserializeObject<IEnumerable<BlueprintInfoJson>>;
        
        public static Func<IEnumerable<BlueprintInfoJson>, string> SerializeAll = JsonConvert.SerializeObject;
    }

    internal static class Extensions
    {
        internal static BlueprintInfo<T> FromJson<T>(this BlueprintInfoJson bpj) where T : BlueprintScriptableObject
            => new(bpj);
        internal static BlueprintInfoJson ToJson<T>(this BlueprintInfo<T> bpi) where T : BlueprintScriptableObject
            => new() { Guid = bpi.GuidString, Name = bpi.Name, DisplayName = bpi.DisplayName, Description = bpi.Description };
    }
}

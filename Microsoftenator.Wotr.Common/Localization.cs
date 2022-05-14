using System;
using System.Collections.Generic;

using Kingmaker.Blueprints.Facts;
using Kingmaker.Localization;

using Microsoftenator.Wotr.Common.Localization.Extensions;
using Microsoftenator.Wotr.Common.Util;

namespace Microsoftenator.Wotr.Common.Localization
{
    public static class LocalizationHelpers
    {
        private static readonly Dictionary<string, LocalizedString> Strings = new();

        public static LocalizationPack.StringEntry CreateStringEntry(string text) => new() { Text = text };
        
        public static LocalizationPack CreateLocalizationPack(Dictionary<string, LocalizationPack.StringEntry> strings)
            => new() { m_Strings =  strings};
        
        public static LocalizedString LocalizedString(string key) => new() { m_Key = key };

        public static LocalizedString DefineString(string key, string text)
        {
            LocalizationManager.CurrentPack.AddString(key, text);

            return LocalizedString(key);
        }
    }
}

namespace Microsoftenator.Wotr.Common.Localization.Extensions
{
    public static class LocalizationExtensions
    {
        public static LocalizedString GetDisplayNameLocalizedString(this BlueprintUnitFact fact) => fact.m_DisplayName;
        public static LocalizedString GetDescriptionLocalizedString(this BlueprintUnitFact fact) => fact.m_Description;

        public static LocalizedString CopyWith(this LocalizedString ls, string key, Func<string, string> mutator)
            => LocalizationHelpers.DefineString(key, mutator(LocalizationManager.CurrentPack.GetText(ls)));

        public static LocalizedString Copy(this LocalizedString ls, string key) => ls.CopyWith(key, Functional.Id);

        public static void AddStrings(this LocalizationPack pack, IEnumerable<(string key, string text)> strings)
        {
            var dict = new Dictionary<string, LocalizationPack.StringEntry>();

            foreach ((var key, var text) in strings)
            {
                dict[key] = LocalizationHelpers.CreateStringEntry(text);
            }

            pack.AddStrings(LocalizationHelpers.CreateLocalizationPack(dict));
        }

        public static void AddString(this LocalizationPack pack, string key, string text)
            => pack.AddStrings(new[] { (key, text) });

    }
}

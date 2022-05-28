using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Localization;

using Microsoftenator.Wotr.Common.Localization;

namespace AlternateHumanTraits.Resources
{
    internal static class Localization
    {
        private static readonly Lazy<LocalizedStringsPack> defaultStringsLazy = new(() => new(LocalizationManager.CurrentLocale));
        public static LocalizedStringsPack Default => defaultStringsLazy.Value;


    }
}

using System;

using UnityModManagerNet;

using HarmonyLib;

namespace AlternateHumanTraits
{
    static class Main
    {
        internal class Logger
        {
            private readonly UnityModManager.ModEntry.ModLogger logger;

            internal Logger(UnityModManager.ModEntry.ModLogger logger) => this.logger = logger;

            public Action<string> Debug =>
#if DEBUG
                s => logger.Log($"[DEBUG] {s}");
#else
                Functional.Ignore;
#endif
            public Action<string> Info => logger.Log;
            public Action<string> Warning => logger.Warning;
            public Action<string> Error => logger.Error;
            public Action<string> Critical => logger.Critical;
        }

        internal static UnityModManager.ModEntry? ModEntry { get; private set; }
        static internal Logger? Log { get; private set; }
        internal static bool Enabled { get; private set; } = false;

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Log?.Debug($"{nameof(Main)}.{nameof(OnToggle)}({value})");

            Enabled = value;
            return true;
        }

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            Log = new(modEntry.Logger);


            Log.Debug($"{nameof(Main)}.{nameof(Load)}");

            ModEntry = modEntry;

            var harmony = new Harmony(modEntry.Info.Id);

            harmony.PatchAll();

            return true;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoftenator.Wotr.Common.Util
{
    public static class Functional
    {
        public static void Ignore<T>(T x) { return; }
        public static void Ignore<T1, T2>(T1 x, T2 y) { return; }

        public static T Id<T>(T x) { return x; }

        public static void IgnoreRef<T>(ref T x) { return; }
        public static void IgnoreRef<T1, T2>(ref T1 x, ref T2 y) { return; }
    }
    
    public static class TTT_Utils
    {
        public static T Clone<T>(T original) where T : notnull
            => (T)(TabletopTweaks.Core.Utilities.ObjectDeepCopier.Clone(original) ?? throw new NullReferenceException());
    }
}

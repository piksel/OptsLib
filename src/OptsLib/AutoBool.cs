using System;

namespace OptsLib
{
    public enum AutoBool
    {
        Auto = -1,
        False = 0,
        True = 1
    }

    public static class AutoBoolExtensions {
        public static bool Resolve(this AutoBool ab, Func<bool> autoResolver)
            => ab switch
            {
                AutoBool.True => true,
                AutoBool.False => false,
                _ => autoResolver()
            };
    }
}

using System;

namespace HorosUsefulMethods
{
    public static class HoroStringModifiers
    {
        public static string TextBefore(this String str, string value )
        {
            return str.Substring(0 , str.IndexOf(value)-1);
        }

    }
}

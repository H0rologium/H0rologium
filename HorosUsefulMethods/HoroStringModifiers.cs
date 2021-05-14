using System;

namespace HorosUsefulMethods
{
    public static class HoroStringModifiers
    {
		///<summary>
		///Returns a string with only the leading text of the position of the supplied argument
		///</summary>
        public static string TextBefore(this String str, string value )
        {
            return str.Substring(0 , str.IndexOf(value)-1);
        }

    }
}

﻿namespace MySpellChecker
{
    // Расширения для класса String.
    /// <summary>
    ///Extensions for <c>String</c>
    /// </summary>
    static class StringExtensions     
    {
        /// <summary>
        /// Returns part of a string starting at the specified position.
        /// </summary>
        /// <param name="str">Source line.</param>
        /// <param name="n">A pointer to the start of the index selection.</param>
        /// <returns>String.</returns>
        public static string From(this string str, int n)
        {
            if (str == null) return null;
            var len = str.Length;
            if (n >= len) return "";

            if (n <= 0) return str;

            return str.Substring(n, (len - n) );
        }

        /// <summary>
        /// Returns part of a string starting from the beginning to the specified position.
        /// </summary>
        /// <param name="str">Source line.</param>
        /// <param name="n">A pointer to the finish of the index selection.</param>
        /// <returns>String.</returns>
        public static string To(this string str, int n)
        {
            if (str == null) return null;

            var len = str.Length;

            if (n <= 0) return "";
            if (n >= len) return str;

            return str.Substring(0, n);
        }
    }

}

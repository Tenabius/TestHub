﻿namespace TestHub.Core.Extensions
{
    public static class Extensions
    {
        private static readonly Random _rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static string ToShortGuid(this Guid guid)
        {
            return Base32Encoding.ToString(guid.ToByteArray()).ToLower();
        }

        public static Guid FromShortGuid(this string shortGuid)
        {
            return new Guid(Base32Encoding.ToBytes(shortGuid));
        }

    }
}

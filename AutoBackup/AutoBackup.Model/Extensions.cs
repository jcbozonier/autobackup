using System;
using System.Collections.Generic;

namespace AutoBackup.Model
{
    public static class Extensions
    {
        public static bool IsSameAgeOrNewerThan(this DateTime thisTime, DateTime thatTime)
        {
            return thisTime.CompareTo(thatTime) >= 0;
        }

        public static IEnumerator<int> Range(int startInclusive, int endExclusive)
        {
            for(var i=startInclusive; i<endExclusive; i++)
            {
                yield return i;
            }
        }
    }
}
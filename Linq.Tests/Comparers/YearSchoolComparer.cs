using Linq.Objects;
using System.Collections.Generic;

namespace Linq.Tests.Comparers
{
    internal class YearSchoolComparer : IEqualityComparer<YearSchoolStat>
    {
        public bool Equals(YearSchoolStat x, YearSchoolStat y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.NumberOfSchools == y.NumberOfSchools && x.Year == y.Year;
        }

        public int GetHashCode(YearSchoolStat obj)
        {
            return obj.GetHashCode();
        }
    }
}
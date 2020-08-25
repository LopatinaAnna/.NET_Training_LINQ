using Linq.Objects;
using System.Collections.Generic;

namespace Linq.Tests.Comparers
{
    internal class CountryStatComparer : IEqualityComparer<CountryStat>
    {
        public bool Equals(CountryStat x, CountryStat y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.StoresNumber == y.StoresNumber && x.MinPrice == y.MinPrice && x.Country.Equals(y.Country);
        }

        public int GetHashCode(CountryStat obj)
        {
            return obj.GetHashCode();
        }
    }
}
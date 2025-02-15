﻿using Linq.Objects;
using System;
using System.Collections.Generic;

namespace Linq.Tests.Comparers
{
    internal class MaxDiscountOwnerComparer : IEqualityComparer<MaxDiscountOwner>
    {
        private SupplierComparer _supplierComparer = new SupplierComparer();

        public bool Equals(MaxDiscountOwner x, MaxDiscountOwner y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.ShopName.Equals(y.ShopName) && Math.Abs(x.Discount - y.Discount) < 0.00001 &&
                   _supplierComparer.Equals(x.Owner, y.Owner);
        }

        public int GetHashCode(MaxDiscountOwner obj)
        {
            return obj.GetHashCode();
        }
    }
}
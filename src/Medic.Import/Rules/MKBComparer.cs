using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class MKBComparer : IEqualityComparer<MKB>
    {
        public bool Equals(MKB x, MKB y)
        {
            if (x == default && y == default)
            {
                return true;
            }

            if (x == default || y == default)
            {
                return false;
            }

            return string.Equals(x.Code, y.Code, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(MKB obj)
        {
            return obj.Code.GetHashCode();
        }
    }
}

using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class SpecialtyTypeComparer : IEqualityComparer<SpecialtyType>
    {
        public bool Equals(SpecialtyType x, SpecialtyType y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(x.SpecialtyCode) && !string.IsNullOrWhiteSpace(y.SpecialtyCode))
            {
                return string.Equals(x.SpecialtyCode, y.SpecialtyCode, StringComparison.OrdinalIgnoreCase);
            }

            return string.Equals(x.SpecialtyCode, y.SpecialtyCode, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(SpecialtyType obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (!string.IsNullOrWhiteSpace(obj.SpecialtyCode))
            {
                return obj.SpecialtyCode.GetHashCode();
            }

            return -1;
        }
    }
}

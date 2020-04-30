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

            return x.SpecialtyCode == y.SpecialtyCode;
        }

        public int GetHashCode(SpecialtyType obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.SpecialtyCode != default ? obj.SpecialtyCode.GetHashCode() : -1;
        }
    }
}
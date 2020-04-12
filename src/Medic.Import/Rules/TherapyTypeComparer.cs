using Medic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.Import.Rules
{
    internal class TherapyTypeComparer : IEqualityComparer<TherapyType>
    {
        public bool Equals(TherapyType x, TherapyType y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return x.Code == y.Code;
        }

        public int GetHashCode(TherapyType obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Code.GetHashCode();
        }
    }
}

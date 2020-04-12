using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class SexComparer : IEqualityComparer<Sex>
    {
        public bool Equals(Sex x, Sex y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return x.Id == y.Id;
        }

        public int GetHashCode(Sex obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Id.GetHashCode();
        }
    }
}

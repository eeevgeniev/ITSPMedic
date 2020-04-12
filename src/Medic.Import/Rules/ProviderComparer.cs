using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class ProviderComparer : IEqualityComparer<Provider>
    {
        public bool Equals(Provider x, Provider y)
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

        public int GetHashCode(Provider obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Code.GetHashCode();
        }
    }
}

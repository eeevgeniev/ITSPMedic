using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class SenderTypeComparer : IEqualityComparer<SenderType>
    {
        public bool Equals(SenderType x, SenderType y)
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

        public int GetHashCode(SenderType obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            
            return obj.Code.GetHashCode();
        }
    }
}

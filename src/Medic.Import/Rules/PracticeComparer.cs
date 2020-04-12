using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class PracticeComparer : IEqualityComparer<Practice>
    {
        public bool Equals(Practice x, Practice y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return string.Equals(x.Code, y.Code, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Practice obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (!string.IsNullOrWhiteSpace(obj.Code))
            {
                return obj.Code.GetHashCode();
            }

            return -1;
        }
    }
}

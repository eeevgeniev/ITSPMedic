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

            return string.Equals(x.Code, y.Code, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Number, y.Number, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Practice obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (!string.IsNullOrWhiteSpace(obj.Code) || !string.IsNullOrWhiteSpace(obj.Number))
            {
                return ((obj.Code ?? string.Empty) + (obj.Number ?? string.Empty)).GetHashCode();
            }

            return -1;
        }
    }
}

using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class HealthcarePractitionerComparer : IEqualityComparer<HealthcarePractitioner>
    {
        public bool Equals(HealthcarePractitioner x, HealthcarePractitioner y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return string.Equals(x.UniqueIdentifier, y.UniqueIdentifier, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(HealthcarePractitioner obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            string uniqueIdentifier = obj.UniqueIdentifier ?? string.Empty;
            string name = obj.Name ?? string.Empty;

            return ($"{uniqueIdentifier} - {name}").GetHashCode();
        }
    }
}
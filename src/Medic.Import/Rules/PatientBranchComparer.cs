using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class PatientBranchComparer : IEqualityComparer<PatientBranch>
    {
        public bool Equals(PatientBranch x, PatientBranch y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return x.HealthRegion.Code == y.HealthRegion.Code;
        }

        public int GetHashCode(PatientBranch obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.HealthRegion.Code != default ? obj.HealthRegion.Code.GetHashCode() : -1;
        }
    }
}

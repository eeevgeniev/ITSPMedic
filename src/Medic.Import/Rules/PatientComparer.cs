using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class PatientComparer : IEqualityComparer<Patient>
    {
        public bool Equals(Patient x, Patient y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return string.Equals(x.IdentityNumber, y.IdentityNumber, StringComparison.OrdinalIgnoreCase) &&
                DateTime.Equals(x.BirthDate, y.BirthDate) &&
                string.Equals(x.CountryCode, y.CountryCode, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.PersonalIdNumber, y.PersonalIdNumber, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Patient obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            string identityNumber = obj.IdentityNumber ?? string.Empty;
            string countryCode = obj.CountryCode ?? string.Empty;
            string personIdNumber = obj.PersonalIdNumber ?? string.Empty;

            return ($"{identityNumber} - {obj.BirthDate} - {countryCode} - {personIdNumber}").GetHashCode();
        }
    }
}

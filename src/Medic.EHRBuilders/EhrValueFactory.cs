using Medic.EHR.Primitives;
using Medic.EHRBuilders.Contracts;
using System;
using System.Globalization;

namespace Medic.EHRBuilders
{
    public class EhrValueFactory : IEhrValueFactory
    {
        public EHRBoolean CreateBoolean(bool value)
        {
            return new EHRBoolean()
            {
                Value = value
            };
        }

        public EHRDate CreateDate(DateTime value)
        {
            return new EHRDate()
            {
                Value = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
        }

        public EHRDateTime CreateDateTime(DateTime value)
        {
            return new EHRDateTime()
            {
                Value = value.ToString("s")
            };
        }

        public EHRInteger CreateInteger(int value)
        {
            return new EHRInteger
            {
                Value = value
            };
        }

        public EHRPointInTime CreatePointInTime(DateTime value)
        {
            return new EHRPointInTime()
            {
                Value = value.ToString("s", CultureInfo.InvariantCulture)
            };
        }

        public EHRReal CreateReal(double value)
        {
            return new EHRReal()
            {
                Value = value
            };
        }

        public EHRString CreateString(string value)
        {
            return new EHRString()
            {
                Value = value
            };
        }

        public EHRTime CreateTime(DateTime value)
        {
            return new EHRTime()
            {
                Value = value.ToString("HH:mm:ss.FFFF", CultureInfo.InvariantCulture)
            };
        }
    }
}

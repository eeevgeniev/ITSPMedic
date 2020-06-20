using Medic.EHR.Complexes;
using Medic.EHR.Primitives;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEhrValueFactory
    {
        EHRBoolean CreateBoolean(bool value);

        EHRDate CreateDate(DateTime value);

        EHRDateTime CreateDateTime(DateTime value);

        EHRInteger CreateInteger(int value);

        EHRPointInTime CreatePointInTime(DateTime value);

        EHRReal CreateReal(double value);

        EHRString CreateString(string value);

        EHRTime CreateTime(DateTime value);
    }
}

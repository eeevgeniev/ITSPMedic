using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IDATEBuilder : IDisposable
    {
        IDATEBuilder AddDate(DateTime dateTime);

        IDATEBuilder AddNullFlavor(CS cs);

        DATE Build();

        IDATEBuilder Clear();
    }
}

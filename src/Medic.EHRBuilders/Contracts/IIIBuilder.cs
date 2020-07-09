using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IIIBuilder : IDisposable
    {
        IIIBuilder AddNullFlavor(CS cs);

        IIIBuilder AddExtension(string extension);

        IIIBuilder AddAssigningAuthorityName(string assigningAuthorityName);

        IIIBuilder AddValidTime(IVLTS validTime);

        IIIBuilder AddRoot(OID root);

        II Build();

        IIIBuilder Clear();
    }
}

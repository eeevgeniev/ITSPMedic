using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICSBuilder : IDisposable
    {
        ICSBuilder AddNullFlavor(CS cs);

        ICSBuilder AddCodingScheme(OID codingScheme);

        ICSBuilder AddCodingSchemeName(string codingSchemeName);

        ICSBuilder AddCodingSchemeVersion(string codingSchemeVersion);

        ICSBuilder AddCodeValue(string codeValue);

        CS Build();

        ICSBuilder Clear();
    }
}

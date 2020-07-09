using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICVBuilder : IDisposable
    {
        ICVBuilder AddNullFlavor(CS cs);

        ICVBuilder AddCodingScheme(OID codingScheme);

        ICVBuilder AddCodingSchemeName(string codingSchemeName);

        ICVBuilder AddCodingSchemeVersion(string codingSchemeVersion);

        ICVBuilder AddCodeValue(string codeValue);

        ICVBuilder AddDisplayName(string displayName);

        CV Build();

        ICVBuilder Clear();
    }
}

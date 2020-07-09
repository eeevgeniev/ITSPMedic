using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICDBuilder : IDisposable
    {
        ICDBuilder AddNullFlavor(CS cs);

        ICDBuilder AddCodingScheme(OID codingScheme);

        ICDBuilder AddCodingSchemeName(string codingSchemeName);

        ICDBuilder AddCodingSchemeVersion(string codingSchemeVersion);

        ICDBuilder AddCodeValue(string codeValue);

        ICDBuilder AddDisplayName(string displayName);

        ICDBuilder AddMappings(params CD[] mappings);

        ICDBuilder AddQualifiers(params CR[] qualifiers);

        CD Build();

        ICDBuilder Clear();
    }
}

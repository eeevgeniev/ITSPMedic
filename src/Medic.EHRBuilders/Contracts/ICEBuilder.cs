using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICEBuilder : IDisposable
    {
        ICEBuilder AddNullFlavor(CS cs);

        ICEBuilder AddCodingScheme(OID codingScheme);

        ICEBuilder AddCodingSchemeName(string codingSchemeName);

        ICEBuilder AddCodingSchemeVersion(string codingSchemeVersion);

        ICEBuilder AddCodeValue(string codeValue);

        ICEBuilder AddDisplayName(string displayName);

        ICEBuilder AddMappings(params CD[] mappings);

        CE Build();

        ICEBuilder Clear();
    }
}

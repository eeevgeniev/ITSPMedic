using Medic.EHR.DataTypes;

namespace Medic.EHRBuilders.Contracts
{
    public interface IOIDBuilder
    {
        OID Build(string value);
    }
}

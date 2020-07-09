using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Contracts;

namespace Medic.EHRBuilders
{
    public class OIDBuilder : IOIDBuilder
    {
        public OID Build(string value)
        {
            return new OID() { Oid = value };
        }
    }
}

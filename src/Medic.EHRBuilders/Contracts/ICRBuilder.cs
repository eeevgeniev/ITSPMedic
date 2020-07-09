using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ICRBuilder : IDisposable
    {
        public ICRBuilder AddInverted(bool inverted);

        public ICRBuilder AddQualCode(CV qualCode);

        public ICRBuilder AddRole(CV role);

        CR Build();

        ICRBuilder Clear();
    }
}

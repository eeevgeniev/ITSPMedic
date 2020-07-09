using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IFunctionalRoleBuilder : IDisposable
    {
        public IFunctionalRoleBuilder AddFunction(CV function);

        public IFunctionalRoleBuilder AddPerformer(II performer);

        public IFunctionalRoleBuilder AddMode(CS mode);

        public IFunctionalRoleBuilder AddHealthcareFacillity(II healthcareFacillity);

        public IFunctionalRoleBuilder AddServiceSetting(CV serviceSetting);

        FunctionalRole Build();

        IFunctionalRoleBuilder Clear();
    }
}

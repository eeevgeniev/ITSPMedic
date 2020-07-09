using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class FunctionalRoleBuilder : DataValueBuilder, IFunctionalRoleBuilder
    {
        private FunctionalRole _value;

        public FunctionalRoleBuilder()
        {
            Clear();
        }

        public IFunctionalRoleBuilder AddFunction(CV function)
        {
            _value.Function = function;

            return this;
        }

        public IFunctionalRoleBuilder AddHealthcareFacillity(II healthcareFacillity)
        {
            _value.HealthcareFacillity = healthcareFacillity;

            return this;
        }

        public IFunctionalRoleBuilder AddMode(CS mode)
        {
            _value.Mode = mode;

            return this;
        }

        public IFunctionalRoleBuilder AddPerformer(II performer)
        {
            _value.Performer = performer;

            return this;
        }

        public IFunctionalRoleBuilder AddServiceSetting(CV serviceSetting)
        {
            _value.ServiceSetting = serviceSetting;

            return this;
        }

        public FunctionalRole Build() => base.DeepClone<FunctionalRole>(_value);

        public IFunctionalRoleBuilder Clear()
        {
            _value = base.ResetValue<FunctionalRole>();

            return this;
        }

        public override void Dispose()
        {
            if (!base._isDisposed)
            {
                _value = null;
                GC.SuppressFinalize(this);
                base._isDisposed = !base._isDisposed;
            }
        }
    }
}

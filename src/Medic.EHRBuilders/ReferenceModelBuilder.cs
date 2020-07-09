using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class ReferenceModelBuilder : DataValueBuilder, IReferenceModelBuilder
    {
        private ReferenceModel _value;

        public ReferenceModelBuilder()
        {
            Clear();
        }
        
        public IReferenceModelBuilder AddComposition(Composition composition)
        {
            _value.Composition = composition;

            return this;
        }

        public IReferenceModelBuilder AddFolder(Folder folder)
        {
            _value.Folder = folder;

            return this;
        }

        public ReferenceModel Build() => base.DeepClone<ReferenceModel>(_value);

        public IReferenceModelBuilder Clear()
        {
            _value = base.ResetValue<ReferenceModel>();

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

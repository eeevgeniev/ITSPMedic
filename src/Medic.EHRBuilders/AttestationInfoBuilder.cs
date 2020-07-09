using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class AttestationInfoBuilder : DataValueBuilder, IAttestationInfoBuilder
    {
        private AttestationInfo _value;

        public AttestationInfoBuilder()
        {
            Clear();
        }

        public IAttestationInfoBuilder AddAttestedView(ED attestedView)
        {
            _value.AttestedView = attestedView;

            return this;
        }

        public IAttestationInfoBuilder AddProof(ED proof)
        {
            _value.Proof = proof;

            return this;
        }

        public IAttestationInfoBuilder AddReasonForAttestation(CV reasonForAttestation)
        {
            _value.ReasonForAttestation = reasonForAttestation;

            return this;
        }

        public IAttestationInfoBuilder AddReasonForRevision(FunctionalRole attester)
        {
            _value.Attester = attester;

            return this;
        }

        public IAttestationInfoBuilder AddTarget(params II[] target)
        {
            if (target == default || target.Length == 0)
            {
                return this;
            }

            if (_value.Target == default)
            {
                _value.Target = new List<II>();
            }

            _value.Target.AddRange(target);


            return this;
        }

        public IAttestationInfoBuilder AddTime(TS time)
        {
            _value.Time = time;

            return this;
        }

        public AttestationInfo Build() => base.DeepClone<AttestationInfo>(_value);

        public IAttestationInfoBuilder Clear()
        {
            _value = base.ResetValue<AttestationInfo>();

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

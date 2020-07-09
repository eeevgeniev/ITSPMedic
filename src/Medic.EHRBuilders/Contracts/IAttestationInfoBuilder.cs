using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IAttestationInfoBuilder : IDisposable
    {
        public IAttestationInfoBuilder AddTime(TS time);

        public IAttestationInfoBuilder AddProof(ED proof);

        public IAttestationInfoBuilder AddAttestedView(ED attestedView);

        public IAttestationInfoBuilder AddReasonForAttestation(CV reasonForAttestation);

        public IAttestationInfoBuilder AddReasonForRevision(FunctionalRole attester);

        public IAttestationInfoBuilder AddTarget(params II[] target);

        AttestationInfo Build();

        IAttestationInfoBuilder Clear();
    }
}

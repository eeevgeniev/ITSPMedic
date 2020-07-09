using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class CompositionBuilder : DataValueBuilder, ICompositionBuilder
    {
        private Composition _value;
        
        public ICompositionBuilder AddArchetypeId(string archetypeId)
        {
            _value.ArchetypeId = archetypeId;

            return this;
        }

        public ICompositionBuilder AddAttestations(params AttestationInfo[] attestations)
        {
            if (attestations == default || attestations.Length == 0)
            {
                return this;
            }

            if (_value.Attestations == default)
            {
                _value.Attestations = new List<AttestationInfo>();
            }

            _value.Attestations.AddRange(attestations);

            return this;
        }

        public ICompositionBuilder AddCommittal(AuditInfo committal)
        {
            _value.Committal = committal;

            return this;
        }

        public ICompositionBuilder AddComposer(FunctionalRole composer)
        {
            _value.Composer = composer;

            return this;
        }

        public ICompositionBuilder AddContent(params Content[] content)
        {
            if (content == default || content.Length == 0)
            {
                return this;
            }

            if (_value.Content == default)
            {
                _value.Content = new List<Content>();
            }

            _value.Content.AddRange(content);

            return this;
        }

        public ICompositionBuilder AddContributionId(II contributionId)
        {
            _value.ContributionId = contributionId;

            return this;
        }

        public ICompositionBuilder AddFeederAudit(AuditInfo feederAudit)
        {
            _value.FeederAudit = feederAudit;

            return this;
        }

        public ICompositionBuilder AddLinks(params Link[] links)
        {
            if (links == default || links.Length == 0)
            {
                return this;
            }

            if (_value.Links == default)
            {
                _value.Links = new List<Link>();
            }

            _value.Links.AddRange(links);

            return this;
        }

        public ICompositionBuilder AddMeaning(CV meaning)
        {
            _value.Meaning = meaning;

            return this;
        }

        public ICompositionBuilder AddName(Text name)
        {
            _value.Name = name;

            return this;
        }

        public ICompositionBuilder AddOrigParentRef(II origParentRef)
        {
            _value.OrigParentRef = origParentRef;

            return this;
        }

        public ICompositionBuilder AddOtherParticipation(params FunctionalRole[] otherParticipation)
        {
            if (otherParticipation == default || otherParticipation.Length == 0)
            {
                return this;
            }

            if (_value.OtherParticipation == default)
            {
                _value.OtherParticipation = new List<FunctionalRole>();
            }

            _value.OtherParticipation.AddRange(otherParticipation);

            return this;
        }

        public ICompositionBuilder AddPolicyIds(params II[] policyIds)
        {
            if (policyIds == default || policyIds.Length == 0)
            {
                return this;
            }

            if (_value.PolicyIds == default)
            {
                _value.PolicyIds = new List<II>();
            }

            _value.PolicyIds.AddRange(policyIds);

            return this;
        }

        public ICompositionBuilder AddRcId(II rcId)
        {
            _value.RcId = rcId;

            return this;
        }

        public ICompositionBuilder AddSensitivity(int sensitivity)
        {
            _value.Sensitivity = sensitivity;

            return this;
        }

        public ICompositionBuilder AddSessionTime(IVLTS sessionTime)
        {
            _value.SessionTime = sessionTime;

            return this;
        }

        public ICompositionBuilder AddSynthesised(bool synthesised)
        {
            _value.Synthesised = synthesised;

            return this;
        }

        public ICompositionBuilder AddTerritory(CS territory)
        {
            _value.Territory = territory;

            return this;
        }

        public Composition Build() => base.DeepClone<Composition>(_value);

        public ICompositionBuilder Clear()
        {
            _value = base.ResetValue<Composition>();

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

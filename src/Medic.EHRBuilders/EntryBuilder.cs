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
    public class EntryBuilder : DataValueBuilder, IEntryBuilder
    {
        private Entry _value;

        public EntryBuilder()
        {
            Clear();
        }
        
        public IEntryBuilder AddActId(string actId)
        {
            _value.ActId = actId;

            return this;
        }

        public IEntryBuilder AddActStatus(CS actStatus)
        {
            _value.ActStatus = actStatus;

            return this;
        }

        public IEntryBuilder AddArchetypeId(string archetypeId)
        {
            _value.ArchetypeId = archetypeId;

            return this;
        }

        public IEntryBuilder AddFeederAudit(AuditInfo feederAudit)
        {
            _value.FeederAudit = feederAudit;

            return this;
        }

        public IEntryBuilder AddInfoProvider(FunctionalRole infoProvider)
        {
            _value.InfoProvider = infoProvider;

            return this;
        }

        public IEntryBuilder AddItems(params Item[] items)
        {
            if (items == default || items.Length == 0)
            {
                return this;
            }

            if (_value.Items == default)
            {
                _value.Items = new List<Item>();
            }

            _value.Items.AddRange(items);

            return this;
        }

        public IEntryBuilder AddLinks(params Link[] links)
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

        public IEntryBuilder AddMeaning(CV meaning)
        {
            _value.Meaning = meaning;

            return this;
        }

        public IEntryBuilder AddName(Text name)
        {
            _value.Name = name;

            return this;
        }

        public IEntryBuilder AddOrigParentRef(II origParentRef)
        {
            _value.OrigParentRef = origParentRef;

            return this;
        }

        public IEntryBuilder AddOtherParticipations(params FunctionalRole[] otherParticipations)
        {
            if (otherParticipations == default || otherParticipations.Length == 0)
            {
                return this;
            }

            if (_value.OtherParticipations == default)
            {
                _value.OtherParticipations = new List<FunctionalRole>();
            }

            _value.OtherParticipations.AddRange(otherParticipations);

            return this;
        }

        public IEntryBuilder AddPolicyIds(params II[] policyIds)
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

        public IEntryBuilder AddRcId(II rcId)
        {
            _value.RcId = rcId;

            return this;
        }

        public IEntryBuilder AddSensitivity(int sensitivity)
        {
            _value.Sensitivity = sensitivity;

            return this;
        }

        public IEntryBuilder AddSubjectOfInformation(RelatedParty subjectOfInformation)
        {
            _value.SubjectOfInformation = subjectOfInformation;

            return this;
        }

        public IEntryBuilder AddSubjectOfInformationCategory(CS subjectOfInformationCategory)
        {
            _value.SubjectOfInformationCategory = subjectOfInformationCategory;

            return this;
        }

        public IEntryBuilder AddSynthesised(bool synthesised)
        {
            _value.Synthesised = synthesised;

            return this;
        }

        public IEntryBuilder AddUncertaintyExpressed(bool uncertaintyExpressed)
        {
            _value.UncertaintyExpressed = uncertaintyExpressed;

            return this;
        }

        public Entry Build() => base.DeepClone<Entry>(_value);

        public IEntryBuilder Clear()
        {
            _value = base.ResetValue<Entry>();

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

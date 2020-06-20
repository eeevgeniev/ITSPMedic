using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class EhrEntryBuilder : BaseInstanceIdentifierHelper, IEhrEntryBuilder
    {
        private bool _isDisposed = false;


        private Entry Entry;

        public EhrEntryBuilder()
        {
            Entry = new Entry();
        }

        public IEhrEntryBuilder AddCodedValue(string originalText, string code, string codeSystem, string displayName)
        {
            ValidateCodedValues(originalText, code, codeSystem, displayName);

            if (Entry.SubjectOfInformationCategory == default)
            {
                Entry.SubjectOfInformationCategory = new CodedValue()
                {
                    OriginalText = new SimpleText()
                };
            }

            Entry.SubjectOfInformationCategory.OriginalText.Value = originalText;
            Entry.SubjectOfInformationCategory.Code = code;
            Entry.SubjectOfInformationCategory.CodeSystem = codeSystem;
            Entry.SubjectOfInformationCategory.DisplayName = displayName;

            return this;
        }

        public IEhrEntryBuilder AddIdentifierName(string identifierName)
        {
            if (string.IsNullOrWhiteSpace(identifierName))
            {
                throw new ArgumentException(nameof(identifierName));
            }

            if (Entry.ArchetypeId == default)
            {
                Entry.ArchetypeId = new InstanceIdentifier();
            }

            Entry.ArchetypeId.IdentifierName = identifierName;

            return this;
        }

        public IEhrEntryBuilder AddInformationProvider(string rootName, string extension, string identifierName)
        {
            base.ValidateInstanceIdentifierValues(rootName, extension, identifierName);

            if (Entry.InformationProvider == default)
            {
                Entry.InformationProvider = new InstanceIdentifier();
            }

            Entry.InformationProvider.Root = rootName;
            Entry.InformationProvider.Extension = extension;
            Entry.InformationProvider.IdentifierName = identifierName;

            return this;
        }

        public IEhrEntryBuilder AddItem(Item item)
        {
            if (item == default)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Entry.Items == default)
            {
                Entry.Items = new List<Item>();
            }

            Entry.Items.Add(item);

            return this;
        }

        public Entry Build()
        {
            return base.CreateDeepCopy<Entry>(Entry);
        }

        public IEhrEntryBuilder Clear()
        {
            Entry = new Entry();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Entry = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }

        private void ValidateCodedValues(string originalText, string code, string codeSystem, string displayName)
        {
            if (string.IsNullOrWhiteSpace(originalText))
            {
                throw new ArgumentException(nameof(originalText));
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException(nameof(code));
            }

            if (string.IsNullOrWhiteSpace(codeSystem))
            {
                throw new ArgumentException(nameof(codeSystem));
            }

            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentException(nameof(displayName));
            }
        }
    }
}

using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class CDBuilder : DataValueBuilder, ICDBuilder
    {
        private CD _value;

        public CDBuilder()
        {
            Clear();
        }
        
        public ICDBuilder AddCodeValue(string codeValue)
        {
            _value.CodeValue = codeValue;

            return this;
        }

        public ICDBuilder AddCodingScheme(OID codingScheme)
        {
            _value.CodingScheme = codingScheme;

            return this;
        }

        public ICDBuilder AddCodingSchemeName(string codingSchemeName)
        {
            _value.CodingSchemeName = codingSchemeName;

            return this;
        }

        public ICDBuilder AddCodingSchemeVersion(string codingSchemeVersion)
        {
            _value.CodingSchemeVersion = codingSchemeVersion;

            return this;
        }

        public ICDBuilder AddDisplayName(string displayName)
        {
            _value.DisplayName = displayName;

            return this;
        }

        public ICDBuilder AddMappings(params CD[] mappings)
        {
            if (mappings == default || mappings.Length == 0)
            {
                return this;
            }

            if (_value.Mappings == default)
            {
                _value.Mappings = new List<CD>();
            }

            _value.Mappings.AddRange(mappings);

            return this;
        }

        public ICDBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public ICDBuilder AddQualifiers(params CR[] qualifiers)
        {
            if (qualifiers == default || qualifiers.Length == 0)
            {
                return this;
            }

            if (_value.Qualifiers == default)
            {
                _value.Qualifiers = new List<CR>();
            }

            _value.Qualifiers.AddRange(qualifiers);

            return this;
        }

        public CD Build() => base.DeepClone<CD>(_value);

        public ICDBuilder Clear()
        {
            _value = base.ResetValue<CD>();

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

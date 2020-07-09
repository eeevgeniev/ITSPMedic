using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class CEBuilder : DataValueBuilder, ICEBuilder
    {
        private CE _value;

        public CEBuilder()
        {
            Clear();
        }
        
        public ICEBuilder AddCodeValue(string codeValue)
        {
            _value.CodeValue = codeValue;

            return this;
        }

        public ICEBuilder AddCodingScheme(OID codingScheme)
        {
            _value.CodingScheme = codingScheme;

            return this;
        }

        public ICEBuilder AddCodingSchemeName(string codingSchemeName)
        {
            _value.CodingSchemeName = codingSchemeName;

            return this;
        }

        public ICEBuilder AddCodingSchemeVersion(string codingSchemeVersion)
        {
            _value.CodingSchemeVersion = codingSchemeVersion;

            return this;
        }

        public ICEBuilder AddDisplayName(string displayName)
        {
            _value.DisplayName = displayName;

            return this;
        }

        public ICEBuilder AddMappings(params CD[] mappings)
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

        public ICEBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public CE Build() => base.DeepClone<CE>(_value);

        public ICEBuilder Clear()
        {
            _value = base.ResetValue<CE>();

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

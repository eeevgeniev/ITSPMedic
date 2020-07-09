using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class CSBuilder : DataValueBuilder, ICSBuilder
    {
        private CS _value;

        public CSBuilder()
        {
            Clear();
        }
        
        public ICSBuilder AddCodeValue(string codeValue)
        {
            _value.CodeValue = codeValue;

            return this;
        }

        public ICSBuilder AddCodingScheme(OID codingScheme)
        {
            _value.CodingScheme = codingScheme;

            return this;
        }

        public ICSBuilder AddCodingSchemeName(string codingSchemeName)
        {
            _value.CodingSchemeName = codingSchemeName;

            return this;
        }

        public ICSBuilder AddCodingSchemeVersion(string codingSchemeVersion)
        {
            _value.CodingSchemeVersion = codingSchemeVersion;

            return this;
        }

        public ICSBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public CS Build() => base.DeepClone<CS>(_value);

        public ICSBuilder Clear()
        {
            _value = base.ResetValue<CS>();

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

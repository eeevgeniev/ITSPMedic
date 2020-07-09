using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class CVBuilder : DataValueBuilder, ICVBuilder
    {
        private CV _value;

        public CVBuilder()
        {
            Clear();
        }
        
        public ICVBuilder AddCodeValue(string codeValue)
        {
            _value.CodeValue = codeValue;

            return this;
        }

        public ICVBuilder AddCodingScheme(OID codingScheme)
        {
            _value.CodingScheme = codingScheme;

            return this;
        }

        public ICVBuilder AddCodingSchemeName(string codingSchemeName)
        {
            _value.CodingSchemeName = codingSchemeName;

            return this;
        }

        public ICVBuilder AddCodingSchemeVersion(string codingSchemeVersion)
        {
            _value.CodingSchemeVersion = codingSchemeVersion;

            return this;
        }

        public ICVBuilder AddDisplayName(string displayName)
        {
            _value.DisplayName = displayName;

            return this;
        }

        public ICVBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public CV Build() => base.DeepClone<CV>(_value);

        public ICVBuilder Clear()
        {
            _value = base.ResetValue<CV>();

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

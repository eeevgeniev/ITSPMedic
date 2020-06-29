using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class URIBuilder : DataValueBuilder, IURIBuilder
    {
        private URI _value;

        public URIBuilder()
        {
            _value = base.ResetValue<URI>();
        }

        public IURIBuilder AddFragmentId(string fragmentId)
        {
            _value.FragmentId = fragmentId;

            return this;
        }

        public IURIBuilder AddLiteral(string literal)
        {
            _value.Literal = literal;

            return this;
        }

        public override IDataValueBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IURIBuilder AddPath(string path)
        {
            _value.Path = path;

            return this;
        }

        public IURIBuilder AddScheme(string scheme)
        {
            _value.Scheme = scheme;

            return this;
        }

        public IURIBuilder AddUriQuery(string uriQuery)
        {
            _value.UriQuery = uriQuery;

            return this;
        }

        public IURIBuilder AddValue(string value)
        {
            _value.Value = value;

            return this;
        }

        public override DataValue Build() => base.DeepCopy<URI>(_value);

        public IURIBuilder Clear()
        {
            _value = base.ResetValue<URI>();

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

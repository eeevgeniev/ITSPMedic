using Medic.EHR.Clinical;
using Medic.EHR.Complexes;
using Medic.EHR.Primitives.Base;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class EhrElementBuilder : BaseEhrCopy, IEhrElementBuilder
    {
        private bool _isDisposed = false;


        private Element Element;

        public EhrElementBuilder()
        {
            Element = new Element();
        }

        public IEhrElementBuilder AddIdentifierName(string identifierName)
        {
            if (string.IsNullOrWhiteSpace(identifierName))
            {
                throw new ArgumentException(nameof(identifierName));
            }

            if (Element.ArchetypeId == default)
            {
                Element.ArchetypeId = new InstanceIdentifier();
            }

            Element.ArchetypeId.IdentifierName = identifierName;

            return this;
        }

        public IEhrElementBuilder AddValue(EHRDataValue value)
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Element.Value = value;

            return this;
        }

        public Element Build()
        {
            return base.CreateDeepCopy<Element>(Element);
        }

        public IEhrElementBuilder Clear()
        {
            Element = new Element();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Element = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }
    }
}

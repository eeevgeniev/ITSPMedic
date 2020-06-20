using Medic.EHR.Clinical;
using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class EhrCompositionBuilder : BaseInstanceIdentifierHelper, IEhrCompositionBuilder
    {
        private bool _isDisposed = false;

        private Composition Composition;

        public EhrCompositionBuilder()
        {
            Composition = new Composition();
        }

        public IEhrCompositionBuilder AddComposer(string rootName, string extension, string identifierName)
        {
            base.ValidateInstanceIdentifierValues(rootName, extension, identifierName);

            if (Composition.Composer == default)
            {
                Composition.Composer = new InstanceIdentifier();
            }

            Composition.Composer.Root = rootName;
            Composition.Composer.Extension = extension;
            Composition.Composer.IdentifierName = identifierName;

            return this;
        }

        public IEhrCompositionBuilder AddContent(Content content)
        {
            if (content == default)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (Composition.Content == default)
            {
                Composition.Content = new List<Content>();
            }

            Composition.Content.Add(content);

            return this;
        }

        public IEhrCompositionBuilder AddPolicyIds(string rootName, string extension, string identifierName)
        {
            base.ValidateInstanceIdentifierValues(rootName, extension, identifierName);

            if (Composition.PolicyIds == default)
            {
                Composition.PolicyIds = new List<InstanceIdentifier>();
            }

            Composition.PolicyIds.Add(new InstanceIdentifier()
            {
                Root = rootName,
                Extension = extension,
                IdentifierName = identifierName
            });

            return this;
        }

        public IEhrCompositionBuilder AddSensitivity(string sensitivity)
        {
            Composition.Sensitivity = sensitivity;

            return this;
        }

        public Composition Build()
        {
            return base.CreateDeepCopy<Composition>(Composition);
        }

        public IEhrCompositionBuilder Clear()
        {
            Composition = new Composition();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Composition = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }
    }
}

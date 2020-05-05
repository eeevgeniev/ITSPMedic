using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;
using System;

namespace Medic.Resources
{
    public class MedicDataAnnotationLocalizerProvider : IMedicDataAnnotationLocalizerProvider
    {
        public IStringLocalizer Build(IStringLocalizerFactory factory)
        {
            if (factory == default)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            return factory.Create(nameof(MedicDataAnnotationLocalizerProvider), this.GetType().Assembly.GetName().Name);
        }
    }
}
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;
using System;

namespace Medic.Resources.Bases
{
    public abstract class BaseLocalization : ILocalizationService
    {
        protected readonly IStringLocalizer StringLocalizer;

        public BaseLocalization(IStringLocalizerFactory factory, string name)
        {
            if (factory == default)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            StringLocalizer = factory.Create(name, this.GetType().Assembly.GetName().Name);
        }

        public abstract string Get(string name);
    }
}

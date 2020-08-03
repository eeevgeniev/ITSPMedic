using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;
using System;

namespace Medic.Resources.Bases
{
    public abstract class BaseLocalization : ILocalizationService
    {
        private readonly IStringLocalizer _stringLocalizer;

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

            _stringLocalizer = factory.Create(name, this.GetType().Assembly.GetName().Name);
        }

        protected IStringLocalizer StringLocalizer => _stringLocalizer;

        public abstract string Get(string name);
    }
}

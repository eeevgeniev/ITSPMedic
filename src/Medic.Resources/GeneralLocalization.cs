using Medic.Resources.Bases;
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;

namespace Medic.Resources
{
    public class GeneralLocalization : BaseLocalization, ILocalizationService
    {
        public GeneralLocalization(IStringLocalizerFactory factory)
            : base(factory, nameof(GeneralLocalization)) { }

        public override string Get(string name)
        {
            return StringLocalizer[name];
        }
    }
}
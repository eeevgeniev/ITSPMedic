using Medic.Resources.Bases;
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;

namespace Medic.Resources
{
    public class PatientLocalization : BaseLocalization, ILocalizationService
    {
        public PatientLocalization(IStringLocalizerFactory factory)
            : base (factory, nameof(PatientLocalization)) {}

        public override string Get(string name)
        {
            return StringLocalizer[name];
        }
    }
}
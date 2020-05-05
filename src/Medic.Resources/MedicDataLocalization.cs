using Medic.Resources.Bases;
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;

namespace Medic.Resources
{
    public class MedicDataLocalization : BaseLocalization, ILocalizationService
    {
        public MedicDataLocalization(IStringLocalizerFactory factory)
            : base(factory, nameof(MedicDataLocalization)) { }

        public override string Get(string name)
        {
            return StringLocalizer[name];
        }
    }
}

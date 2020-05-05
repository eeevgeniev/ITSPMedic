using Microsoft.Extensions.Localization;

namespace Medic.Resources.Contracts
{
    public interface IMedicDataAnnotationLocalizerProvider
    {
        IStringLocalizer Build(IStringLocalizerFactory factory);
    }
}

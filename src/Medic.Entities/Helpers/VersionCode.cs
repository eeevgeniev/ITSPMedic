using AutoMapper;
using Medic.AppModels.VersionCodes;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class VersionCode
    {
        public VersionCode Copy()
        {
            return base.Copy<VersionCode>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<VersionCode, CLPR.VersionCode>();

            expression.CreateMap<CLPR.VersionCode, VersionCode>()
                .ForMember(vc => vc.ClinicUsedDrug, config => config.Ignore())
                .ForMember(vc => vc.Id, config => config.Ignore());

            expression.CreateMap<VersionCode, VersionCodeViewModel>();
        }
    }
}
using AutoMapper;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class ClinicHematologyPart
    {
        public ClinicHematologyPart Copy()
        {
            return base.Copy<ClinicHematologyPart>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ClinicHematologyPart, CLPR.ClinicHematologyPart>();

            expression.CreateMap<CLPR.ClinicHematologyPart, ClinicHematologyPart>()
                .ForMember(chp => chp.EvalutionId, config => config.Ignore())
                .ForMember(chp => chp.APr05s, config => config.Ignore())
                .ForMember(chp => chp.DecisionId, config => config.Ignore())
                .ForMember(chp => chp.Id, config => config.Ignore());
        }
    }
}

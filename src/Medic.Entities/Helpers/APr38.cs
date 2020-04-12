using AutoMapper;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class APr38
    {
        public APr38 Copy()
        {
            return base.Copy<APr38>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<APr38, CLPR.APr38>();

            expression.CreateMap<CLPR.APr38, APr38>()
                .ForMember(ap => ap.DecisionId, config => config.Ignore())
                .ForMember(ap => ap.CommissionApr, config => config.Ignore())
                .ForMember(ap => ap.Id, config => config.Ignore());
        }
    }
}
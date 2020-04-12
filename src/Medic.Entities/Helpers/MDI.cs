using AutoMapper;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class MDI
    {
        public MDI Copy()
        {
            return base.Copy<MDI>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<MDI, CLPR.MDI>();

            expression.CreateMap<CLPR.MDI, MDI>()
                .ForMember(m => m.DispObservation, config => config.Ignore())
                .ForMember(m => m.DispObservationId, config => config.Ignore())
                .ForMember(m => m.Id, config => config.Ignore());
        }
    }
}
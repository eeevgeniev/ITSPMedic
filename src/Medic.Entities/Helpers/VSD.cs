using AutoMapper;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class VSD
    {
        public VSD Copy()
        {
            return base.Copy<VSD>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<VSD, CLPR.VSD>();

            expression.CreateMap<CLPR.VSD, VSD>()
                .ForMember(m => m.DispObservation, config => config.Ignore())
                .ForMember(m => m.DispObservationId, config => config.Ignore())
                .ForMember(m => m.Id, config => config.Ignore());
        }
    }
}

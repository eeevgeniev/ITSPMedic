using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Marker
    {
        public Marker Copy()
        {
            return base.Copy<Marker>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Marker, CP.Marker>();

            expression.CreateMap<CP.Marker, Marker>()
                .ForMember(gm => gm.GenMarkerId, config => config.Ignore())
                .ForMember(gm => gm.GenMarker, config => config.Ignore())
                .ForMember(gm => gm.EvaluationId, config => config.Ignore())
                .ForMember(gm => gm.Evaluation, config => config.Ignore())
                .ForMember(gm => gm.Id, config => config.Ignore());
        }
    }
}
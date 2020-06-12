using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Resign
    {
        public Resign Copy()
        {
            return base.Copy<Resign>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Resign, CP.Resign>();

            expression.CreateMap<CP.Resign, Resign>()
                .ForMember(r => r.Id, config => config.Ignore())
                .ForMember(r => r.Out, config => config.Ignore());
        }
    }
}

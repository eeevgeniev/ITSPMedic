using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Redirected
    {
        public Redirected Copy()
        {
            return base.Copy<Redirected>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Redirected, CP.Redirected>();

            expression.CreateMap<CP.Redirected, Redirected>()
                .ForMember(r => r.Id, config => config.Ignore())
                .ForMember(r => r.Out, config => config.Ignore())
                .ForMember(r => r.PracticeId, config => config.Ignore())
                .ForMember(r => r.DiagnoseId, config => config.Ignore());
        }
    }
}

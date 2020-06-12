using AutoMapper;
using Medic.AppModels.Epicrisises;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Epicrisis
    {
        public Epicrisis Copy()
        {
            return base.Copy<Epicrisis>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Epicrisis, CP.Epicrisis>()
                    .ForMember(e => e.DateOfSurgeryAsString, config => config.Ignore());

            expression.CreateMap<CP.Epicrisis, Epicrisis>()
                    .ForMember(e => e.Out, config => config.Ignore())
                    .ForMember(e => e.Id, config => config.Ignore());

            expression.CreateMap<Epicrisis, EpicrisisSummaryViewModel>();
        }
    }
}

using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Choise
    {
        public Choise Copy()
        {
            return base.Copy<Choise>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Choise, CP.Choise>();

            expression.CreateMap<CP.Choise, Choise>()
                    .ForMember(c => c.Evaluation, config => config.Ignore())
                    .ForMember(c => c.EvaluationId, config => config.Ignore())
                    .ForMember(c => c.Id, config => config.Ignore());
        }
    }
}
using AutoMapper;
using Medic.AppModels.Choices;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Choice
    {
        public Choice Copy()
        {
            return base.Copy<Choice>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Choice, CP.Choice>();

            expression.CreateMap<CP.Choice, Choice>()
                    .ForMember(c => c.Evaluation, config => config.Ignore())
                    .ForMember(c => c.EvaluationId, config => config.Ignore())
                    .ForMember(c => c.Id, config => config.Ignore());

            expression.CreateMap<Choice, ChoicePreviewViewModel>();
        }
    }
}
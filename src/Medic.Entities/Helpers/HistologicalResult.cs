using AutoMapper;
using Medic.AppModels.HistologicalResult;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class HistologicalResult
    {
        public HistologicalResult Copy()
        {
            return base.Copy<HistologicalResult>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<HistologicalResult, CP.HistologicalResult>()
                .ForMember(hr => hr.DateAsString, config => config.Ignore());

            expression.CreateMap<CP.HistologicalResult, HistologicalResult>()
                .ForMember(hr => hr.Out, config => config.Ignore())
                .ForMember(hr => hr.Id, config => config.Ignore());

            expression.CreateMap<HistologicalResult, HistologicalResultSummaryViewModel>();
        }
    }
}

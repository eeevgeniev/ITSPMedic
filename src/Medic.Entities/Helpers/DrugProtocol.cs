using AutoMapper;
using Medic.AppModels.DrugProtocols;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class DrugProtocol
    {
        public DrugProtocol Copy()
        {
            return base.Copy<DrugProtocol>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DrugProtocol, CP.DrugProtocol>()
                .ForMember(dp => dp.TherapyType, config => config.MapFrom(d => d.TherapyType == default ? default : d.TherapyType.Code));

            expression.CreateMap<CP.DrugProtocol, DrugProtocol>()
                .ForMember(dp => dp.TherapyType, config => config.MapFrom(dp => new TherapyType() { Code = dp.TherapyType }))
                .ForMember(dp => dp.TherapyTypeId, config => config.Ignore())
                .ForMember(cp => cp.ProtocolDrugTherapy, config => config.Ignore())
                .ForMember(cp => cp.ProtocolDrugTherapyId, config => config.Ignore())
                .ForMember(dp => dp.Id, config => config.Ignore());

            expression.CreateMap<DrugProtocol, DrugProtocolPreviewViewModel>();
        }
    }
}

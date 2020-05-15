using AutoMapper;
using Medic.AppModels.AccompanyingDrugs;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class AccompanyingDrug {
        public AccompanyingDrug Copy()
        {
            return base.Copy<AccompanyingDrug>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<AccompanyingDrug, CP.AccompanyingDrug>()
                .ForMember(ad => ad.TherapyType, config => config.MapFrom(ad => ad.TherapyType == default ? default : ad.TherapyType.Code));

            expression.CreateMap<CP.AccompanyingDrug, AccompanyingDrug>()
                .ForMember(ad => ad.TherapyType, config => config.MapFrom(ad => new TherapyType() { Code = ad.TherapyType }))
                .ForMember(ad => ad.TherapyTypeId, config => config.Ignore())
                .ForMember(ad => ad.ProtocolDrugTherapy, config => config.Ignore())
                .ForMember(ad => ad.ProtocolDrugTherapyId, config => config.Ignore())
                .ForMember(ad => ad.Id, config => config.Ignore());

            expression.CreateMap<AccompanyingDrug, AccompanyingDrugPreviewViewModel>();
        }
    }
}
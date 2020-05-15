using AutoMapper;
using Medic.AppModels.HematologyParts;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class HematologyPart
    {
        public HematologyPart Copy()
        {
            return base.Copy<HematologyPart>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<HematologyPart, CP.HematologyPart>();

            expression.CreateMap<CP.HematologyPart, HematologyPart>()
                .ForMember(hp => hp.PredMarkerId, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapy, config => config.Ignore())
                .ForMember(hp => hp.Id, config => config.Ignore());

            expression.CreateMap<HematologyPart, HematologyPartPreviewViewModel>();
        }
    }
}
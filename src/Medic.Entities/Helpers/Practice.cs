using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Practice
    {
        public Practice Copy()
        {
            return base.Copy<Practice>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Practice, CP.Practice>()
                .ForMember(p => p.HealthRegion, config => config.MapFrom(p => p.HealthRegion == default ? default : p.HealthRegion.Code));

            expression.CreateMap<CP.Practice, Practice>()
                .ForMember(p => p.HealthRegion, config => config.MapFrom(p => new HealthRegion() { Code = p.HealthRegion }))
                .ForMember(p => p.HealthRegionId, config => config.Ignore())
                .ForMember(p => p.Code, config => config.Ignore())
                .ForMember(p => p.CPFiles, config => config.Ignore())
                .ForMember(p => p.HealthcarePractitioners, config => config.Ignore())
                .ForMember(p => p.HospitalPractices, config => config.Ignore())
                .ForMember(p => p.Id, config => config.Ignore());
        }
    }
}
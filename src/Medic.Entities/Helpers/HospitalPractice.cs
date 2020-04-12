using AutoMapper;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class HospitalPractice
    {
        public HospitalPractice Copy()
        {
            return base.Copy<HospitalPractice>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<HospitalPractice, CLPR.HospitalPractice>()
                .ForMember(hp => hp.HealthRegion, config => config.MapFrom(hp => hp.HealthRegion == default ? default : hp.HealthRegion.Code))
                .ForMember(hp => hp.FileType, config => config.MapFrom(hp => hp.FileType == default ? default : hp.FileType.Name))
                .ForMember(hp => hp.PracticeCode, config => config.MapFrom(hp => hp.Practice == default ? default : hp.Practice.Code))
                .ForMember(hp => hp.PracticeName, config => config.MapFrom(hp => hp.Practice == default ? default : hp.Practice.Name))
                .ForMember(hp => hp.DateFromAsString, config => config.Ignore())
                .ForMember(hp => hp.DateToAsString, config => config.Ignore());

            expression.CreateMap<CLPR.HospitalPractice, HospitalPractice>()
                .ForMember(hp => hp.HealthRegion, config => config.MapFrom(hp => hp.HealthRegion == default ? default : new HealthRegion() { Code = hp.HealthRegion }))
                .ForMember(hp => hp.Practice, config => config.MapFrom(hp => new Practice() { Code = hp.PracticeCode, Name = hp.PracticeName }))
                .ForMember(hp => hp.PracticeId, config => config.Ignore())
                .ForMember(hp => hp.HealthRegionId, config => config.Ignore())
                .ForMember(hp => hp.FileType, config => config.MapFrom(hp => hp.FileType == default ? default : new FileType() { Name = hp.FileType }))
                .ForMember(hp => hp.FileTypeId, config => config.Ignore())
                .ForMember(hp => hp.Id, config => config.Ignore());
        }
    }
}
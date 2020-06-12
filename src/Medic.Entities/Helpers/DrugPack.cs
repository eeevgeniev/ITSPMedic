using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class DrugPack
    {
        public DrugPack Copy()
        {
            return base.Copy<DrugPack>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DrugPack, CP.DrugPack>()
                    .ForMember(dp => dp.DrugDateAsString, config => config.Ignore());

            expression.CreateMap<CP.DrugPack, DrugPack>()
                    .ForMember(dp => dp.CPFile, config => config.Ignore())
                    .ForMember(dp => dp.CPFileId, config => config.Ignore())
                    .ForMember(dp => dp.HospitalPracticeId, config => config.Ignore())
                    .ForMember(dp => dp.HospitalPractice, config => config.Ignore())
                    .ForMember(dp => dp.Id, config => config.Ignore());
        }
    }
}

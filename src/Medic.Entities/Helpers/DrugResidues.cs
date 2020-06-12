using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class DrugResidue
    {
        public DrugResidue Copy()
        {
            return base.Copy<DrugResidue>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DrugResidue, CP.DrugResidue>()
                .ForMember(dr => dr.ExpiryDateAsString, config => config.Ignore())
                .ForMember(dr => dr.DrugDateAsString, config => config.Ignore());

            expression.CreateMap<CP.DrugResidue, DrugResidue>()
                .ForMember(dr => dr.Id, config => config.Ignore())
                .ForMember(dr => dr.CPFileId, config => config.Ignore())
                .ForMember(dr => dr.CPFile, config => config.Ignore())
                .ForMember(dr => dr.HospitalPracticeId, config => config.Ignore())
                .ForMember(dr => dr.HospitalPractice, config => config.Ignore());
        }
    }
}

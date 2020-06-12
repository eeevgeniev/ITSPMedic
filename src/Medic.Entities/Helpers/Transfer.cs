using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Transfer
    {
        public Transfer Copy()
        {
            return base.Copy<Transfer>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Transfer, CP.Transfer>()
                .ForMember(t => t.TransferDateTimeAsString, config => config.Ignore());

            expression.CreateMap<CP.Transfer, Transfer>()
                .ForMember(t => t.FirstMainDiagId, config => config.Ignore())
                .ForMember(t => t.SecondMainDiagId, config => config.Ignore())
                .ForMember(t => t.CPFileId, config => config.Ignore())
                .ForMember(t => t.CPFile, config => config.Ignore())
                .ForMember(t => t.HospitalPracticeId, config => config.Ignore())
                .ForMember(t => t.HospitalPractice, config => config.Ignore())
                .ForMember(t => t.Id, config => config.Ignore());
        }
    }
}

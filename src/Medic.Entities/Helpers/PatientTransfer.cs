using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class PatientTransfer
    {
        public PatientTransfer Copy()
        {
            return base.Copy<PatientTransfer>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<PatientTransfer, CP.PatientTransfer>()
                .ForMember(pt => pt.TransferDateTimeAsString, config => config.Ignore());

            expression.CreateMap<CP.PatientTransfer, PatientTransfer>()
                .ForMember(pt => pt.FirstMainDiagId, config => config.Ignore())
                .ForMember(pt => pt.SecondMainDiagId, config => config.Ignore())
                .ForMember(pt => pt.SecondMainDiag, config => config.Ignore())
                .ForMember(pt => pt.HospitalPracticeId, config => config.Ignore())
                .ForMember(pt => pt.HospitalPractice, config => config.Ignore())
                .ForMember(pt => pt.CPFileId, config => config.Ignore())
                .ForMember(pt => pt.CPFile, config => config.Ignore())
                .ForMember(pt => pt.Id, config => config.Ignore());
        }
    }
}

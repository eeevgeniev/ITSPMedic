using AutoMapper;
using Medic.AppModels.Transfers;
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

            expression.CreateMap<Transfer, PatientTransferPreviewViewModel>()
                .ForMember(ptvm => ptvm.MKBCode, config => config.MapFrom(icp => icp.FirstMainDiag.MKB.Code))
                .ForMember(ptvm => ptvm.MKBName, config => config.MapFrom(icp => icp.FirstMainDiag.MKB.Name));

            expression.CreateMap<Transfer, TransferViewModel>()
                .ForMember(tvm => tvm.CPFile, config => config.MapFrom(t => t.CPFile != default && t.CPFile.FileType != default ? t.CPFile.FileType.Name : default));

            expression.CreateMap<Transfer, TransferPreviewViewModel>()
                .ForMember(tpvm => tpvm.FirstMainDiagCode, config => config.MapFrom(t => t.FirstMainDiag != default && t.FirstMainDiag.MKB != default ? t.FirstMainDiag.MKB.Code : default))
                .ForMember(tpvm => tpvm.FirstMainDiagName, config => config.MapFrom(t => t.FirstMainDiag != default && t.FirstMainDiag.MKB != default ? t.FirstMainDiag.MKB.Name : default))
                .ForMember(tpvm => tpvm.SecondMainDiagCode, config => config.MapFrom(t => t.SecondMainDiag != default && t.SecondMainDiag.MKB != default ? t.SecondMainDiag.MKB.Code : default))
                .ForMember(tpvm => tpvm.SecondMainDiagName, config => config.MapFrom(t => t.SecondMainDiag != default && t.SecondMainDiag.MKB != default ? t.SecondMainDiag.MKB.Name : default));
        }
    }
}

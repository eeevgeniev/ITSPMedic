using AutoMapper;
using Medic.AppModels.ProtocolDrugTherapies;
using System.Linq;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class ProtocolDrugTherapy
    {
        public ProtocolDrugTherapy Copy()
        {
            return base.Copy<ProtocolDrugTherapy>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ProtocolDrugTherapy, CP.ProtocolDrugTherapy>()
                .ForMember(pdt => pdt.PatientBranch, config => config.MapFrom(pdt => pdt.PatientBranch == default && pdt.PatientBranch.HealthRegion == default ? default : pdt.PatientBranch.HealthRegion.Code))
                .ForMember(pdt => pdt.PatientHRegion, config => config.MapFrom(pdt => pdt.PatientHRegion == default ? default : pdt.PatientHRegion.Code))
                .ForMember(pdt => pdt.PracticeCode, config => config.MapFrom(pdt => pdt.Practice == default ? default : pdt.Practice.Code))
                .ForMember(pdt => pdt.PracticeName, config => config.MapFrom(pdt => pdt.Practice == default ? default : pdt.Practice.Name))
                .ForMember(pdt => pdt.PracticeRegion, config => config.MapFrom(pdt => pdt.Practice == default && pdt.Practice.HealthRegion == default ? default : pdt.Practice.HealthRegion.Code))
                .ForMember(pdt => pdt.Members, config => config.MapFrom(pdt => pdt.Members == default ? default : pdt.Members.Select(m => m.HealthcarePractitioner)))
                .ForMember(pdt => pdt.DecisionDateAsString, config => config.Ignore())
                .ForMember(pdt => pdt.ProtocolDateAsString, config => config.Ignore());

            expression.CreateMap<CP.ProtocolDrugTherapy, ProtocolDrugTherapy>()
                .ForMember(pdt => pdt.PatientBranch, config => config.MapFrom(pdt => pdt.PatientBranch == default ? default : new PatientBranch() { HealthRegion = new HealthRegion() { Code = pdt.PatientBranch } }))
                .ForMember(pdt => pdt.PatientBranchId, config => config.Ignore())
                .ForMember(pdt => pdt.PatientHRegion, config => config.MapFrom(pdt => pdt.PatientHRegion == default ? default : new HealthRegion() { Code = pdt.PatientHRegion }))
                .ForMember(pdt => pdt.PatientHRegionId, config => config.Ignore())
                .ForMember(
                    pdt => pdt.Practice,
                    config => config.MapFrom(pdt => pdt.PracticeCode == default ?
                    default :
                        new Practice()
                        {
                            Code = pdt.PracticeCode,
                            Name = pdt.PracticeName,
                            HealthRegion = new HealthRegion() { Code = pdt.PatientHRegion }
                        }))
                .ForMember(
                    pdt => pdt.Members,
                    config => config.MapFrom(pdt => pdt.Members == default ?
                    default :
                    pdt.Members.Select(c =>
                        new ProtocolDrugTherapyHealthPractitioner()
                        {
                            HealthcarePractitioner = new HealthcarePractitioner()
                            {
                                Name = c.DoctorName,
                                Speciality = new SpecialtyType() { SpecialtyCode = c.Speciality },
                                UniqueIdentifier = c.UniqueIdentifier
                            }
                        })))
                .ForMember(pdt => pdt.PracticeId, config => config.Ignore())
                .ForMember(pdt => pdt.CPFile, config => config.Ignore())
                .ForMember(pdt => pdt.CPFileId, config => config.Ignore())
                .ForMember(pdt => pdt.PatientId, config => config.Ignore())
                .ForMember(pdt => pdt.DiagId, config => config.Ignore())
                .ForMember(pdt => pdt.HematologyPartId, config => config.Ignore())
                .ForMember(pdt => pdt.ChemotherapyPartId, config => config.Ignore())
                .ForMember(pdt => pdt.ChairmanId, config => config.Ignore())
                .ForMember(pdt => pdt.HospitalPractice, config => config.Ignore())
                .ForMember(pdt => pdt.HospitalPracticeId, config => config.Ignore())
                .ForMember(pdt => pdt.Id, config => config.Ignore());

            expression.CreateMap<ProtocolDrugTherapy, PatientProtocolDrugTherapyPreviewViewModel>()
                .ForMember(ppdt => ppdt.MKBCode, config => config.MapFrom(pdt => pdt.Diag.MKB.Code))
                .ForMember(ppdt => ppdt.MKBName, config => config.MapFrom(pdt => pdt.Diag.MKB.Name));

            expression.CreateMap<ProtocolDrugTherapy, ProtocolDrugTherapyViewModel>()
                .ForMember(pdtvm => pdtvm.PatientBranch, config => config.MapFrom(pdt => pdt.PatientBranch != default && pdt.PatientBranch.HealthRegion != default ? pdt.PatientBranch.HealthRegion.Name : default))
                .ForMember(pdtvm => pdtvm.PatientHRegion, config => config.MapFrom(pdt => pdt.PatientHRegion != default ? pdt.PatientHRegion.Name : default))
                .ForMember(pdtvm => pdtvm.CPFile, config => config.MapFrom(pdt => pdt.CPFile != default && pdt.CPFile.FileType != default ? pdt.CPFile.FileType.Name : default));
        }
    }
}

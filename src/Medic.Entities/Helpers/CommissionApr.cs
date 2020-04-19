using AutoMapper;
using Medic.AppModels.CommissionAprs;
using System.Linq;
using CLPR = Medic.Models.CLPR;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class CommissionApr
    {
        public CommissionApr Copy()
        {
            return base.Copy<CommissionApr>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<CommissionApr, CLPR.CommissionApr>()
                .ForMember(ca => ca.PatientBranch, config => config.MapFrom(ca => ca.PatientBranch == default ? default : ca.PatientBranch.Code))
                .ForMember(ca => ca.PatientHRegion, config => config.MapFrom(ca => ca.PatientHRegion == default ? default : ca.PatientHRegion.Code))
                .ForMember(ca => ca.Members, config => config.MapFrom(
                    ca => ca.Members == default ? default : ca.Members.Select(
                        m => new CP.Member()
                        {
                            DoctorName = m.HealthcarePractitioner.Name,
                            Speciality = m.HealthcarePractitioner.Speciality == default ? default : m.HealthcarePractitioner.Speciality.SpecialtyCode,
                            UniqueIdentifier = m.HealthcarePractitioner.UniqueIdentifier
                        })
                    .ToList()
                    ))
                .ForMember(ca => ca.DecisionDateAsString, config => config.Ignore())
                .ForMember(ca => ca.DiagDateAsString, config => config.Ignore());

            expression.CreateMap<CLPR.CommissionApr, CommissionApr>()
                .ForMember(ca => ca.PatientBranch, config => config.MapFrom(ca => ca.PatientBranch == default ? default :  new PatientBranch() { Code = ca.PatientBranch }))
                .ForMember(ca => ca.PatientHRegion, config => config.MapFrom(ca => ca.PatientHRegion == default ? default : new HealthRegion() { Code = ca.PatientHRegion }))
                .ForMember(ca => ca.Members, config => config.MapFrom(ca => 
                    ca.Members.Select(m => new CommissionAprHealthcarePractitioner() 
                    { 
                        HealthcarePractitioner = new HealthcarePractitioner() { Name = m.DoctorName } 
                    })
                    .ToList()
                    ))
                .ForMember(ca => ca.PatientId, config => config.Ignore())
                .ForMember(ca => ca.PatientBranchId, config => config.Ignore())
                .ForMember(ca => ca.PatientHRegionId, config => config.Ignore())
                .ForMember(ca => ca.SenderId, config => config.Ignore())
                .ForMember(ca => ca.ChairmanId, config => config.Ignore())
                .ForMember(ca => ca.MainDiagId, config => config.Ignore())
                .ForMember(ca => ca.HospitalPracticeId, config => config.Ignore())
                .ForMember(ca => ca.HospitalPractice, config => config.Ignore())
                .ForMember(ca => ca.APr38Id, config => config.Ignore())
                .ForMember(ca => ca.APr05Id, config => config.Ignore())
                .ForMember(ca => ca.Id, config => config.Ignore());

            expression.CreateMap<CommissionApr, PatientCommissionAprPreviewViewModel>()
                .ForMember(pca => pca.MKBCode, config => config.MapFrom(ca => ca.MainDiag.MKB.Code))
                .ForMember(pca => pca.MKBName, config => config.MapFrom(ca => ca.MainDiag.MKB.Name));
        }
    }
}

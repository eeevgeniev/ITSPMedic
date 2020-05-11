using AutoMapper;
using Medic.AppModels.InClinicProcedures;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class InClinicProcedure
    {
        public InClinicProcedure Copy()
        {
            return base.Copy<InClinicProcedure>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<InClinicProcedure, CLPR.InClinicProcedure>()
                .ForMember(icp => icp.PatientBranch, config => config.MapFrom(icp => icp.PatientBranch == default && icp.PatientBranch.HealthRegion == default ? default : icp.PatientBranch.HealthRegion.Code))
                .ForMember(icp => icp.PatientHRegion, config => config.MapFrom(icp => icp.PatientHealthRegion == default ? default : icp.PatientHealthRegion.Code))
                .ForMember(icp => icp.MainDiag1, config => config.MapFrom(icp => icp.FirstMainDiag))
                .ForMember(icp => icp.MainDiag2, config => config.MapFrom(icp => icp.SecondMainDiag))
                .ForMember(icp => icp.DateSendAsString, config => config.Ignore())
                .ForMember(icp => icp.FirstVisitDateAsString, config => config.Ignore())
                .ForMember(icp => icp.PlanVisitDateAsString, config => config.Ignore());

            expression.CreateMap<CLPR.InClinicProcedure, InClinicProcedure>()
                .ForMember(icp => icp.PatientBranch, config => config.MapFrom(icp => new PatientBranch() { HealthRegion = new HealthRegion() { Code = icp.PatientBranch } }))
                .ForMember(icp => icp.PatientBranchId, config => config.Ignore())
                .ForMember(icp => icp.PatientHealthRegion, config => config.MapFrom(icp => icp.PatientHRegion == default ? default : new HealthRegion() { Code = icp.PatientHRegion }))
                .ForMember(icp => icp.PatientHealthRegionId, config => config.Ignore())
                .ForMember(icp => icp.FirstMainDiag, config => config.MapFrom(icp => icp.MainDiag1))
                .ForMember(icp => icp.FirstMainDiagId, config => config.Ignore())
                .ForMember(icp => icp.SecondMainDiag, config => config.MapFrom(icp => icp.MainDiag2))
                .ForMember(icp => icp.SecondMainDiagId, config => config.Ignore())
                .ForMember(icp => icp.HospitalPractice, config => config.Ignore())
                .ForMember(icp => icp.HospitalPracticeId, config => config.Ignore())
                .ForMember(icp => icp.PatientId, config => config.Ignore())
                .ForMember(icp => icp.SenderId, config => config.Ignore())
                .ForMember(icp => icp.CeasedClinicalPathId, config => config.Ignore())
                .ForMember(icp => icp.Id, config => config.Ignore());

            expression.CreateMap<InClinicProcedure, PatientInClinicProcedurePreviewViewModel>()
                .ForMember(pip => pip.MKBCode, config => config.MapFrom(icp => icp.FirstMainDiag.MKB.Code))
                .ForMember(pip => pip.MKBName, config => config.MapFrom(icp => icp.FirstMainDiag.MKB.Name));

            expression.CreateMap<InClinicProcedure, InClinicProcedureViewModel>()
                .ForMember(icpvm => icpvm.PatientBranch, config => config.MapFrom(icp => icp.PatientBranch == default && icp.PatientBranch.HealthRegion == default ? default : icp.PatientBranch.HealthRegion.Name))
                .ForMember(icpvm => icpvm.PatientHealthRegion, config => config.MapFrom(icp => icp.PatientHealthRegion == default ? default : icp.PatientHealthRegion.Name))
                .ForMember(icpvm => icpvm.PatientStatus, config => config.MapFrom(icp => icp.PacientStatus));
        }
    }
}
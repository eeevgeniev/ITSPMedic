using AutoMapper;
using Medic.AppModels.DispObservations;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class DispObservation
    {
        public DispObservation Copy()
        {
            return base.Copy<DispObservation>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DispObservation, CLPR.DispObservation>()
                .ForMember(disp => disp.PatientBranch, config => config.MapFrom(disp => disp.PatientBranch == default ? default : disp.PatientBranch.Code))
                .ForMember(disp => disp.PatientHRegion, config => config.MapFrom(disp => disp.PatientHRegion == default ? default : disp.PatientHRegion.Code))
                .ForMember(disp => disp.DispDateAsString, config => config.Ignore())
                .ForMember(disp => disp.DispTimeAsString, config => config.Ignore())
                .ForMember(disp => disp.DiagDateAsString, config => config.Ignore())
                .ForMember(disp => disp.DispancerDateAsString, config => config.Ignore());
            
            expression.CreateMap<CLPR.DispObservation, DispObservation>()
                .ForMember(disp => disp.PatientBranch, config => config.MapFrom(disp => disp.PatientBranch == default ? default : new PatientBranch() { Code = disp.PatientBranch }))
                .ForMember(disp => disp.PatientHRegion, config => config.MapFrom(disp => disp.PatientHRegion == default ? default : new HealthRegion() { Code = disp.PatientHRegion }))
                .ForMember(disp => disp.PatientId, config => config.Ignore())
                .ForMember(disp => disp.PatientBranchId, config => config.Ignore())
                .ForMember(disp => disp.PatientHRegionId, config => config.Ignore())
                .ForMember(disp => disp.SenderId, config => config.Ignore())
                .ForMember(disp => disp.DoctorId, config => config.Ignore())
                .ForMember(disp => disp.MainDiagFirstId, config => config.Ignore())
                .ForMember(disp => disp.MainDiagSecondId, config => config.Ignore())
                .ForMember(disp => disp.HospitalPracticeId, config => config.Ignore())
                .ForMember(disp => disp.HospitalPractice, config => config.Ignore())
                .ForMember(disp => disp.Id, config => config.Ignore());

            expression.CreateMap<DispObservation, PatientDispObservationPreviewViewModel>()
                .ForMember(pdisp => pdisp.MKBCode, config => config.MapFrom(disp => disp.FirstMainDiag.MKB.Code))
                .ForMember(pdisp => pdisp.MKBName, config => config.MapFrom(disp => disp.FirstMainDiag.MKB.Name));
        }
    }
}
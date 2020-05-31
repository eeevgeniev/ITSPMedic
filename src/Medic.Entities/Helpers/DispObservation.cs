using AutoMapper;
using Medic.AppModels.DispObservations;
using System.ComponentModel;
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
                .ForMember(disp => disp.PatientBranch, config => config.MapFrom(disp => disp.PatientBranch == default && disp.PatientBranch.HealthRegion == default ? default : disp.PatientBranch.HealthRegion.Code))
                .ForMember(disp => disp.PatientHRegion, config => config.MapFrom(disp => disp.PatientHRegion == default ? default : disp.PatientHRegion.Code))
                .ForMember(disp => disp.DispDateAsString, config => config.Ignore())
                .ForMember(disp => disp.DispTimeAsString, config => config.Ignore())
                .ForMember(disp => disp.DiagDateAsString, config => config.Ignore())
                .ForMember(disp => disp.DispanserDateAsString, config => config.Ignore());
            
            expression.CreateMap<CLPR.DispObservation, DispObservation>()
                .ForMember(disp => disp.PatientBranch, config => config.MapFrom(disp => disp.PatientBranch == default ? default : new PatientBranch() { HealthRegion = new HealthRegion() { Code = disp.PatientBranch } }))
                .ForMember(disp => disp.PatientHRegion, config => config.MapFrom(disp => disp.PatientHRegion == default ? default : new HealthRegion() { Code = disp.PatientHRegion }))
                .ForMember(disp => disp.PatientId, config => config.Ignore())
                .ForMember(disp => disp.PatientBranchId, config => config.Ignore())
                .ForMember(disp => disp.PatientHRegionId, config => config.Ignore())
                .ForMember(disp => disp.DoctorId, config => config.Ignore())
                .ForMember(disp => disp.MainDiagFirstId, config => config.Ignore())
                .ForMember(disp => disp.MainDiagSecondId, config => config.Ignore())
                .ForMember(disp => disp.HospitalPracticeId, config => config.Ignore())
                .ForMember(disp => disp.HospitalPractice, config => config.Ignore())
                .ForMember(disp => disp.Id, config => config.Ignore());

            expression.CreateMap<DispObservation, PatientDispObservationPreviewViewModel>()
                .ForMember(pdisp => pdisp.MKBCode, config => config.MapFrom(disp => disp.FirstMainDiag.MKB.Code))
                .ForMember(pdisp => pdisp.MKBName, config => config.MapFrom(disp => disp.FirstMainDiag.MKB.Name));

            expression.CreateMap<DispObservation, DispObservationViewModel>()
                .ForMember(dovm => dovm.PatientBranch, config => config.MapFrom(disp => disp.PatientBranch != default && disp.PatientBranch.HealthRegion != default ? disp.PatientBranch.HealthRegion.Name : default))
                .ForMember(dovm => dovm.PatientHRegion, config => config.MapFrom(disp => disp.PatientHRegion != default ? disp.PatientHRegion.Name : default));

            expression.CreateMap<DispObservation, DispObservationPreviewViewModel>()
                .ForMember(dovm => dovm.FirstMainDiagCode, config => config.MapFrom(disp => disp.FirstMainDiag != default && disp.FirstMainDiag.MKB != default ? disp.FirstMainDiag.MKB.Code : default))
                .ForMember(dovm => dovm.FirstMainDiagName, config => config.MapFrom(disp => disp.FirstMainDiag != default && disp.FirstMainDiag.MKB != default ? disp.FirstMainDiag.MKB.Name : default))
                .ForMember(dovm => dovm.SecondMainDiagCode, config => config.MapFrom(disp => disp.SecondMainDiag != default && disp.SecondMainDiag.MKB != default ? disp.SecondMainDiag.MKB.Code : default))
                .ForMember(dovm => dovm.SecondMainDiagName, config => config.MapFrom(disp => disp.SecondMainDiag != default && disp.SecondMainDiag.MKB != default ? disp.SecondMainDiag.MKB.Name : default));
        }
    }
}
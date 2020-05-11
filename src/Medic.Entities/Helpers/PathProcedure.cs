using AutoMapper;
using Medic.AppModels.PathProcedures;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class PathProcedure
    {
        public PathProcedure Copy()
        {
            return base.Copy<PathProcedure>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<PathProcedure, CLPR.PathProcedure>()
                .ForMember(pp => pp.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch == default && pp.PatientBranch.HealthRegion == default ? default : pp.PatientBranch.HealthRegion.Code))
                .ForMember(pp => pp.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion == default ? default : pp.PatientHRegion.Code))
                .ForMember(pp => pp.Patient, config => config.MapFrom(pp => pp.Patient))
                .ForMember(pp => pp.MainDiag1, config => config.MapFrom(pp => pp.FirstMainDiag))
                .ForMember(pp => pp.MainDiag2, config => config.MapFrom(pp => pp.SecondMainDiag))
                .ForMember(pp => pp.PatientStatus, config => config.MapFrom(pp => pp.PatientStatus))
                .ForMember(pp => pp.DateSendAsString, config => config.Ignore())
                .ForMember(pp => pp.DateProcedureBegins, config => config.Ignore())
                .ForMember(pp => pp.DateProcedureBeginsAsString, config => config.Ignore())
                .ForMember(pp => pp.FirstVisitDateAsString, config => config.Ignore())
                .ForMember(pp => pp.DatePlanPriemAsString, config => config.Ignore())
                .ForMember(pp => pp.DateProcedureEndAsString, config => config.Ignore());

            expression.CreateMap<CLPR.PathProcedure, PathProcedure>()
                .ForMember(pp => pp.PatientBranch, config => config.MapFrom(pp => new PatientBranch() { HealthRegion = new HealthRegion() { Code = pp.PatientBranch } }))
                .ForMember(pp => pp.PatientBranchId, config => config.Ignore())
                .ForMember(pp => pp.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion == default ? default : new HealthRegion() { Code = pp.PatientHRegion }))
                .ForMember(pp => pp.PatientHRegionId, config => config.Ignore())
                .ForMember(pp => pp.FirstMainDiag, config => config.MapFrom(pp => pp.MainDiag1))
                .ForMember(pp => pp.FirstMainDiagId, config => config.Ignore())
                .ForMember(pp => pp.SecondMainDiag, config => config.MapFrom(pp => pp.MainDiag2))
                .ForMember(pp => pp.SecondMainDiagId, config => config.Ignore())
                .ForMember(pp => pp.HospitalPractice, config => config.Ignore())
                .ForMember(pp => pp.HospitalPracticeId, config => config.Ignore())
                .ForMember(pp => pp.PatientId, config => config.Ignore())
                .ForMember(pp => pp.SenderId, config => config.Ignore())
                .ForMember(pp => pp.CeasedClinicalPathId, config => config.Ignore())
                .ForMember(pp => pp.UsedDrugId, config => config.Ignore())
                .ForMember(pp => pp.CeasedProcedureId, config => config.Ignore())
                .ForMember(pp => pp.Id, config => config.Ignore());

            expression.CreateMap<PathProcedure, PatientPathProcedurePreviewViewModel>()
                .ForMember(ppp => ppp.MKBCode, config => config.MapFrom(pp => pp.FirstMainDiag.MKB.Code))
                .ForMember(ppp => ppp.MKBName, config => config.MapFrom(pp => pp.FirstMainDiag.MKB.Name));

            expression.CreateMap<PathProcedure, PathProcedureViewModel>()
                .ForMember(ppvm => ppvm.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch != default && pp.PatientBranch.HealthRegion != default ? pp.PatientBranch.HealthRegion.Name : default))
                .ForMember(ppvm => ppvm.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion != default ? pp.PatientHRegion.Name : default));
        }
    }
}
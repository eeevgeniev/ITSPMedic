using AutoMapper;
using Medic.AppModels.PlannedProcedures;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class PlannedProcedure
    {
        public PlannedProcedure Copy()
        {
            return base.Copy<PlannedProcedure>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<PlannedProcedure, CP.PlannedProcedure>()
                .ForMember(pp => pp.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch == default && pp.PatientBranch.HealthRegion == default ? default : pp.PatientBranch.HealthRegion.Code))
                .ForMember(pp => pp.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion == default ? default : pp.PatientHRegion.Code))
                .ForMember(pp => pp.ExaminationDateAsString, config => config.Ignore())
                .ForMember(pp => pp.PlannedEntryDateAsString, config => config.Ignore())
                .ForMember(pp => pp.SendDateAsString, config => config.Ignore());

            expression.CreateMap<CP.PlannedProcedure, PlannedProcedure>()
                .ForMember(pp => pp.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch == default ? default : new PatientBranch() { HealthRegion = new HealthRegion() { Code = pp.PatientBranch } }))
                .ForMember(pp => pp.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion == default ? default : new HealthRegion() { Code = pp.PatientHRegion }))
                .ForMember(pp => pp.PatientId, config => config.Ignore())
                .ForMember(pp => pp.PatientBranchId, config => config.Ignore())
                .ForMember(pp => pp.PatientHRegionId, config => config.Ignore())
                .ForMember(pp => pp.SenderId, config => config.Ignore())
                .ForMember(pp => pp.SendDiagnoseId, config => config.Ignore())
                .ForMember(pp => pp.DiagnoseId, config => config.Ignore())
                .ForMember(pp => pp.CPFileId, config => config.Ignore())
                .ForMember(pp => pp.CPFile, config => config.Ignore())
                .ForMember(pp => pp.Id, config => config.Ignore());

            expression.CreateMap<PlannedProcedure, PatientPlannedProcedurePreviewViewModel>()
                .ForMember(ppp => ppp.MKBCode, config => config.MapFrom(pp => pp.Diagnose.Primary.Code))
                .ForMember(ppp => ppp.MKBName, config => config.MapFrom(pp => pp.Diagnose.Primary.Name));
        }
    }
}
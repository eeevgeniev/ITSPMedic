using AutoMapper;
using Medic.AppModels.Outs;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Out
    {
        public Out Copy()
        {
            return base.Copy<Out>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Out, CP.Out>()
                .ForMember(o => o.PatientBranch, config => config.MapFrom(o => o.PatientBranch == default ? default : o.PatientBranch.Code))
                .ForMember(o => o.PatientHRegion, config => config.MapFrom(o => o.PatientHRegion == default ? default : o.PatientHRegion.Code))
                .ForMember(o => o.SendDiagnose, config => config.MapFrom(o => o.SendDiagnose))
                .ForMember(o => o.Diagnoses, config => config.MapFrom(o => o.Diagnoses))
                .ForMember(o => o.OutDiagnoses, config => config.MapFrom(o => o.OutDiagnoses))
                .ForMember(o => o.SendDateAsString, config => config.Ignore())
                .ForMember(o => o.ExaminationDateAsString, config => config.Ignore())
                .ForMember(o => o.EntryDateAsString, config => config.Ignore())
                .ForMember(o => o.OutDateAsString, config => config.Ignore())
                .ForMember(o => o.HLDateFromAsString, config => config.Ignore());

            expression.CreateMap<CP.Out, Out>()
                .ForMember(o => o.PatientBranch, config => config.MapFrom(o => new PatientBranch() { Code = o.PatientBranch }))
                .ForMember(o => o.PatientBranchId, config => config.Ignore())
                .ForMember(o => o.PatientHRegion, config => config.MapFrom(o => new HealthRegion() { Code = o.PatientHRegion }))
                .ForMember(o => o.SendDiagnose, config => config.MapFrom(o => o.SendDiagnose))
                .ForMember(o => o.SendDiagnoseId, config => config.Ignore())
                .ForMember(o => o.OutDiagnoses, config => config.MapFrom(o => o.OutDiagnoses))
                .ForMember(o => o.Diagnoses, config => config.MapFrom(o => o.Diagnoses))
                .ForMember(o => o.CPFile, config => config.Ignore())
                .ForMember(o => o.CPFileId, config => config.Ignore())
                .ForMember(o => o.PatientId, config => config.Ignore())
                .ForMember(o => o.PatientHRegionId, config => config.Ignore())
                .ForMember(o => o.SenderId, config => config.Ignore())
                .ForMember(o => o.DeadId, config => config.Ignore())
                .ForMember(o => o.OutMainDiagnoseId, config => config.Ignore())
                .ForMember(o => o.EpicrisisId, config => config.Ignore())
                .ForMember(o => o.HistologicalResultId, config => config.Ignore())
                .ForMember(o => o.UsedDrugId, config => config.Ignore())
                .ForMember(o => o.Id, config => config.Ignore());

            expression.CreateMap<Out, PatientOutPreviewViewModel>()
                .ForMember(po => po.MKBCode, config => config.MapFrom(o => o.OutMainDiagnose.Primary.Code))
                .ForMember(po => po.MKBName, config => config.MapFrom(o => o.OutMainDiagnose.Primary.Name));
        }
    }
}
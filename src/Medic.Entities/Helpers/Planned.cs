using AutoMapper;
using Medic.AppModels.Plannings;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Planned
    {
        public Planned Copy()
        {
            return base.Copy<Planned>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Planned, CP.Planned>()
                .ForMember(pp => pp.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch == default && pp.PatientBranch.HealthRegion == default ? default : pp.PatientBranch.HealthRegion.Code))
                .ForMember(pp => pp.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion == default ? default : pp.PatientHRegion.Code))
                .ForMember(pp => pp.ExaminationDateAsString, config => config.Ignore())
                .ForMember(pp => pp.PlannedEntryDateAsString, config => config.Ignore())
                .ForMember(pp => pp.SendDateAsString, config => config.Ignore());

            expression.CreateMap<CP.Planned, Planned>()
                .ForMember(pp => pp.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch == default ? default : new PatientBranch() { HealthRegion = new HealthRegion() { Code = pp.PatientBranch } }))
                .ForMember(pp => pp.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion == default ? default : new HealthRegion() { Code = pp.PatientHRegion }))
                .ForMember(pp => pp.PatientId, config => config.Ignore())
                .ForMember(pp => pp.PatientBranchId, config => config.Ignore())
                .ForMember(pp => pp.PatientHRegionId, config => config.Ignore())
                .ForMember(pp => pp.SenderId, config => config.Ignore())
                .ForMember(pp => pp.CPFileId, config => config.Ignore())
                .ForMember(pp => pp.CPFile, config => config.Ignore())
                .ForMember(pp => pp.Id, config => config.Ignore());

            expression.CreateMap<Planned, PatientPlannedPreviewViewModel>();

            expression.CreateMap<Planned, PlannedViewModel>()
                .ForMember(ppvm => ppvm.PatientBranch, config => config.MapFrom(pp => pp.PatientBranch != default && pp.PatientBranch.HealthRegion != default ? pp.PatientBranch.HealthRegion.Name : default))
                .ForMember(ppvm => ppvm.PatientHRegion, config => config.MapFrom(pp => pp.PatientHRegion != default ? pp.PatientHRegion.Name : default));

            expression.CreateMap<Planned, PlannedPreviewViewModel>();
        }
    }
}
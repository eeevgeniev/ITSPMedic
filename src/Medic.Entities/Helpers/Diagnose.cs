using AutoMapper;
using Medic.AppModels.Diagnoses;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Diagnose
    {
        public Diagnose Copy()
        {
            return base.Copy<Diagnose>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Diagnose, CP.Diagnose>()
                .ForMember(d => d.Primary, config => config.MapFrom(d => d.Primary == default ? default : d.Primary.Code))
                .ForMember(d => d.Secondary, config => config.MapFrom(d => d.Secondary == default ? default : d.Secondary.Code));

            expression.CreateMap<Diagnose, CP.Dead>()
                .ForMember(d => d.Primary, config => config.MapFrom(d => d.Primary == default ? default : d.Primary.Code));

            expression.CreateMap<Diagnose, CP.SendDiagnose>()
                .ForMember(sd => sd.Primary, config => config.MapFrom(d => d.Primary == default ? default : d.Primary.Code))
                .ForMember(sd => sd.Secondary, config => config.MapFrom(d => d.Secondary == default ? default : d.Secondary.Code));

            expression.CreateMap<Diagnose, CP.OutMainDiagnose>()
                .ForMember(omd => omd.Primary, config => config.MapFrom(d => d.Primary == default ? default : d.Primary.Code))
                .ForMember(omd => omd.Secondary, config => config.MapFrom(d => d.Secondary == default ? default : d.Secondary.Code));

            expression.CreateMap<Diagnose, CP.OutDiagnose>()
                .ForMember(od => od.Primary, config => config.MapFrom(d => d.Primary == default ? default : d.Primary.Code))
                .ForMember(od => od.Secondary, config => config.MapFrom(d => d.Secondary == default ? default : d.Secondary.Code));

            expression.CreateMap<CP.Diagnose, Diagnose>()
                .ForMember(d => d.SendIn, config => config.Ignore())
                .ForMember(d => d.SendInId, config => config.Ignore())
                .ForMember(d => d.Primary, config => config.MapFrom(d => d.Primary == default ? default : new MKB() { Code = d.Primary }))
                .ForMember(d => d.PrimaryCode, config => config.MapFrom(d => d.Primary == default ? default : d.Primary))
                .ForMember(d => d.Secondary, config => config.MapFrom(d => d.Secondary == default ? default : new MKB() { Code = d.Secondary }))
                .ForMember(d => d.SecondaryCode, config => config.MapFrom(d => d.Secondary == default ? default : d.Secondary))
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.InId, config => config.Ignore())
                .ForMember(d => d.SendOutId, config => config.Ignore())
                .ForMember(d => d.SendOut, config => config.Ignore())
                .ForMember(d => d.Out, config => config.Ignore())
                .ForMember(d => d.OutId, config => config.Ignore())
                .ForMember(d => d.OutDead, config => config.Ignore())
                .ForMember(d => d.OutMain, config => config.Ignore())
                .ForMember(d => d.OutOut, config => config.Ignore())
                .ForMember(d => d.OutOutId, config => config.Ignore())
                .ForMember(d => d.SendPlanned, config => config.Ignore())
                .ForMember(d => d.SendPlannedId, config => config.Ignore())
                .ForMember(d => d.Planned, config => config.Ignore())
                .ForMember(d => d.PlannedId, config => config.Ignore())
                .ForMember(d => d.Redirected, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<CP.Dead, Diagnose>()
                .ForMember(d => d.SendIn, config => config.Ignore())
                .ForMember(d => d.SendInId, config => config.Ignore())
                .ForMember(d => d.Primary, config => config.MapFrom(d => d.Primary == default ? default : new MKB() { Code = d.Primary }))
                .ForMember(d => d.PrimaryCode, config => config.MapFrom(d => d.Primary == default ? default : d.Primary))
                .ForMember(d => d.Secondary, config => config.Ignore())
                .ForMember(d => d.SecondaryCode, config => config.Ignore())
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.InId, config => config.Ignore())
                .ForMember(d => d.SendOutId, config => config.Ignore())
                .ForMember(d => d.SendOut, config => config.Ignore())
                .ForMember(d => d.Out, config => config.Ignore())
                .ForMember(d => d.OutId, config => config.Ignore())
                .ForMember(d => d.OutDead, config => config.Ignore())
                .ForMember(d => d.OutMain, config => config.Ignore())
                .ForMember(d => d.OutOut, config => config.Ignore())
                .ForMember(d => d.OutOutId, config => config.Ignore())
                .ForMember(d => d.SendPlanned, config => config.Ignore())
                .ForMember(d => d.SendPlannedId, config => config.Ignore())
                .ForMember(d => d.Planned, config => config.Ignore())
                .ForMember(d => d.PlannedId, config => config.Ignore())
                .ForMember(d => d.Secondary, config => config.Ignore())
                .ForMember(d => d.Redirected, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<CP.OutDiagnose, Diagnose>()
                .ForMember(d => d.SendIn, config => config.Ignore())
                .ForMember(d => d.SendInId, config => config.Ignore())
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.Primary, config => config.MapFrom(od => od.Primary == default ? default : new MKB() { Code = od.Primary }))
                .ForMember(d => d.PrimaryCode, config => config.MapFrom(od => od.Primary == default ? default : od.Primary))
                .ForMember(d => d.Secondary, config => config.MapFrom(od => od.Secondary == default ? default : new MKB() { Code = od.Secondary }))
                .ForMember(d => d.SecondaryCode, config => config.MapFrom(od => od.Secondary == default ? default : od.Secondary))
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.InId, config => config.Ignore())
                .ForMember(d => d.SendOut, config => config.Ignore())
                .ForMember(d => d.SendOutId, config => config.Ignore())
                .ForMember(d => d.Out, config => config.Ignore())
                .ForMember(d => d.OutId, config => config.Ignore())
                .ForMember(d => d.OutDead, config => config.Ignore())
                .ForMember(d => d.OutMain, config => config.Ignore())
                .ForMember(d => d.OutOut, config => config.Ignore())
                .ForMember(d => d.OutOutId, config => config.Ignore())
                .ForMember(d => d.SendPlanned, config => config.Ignore())
                .ForMember(d => d.SendPlannedId, config => config.Ignore())
                .ForMember(d => d.Planned, config => config.Ignore())
                .ForMember(d => d.PlannedId, config => config.Ignore())
                .ForMember(d => d.Redirected, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<CP.SendDiagnose, Diagnose>()
                .ForMember(d => d.SendIn, config => config.Ignore())
                .ForMember(d => d.SendInId, config => config.Ignore())
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.Primary, config => config.MapFrom(sd => sd.Primary == default ? default : new MKB() { Code = sd.Primary }))
                .ForMember(d => d.PrimaryCode, config => config.MapFrom(sd => sd.Primary == default ? default : sd.Primary))
                .ForMember(d => d.Secondary, config => config.MapFrom(sd => sd.Secondary == default ? default : new MKB() { Code = sd.Secondary }))
                .ForMember(d => d.SecondaryCode, config => config.MapFrom(sd => sd.Secondary == default ? default : sd.Secondary))
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.InId, config => config.Ignore())
                .ForMember(d => d.SendOut, config => config.Ignore())
                .ForMember(d => d.SendOutId, config => config.Ignore())
                .ForMember(d => d.Out, config => config.Ignore())
                .ForMember(d => d.OutId, config => config.Ignore())
                .ForMember(d => d.OutDead, config => config.Ignore())
                .ForMember(d => d.OutMain, config => config.Ignore())
                .ForMember(d => d.OutOut, config => config.Ignore())
                .ForMember(d => d.OutOutId, config => config.Ignore())
                .ForMember(d => d.SendPlanned, config => config.Ignore())
                .ForMember(d => d.SendPlannedId, config => config.Ignore())
                .ForMember(d => d.Planned, config => config.Ignore())
                .ForMember(d => d.PlannedId, config => config.Ignore())
                .ForMember(d => d.Redirected, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<CP.OutMainDiagnose, Diagnose>()
                .ForMember(d => d.SendIn, config => config.Ignore())
                .ForMember(d => d.SendInId, config => config.Ignore())
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.Primary, config => config.MapFrom(omd => omd.Primary == default ? default : new MKB() { Code = omd.Primary }))
                .ForMember(d => d.PrimaryCode, config => config.MapFrom(omd => omd.Primary == default ? default : omd.Primary))
                .ForMember(d => d.Secondary, config => config.MapFrom(omd => omd.Secondary == default ? default : new MKB() { Code = omd.Secondary }))
                .ForMember(d => d.SecondaryCode, config => config.MapFrom(omd => omd.Secondary == default ? default : omd.Secondary))
                .ForMember(d => d.In, config => config.Ignore())
                .ForMember(d => d.InId, config => config.Ignore())
                .ForMember(d => d.SendOut, config => config.Ignore())
                .ForMember(d => d.SendOutId, config => config.Ignore())
                .ForMember(d => d.Out, config => config.Ignore())
                .ForMember(d => d.OutId, config => config.Ignore())
                .ForMember(d => d.OutDead, config => config.Ignore())
                .ForMember(d => d.OutMain, config => config.Ignore())
                .ForMember(d => d.OutOut, config => config.Ignore())
                .ForMember(d => d.OutOutId, config => config.Ignore())
                .ForMember(d => d.SendPlanned, config => config.Ignore())
                .ForMember(d => d.SendPlannedId, config => config.Ignore())
                .ForMember(d => d.Planned, config => config.Ignore())
                .ForMember(d => d.PlannedId, config => config.Ignore())
                .ForMember(d => d.Redirected, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<Diagnose, DiagnosePreviewViewModel>()
                .ForMember(dpvm => dpvm.Name, config => config.MapFrom(d => d.Primary.Name))
                .ForMember(dpvm => dpvm.Code, config => config.MapFrom(d => d.Primary.Code));
        }
    }
}
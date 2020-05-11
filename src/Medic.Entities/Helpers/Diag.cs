using AutoMapper;
using Medic.AppModels.Diags;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Diag
    {
        public Diag Copy()
        {
            return base.Copy<Diag>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Diag, CP.Diag>()
                .ForMember(d => d.MKB, config => config.MapFrom(d => d.MKB == default? default : d.MKB.Code))
                .ForMember(d => d.LinkDMKB, config => config.MapFrom(d => d.LinkDMKB == default ? default: d.LinkDMKB.Code));
            
            expression.CreateMap<Diag, CP.AddDiag>()
                .ForMember(d => d.MKB, config => config.MapFrom(d => d.MKB == default ? default : d.MKB.Code));

            expression.CreateMap<CP.Diag, Diag>()
                .ForMember(d => d.ChemotherapyPart, config => config.Ignore())
                .ForMember(d => d.MKBCode, config => config.MapFrom(d => d.MKB))
                .ForMember(d => d.MKB, config => config.MapFrom(d => d.MKB == default ? default : new MKB() { Code = d.MKB }))
                .ForMember(d => d.LinkDMKBCode, config => config.MapFrom(d => d.LinkDMKB))
                .ForMember(d => d.LinkDMKB, config => config.MapFrom(d => d.LinkDMKB == default ? default : new MKB() { Code = d.LinkDMKB }))
                .ForMember(d => d.FirstInClinicProcedure, config => config.Ignore())
                .ForMember(d => d.SecondInClinicProcedure, config => config.Ignore())
                .ForMember(d => d.FirstPathProcedure, config => config.Ignore())
                .ForMember(d => d.SecondPathProcedure, config => config.Ignore())
                .ForMember(d => d.ProtocolDrugTherapy, config => config.Ignore())
                .ForMember(d => d.CommissionAprMain, config => config.Ignore())
                .ForMember(d => d.CommissionAprId, config => config.Ignore())
                .ForMember(d => d.CommissionApr, config => config.Ignore())
                .ForMember(d => d.FirstDispObservation, config => config.Ignore())
                .ForMember(d => d.SecondDispObservation, config => config.Ignore())
                .ForMember(d => d.FirstPatientTransfer, config => config.Ignore())
                .ForMember(d => d.SecondPatientTransfer, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<CP.AddDiag, Diag>()
                .ForMember(d => d.LinkDName, config => config.Ignore())
                .ForMember(d => d.LinkDMKB, config => config.Ignore())
                .ForMember(d => d.LinkDMKBCode, config => config.Ignore())
                .ForMember(d => d.MKBCode, config => config.MapFrom(d => d.MKB))
                .ForMember(d => d.MKB, config => config.MapFrom(d => d.MKB == default ? default : new MKB() { Code = d.MKB }))
                .ForMember(d => d.ChemotherapyPart, config => config.Ignore())
                .ForMember(d => d.FirstInClinicProcedure, config => config.Ignore())
                .ForMember(d => d.SecondInClinicProcedure, config => config.Ignore())
                .ForMember(d => d.FirstPathProcedure, config => config.Ignore())
                .ForMember(d => d.SecondPathProcedure, config => config.Ignore())
                .ForMember(d => d.ProtocolDrugTherapy, config => config.Ignore())
                .ForMember(d => d.CommissionAprMain, config => config.Ignore())
                .ForMember(d => d.CommissionAprId, config => config.Ignore())
                .ForMember(d => d.CommissionApr, config => config.Ignore())
                .ForMember(d => d.FirstDispObservation, config => config.Ignore())
                .ForMember(d => d.SecondDispObservation, config => config.Ignore())
                .ForMember(d => d.FirstPatientTransfer, config => config.Ignore())
                .ForMember(d => d.SecondPatientTransfer, config => config.Ignore())
                .ForMember(d => d.Id, config => config.Ignore());

            expression.CreateMap<Diag, DiagPreviewViewModel>()
                .ForMember(dpvm => dpvm.Code, config => config.MapFrom(d => d.MKB == default ? default : d.MKB.Code))
                .ForMember(dpvm => dpvm.Name, config => config.MapFrom(d => d.MKB == default ? default : d.MKB.Name));
        }
    }
}
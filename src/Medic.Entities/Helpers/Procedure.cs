using AutoMapper;
using CLPR = Medic.Models.CLPR;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Procedure
    {
        public Procedure Copy()
        {
            return base.Copy<Procedure>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Procedure, CP.Procedure>()
                .ForMember(p => p.OutHosp, config => config.MapFrom(p => p.OutHospital))
                .ForMember(p => p.DateAsString, config => config.Ignore())
                .ForMember(p => p.HLDateFromAsString, config => config.Ignore());

            expression.CreateMap<Procedure, CLPR.DoneNewProcedure>()
                .ForMember(dnp => dnp.ProcedureCode, config => config.MapFrom(p => p.Code))
                .ForMember(dnp => dnp.ProcedureDate, config => config.MapFrom(p => p.Date))
                .ForMember(dnp => dnp.ProcedureDateAsString, config => config.Ignore());

            expression.CreateMap<CP.Procedure, Procedure>()
                .ForMember(p => p.OutHospital, config => config.MapFrom(p => p.OutHosp))
                .ForMember(p => p.ACHICode, config => config.Ignore())
                .ForMember(p => p.Out, config => config.Ignore())
                .ForMember(p => p.OutId, config => config.Ignore())
                .ForMember(p => p.PathProcedure, config => config.Ignore())
                .ForMember(p => p.PathProcedureId, config => config.Ignore())
                .ForMember(p => p.ImplantId, config => config.Ignore())
                .ForMember(p => p.Id, config => config.Ignore());

            expression.CreateMap<CLPR.DoneNewProcedure, Procedure>()
                .ForMember(p => p.Code, config => config.MapFrom(dnp => dnp.ProcedureCode))
                .ForMember(p => p.Date, config => config.MapFrom(dnp => dnp.ProcedureDate))
                .ForMember(p => p.OutHospital, config => config.Ignore())
                .ForMember(p => p.Implant, config => config.Ignore())
                .ForMember(p => p.Out, config => config.Ignore())
                .ForMember(p => p.OutId, config => config.Ignore())
                .ForMember(p => p.PathProcedure, config => config.Ignore())
                .ForMember(p => p.PathProcedureId, config => config.Ignore())
                .ForMember(p => p.ImplantId, config => config.Ignore())

                .ForMember(p => p.BedDays, config => config.Ignore())
                .ForMember(p => p.HLDateFrom, config => config.Ignore())
                .ForMember(p => p.HLNumber, config => config.Ignore())
                .ForMember(p => p.HLTotalDays, config => config.Ignore())
                .ForMember(p => p.StateAtDischarge, config => config.Ignore())
                .ForMember(p => p.Laparoscopic, config => config.Ignore())
                .ForMember(p => p.PathologicFinding, config => config.Ignore())
                .ForMember(p => p.EndCourse, config => config.Ignore())
                .ForMember(p => p.SendAPr, config => config.Ignore())
                .ForMember(p => p.InAPr, config => config.Ignore())

                .ForMember(p => p.Id, config => config.Ignore());
        }
    }
}
using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Patient
    {
        public Patient Copy()
        {
            return base.Copy<Patient>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Patient, CP.Patient>()
                .ForMember(p => p.Sex, config => config.MapFrom(p => p.Sex == default ? -1 : p.Sex.Id - 1))
                .ForMember(pp => pp.BirthDateAsString, config => config.Ignore())
                .ForMember(pp => pp.DateToAsString, config => config.Ignore());

            expression.CreateMap<CP.Patient, Patient>()
                .ForMember(p => p.Sex, config => config.MapFrom(p => new Sex() { Id = p.Sex + 1 }))
                .ForMember(p => p.SexId, config => config.Ignore())
                .ForMember(p => p.Ins, config => config.Ignore())
                .ForMember(p => p.InClinicProcedures, config => config.Ignore())
                .ForMember(p => p.Outs, config => config.Ignore())
                .ForMember(p => p.PathProcedures, config => config.Ignore())
                .ForMember(p => p.ProtocolDrugTherapies, config => config.Ignore())
                .ForMember(p => p.CommissionAprs, config => config.Ignore())
                .ForMember(p => p.DispObservations, config => config.Ignore())
                .ForMember(p => p.PlannedProcedures, config => config.Ignore())
                .ForMember(p => p.Id, config => config.Ignore());
        }
    }
}

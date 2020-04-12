using AutoMapper;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class DoneProcedure
    {
        public DoneProcedure Copy()
        {
            return base.Copy<DoneProcedure>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DoneProcedure, CLPR.DoneProcedure>()
                .ForMember(dp => dp.ProcedureDateAsString, config => config.Ignore())
                .ForMember(dp => dp.TimeBegin, config => config.Ignore())
                .ForMember(dp => dp.TimeEnd, config => config.Ignore());
            
            expression.CreateMap<CLPR.DoneProcedure, DoneProcedure>()
                .ForMember(dp => dp.DoctorId, config => config.Ignore())
                .ForMember(dp => dp.Doctor, config => config.Ignore())
                .ForMember(dp => dp.PathProcedureId, config => config.Ignore())
                .ForMember(dp => dp.PathProcedure, config => config.Ignore())
                .ForMember(dp => dp.Id, config => config.Ignore());
        }
    }
}

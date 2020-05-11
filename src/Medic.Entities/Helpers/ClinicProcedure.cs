using AutoMapper;
using Medic.AppModels.ClinicProcedures;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class ClinicProcedure
    {
        public ClinicProcedure Copy()
        {
            return base.Copy<ClinicProcedure>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ClinicProcedure, CLPR.ClinicProcedure>()
                .ForMember(cp => cp.ProcedureDateAsString, config => config.Ignore());

            expression.CreateMap<CLPR.ClinicProcedure, ClinicProcedure>()
                .ForMember(cp => cp.PathProcedure, config => config.Ignore())
                .ForMember(cp => cp.PathProcedureId, config => config.Ignore())
                .ForMember(cp => cp.Id, config => config.Ignore());

            expression.CreateMap<ClinicProcedure, ClinicProcedureViewModel>();
        }
    }
}
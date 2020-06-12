using AutoMapper;
using System.Runtime.CompilerServices;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class ClinicChemotherapyPart
    {
        public ClinicChemotherapyPart Copy()
        {
            return base.Copy<ClinicChemotherapyPart>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ClinicChemotherapyPart, CLPR.ClinicChemotherapyPart>();

            expression.CreateMap<CLPR.ClinicChemotherapyPart, ClinicChemotherapyPart>()
                .ForMember(ccp => ccp.EvalutionId, config => config.Ignore())
                .ForMember(ccp => ccp.APr05s, config => config.Ignore())
                .ForMember(ccp => ccp.DecisionId, config => config.Ignore())
                .ForMember(ccp => ccp.Id, config => config.Ignore());
        }
    }
}
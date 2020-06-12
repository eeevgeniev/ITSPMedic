using AutoMapper;
using Medic.AppModels.CeasedClinicals;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class CeasedClinical {
        
        public CeasedClinical Copy()
        {
            return base.Copy<CeasedClinical>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<CeasedClinical, CLPR.CeasedClinical>();

            expression.CreateMap<CLPR.CeasedClinical, CeasedClinical>()
                    .ForMember(ccp => ccp.PathProcedurePath, config => config.Ignore())
                    .ForMember(ccp => ccp.PathProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.CeasedOnlyPathProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.CeasedClinicalPathInClinicProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.CeasedProcedureInClinicProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.CeasedOnlyInClinicProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.Id, config => config.Ignore());

            expression.CreateMap<CeasedClinical, CeasedClinicalViewModel>();
        }
    }
}
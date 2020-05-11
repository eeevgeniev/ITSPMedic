using AutoMapper;
using Medic.AppModels.CeasedClinicalPaths;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class CeasedClinicalPath {
        
        public CeasedClinicalPath Copy()
        {
            return base.Copy<CeasedClinicalPath>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<CeasedClinicalPath, CLPR.CeasedClinicalPath>();

            expression.CreateMap<CLPR.CeasedClinicalPath, CeasedClinicalPath>()
                    .ForMember(ccp => ccp.PathProcedurePath, config => config.Ignore())
                    .ForMember(ccp => ccp.PathProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.InClinicProcedure, config => config.Ignore())
                    .ForMember(ccp => ccp.Id, config => config.Ignore());

            expression.CreateMap<CeasedClinicalPath, CeasedClinicalPathViewModel>();
        }
    }
}
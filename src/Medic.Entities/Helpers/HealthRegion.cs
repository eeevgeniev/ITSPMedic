using AutoMapper;
using Medic.AppModels.HealthRegions;

namespace Medic.Entities
{
    public partial class HealthRegion
    {
        public HealthRegion Copy()
        {
            return base.Copy<HealthRegion>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<HealthRegion, HealthRegionOption>();
        }
    }
}
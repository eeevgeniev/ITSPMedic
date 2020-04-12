using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class GenMarker
    {
        public GenMarker Copy()
        {
            return base.Copy<GenMarker>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<GenMarker, CP.GenMarker>();

            expression.CreateMap<CP.GenMarker, GenMarker>()
                .ForMember(gm => gm.ChemotherapyPartId, config => config.Ignore())
                .ForMember(gm => gm.ChemotherapyPart, config => config.Ignore())
                .ForMember(gm => gm.Id, config => config.Ignore());
        }
    }
}
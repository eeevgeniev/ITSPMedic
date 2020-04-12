using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Histology
    {
        public Histology Copy()
        {
            return base.Copy<Histology>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Histology, CP.Histology>();

            expression.CreateMap<CP.Histology, Histology>()
                .ForMember(h => h.ChemotherapyParts, config => config.Ignore())
                .ForMember(h => h.APr05, config => config.Ignore())
                .ForMember(h => h.Id, config => config.Ignore());
        }
    }
}

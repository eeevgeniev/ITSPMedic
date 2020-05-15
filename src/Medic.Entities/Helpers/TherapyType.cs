using AutoMapper;
using Medic.AppModels.TherapyTypes;

namespace Medic.Entities
{
    public partial class TherapyType
    {
        public TherapyType Copy()
        {
            return base.Copy<TherapyType>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<TherapyType, TherapyTypePreviewViewModel>();
        }
    }
}
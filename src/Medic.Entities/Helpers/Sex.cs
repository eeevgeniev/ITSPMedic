using AutoMapper;
using Medic.AppModels.Sexes;

namespace Medic.Entities
{
    public partial class Sex
    {
        public Sex Copy()
        {
            return base.Copy<Sex>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Sex, SexOption>();
        }
    }
}
using AutoMapper;

namespace Medic.Mappers.Contracts
{
    public interface IModelTransformer
    {
        void ConfigureTransformations(IMapperConfigurationExpression expression);
    }
}

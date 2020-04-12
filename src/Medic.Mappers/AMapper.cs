using AutoMapper;
using Medic.Mappers.Contracts;

namespace Medic.Mappers
{
    public class AMapper : IMappable
    {
        private readonly IMapper Mapper;

        public AMapper(MapperConfiguration configuration)
        {
            Mapper = configuration.CreateMapper();
        }
        
        public TResult Map<TResult, TSource>(TSource source)
        {
            return Mapper.Map<TResult>(source);
        }
    }
}
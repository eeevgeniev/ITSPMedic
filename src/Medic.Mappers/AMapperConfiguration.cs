using AutoMapper;
using Medic.Mappers.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Medic.Mappers
{
    public class AMapperConfiguration
    {
        public MapperConfiguration CreateConfiguration()
        {
            Type transformer = typeof(IModelTransformer);

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.IsClass && transformer.IsAssignableFrom(t))
                    .ToList()
                    .ForEach(modelTransformer =>
                    {
                        if (modelTransformer.GetConstructors().Any(c => c.GetParameters().Length == 0))
                        {
                            if (Activator.CreateInstance(modelTransformer) is IModelTransformer currentModelTransformer)
                            {
                                currentModelTransformer.ConfigureTransformations(cfg);
                                return;
                            }
                        }

                        throw new InvalidOperationException(nameof(modelTransformer.FullName));
                    });
            });

            configuration.AssertConfigurationIsValid();

            return configuration;
        }
    }
}
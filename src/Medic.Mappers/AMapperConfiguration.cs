using AutoMapper;
using Medic.Mappers.Contracts;
using System;
using System.Linq;

namespace Medic.Mappers
{
    public class AMapperConfiguration
    {
        public MapperConfiguration CreateConfiguration()
        {
            Type transformer = typeof(IModelTransformer);

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                var a = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(a => a.FullName.Contains("Medic"))
                    .ToList();

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
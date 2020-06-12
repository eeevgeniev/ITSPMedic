using Medic.Contexts.Contracts;
using Medic.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Medic.Contexts.Seeders
{
    public class MedicContextSeeder : IMedicContextSeeder
    {
        private readonly MedicContext MedicContext;

        public MedicContextSeeder(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
        }

        public void Seed()
        {
            MedicContext.Database.EnsureCreated();

            bool isSpecialtyInserted = MedicContext.SpecialtyTypes.Any();
            bool isRegionsInserted = MedicContext.HealthRegions.Any();
            bool isSexesInserted = MedicContext.Sexes.Any();
            bool isMKBInserted = MedicContext.MKBs.Any();

            if (!isSexesInserted)
            {
                foreach (Sex sex in GetElementsFromFile<Sex>(Path.Combine("./Resources/sexes.json")))
                {
                    MedicContext.Sexes.Add(sex);

                    MedicContext.SaveChanges();
                }
            }

            if (!isSpecialtyInserted)
            {
                MedicContext.SpecialtyTypes
                    .AddRange(GetElementsFromFile<SpecialtyType>(Path.Combine("./Resources/specialtytypes.json")));
            }

            if (!isRegionsInserted)
            {
                MedicContext.HealthRegions
                    .AddRange(GetElementsFromFile<HealthRegion>(Path.Combine("./Resources/healthRegions.json")));
            }

            if (!isMKBInserted)
            {
                MedicContext.MKBs
                    .AddRange(GetElementsFromFile<MKB>(Path.Combine("./Resources/mkbs.json")));
            }

            if (!isSpecialtyInserted || !isRegionsInserted || !isMKBInserted)
            {
                MedicContext.SaveChanges();
            }
        }

        private List<T> GetElementsFromFile<T>(string path) where T : class
        {
            string filePath = Path.GetFullPath(path);
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(nameof(path));
            }

            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }
    }
}
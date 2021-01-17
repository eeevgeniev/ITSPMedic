using Medic.AppModels.AccompanyingDrugs;
using Medic.AppModels.ChemotherapyParts;
using Medic.AppModels.DrugProtocols;
using Medic.Lookups.Contracts;
using Medic.Lookups.Enums;
using System;
using System.Collections.Generic;

namespace Medic.Lookups.Resolvers
{
    public class EnumResolver : IEnumResolver
    {
        private static Dictionary<string, Type> _enumsByName = new Dictionary<string, Type>()
        {
            { nameof(DrugProtocolPreviewViewModel), typeof(ProtocolDrugTherapyTypesEnum)},
            { nameof(AccompanyingDrugPreviewViewModel), typeof(AccompanyingDrugTherapyTypesEnum)},
            { nameof(ChemotherapyPartPreviewViewModel), typeof(ChemotherapyPartTherapyTypesEnum) }
        };
        
        public string GetEnumValue<T>(int value) where T : Enum =>
            GetEnumValue(typeof(T), value);

        public string GetEnumValueByType(Type type, int value)
        {
            if (typeof(Enum).IsAssignableFrom(type))
            {
                return GetEnumValue(type, value);
            }

            return value.ToString();
        }
            
        public Type GetEnumByModel(string modelName)
        {
            if (_enumsByName.TryGetValue(modelName, out Type value))
            {
                return value;
            }

            return null;
        }

        private string GetEnumValue(Type type, int value) => 
            Enum.IsDefined(type, value) ? Enum.GetName(type, value) : value.ToString();
    }
}

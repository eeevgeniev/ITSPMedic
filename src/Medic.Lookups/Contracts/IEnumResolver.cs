using System;

namespace Medic.Lookups.Contracts
{
    public interface IEnumResolver
    {
        string GetEnumValue<T>(int value) where T : Enum;

        string GetEnumValueByType(Type type, int value);

        Type GetEnumByModel(string modelName);
    }
}

using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Medic.EHRBuilders.Base
{
    public abstract class DataValueBuilder : IDataValueBuilder
    {
        protected bool _isDisposed = false;
        
        public abstract IDataValueBuilder AddNullFlavor(CS cs);

        public abstract void Dispose();

        public abstract DataValue Build();

        protected virtual T DeepCopy<T>(T value) where T : DataValue
        {
            if (value == default)
            {
                throw new ArgumentNullException(nameof(T));
            }

            using MemoryStream memoryStream = new MemoryStream();

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(memoryStream, value);

            memoryStream.Position = 0;

            T deepCopy = binaryFormatter.Deserialize(memoryStream) as T;

            if (deepCopy != default)
            {
                return deepCopy;
            }

            throw new InvalidCastException(nameof(deepCopy));
        }

        protected virtual T ResetValue<T>() where T : DataValue, new()
        {
            return new T();
        }
    }
}

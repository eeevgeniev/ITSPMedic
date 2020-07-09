using Medic.EHR.DataTypes.Base;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Medic.EHRBuilders.Base
{
    public abstract class DataValueBuilder
    {
        protected bool _isDisposed = false;
        
        public abstract void Dispose();

        protected virtual T DeepClone<T>(T value) where T : class
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

        protected virtual T ResetValue<T>() where T : new()
        {
            return new T();
        }
    }
}

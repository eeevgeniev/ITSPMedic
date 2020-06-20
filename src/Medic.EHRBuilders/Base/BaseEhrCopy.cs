using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Medic.EHRBuilders.Base
{
    public abstract class BaseEhrCopy
    {
        protected T CreateDeepCopy<T>(T element) where T : class
        {
            if (element == default)
            {
                return default;
            }

            using MemoryStream memoryStream = new MemoryStream();

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(memoryStream, element);

            memoryStream.Position = 0;

            T result = binaryFormatter.Deserialize(memoryStream) as T;

            if (result == default)
            {
                throw new InvalidOperationException(nameof(element));
            }

            return result;
        }
    }
}
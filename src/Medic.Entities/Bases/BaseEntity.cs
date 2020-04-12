using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Medic.Entities.Bases
{
    [Serializable]
    public abstract class BaseEntity
    {
        protected T Copy<T>(T entity) where T : BaseEntity
        {
            if (entity == default)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T copy;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, entity);

                memoryStream.Position = 0;

                copy = (T)binaryFormatter.Deserialize(memoryStream);
            }

            return copy;
        }
    }
}
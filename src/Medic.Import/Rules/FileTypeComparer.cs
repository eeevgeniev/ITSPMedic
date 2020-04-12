using Medic.Entities;
using System;
using System.Collections.Generic;

namespace Medic.Import.Rules
{
    internal class FileTypeComparer : IEqualityComparer<FileType>
    {
        public bool Equals(FileType x, FileType y)
        {
            if (x == default && y == default)
            {
                return true;
            }
            else if (x == default || y == default)
            {
                return false;
            }

            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(FileType obj)
        {
            if (obj == default)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Name.GetHashCode();
        }
    }
}

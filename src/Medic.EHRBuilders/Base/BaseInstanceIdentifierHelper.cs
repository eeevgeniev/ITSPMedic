using System;

namespace Medic.EHRBuilders.Base
{
    public abstract class BaseInstanceIdentifierHelper : BaseEhrCopy
    {
        private protected void ValidateInstanceIdentifierValues(string rootName, string extension, string identifierName)
        {
            if (string.IsNullOrWhiteSpace(rootName))
            {
                throw new ArgumentException(nameof(rootName));
            }

            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentException(nameof(extension));
            }

            if (string.IsNullOrWhiteSpace(identifierName))
            {
                throw new ArgumentException(nameof(identifierName));
            }
        }
    }
}

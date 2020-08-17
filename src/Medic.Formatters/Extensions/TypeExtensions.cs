using System;

namespace Medic.Formatters.Extensions
{
    public static class TypeExtensions
    {
        public static string GetNameWithoutGeneric(this Type type)
        {
            if (type == default)
            {
                return default;
            }

            int position = type.Name.IndexOf('`');

            return position < 0 ? type.Name : type.Name.Substring(0, position);
        }
    }
}

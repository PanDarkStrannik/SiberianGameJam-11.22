using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static class IEnumerableUtils
    {
        public static bool HasElement<T>(this IEnumerable<T> someEnumerable, Type elementType)
        {
            return someEnumerable.Any(e => e.GetType() == elementType);
        }

        public static bool TryGet<T>(this ICollection<T> someCollection, Type elementType, out T element)
        {
            element = default;
            var hasElement = someCollection.HasElement(elementType);
            if (!hasElement)
                return false;

            element = someCollection.First(someElement => someElement.GetType() == elementType);
            return true;
        }
    }
}
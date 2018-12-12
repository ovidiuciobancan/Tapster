using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils.Extensions
{
    public static class CollectionExtensionMethods
    {
        /// <summary>
        /// Concatenates items from IEnumerable with separator and format
        /// </summary>
        public static string Join<T>(this IEnumerable<T> value, string separator = ",", string formatter = "{0}")
        {
            if (value == null || !value.Any())
            {
                return string.Empty;
            }

            return value
                .Select(x => string.Format(formatter, x))
                .Aggregate((i, j) => i + separator + j);
        }
        public static IEnumerable<T> Union<T>(this IEnumerable<T> first, T second)
        {
            return first.Union(new List<T> { second });
        }
        public static void Replace<T, U>(this List<T> collection, T element, Func<T, U> predicate)
            where T : class
        {
            var elementToReplace = collection.FirstOrDefault(p => predicate(p).Equals(predicate(element)));
            if(elementToReplace != null)
            {
                collection[collection.IndexOf(elementToReplace)] = element;
            }
        }
        public static Task ForEachAsync<T>(this IEnumerable<T> sequence, Func<T, Task> action)
        {
            return Task.WhenAll(sequence.Select(action));
        }
    }
}
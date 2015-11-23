using System;
using System.Collections.Generic;
using System.Linq;
namespace JustinStanley.Extensions
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// returns whether or not an item in a "Search List" esits in an IEnumerable<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="searchList"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this IEnumerable<T> list, IEnumerable<T> searchList)
        {
            return list.Any(x => searchList.Any(y => x.Equals(y)));
        }
        /// <summary>
        /// returns whether or not an IEnumerable<typeparamref name="T"/> contains an item that starts with a particular string />
        /// </summary>
        /// <param name="s"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool StartsWithAny(this string s, IEnumerable<string> items)
        {
            return items.Any(i => s.StartsWith(i));
        }

    }
}

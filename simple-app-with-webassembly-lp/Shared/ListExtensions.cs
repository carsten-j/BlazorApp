using System;
using System.Collections.Generic;
using System.Linq;

namespace BellyBox.Shared
{
    public static class ListExtensions
    {
        static public bool ContainsAll<T, TKey>(this List<T> list, List<T> subList, Func<T, TKey> keySelector)
        {
            var listOfKeys = new HashSet<TKey>(list.Select(keySelector));
            return subList.All(x => listOfKeys.Contains(keySelector(x)));
        }
        static public bool ContainsAll<T>(this List<T> list, List<T> subList) => list.ContainsAll(subList, item => item);
    }
}

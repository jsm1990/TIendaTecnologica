using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica
{
    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, Predicate<T> oldItemSelector, T newItem)
        {
            var oldItemIndex = list.FindIndex(oldItemSelector);
            list[oldItemIndex] = newItem;
        }
    }
}

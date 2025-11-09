using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Implementation.Config.Abstraction;

public static class CollectionExtensions
{
    public static T SelectRandom<T>(this IList<T> collection)
    {
        if (collection.Count == 0) throw new ArgumentException("Collection is empty.");

        return collection[Random.Shared.Next(collection.Count)];
    }
}

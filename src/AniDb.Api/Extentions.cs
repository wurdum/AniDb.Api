using System.Collections.Generic;
using System.Linq;

namespace AniDb.Api
{
    public static class Extentions
    {
         public static bool SafeSequenceEqual<T>(this IEnumerable<T> self, IEnumerable<T> other) {
             if (self == null && other == null)
                 return true;

             return self.SequenceEqual(other);
         }
    }
}
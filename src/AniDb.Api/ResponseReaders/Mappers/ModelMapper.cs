using System.Collections.Generic;
using System.Linq;

namespace AniDb.Api.ResponseReaders.Mappers
{
    public abstract class ModelMapper<T, K>
    {
        public abstract T Map(K a);

        protected T[] ArrayOrEmpty<T>(IEnumerable<T> collection) {
            return collection == null ? new T[0] : collection.ToArray();
        }
    }
}
using System;
using System.Collections.Concurrent;

namespace BananaTheGame
{
    public class Dictionary2<T> : ConcurrentDictionary<long, T>
    {
        const long size = Int32.MaxValue;

        public long KeyFromCoords(int x, int z)
        {
            return (long)(x + (z * size));
        }

        //prefer to let the key calculation inlined here
        public virtual T this[int x, int z]
        {
            get
            {
                T outVal = default(T);
                TryGetValue((long)(x + (z * size)), out outVal);
                return outVal;
            }
            set
            {
                long key = (long)(x + (z * size));

                this[key] = value;
            }
        }

        public virtual bool TryGetValue(Vector2Int coord, out T outVal)
        {
            outVal = default(T);
            return TryGetValue(coord.X, coord.Z, out outVal);
        }

        public virtual bool TryGetValue(int x, int z, out T outVal)
        {
            outVal = default(T);
            return TryGetValue(KeyFromCoords(x, z), out outVal);
        }

        public virtual void Remove(int x, int z)
        {
            T removed;
            TryRemove(KeyFromCoords(x, z), out removed);
        }

        public virtual bool TryRemove(int x, int z)
        {
            T removed;
            return TryRemove(KeyFromCoords(x, z), out removed);
        }
    }
}

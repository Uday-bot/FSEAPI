using System;
using System.Collections.Generic;
using System.Text;

namespace FSEFinalTaskUnitTest
{
    public class SimpleCache<T>
    {
        private readonly List<T> cache = new List<T>();

        public void Add(T item)
        {
            if (!Contains(item))
                cache.Add(item);
        }

        public bool Contains(T item)
        {
            return cache.Contains(item);
        }
    }


    public class SimpleCacheDict<T>
    {
        private readonly Dictionary<T, T> cache = new Dictionary<T, T>();

        public void Add(T item)
        {
            if (!Contains(item))
                cache.Add(item, item);
        }

        public bool Contains(T item)
        {
            return cache.ContainsKey(item);
        }
    }
}

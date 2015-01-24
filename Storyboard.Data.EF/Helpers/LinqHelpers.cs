using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.EF.Helpers
{
    public static class LinqHelpers
    {
        public static IEnumerable<HashSet<T>>Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            HashSet<T> chunk = new HashSet<T>();

            foreach (T item in source)
            {
                chunk.Add(item);

                if (chunk.Count >= chunkSize)
                {
                    yield return chunk;
                    chunk = new HashSet<T>();
                }
            }
            if (chunk.Count > 0)
            {
                yield return chunk;
            }
        }
    }
}

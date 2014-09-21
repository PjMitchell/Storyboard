using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.Helpers
{
    public static class LinqHelpers
    {
        public static IEnumerable<IEnumerable<T>>Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            List<T> chunk = new List<T>(chunkSize);

            foreach (T item in source)
            {
                chunk.Add(item);

                if (chunk.Count >= chunkSize)
                {
                    yield return chunk;
                    chunk = new List<T>(chunkSize);
                }
            }
            if (chunk.Count > 0)
            {
                yield return chunk;
            }
        }
    }
}

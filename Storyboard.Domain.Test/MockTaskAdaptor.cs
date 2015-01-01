using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Test
{
    public class MockTaskAdaptor
    {
        public static Task<T> MockTaskResult<T>(Func<T> mockfunction)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(mockfunction.Invoke());
            return tcs.Task;
        }
    }
}

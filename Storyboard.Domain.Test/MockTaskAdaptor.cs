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

        public static Task MockTaskAction(Action mockfunction)
        {
            mockfunction.Invoke();
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        public static Task MockTaskAction()
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

    }
}

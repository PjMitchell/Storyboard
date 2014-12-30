using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Web.Tests.Helpers
{
    public class HttpTestHelper
    {
        public static T GetHttpMessAgeContent<T>(HttpResponseMessage message)
        {
            var content = (ObjectContent<T>)message.Content;
            return (T)content.Value;
        }
    }
}

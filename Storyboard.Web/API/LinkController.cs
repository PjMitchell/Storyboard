using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Storyboard.Web.API
{
    /// <summary>
    /// Link Crud
    /// </summary>
    public class LinkController : ApiController
    {
        private ILinkDataService dataService;
        
        public LinkController(ILinkDataService dataService)
        {
            this.dataService = dataService;
        }
        
        // GET: api/Link
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Link/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Link
        public void Post([FromBody]CreateLinkCommand command)
        {
            dataService.Add(command);
        }

        // PUT: api/Link/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Link/5
        //public void Delete(int id)
        //{
        //}
    }
}

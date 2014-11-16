using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using Storyboard.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Storyboard.Web.API
{
    public class StoryOverviewController : ApiController
    {
        private readonly IStoryRepository repository;
        private readonly IStoryReadService storyReadService;
        
        public StoryOverviewController(IStoryReadService storyReadService, IStoryRepository repository)
        {
            this.repository = repository;
            this.storyReadService = storyReadService;
        }

        // GET api/StoryOverview
        public IEnumerable<StorySummary> Get()
        {
            return storyReadService.GetStorySummaries();
        }
              
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/StoryOverview
        public void Post([FromBody]AddUpdateStoryCommand addUpdateStoryCommand)
        {
            repository.AddOrUpdate(addUpdateStoryCommand);
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/StoryOverview/5
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        
    }
}
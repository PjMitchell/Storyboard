using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Web.Models.Home;
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
        
        public StoryOverviewController(IStoryRepository repository)
        {
            this.repository = repository;
        }

        // GET api/StoryOverview
        public IEnumerable<StoryOverviewSummary> Get()
        {
            return repository.Get().Select(MapToOverviewSummary);
        }

        private StoryOverviewSummary MapToOverviewSummary(Story arg)
        {
            return new StoryOverviewSummary
                {
                    Id = arg.Id,
                    Synopsis = arg.Synopsis,
                    Title = arg.Title
                };
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

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
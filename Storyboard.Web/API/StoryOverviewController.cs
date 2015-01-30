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
using System.Threading.Tasks;
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
        public async Task<List<StorySummary>> Get()
        {
            var result = await storyReadService.GetStorySummaries();
            return result;
        }

        // GET api/StoryOverview/5
        public async Task<StoryOverview> Get(int id)
        {
            return await storyReadService.GetStoryOverview(id);
        }

        //// POST api/StoryOverview
        public async Task Post([FromBody]AddUpdateStoryCommand addUpdateStoryCommand)
        {
            await repository.Add(addUpdateStoryCommand);
        }

        // PUT api/<controller>/5
        public Task Put(int id, [FromBody]AddUpdateStoryCommand addUpdateStoryCommand)
        {
            return repository.Update(addUpdateStoryCommand);
        }

        // DELETE api/StoryOverview/5
        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        
    }
}
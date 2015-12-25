using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using Storyboard.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Storyboard.Web.API
{
    [Route("api/[controller]")]
    //todo Consider breaking up concept of storysummary story creation and overview
    public class StoryOverviewController : Controller
    {
        private readonly IStoryRepository repository;
        private readonly IStoryReadService storyReadService;
        
        public StoryOverviewController(IStoryReadService storyReadService, IStoryRepository repository)
        {
            this.repository = repository;
            this.storyReadService = storyReadService;
        }

        [HttpGet]
        public async Task<List<StorySummary>> Get()
        {
            var result = await storyReadService.GetStorySummaries();
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<StoryOverview> GetOverview(int id)
        {
            return await storyReadService.GetStoryOverview(id);
        }

        // POST api/StoryOverview
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody]AddUpdateStoryCommand addUpdateStoryCommand)
        {
            var resultingCommand = await repository.Add(addUpdateStoryCommand);           
            return CreatedAtAction(nameof(GetOverview), new { id = resultingCommand.Id }, resultingCommand);
        }

        // PUT api/<controller>/5
        [HttpPut("{id:int}")]
        public Task Put(int id, [FromBody]AddUpdateStoryCommand addUpdateStoryCommand)
        {
            return repository.Update(addUpdateStoryCommand);
        }

        // DELETE api/StoryOverview/5
        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        
    }
}
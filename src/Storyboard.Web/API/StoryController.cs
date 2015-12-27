using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using Storyboard.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Storyboard.Web.API
{
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        private readonly IStoryRepository repository;
        
        public StoryController(IStoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<List<Story>> Get()
        {
            var result = await repository.GetAsync();
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<Story> GetById(int id)
        {
            var result = await repository.GetAsync(id);
            return result;
        }

        // POST api/StoryOverview
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody]AddUpdateStoryCommand addUpdateStoryCommand)
        {
            var resultingCommand = await repository.Add(addUpdateStoryCommand);           
            return CreatedAtAction(nameof(GetById), new { id = resultingCommand.Id }, resultingCommand);
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
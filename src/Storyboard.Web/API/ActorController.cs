using HDLink;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Web.Models.Home;
using Storyboard.Web.Models.Util;
using System.Collections.Generic;
using System.Net;

using System.Threading.Tasks;


namespace Storyboard.Web.API
{
    /// <summary>
    /// Api for Actors
    /// </summary>
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private IActorRepository repository;
        private ILinkDataService linkDataService;
        public ActorController(IActorRepository repo, ILinkDataService linkDataService)
        {
            repository = repo;
            this.linkDataService = linkDataService;
        }

        //Get ap/Actor/1
        [HttpGet("{id:int}")]
        public async Task<Actor> GetById(int id)
        {
            return await repository.GetAsync(id);
        }

        // Post api/Actor
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateActorCommand command)
        {
            if (command == null)
                return HttpBadRequest();
            var id = await repository.Add(command.ActorCommand);
            command.ActorCommand.Id = id;
            foreach(var link in command?.Links?? new List<CreateLinkForNewNodeCommand>())
            {
                await linkDataService.Add(link.ToCreateLinkCommand(id, StoryboardNodeTypes.Actor));
            }

            return CreatedAtAction(nameof(GetById), new { id= id}, command); 
        }

        // Post api/Actor
        [HttpPut("{id:int}")]
        public async Task<HttpStatusCodeResult> Put(int id, [FromBody]AddUpdateActorCommand command)
        {
            await repository.Update(command);
            return new HttpOkResult();
        }

        //Delete api/Actor/1
        [HttpDelete("{id:int}")]
        public async Task<HttpStatusCodeResult> Delete(int id)
        {
            await repository.Delete(id);
            return new NoContentResult();

        }

    }
}

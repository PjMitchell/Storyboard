using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System.Net;
using System.Net.Http;

using System.Threading.Tasks;
using System.Web.Http;

namespace Storyboard.Web.API
{
    /// <summary>
    /// Api for Actors
    /// </summary>
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private IActorRepository repository;
        
        public ActorController(IActorRepository repo)
        {
            repository = repo;
        }

        //Get ap/Actor/1
        [HttpGet("{id:int}")]
        public async Task<Actor> Get(int id)
        {
            return await repository.GetAsync(id);
        }

        // Post api/Actor
        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]AddUpdateActorCommand command)
        {
            var id = await repository.Add(command);

            return new ObjectResult(id) { StatusCode = (int)HttpStatusCode.Created }; 
        }

        // Post api/Actor
        [HttpPut("{id:int}")]
        public async Task<HttpStatusCodeResult> Put(int id, [FromBody]AddUpdateActorCommand command)
        {
            await repository.Update(command);
            return new OkResult();
        }

        //Delete api/Actor/1
        [HttpDelete("{id:int}")]
        public async Task<HttpStatusCodeResult> Delete(int id)
        {
            await repository.Delete(id);
            return new OkResult();

        }

    }
}

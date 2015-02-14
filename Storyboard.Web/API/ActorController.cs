using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Storyboard.Web.API
{
    /// <summary>
    /// Api for Actors
    /// </summary>
    public class ActorController : ApiController
    {
        private IActorRepository repository;
        
        public ActorController(IActorRepository repo)
        {
            repository = repo;
        }
        
        //Get ap/Actor/1
        public async Task<Actor> Get(int id)
        {
            return await repository.GetAsync(id);
        }

        // Post api/Actor
        public async Task<HttpResponseMessage> Post(AddUpdateActorCommand command)
        {
            var id = await repository.Add(command);
            return Request.CreateResponse<int>(HttpStatusCode.Created, id);
        }

        // Post api/Actor
        public async Task<HttpResponseMessage> Put(int id, AddUpdateActorCommand command)
        {
            await repository.Update(command);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //Delete api/Actor/1
        public async Task Delete(int id)
        {
            await repository.Delete(id);

        }

    }
}

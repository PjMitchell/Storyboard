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
        
        // Post api/Actor
        public async Task<HttpResponseMessage> Post(AddUpdateActorCommand command)
        {
            
            var id = await repository.Add(command);
            return Request.CreateResponse<int>(HttpStatusCode.Created, id);
        }

        //Delete api/Actor/1
        public async Task Delete(int id)
        {
            await repository.Delete(id);

        }

    }
}

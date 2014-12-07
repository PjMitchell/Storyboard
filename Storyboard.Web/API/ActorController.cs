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
        public AddUpdateActorCommand Post(AddUpdateActorCommand command)
        {
            repository.AddOrUpdate(command);
            return command;
        }

        //Delete api/Actor/1
        public void Delete(int id)
        {
            repository.Delete(id);

        }

    }
}

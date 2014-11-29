using HDLink;
using Storyboard.Domain.Core;
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
    /// Api for Story 
    /// </summary>
    public class StoryController : ApiController
    {
        private IActorRepository repository;
        private ILinkDataService dataService;

        public StoryController(IActorRepository repository, ILinkDataService dataService)
        {
            this.repository = repository;
            this.dataService = dataService;
        }

        
        // GET api/Story/AddNewActor/5
        /// <summary>
        /// Adds new Actor to story
        /// </summary>
        [HttpPut]
        public void AddNewActor(int id, AddUpdateActorCommand command)
        {
            repository.AddOrUpdate(command);
            var link = new SimpleLink
            {
                NodeA = new Node(id, StoryboardNodeTypes.Story),
                NodeB = new Node(command.Id, StoryboardNodeTypes.Actor)
            };
            dataService.Add(link);

        }
    }
}

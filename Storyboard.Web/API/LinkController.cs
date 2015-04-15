using HDLink;
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
    /// <summary>
    /// Link Crud
    /// </summary>
    public class LinkController : ApiController
    {
        private ILinkDataService dataService;
        
        public LinkController(ILinkDataService dataService)
        {
            this.dataService = dataService;
        }
        
        // POST: api/Link
        public void Post([FromBody]CreateLinkRequest request)
        {
            dataService.Add(MapRequest(request));
        }

        private CreateLinkCommand MapRequest(CreateLinkRequest request)
        {
            return new CreateLinkCommand
            {
                NodeA = new Node(request.NodeAId, StoryboardNodeTypes.GetFromValue(request.NodeAType)),
                NodeB = new Node(request.NodeBId, StoryboardNodeTypes.GetFromValue(request.NodeBType)),
                Strength = request.Strength,
                Direction = (LinkFlow)request.Direction,
                Type = new LinkType { Id = request.Type }
            };
        }
    }
}

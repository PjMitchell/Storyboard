using HDLink;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Web.Models.Home;


namespace Storyboard.Web.API
{
    /// <summary>
    /// Link Crud
    /// </summary>
    [Route("api/[controller]")]
    public class LinkController : Controller
    {
        private ILinkDataService dataService;
        
        public LinkController(ILinkDataService dataService)
        {
            this.dataService = dataService;
        }
        
        // POST: api/Link
        [HttpPost]
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

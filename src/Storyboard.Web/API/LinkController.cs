using HDLink;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Data;
using Storyboard.Web.Models.Home;
using Storyboard.Web.Models.Util;

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
            dataService.Add(request.ToCreateLinkCommand());
        }
    }
}

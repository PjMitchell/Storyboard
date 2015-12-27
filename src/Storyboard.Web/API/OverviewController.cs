using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Storyboard.Domain.Models;
using Storyboard.Domain.Data;
using Storyboard.Domain.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Storyboard.Web.API
{
    [Route("api/[controller]")]
    public class OverviewController : Controller
    {
        private readonly IStoryReadService storyReadService;

        public OverviewController(IStoryReadService storyReadService)
        {
            this.storyReadService = storyReadService;
        }

        [HttpGet("{id:int}")]
        public async Task<StoryOverview> GetOverview(int id)
        {
            return await storyReadService.GetStoryOverview(id);
        }
    }
}

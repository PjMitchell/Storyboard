using Xunit;
using Storyboard.Domain.Data;
using Storyboard.Web.API;
using Telerik.JustMock;
using System.Collections.Generic;
using Storyboard.Domain.Core;
using System.Linq;
using Storyboard.Domain.Models;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Services;
using System.Threading.Tasks;

namespace Storyboard.Web.Tests.Apis
{
    public class OverviewControllerTests
    {
        private IStoryRepository repo;
        private IStoryReadService service;
        private OverviewController target;

        public OverviewControllerTests()
        {
            repo = Mock.Create<IStoryRepository>();
            service = Mock.Create<IStoryReadService>();
            target = new OverviewController(service);
        }


        [Fact(DisplayName = "StoryOverviewController Get(Id) Gets GetsStoryOverview")]
        public async Task Get_Id_GetsStoryOverview()
        {
            var id = 1;
            var story = new StoryOverview();
            Mock.Arrange(() => service.GetStoryOverview(id))
                .Returns(() => Task.FromResult(story));
            // Act

            var result = await target.GetOverview(id);
            // Assert
            Assert.Equal(story, result);
        }
    }
}

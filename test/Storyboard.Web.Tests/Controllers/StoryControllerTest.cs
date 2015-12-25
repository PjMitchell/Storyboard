using System.Collections.Generic;
using System.Linq;
using Xunit;
using Storyboard.Web.Controllers;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Services;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Storyboard.Web.Tests.Controllers
{
    public class StoryControllerTest
    {
        private IStoryRepository repo;
        private IStoryReadService service;

        private StoryController target;
        
        public StoryControllerTest()
        {
            repo = Mock.Create<IStoryRepository>();
            service = Mock.Create<IStoryReadService>();
            target = new StoryController(service,repo);
        }


        [Fact(DisplayName = "Index Gets All Stories")]
        public async Task Index_GetsAllStories()
        {
            var stories = GetTestList();
            Mock.Arrange(() => repo.GetAsync())
                .Returns(() => Task.FromResult(stories));
            // Act
            ViewResult result = (await target.Index()) as ViewResult;
            var model = result.ViewData.Model as List<Story>;
            // Assert
            Assert.NotNull(model);
            Assert.Equal(stories.Count, model.Count());
            Assert.Equal(stories[0].Id, model[0].Id);
            Assert.Equal(stories[1].Id, model[1].Id);
        }

        [Fact(DisplayName = "Create calls repository if valid")]
        public async Task Create_CallsRepositoryIfValid()
        {
            var command = new AddUpdateStoryCommand
            {
                Title = "Title",
                Synopsis = "Synposis"
            };
            Mock.Arrange(() => repo.Add(command))
                .Returns(() => Task.FromResult(command))
                .MustBeCalled();

            // Act
            await target.Create(command);
            // Assert
            Mock.Assert(repo);
        }



        private List<Story> GetTestList()
        {
            return new List<Story>
            {
                new Story { Id = 1, Title = "Epic Story", Synopsis = "A Story that is Epic"},
                new Story { Id = 2, Title = "Poor Story", Synopsis = "A Story that is a bit rubbish"}
            };
        }
    }
}

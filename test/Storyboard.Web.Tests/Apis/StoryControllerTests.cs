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
    public class StoryControllerTests
    {
        private IStoryRepository repo;
        private StoryController target;

        public StoryControllerTests()
        {
            repo = Mock.Create<IStoryRepository>();
            target = new StoryController(repo);
        }


        [Fact(DisplayName = "StoryOverviewController Get Gets All StoryOverviewSummaries")]
        public async Task Get_GetsAllStoryOverviewSummaries()
        {
            var stories = GetTestList();
            Mock.Arrange(() => repo.GetAsync())
                .Returns(() => Task.FromResult(stories));
            // Act

            var result = await target.Get();
            // Assert
            Assert.Equal(stories.Count, result.Count());
            AssertStoriesEqual(result.SingleOrDefault(s => s.Id == 1), GetTestList().SingleOrDefault(s => s.Id == 1));
            AssertStoriesEqual(result.SingleOrDefault(s => s.Id == 2), GetTestList().SingleOrDefault(s => s.Id == 2));

        }

        [Fact(DisplayName = "StoryOverviewController Get(Id) Gets GetsStoryOverview")]
        public async Task Get_Id_GetsStoryOverview()
        {
            var id = 1;
            var story = new Story();
            Mock.Arrange(() => repo.GetAsync(id))
                .Returns(() => Task.FromResult(story));
            // Act

            var result = await target.GetById(id);
            // Assert
            Assert.Equal(story, result);

        }

        [Fact(DisplayName = "StoryOverviewController Post Creates New Story")]
        public async Task Post_CreatesNewStory()
        {
            var newStory = new AddUpdateStoryCommand();
            Mock.Arrange(() => repo.Add(newStory))
                .Returns(() => Task.FromResult(newStory))
                .MustBeCalled();

            // Act

            await target.Post(newStory);
            // Assert
            Mock.Assert(repo);

        }

        [Fact(DisplayName = "StoryOverviewController returns Completed Command")]
        public async Task Post_ReturnsCompletedCommand()
        {
            var newId = 42;
            var newStory = new AddUpdateStoryCommand();
            Mock.Arrange(() => repo.Add(newStory))
                .Returns(() =>
                {
                    newStory.Id = newId;
                    return Task.FromResult(newStory);
                });
            // Act
            var result = await target.Post(newStory);
            // Assert
            var completedCommand = result.Value as AddUpdateStoryCommand;
            Assert.NotNull(completedCommand);
            Assert.Equal(newId, completedCommand.Id);
        }

        [Fact(DisplayName = "StoryOverviewController returns Correct location")]
        public async Task Post_ReturnsCorrectLocation()
        {
            var newId = 42;
            var newStory = new AddUpdateStoryCommand();
            Mock.Arrange(() => repo.Add(newStory))
                .Returns(() =>
                {
                    newStory.Id = newId;
                    return Task.FromResult(newStory);
                });
            // Act
            var result = await target.Post(newStory);
            // Assert
            Assert.Equal(nameof(target.GetById), result.ActionName);
            Assert.Equal(newId, result.RouteValues["id"]);
        }

        [Fact(DisplayName = "StoryOverviewController Put updates Story")]
        public async Task Put_UpdatesStory()
        {
            var newStory = new AddUpdateStoryCommand();
            Mock.Arrange(() => repo.Update(newStory))
                .Returns(() => Task.FromResult(1))
                .MustBeCalled();

            // Act

            await target.Put(1, newStory);
            // Assert
            Mock.Assert(repo);

        }

        [Fact(DisplayName = "StoryOverviewController Delete Deletes Story")]
        public async Task Delete_DeletesStory()
        {
            Mock.Arrange(() => repo.Delete(1))
                .Returns(() => Task.FromResult(true))
                .MustBeCalled();

            // Act

            await target.Delete(1);
            // Assert
            Mock.Assert(repo);

        }

        //todo add validation

        private void AssertStoriesEqual(Story story1, Story story2)
        {
            Assert.NotNull(story1);
            Assert.NotNull(story2);
            Assert.Equal(story1.Id, story2.Id);
            Assert.Equal(story1.Title, story2.Title);
            Assert.Equal(story1.Synopsis, story2.Synopsis);

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

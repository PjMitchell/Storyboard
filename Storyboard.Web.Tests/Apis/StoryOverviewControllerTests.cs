using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Domain.Data;
using Storyboard.Web.API;
using Telerik.JustMock;
using System.Collections.Generic;
using Storyboard.Domain.Core;
using System.Linq;
using Storyboard.Domain.Models;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Services;
using Storyboard.Domain.Test;
using System.Threading.Tasks;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class StoryOverviewControllerTests
    {
        private IStoryRepository repo;
        private IStoryReadService service;
        private StoryOverviewController target;

        [TestInitialize]
        public void Init()
        {
            repo = Mock.Create<IStoryRepository>();
            service = Mock.Create<IStoryReadService>();
            target = new StoryOverviewController(service,repo);
        }


        [TestMethod]
        public async Task Get_GetsAllStoryOverviewSummaries()
        {
            var stories = GetTestList().Select(s=> new StorySummary{Id = s.Id}).ToList();
            Mock.Arrange(() => service.GetStorySummaries())
                .Returns(() =>MockTaskAdaptor.MockTaskResult(()=> stories));
            // Act
            
            var result = await target.Get();
            // Assert
            Assert.AreEqual(stories.Count, result.Count());
            AssertOverviewSummaryEqual(result.SingleOrDefault(s => s.Id == 1), GetTestList().SingleOrDefault(s => s.Id == 1));
            AssertOverviewSummaryEqual(result.SingleOrDefault(s => s.Id == 2), GetTestList().SingleOrDefault(s => s.Id == 2));

        }

        [TestMethod]
        public async Task Get_Id_GetsStoryOverview()
        {
            var id = 1;
            var story = new StoryOverview();
            Mock.Arrange(() => service.GetStoryOverview(id))
                .Returns(() => MockTaskAdaptor.MockTaskResult(() => story));
            // Act

            var result =await target.Get(id);
            // Assert
            Assert.AreEqual(story, result);
            
        }

        [TestMethod]
        public async Task Post_CreatesNewStory()
        {
            var newStory = new AddUpdateStoryCommand();
            Mock.Arrange(() => repo.Add(newStory))
                .Returns(()=> MockTaskAdaptor.MockTaskResult(()=> 1))
                .MustBeCalled();
                
            // Act

            await target.Post(newStory);
            // Assert
            Mock.Assert(repo);

        }

        [TestMethod]
        public void Delete_DeletesStory()
        {
            Mock.Arrange(() => repo.Delete(1))
                .MustBeCalled();

            // Act

            target.Delete(1);
            // Assert
            Mock.Assert(repo);

        }

        //todo add validation

        private void AssertOverviewSummaryEqual(StorySummary summary, Story story)
        {
            Assert.IsNotNull(summary);
            Assert.IsNotNull(story);
            Assert.AreEqual(summary.Id, summary.Id);
            Assert.AreEqual(summary.Title, summary.Title);
            Assert.AreEqual(summary.Synopsis, summary.Synopsis);

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

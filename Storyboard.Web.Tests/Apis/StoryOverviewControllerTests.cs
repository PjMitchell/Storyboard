using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Domain.Data;
using Storyboard.Web.API;
using Telerik.JustMock;
using System.Collections.Generic;
using Storyboard.Domain.Core;
using System.Linq;
using Storyboard.Web.Models.Home;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class StoryOverviewControllerTests
    {
        private IStoryRepository repo;
        private StoryOverviewController target;

        [TestInitialize]
        public void Init()
        {
            repo = Mock.Create<IStoryRepository>();
            target = new StoryOverviewController(repo);
        }


        [TestMethod]
        public void Get_GetsAllStoryOverviewSummaries()
        {
            var stories = GetTestList();
            Mock.Arrange(() => repo.Get())
                .Returns(() => stories);
            // Act
            
            var result = target.Get().ToList();
            // Assert
            Assert.AreEqual(stories.Count, result.Count());
            AssertOverviewSummaryEqual(result.SingleOrDefault(s=> s.Id ==1), stories.SingleOrDefault(s => s.Id == 1));
            AssertOverviewSummaryEqual(result.SingleOrDefault(s => s.Id == 2), stories.SingleOrDefault(s => s.Id == 2));

        }

        [TestMethod]
        public void Post_CreatesNewStory()
        {
            var newStory = new AddUpdateStoryCommand();
            Mock.Arrange(() => repo.AddOrUpdate(newStory))
                .MustBeCalled();
                
            // Act

            target.Post(newStory);
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

        private void AssertOverviewSummaryEqual(StoryOverviewSummary summary, Story story)
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

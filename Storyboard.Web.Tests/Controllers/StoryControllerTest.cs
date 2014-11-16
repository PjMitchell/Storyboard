using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Web;
using Storyboard.Web.Controllers;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using Storyboard.Domain.Services;

namespace Storyboard.Web.Tests.Controllers
{
    [TestClass]
    public class StoryControllerTest
    {
        private IStoryRepository repo;
        private IStoryReadService service;

        private StoryController target;
        
        [TestInitialize]
        public void Init()
        {
            repo = Mock.Create<IStoryRepository>();
            service = Mock.Create<IStoryReadService>();
            target = new StoryController(service,repo);
        }
        
        
        [TestMethod]
        public void Index_GetsAllStories()
        {
            var stories = GetTestList();
            Mock.Arrange(() => repo.Get())
                .Returns(() => stories);
            // Act
            ViewResult result = target.Index() as ViewResult;
            var model = result.Model as List<Story>;
            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(stories.Count, model.Count());
            Assert.AreEqual(stories[0].Id, model[0].Id);
            Assert.AreEqual(stories[1].Id, model[1].Id);
        }

        [TestMethod]
        public void Create_CallsRepositoryIfValid()
        {
            var command = new AddUpdateStoryCommand
            {
                Title = "Title",
                Synopsis = "Synposis"
            };
            Mock.Arrange(() => repo.AddOrUpdate(command))
                .MustBeCalled();
            // Act
            target.Create(command);
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

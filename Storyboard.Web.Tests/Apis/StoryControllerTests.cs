using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Web.API;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using HDLink;
using Storyboard.Domain.Core;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class StoryControllerTests
    {
        private StoryController target;
        private IActorRepository repository;
        private ILinkDataService dataService;
        private const int targetStoryId = 1;

        [TestInitialize]
        public void Init()
        {
            repository = Mock.Create<IActorRepository>();
            dataService = Mock.Create<ILinkDataService>();
            target = new StoryController(repository, dataService);
        }
        
        [TestMethod]
        public void AddNewActor_AddsNewStoryToRepository()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repository.AddOrUpdate(command)).MustBeCalled();
            target.AddNewActor(targetStoryId, command);
            Mock.Assert(repository);

        }

        [TestMethod]
        public void AddNewActor_AttachesActorToStory()
        {
            var command = new AddUpdateActorCommand();
            var actorId = 10;
            Mock.Arrange(() => repository.AddOrUpdate(command))
                .DoInstead((AddUpdateActorCommand cmd) => cmd.Id = actorId);
            SimpleLink insertedLink = null;
            Mock.Arrange(() => dataService.Add(Arg.IsAny<SimpleLink>()))
                .DoInstead((SimpleLink arg) => insertedLink = arg);

            target.AddNewActor(targetStoryId, command);

            Assert.IsNotNull(insertedLink);
            Assert.AreEqual(targetStoryId, insertedLink.NodeA.Id);
            Assert.AreEqual(StoryboardNodeTypes.Story, insertedLink.NodeA.NodeType);
            Assert.AreEqual(actorId, insertedLink.NodeB.Id);
            Assert.AreEqual(StoryboardNodeTypes.Actor, insertedLink.NodeB.NodeType);
            Assert.AreEqual(LinkFlow.Bidirectional, insertedLink.Direction);
        }


    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Web.API;
using Storyboard.Domain.Core.Commands;
using Storyboard.Web.Models.Home;
using Storyboard.Domain.Core;
using HDLink;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class LinkControllerTests
    {
        private ILinkDataService dataService;
        private LinkController target;
        private CreateLinkRequest defaultRequest;

        [TestInitialize]
        public void Init()
        {
            dataService = Mock.Create<ILinkDataService>();
            target = new LinkController(dataService);
            defaultRequest = new CreateLinkRequest
            {
                NodeAId = 101,
                NodeAType = StoryboardNodeTypes.Story.Id,
                NodeBId = 203,
                NodeBType = StoryboardNodeTypes.Actor.Id,
                Direction = (int)LinkFlow.AtoB,
                Strength = 0.5f,
                Type = 23
            };

        }
        [TestMethod]
        public void PostCallsLinkDataService()
        {
            Mock.Arrange(() => dataService.Add(Arg.IsAny<CreateLinkCommand>())).Occurs(1);
            target.Post(defaultRequest);
            Mock.Assert(dataService);
        }

        [TestMethod]
        public void PostCorrectlyMapsRequest()
        {
            CreateLinkCommand command = null;
            Mock.Arrange(() => dataService.Add(Arg.IsAny<CreateLinkCommand>()))
                .DoInstead((CreateLinkCommand arg)=> command = arg);
            
            target.Post(defaultRequest);

            Assert.AreEqual(defaultRequest.NodeAId, command.NodeA.Id);
            Assert.AreEqual(defaultRequest.NodeAType, command.NodeA.NodeType.Id);
            Assert.AreEqual(defaultRequest.NodeBId, command.NodeB.Id);
            Assert.AreEqual(defaultRequest.NodeBType, command.NodeB.NodeType.Id);

            Assert.AreEqual(LinkFlow.AtoB, command.Direction);
            Assert.AreEqual(defaultRequest.Strength, command.Strength);
            Assert.AreEqual(defaultRequest.Type, command.Type.Id);




        }
    }
}

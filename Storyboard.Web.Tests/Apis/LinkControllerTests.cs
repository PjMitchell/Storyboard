using System;
using Xunit;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Web.API;
using Storyboard.Domain.Core.Commands;
using Storyboard.Web.Models.Home;
using Storyboard.Domain.Core;
using HDLink;

namespace Storyboard.Web.Tests.Apis
{

    public class LinkControllerTests
    {
        private ILinkDataService dataService;
        private LinkController target;
        private CreateLinkRequest defaultRequest;

        public LinkControllerTests()
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
        [Fact(DisplayName = "LinkController: Post Calls Link Data Service")]
        public void PostCallsLinkDataService()
        {
            Mock.Arrange(() => dataService.Add(Arg.IsAny<CreateLinkCommand>())).Occurs(1);
            target.Post(defaultRequest);
            Mock.Assert(dataService);
        }

        [Fact(DisplayName = "LinkController: Post Correctly maps request")]
        public void PostCorrectlyMapsRequest()
        {
            CreateLinkCommand command = null;
            Mock.Arrange(() => dataService.Add(Arg.IsAny<CreateLinkCommand>()))
                .DoInstead((CreateLinkCommand arg)=> command = arg);
            
            target.Post(defaultRequest);

            Assert.Equal(defaultRequest.NodeAId, command.NodeA.Id);
            Assert.Equal(defaultRequest.NodeAType, command.NodeA.NodeType.Id);
            Assert.Equal(defaultRequest.NodeBId, command.NodeB.Id);
            Assert.Equal(defaultRequest.NodeBType, command.NodeB.NodeType.Id);

            Assert.Equal(LinkFlow.AtoB, command.Direction);
            Assert.Equal(defaultRequest.Strength, command.Strength);
            Assert.Equal(defaultRequest.Type, command.Type.Id);




        }
    }
}

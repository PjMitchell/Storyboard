using HDLink;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using Storyboard.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace Storyboard.Domain.Test
{
    [TestClass]
    public class StoryReadServiceTests
    {
        private IStoryReadService target;
        private IStoryRepository storyRepos;
        private IAsyncNodeService nodeService;
        private Story testStory;
        
        [TestInitialize]
        public void Init()
        {
            storyRepos = Mock.Create<IStoryRepository>();
            nodeService = Mock.Create<IAsyncNodeService>();
            target = new StoryReadService(storyRepos, nodeService);
            testStory = new Story { Id = 1, Title = "A Story", Synopsis = "A Summary" };
            Mock.Arrange(() => storyRepos.GetAsync(testStory.Id))
                .Returns(() => Task.FromResult(testStory));
            Mock.Arrange(() => nodeService.Get(Arg.IsAny<INode>(), Arg.IsAny<NodeType<Actor>>()))
                .Returns(() => Task.FromResult(new List<Actor>()));
        }
        
        [TestMethod]
        [Timeout(500)]
        public async Task GetStorySummary_GetsStorySummary()
        {
            var result = await target.GetStorySummary(testStory.Id);
            
            Assert.AreEqual(testStory.Id, result.Id);
            Assert.AreEqual(testStory.Title, result.Title);
            Assert.AreEqual(testStory.Synopsis, result.Synopsis);

        }

        [TestMethod]
        [Timeout(500)]
        public async Task GetStorySummaries_GetsStorySummary()
        {
            Mock.Arrange(() => storyRepos.GetAsync())
                .Returns(() => Task.FromResult(new List<Story> { testStory, testStory }));
            var list = await target.GetStorySummaries();

            Assert.AreEqual(2, list.Count);
            var result = list[0];
            Assert.AreEqual(testStory.Id, result.Id);
            Assert.AreEqual(testStory.Title, result.Title);
            Assert.AreEqual(testStory.Synopsis, result.Synopsis);

        }

        [TestMethod]
        [Timeout(500)]
        public async Task GetStoryOverview_GetsStorySummary()
        {
            var result = await target.GetStoryOverview(testStory.Id);

            Assert.AreEqual(testStory.Id, result.Summary.Id);
            Assert.AreEqual(testStory.Title, result.Summary.Title);
            Assert.AreEqual(testStory.Synopsis, result.Summary.Synopsis);

        }

        [TestMethod]
        [Timeout(500)]
        public async Task GetStoryOverview_GetsActors()
        {
            var actor = new Actor{Id = 10, Name = "Actor"};
            var actors = new List<Actor> { actor };
            Mock.Arrange(()=> nodeService.Get(Arg.IsAny<INode>(), Arg.IsAny<NodeType<Actor>>()))
                .Returns((INode node, INodeType nodetype) => Task.FromResult( 
                    node.Id == testStory.Id 
                    && node.NodeType == testStory.NodeType 
                    && nodetype == StoryboardNodeTypes.Actor
                    ? actors
                    : new List<Actor>()));
            
            var result = await target.GetStoryOverview(testStory.Id);
            Assert.AreEqual(1, result.Actors.Count);
            Assert.AreEqual(10, result.Actors[0].Id);

            

        }
    }
}

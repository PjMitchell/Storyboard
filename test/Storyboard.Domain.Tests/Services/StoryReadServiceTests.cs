using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Storyboard.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.JustMock;
using Xunit;

namespace Storyboard.Domain.Test
{
    public class StoryReadServiceTests
    {
        private IStoryReadService target;
        private IStoryRepository storyRepos;
        private IAsyncNodeService nodeService;
        private IStorySectionRepository storySectionRepository;
        private Story testStory;
        

        public StoryReadServiceTests()
        {
            storyRepos = Mock.Create<IStoryRepository>();
            nodeService = Mock.Create<IAsyncNodeService>();
            storySectionRepository = Mock.Create<IStorySectionRepository>();
            target = new StoryReadService(storyRepos, nodeService, storySectionRepository);
            testStory = new Story { Id = 1, Title = "A Story", Synopsis = "A Summary" };
            Mock.Arrange(() => storyRepos.GetAsync(testStory.Id))
                .Returns(() => Task.FromResult(testStory));
            Mock.Arrange(() => nodeService.Get(Arg.IsAny<INode>(), Arg.IsAny<NodeType<Actor>>()))
                .Returns(() => Task.FromResult(new List<Actor>()));
            Mock.Arrange(() => storySectionRepository.GetTreeForStory(Arg.AnyInt))
                .Returns(() => Task.FromResult(new OrderedHierarchicalTree<StorySection>()));
        }

        [Fact(DisplayName = "StoryReadService: GetStorySummary does just that")]
        public async Task GetStorySummary_GetsStorySummary()
        {
            var result = await target.GetStorySummary(testStory.Id);
            
            Assert.Equal(testStory.Id, result.Id);
            Assert.Equal(testStory.Title, result.Title);
            Assert.Equal(testStory.Synopsis, result.Synopsis);

        }

        [Fact(DisplayName = "StoryReadService: GetStorySummaries Gets StorySummary")]
        public async Task GetStorySummaries_GetsStorySummary()
        {
            Mock.Arrange(() => storyRepos.GetAsync())
                .Returns(() => Task.FromResult(new List<Story> { testStory, testStory }));
            var list = await target.GetStorySummaries();

            Assert.Equal(2, list.Count);
            var result = list[0];
            Assert.Equal(testStory.Id, result.Id);
            Assert.Equal(testStory.Title, result.Title);
            Assert.Equal(testStory.Synopsis, result.Synopsis);

        }

        [Fact(DisplayName = "StoryReadService: GetStoryOverview Gets StorySummary")]
        public async Task GetStoryOverview_GetsStorySummary()
        {
            var result = await target.GetStoryOverview(testStory.Id);

            Assert.Equal(testStory.Id, result.Summary.Id);
            Assert.Equal(testStory.Title, result.Summary.Title);
            Assert.Equal(testStory.Synopsis, result.Summary.Synopsis);

        }

        [Fact(DisplayName = "StoryReadService: GetStoryOverview Gets Actors")]
        public async Task GetStoryOverview_GetsActors()
        {
            var actor = new Actor{Id = 10, Name = "Actor"};
            var actors = new List<Actor> { actor };
            Mock.Arrange(()=> nodeService.Get(Arg.IsAny<INode>(), Arg.IsAny<NodeType<Actor>>()))
                .Returns((INode node, INodeType nodetype) => Task.FromResult( 
                    node.Id == testStory.Id 
                    && node.NodeType.Equals(testStory.NodeType) 
                    && nodetype.Equals(StoryboardNodeTypes.Actor)
                    ? actors
                    : new List<Actor>()));
            
            var result = await target.GetStoryOverview(testStory.Id);
            Assert.Equal(1, result.Actors.Count);
            Assert.Equal(10, result.Actors[0].Id);

        }

        [Fact(DisplayName = "StoryReadService: GetStoryOverview Gets StorySection")]
        public async Task GetStoryOverview_GetsStorySections()
        {
            var storySection = new StorySection { Id = 10, Description = "Chapter One", Order = 1, HierarchyLevel = 1 };
            var storySections = new OrderedHierarchicalTree<StorySection> ( new []{ storySection}) ;
            Mock.Arrange(() => storySectionRepository.GetTreeForStory(testStory.Id))
                .Returns(()=> Task.FromResult(storySections));

            var result = await target.GetStoryOverview(testStory.Id);
            Assert.Equal(1, result.Sections.Count);
            Assert.Equal(10, result.Sections[0].Id);

        }
    }
}

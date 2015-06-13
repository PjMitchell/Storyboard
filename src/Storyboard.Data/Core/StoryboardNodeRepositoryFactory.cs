using System;
using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Storyboard.Data.Core;

namespace Storyboard.Data.Core
{
    public class StoryboardNodeRepositoryFactory : IAsyncNodeRepositoryFactory
    {
        private readonly ILinkDataService linkDataService;
        private readonly StoryboardContext dbContext;

        public StoryboardNodeRepositoryFactory(ILinkDataService linkDataService, StoryboardContext dbContext)
        {
            this.linkDataService = linkDataService;
            this.dbContext = dbContext;
        }

        public IAsyncNodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType == StoryboardNodeTypes.Actor)
                return new ActorRepository(linkDataService, dbContext);
            if (nodeType == StoryboardNodeTypes.Story)
                return new StoryRepository(linkDataService, dbContext);
            throw new ArgumentOutOfRangeException(nameof(nodeType), "Could not find repository for nodeType");
        }


        public IAsyncNodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode =>
            (IAsyncNodeRepository<T>)CreateRepository((INodeType) nodeType);

    }
}

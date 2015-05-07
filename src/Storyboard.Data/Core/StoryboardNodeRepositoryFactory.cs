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

        public StoryboardNodeRepositoryFactory(ILinkDataService linkDataService)
        {
            this.linkDataService = linkDataService;
        }
        public IAsyncNodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType == StoryboardNodeTypes.Actor)
                return new ActorRepository(linkDataService);
            if (nodeType == StoryboardNodeTypes.Story)
                return new StoryRepository(linkDataService);
            throw new ArgumentOutOfRangeException("nodeType", "Could not find repository for nodeType");
        }


        public IAsyncNodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode
        {
            return (IAsyncNodeRepository<T>)CreateRepository((INodeType) nodeType);
        }
    }
}

using System;
using HDLink;
using Storyboard.Domain.Core;
using Microsoft.Framework.DependencyInjection;

namespace Storyboard.Data.Core
{
    public class StoryboardNodeRepositoryFactory : IAsyncNodeRepositoryFactory
    {
        private readonly IServiceProvider serviceProvider;
        
        public StoryboardNodeRepositoryFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IAsyncNodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType == StoryboardNodeTypes.Actor)
                return serviceProvider.GetService<ActorRepository>();
            if (nodeType == StoryboardNodeTypes.Story)
                return serviceProvider.GetService<StoryRepository>();
            throw new ArgumentOutOfRangeException(nameof(nodeType), "Could not find repository for nodeType");
        }


        public IAsyncNodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode
        {
            return serviceProvider.GetService<IAsyncNodeRepository<T>>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLink;
using Storyboard.Domain.Core;

namespace Storyboard.Data.Core
{
    public class StoryboardNodeRepositoryFactory : INodeRepositoryFactory
    {

        public INodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType == StoryboardNodeTypes.Actor)
                return new ActorRepository();
            if (nodeType == StoryboardNodeTypes.Story)
                return new StoryRepository();
            throw new ArgumentOutOfRangeException("nodeType", "Could not find repository for nodeType");
        }
    }
}

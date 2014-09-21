using HDLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Core
{
    public static class StoryboardNodeTypes
    {
        
        private static NodeType story = new NodeType(1, "StoryRepository");
        private static NodeType actor = new NodeType(2, "ActorRepository");

        public static NodeType Story { get { return story; } }
        public static NodeType Actor { get { return actor; } }
   }

    
}

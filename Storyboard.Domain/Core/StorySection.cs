using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLink;
namespace Storyboard.Domain.Core
{
    public class StorySection: IOrderedHierarchyElement, INode
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public INodeType NodeType { get { return StoryboardNodeTypes.StorySection; } }

        public int HierarchyLevel { get; set; }

        public int Order { get; set; }

        public int ParentHierarchyElementId { get; set; }
        
    }
}

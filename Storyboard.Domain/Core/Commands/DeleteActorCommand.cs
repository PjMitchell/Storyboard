using HDLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Core.Commands
{
    /// <summary>
    /// Command for removing Actor 
    /// </summary>
    public class RemoveActorCommand: INode
    {
        /// <summary>
        /// Id of actor to be removed
        /// </summary>
        public int Id { get; set; }
        
        private readonly INodeType nodeType = StoryboardNodeTypes.Actor;
        /// <summary>
        /// Actor Node
        /// </summary>
        public INodeType NodeType { get { return nodeType; } }
    }
}

﻿using HDLink;

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
        
        /// <summary>
        /// Actor Node
        /// </summary>
        public INodeType NodeType => StoryboardNodeTypes.Actor;
    }
}

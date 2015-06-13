using HDLink;
using System;

namespace Storyboard.Domain.Core
{
    public static class StoryboardNodeTypes
    {
        public static readonly NodeType<Story> Story = new NodeType<Story>(1);
        public static readonly NodeType<Actor> Actor = new NodeType<Actor>(2);
        public static readonly NodeType<StorySection> StorySection = new NodeType<StorySection>(3);


        /// <summary>
        /// Gets NodeType From Id
        /// </summary>
        /// <param name="id">Id of Node Type</param>
        /// <returns>Storyboard NodeTypes</returns>
        public static INodeType GetFromValue(int id)
        {
            switch(id)
            {
                case 1 :
                    return Story;
                case 2 :
                    return Actor;
                case 3 :
                    return StorySection;
                default:
                    throw new ArgumentOutOfRangeException(nameof(id));
            }
        }
   }

    
}

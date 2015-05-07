using HDLink;
using System;

namespace Storyboard.Domain.Core
{
    public static class StoryboardNodeTypes
    {
        
        private static NodeType<Story> story = new NodeType<Story>(1);
        private static NodeType<Actor> actor = new NodeType<Actor>(2);
        private static NodeType<StorySection> storySection = new NodeType<StorySection>(3);

        public static NodeType<Story> Story { get { return story; } }
        public static NodeType<Actor> Actor { get { return actor; } }
        public static NodeType<StorySection> StorySection { get { return storySection; } }


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
                    return story;
                case 2 :
                    return actor;
                case 3 :
                    return storySection;
                default:
                    throw new ArgumentOutOfRangeException("id");
            }
        }
   }

    
}

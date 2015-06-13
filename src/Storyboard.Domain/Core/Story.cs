using HDLink;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Domain.Core
{
    public class Story : INode
    {
        public int Id { get; set; }
        public INodeType NodeType => StoryboardNodeTypes.Story;

        public string Title { get; set; }
        public string Synopsis { get; set; }


        public AddUpdateStoryCommand ToAddUpdateCommand()
        {
            return new AddUpdateStoryCommand
            {
                Id = Id,
                Title = Title,
                Synopsis = Synopsis
            };
        }

        
    }
}

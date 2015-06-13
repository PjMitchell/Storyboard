using HDLink;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Domain.Core
{
    public class Actor : INode
    {
        public int Id { get; set; }
        public INodeType NodeType => StoryboardNodeTypes.Actor;

        public string Name { get; set; }
        public string Description { get; set; }

        public AddUpdateActorCommand ToAddUpdateCommand()
        {
            return new AddUpdateActorCommand
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}

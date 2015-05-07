using HDLink;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Domain.Core
{
    public class Actor : INode
    {
        public int Id { get; set; }
        public INodeType NodeType
        {
            get { return StoryboardNodeTypes.Actor; }
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public AddUpdateActorCommand ToAddUpdateCommand()
        {
            return new AddUpdateActorCommand
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}

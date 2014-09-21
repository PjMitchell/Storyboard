using HDLink;
using Storyboard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Core
{
    public class Story : INode
    {
        public int Id { get; set; }
        public INodeType NodeType
        {
            get { return StoryboardNodeTypes.Story; }
        }
        public string Title { get; set; }
        public string Synopsis { get; set; }


        public AddUpdateStoryCommand ToAddUpdateCommand()
        {
            return new AddUpdateStoryCommand
            {
                Id = this.Id,
                Title = this.Title,
                Synopsis = this.Synopsis
            };
        }

        
    }
}

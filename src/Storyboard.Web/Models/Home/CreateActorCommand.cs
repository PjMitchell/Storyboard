using Storyboard.Domain.Core.Commands;
using System.Collections.Generic;

namespace Storyboard.Web.Models.Home
{
    public class CreateActorCommand
    {
        public AddUpdateActorCommand ActorCommand { get; set; }
        public List<CreateLinkForNewNodeCommand> Links { get; set; }
    }
}

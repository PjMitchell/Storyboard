using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Core.Commands;
using Storyboard.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboard.Web.Models.Util
{
    public static class CreateLinkCommandMapper
    {
        public static CreateLinkCommand ToCreateLinkCommand(this CreateLinkForNewNodeCommand command, int newNodeId, INodeType newNodeType)
        {
            return new CreateLinkCommand
            {
                NodeA = new Node(newNodeId, newNodeType),
                NodeB = new Node(command.NodeBId, StoryboardNodeTypes.GetFromValue(command.NodeBType)),
                Strength = command.Strength,
                Direction = (LinkFlow)command.Direction,
                Type = new LinkType { Id = command.Type }
            };
        }

        public static CreateLinkCommand ToCreateLinkCommand(this CreateLinkRequest request)
        {
            return new CreateLinkCommand
            {
                NodeA = new Node(request.NodeAId, StoryboardNodeTypes.GetFromValue(request.NodeAType)),
                NodeB = new Node(request.NodeBId, StoryboardNodeTypes.GetFromValue(request.NodeBType)),
                Strength = request.Strength,
                Direction = (LinkFlow)request.Direction,
                Type = new LinkType { Id = request.Type }
            };
        }
    }
}

using HDLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple.Data;
using Storyboard.Data.DBObject;
using Storyboard.Domain.Core;

namespace Storyboard.Data.Core
{
    public class LinkRepository : ILinkRepository, IAsyncLinkRepository
    {
        public IEnumerable<ILink> Get(INode node, INodeType nodeType)
        {
            var db = Database.Open();
            IEnumerable<LinkTableRow> rows = db.Story.Link.FindAll(
                (db.Story.Link.NodeARef == node.Id && db.Story.Link.NodeAType == node.NodeType.Id && db.Story.Link.NodeBType == nodeType.Id)
                || (db.Story.Link.NodeBRef == node.Id && db.Story.Link.NodeBType == node.NodeType.Id && db.Story.Link.NodeAType == nodeType.Id));
            return rows.Select(MapRow);
        }

        public IEnumerable<ILink> Get(INode node)
        {
            var db = Database.Open();
            IEnumerable<LinkTableRow> rows = db.Story.Link.FindAll(
                (db.Story.Link.NodeARef == node.Id && db.Story.Link.NodeAType == node.NodeType.Id)
                || (db.Story.Link.NodeBRef == node.Id && db.Story.Link.NodeBType == node.NodeType.Id));
            return rows.Select(MapRow);
            
        }

        public IEnumerable<ILink> Get()
        {
            var db = Database.Open();
            IEnumerable<LinkTableRow> rows = db.Story.Link.All();
            return rows.Select(MapRow);
        }

        public Task<List<ILink>> GetAsync(INode node, INodeType nodeType)
        {
            return Task.Run(() => Get(node, nodeType).ToList());
        }

        public Task<List<ILink>> GetAsync(INode node)
        {
            return Task.Run(() => Get(node).ToList());
        }

        public Task<List<ILink>> GetAsync()
        {
            return Task.Run(() => Get().ToList());
        }

        private SimpleLink MapRow(LinkTableRow arg)
        {
            return new SimpleLink
            {
                NodeA = new Node(arg.NodeARef, StoryboardNodeTypes.GetFromValue(arg.NodeAType)),
                NodeB = new Node(arg.NodeBRef, StoryboardNodeTypes.GetFromValue(arg.NodeBType)),
                Direction = (LinkFlow)arg.LinkDirection,
                Strength = arg.LinkStrength,
                Type = new LinkType { Id = arg.LinkTypeRef }
            };
        }

        
    }
}

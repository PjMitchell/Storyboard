using HDLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storyboard.Domain.Core;
using System.Data.Entity;
using Storyboard.Data.EF;
using Storyboard.Data.EF.DbObject;

namespace Storyboard.Data.EF.Core
{
    public class LinkRepository : IAsyncLinkRepository
    {
        public IEnumerable<ILink> Get(INode node, INodeType nodeType)
        {
            using(var db = new StoryboardContext())
            {
                return from row in db.Link
                       where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id && row.NodeBType == nodeType.Id)
                           || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id && row.NodeAType == nodeType.Id)
                       select MapRow(row);
            }
        }

        public IEnumerable<ILink> Get(INode node)
        {
            using (var db = new StoryboardContext())
            {
                return from row in db.Link
                       where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id)
                           || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id)
                       select MapRow(row);
            }
            
        }

        public IEnumerable<ILink> Get()
        {
            using (var db = new StoryboardContext())
            {
                return from row in db.Link
                       select MapRow(row);
            }
        }

        public async Task<List<ILink>> GetAsync(INode node, INodeType nodeType)
        {
            using (var db = new StoryboardContext())
            {
                var rows = await (from row in db.Link
                       where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id && row.NodeBType == nodeType.Id)
                           || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id && row.NodeAType == nodeType.Id)
                       select row).ToListAsync();


                return rows.Select(MapRow).ToList<ILink>();
            }
        }

        public async Task<List<ILink>> GetAsync(INode node)
        {
            using (var db = new StoryboardContext())
            {

                var rows =await (from row in db.Link
                       where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id)
                           || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id)
                        select row).ToListAsync();
                return rows.Select(MapRow).ToList<ILink>();;
            }
        }

        public async Task<List<ILink>> GetAsync()
        {
            using (var db = new StoryboardContext())
            {
                var rows = await (from row in db.Link select row).ToListAsync();
                return rows.Select(MapRow).ToList<ILink>();
            }
        }

        private SimpleLink MapRow(LinkTableRow arg)
        {
            return new SimpleLink
            {
                NodeA = new Node(arg.NodeARef, StoryboardNodeTypes.GetFromValue(arg.NodeAType)),
                NodeB = new Node(arg.NodeBRef, StoryboardNodeTypes.GetFromValue(arg.NodeBType)),
                Direction = (LinkFlow)arg.LinkDirection,
                Strength = (float)arg.LinkStrength,
                Type = new LinkType { Id = arg.LinkTypeRef }
            };
        }

        
    }
}

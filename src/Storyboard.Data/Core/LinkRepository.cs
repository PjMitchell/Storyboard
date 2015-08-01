using HDLink;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storyboard.Domain.Core;
using Storyboard.Data.DbObject;
using Microsoft.Data.Entity;

namespace Storyboard.Data.Core
{
    public class LinkRepository : IAsyncLinkRepository
    {
        private readonly StoryboardContext dbContext;

        public LinkRepository(StoryboardContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ILink> Get(INode node, INodeType nodeType)
        {
        return from row in dbContext.Link
                where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id && row.NodeBType == nodeType.Id)
                    || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id && row.NodeAType == nodeType.Id)
                select MapRow(row);
        }

        public IEnumerable<ILink> Get(INode node)
        {
            return from row in dbContext.Link
                    where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id)
                        || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id)
                    select MapRow(row);          
        }

        public IEnumerable<ILink> Get()
        {
            return from row in dbContext.Link
                    select MapRow(row);
        }

        public async Task<List<ILink>> GetAsync(INode node, INodeType nodeType)
        {
            var rows = await (from row in dbContext.Link
                    where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id && row.NodeBType == nodeType.Id)
                        || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id && row.NodeAType == nodeType.Id)
                    select row).ToListAsync();

            return rows.Select(MapRow).ToList<ILink>();
        }

        public async Task<List<ILink>> GetAsync(INode node)
        {
           var rows =await (from row in dbContext.Link
                       where (row.NodeARef == node.Id && row.NodeAType == node.NodeType.Id)
                           || (row.NodeBRef == node.Id && row.NodeBType == node.NodeType.Id)
                        select row).ToListAsync();
                return rows.Select(MapRow).ToList<ILink>();
        }

        public async Task<List<ILink>> GetAsync()
        {
            var rows = await (from row in dbContext.Link select row).ToListAsync();
            return rows.Select(MapRow).ToList<ILink>();
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

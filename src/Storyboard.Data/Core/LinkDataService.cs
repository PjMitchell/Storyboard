using HDLink;
using Storyboard.Data.DbObject;
using Storyboard.Domain.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Storyboard.Data.Core
{
    /// <summary>
    /// Responsible for altering the ILinkDataStore
    /// </summary>
    public class LinkDataService : ILinkDataService
    {
        /// <summary>
        /// Adds new link to store
        /// </summary>
        public async Task Add(ILink link)
        {
            using(var db = new StoryboardContext())
            {
                var row = MapRow(link);
                db.Link.Add(row);
                await db.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Removes link from store
        /// </summary>
        public async Task Remove(ILink link)
        {
            var linkTypeRef = link.Type == null ? 0 : link.Type.Id;
            using (var db = new StoryboardContext())
            {
                db.Link.RemoveRange(db.Link.Where(w => w.NodeARef == link.NodeA.Id 
                    && w.NodeAType == link.NodeA.NodeType.Id 
                    && w.NodeBRef == link.NodeB.Id 
                    && w.NodeBType == link.NodeB.NodeType.Id
                    && w.LinkTypeRef == linkTypeRef));
                await db.SaveChangesAsync();
            }
         }

        /// <summary>
        /// Removes links from store that contain node
        /// </summary>
        public async Task Remove(INode node)
        {
            using (var db = new StoryboardContext())
            {
                db.Link.RemoveRange(db.Link.Where(w => w.NodeARef == node.Id 
                    && w.NodeAType == node.NodeType.Id
                    && w.NodeBRef == node.Id
                    && w.NodeBType == node.Id));
                await db.SaveChangesAsync();
            }
        }

        private LinkTableRow MapRow(ILink arg)
        {
            return new LinkTableRow
            {
                NodeARef = arg.NodeA.Id,
                NodeAType = (byte)arg.NodeA.NodeType.Id,
                NodeBRef = arg.NodeB.Id,
                NodeBType = (byte)arg.NodeB.NodeType.Id,
                LinkDirection = (byte)arg.Direction,
                LinkStrength = arg.Strength,
                LinkTypeRef = arg.Type == null ? 0 :arg.Type.Id

            };
        }


        
    }
}

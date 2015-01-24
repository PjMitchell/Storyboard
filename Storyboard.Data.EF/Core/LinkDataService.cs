using HDLink;
using Storyboard.Data.EF.DbObject;
using Storyboard.Domain.Data;
using System.Linq;

namespace Storyboard.Data.EF.Core
{
    /// <summary>
    /// Responsible for altering the ILinkDataStore
    /// </summary>
    public class LinkDataService : ILinkDataService
    {
        /// <summary>
        /// Adds new link to store
        /// </summary>
        public void Add(ILink link)
        {
            using(var db = new StoryboardContext())
            {
                var row = MapRow(link);
                db.Link.Add(row);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Removes link from store
        /// </summary>
        public void Remove(ILink link)
        {
            var linkTypeRef = link.Type == null ? 0 : link.Type.Id;
            using (var db = new StoryboardContext())
            {
                db.Link.RemoveRange(db.Link.Where(w => w.NodeARef == link.NodeA.Id 
                    && w.NodeAType == link.NodeA.NodeType.Id 
                    && w.NodeBRef == link.NodeB.Id 
                    && w.NodeBType == link.NodeB.NodeType.Id
                    && w.LinkTypeRef == linkTypeRef));
                db.SaveChanges();
            }
         }

        /// <summary>
        /// Removes links from store that contain node
        /// </summary>
        public void Remove(INode node)
        {
            using (var db = new StoryboardContext())
            {
                db.Link.RemoveRange(db.Link.Where(w => w.NodeARef == node.Id 
                    && w.NodeAType == node.NodeType.Id
                    && w.NodeBRef == node.Id
                    && w.NodeBType == node.Id));
                db.SaveChanges();
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

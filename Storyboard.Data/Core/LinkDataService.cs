using HDLink;
using Simple.Data;
using Storyboard.Data.DBObject;
using Storyboard.Domain.Data;

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
        public void Add(ILink link)
        {
            var db = Database.Open();
            db.Story.Link.Insert(MapRow(link));
        }

        public void Remove(ILink link)
        {
            var linkTypeRef = link.Type == null ? 0 : link.Type.Id;
            var db = Database.Open();
            db.Story.Link.DeleteAll(db.Story.Link.NodeARef == link.NodeA.Id 
                && db.Story.Link.NodeAType == link.NodeA.NodeType.Id 
                && db.Story.Link.NodeBRef == link.NodeB.Id 
                && db.Story.Link.NodeBType == link.NodeB.NodeType.Id
                && db.Story.Link.LinkTypeRef == linkTypeRef
                );
        }

        private LinkTableRow MapRow(ILink arg)
        {
            return new LinkTableRow
            {
                NodeARef = arg.NodeA.Id,
                NodeAType = arg.NodeA.NodeType.Id,
                NodeBRef = arg.NodeB.Id,
                NodeBType = arg.NodeB.NodeType.Id,
                LinkDirection = (int)arg.Direction,
                LinkStrength = arg.Strength,
                LinkTypeRef = arg.Type == null ? 0 :arg.Type.Id

            };
        }


        
    }
}

using Microsoft.Data.Entity.Metadata;

namespace Storyboard.Data.DbObject
{
    /// <summary>
    /// Representation of the Link Table row
    /// </summary>
    public class LinkTableRow
    {
        public int Id { get; set; }
        public int NodeARef { get; set; }
        public byte NodeAType { get; set; }
        public int NodeBRef { get; set; }
        public byte NodeBType { get; set; }
        public double LinkStrength { get; set; }
        public int LinkTypeRef { get; set; }
        public byte LinkDirection { get; set; }
    }
}

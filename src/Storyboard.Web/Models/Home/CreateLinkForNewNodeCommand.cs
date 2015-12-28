namespace Storyboard.Web.Models.Home
{
    /// <summary>
    /// Used to attach a link to a new node. New node will be node A 
    /// </summary>
    public class CreateLinkForNewNodeCommand
    {
        public int Direction { get; set; }
        public int NodeBId { get; set; }
        public int NodeBType { get; set; }
        public float Strength { get; set; }
        public int Type { get; set; }
    }
}

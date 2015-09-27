namespace Storyboard.Web.Models.Home
{
    public class CreateLinkRequest
    {
        public int Direction {get; set;}
        public int NodeAId {get; set;}
        public int NodeAType {get; set;}
        public int NodeBId {get; set;}
        public int NodeBType {get; set;}
        public float Strength {get; set;}
        public int Type { get; set; }
    }
}
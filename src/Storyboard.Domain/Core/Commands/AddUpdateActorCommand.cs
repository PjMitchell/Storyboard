namespace Storyboard.Domain.Core.Commands
{
    public class AddUpdateActorCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

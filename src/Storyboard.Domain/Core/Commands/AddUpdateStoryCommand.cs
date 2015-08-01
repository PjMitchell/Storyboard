
namespace Storyboard.Domain.Core.Commands
{
    /// <summary>
    /// Command for the creation of a new story
    /// </summary>
    public class AddUpdateStoryCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
    }
}

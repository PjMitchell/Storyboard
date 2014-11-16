namespace Storyboard.Domain.Models
{
    /// <summary>
    /// Poco representing a summary of the story
    /// </summary>
    public class StorySummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
    }
}
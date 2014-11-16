using Storyboard.Domain.Models;
using System.Collections.Generic;
namespace Storyboard.Domain.Services
{
    /// <summary>
    /// Composes stories
    /// </summary>
    public interface IStoryReadService
    {
        /// <summary>
        /// Gets requested story overview
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StoryOverview</returns>
        StoryOverview GetStoryOverview(int id);

        /// <summary>
        /// Gets requested story Summary
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StorySummary</returns>
        StorySummary GetStorySummary(int id);

        /// <summary>
        /// Gets all story summaries
        /// </summary>
        /// <returns>All story summaries</returns>
        IEnumerable<StorySummary> GetStorySummaries();
    }
}

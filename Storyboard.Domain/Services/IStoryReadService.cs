using Storyboard.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<StoryOverview> GetStoryOverview(int id);

        /// <summary>
        /// Gets requested story Summary
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StorySummary</returns>
        Task<StorySummary> GetStorySummary(int id);

        /// <summary>
        /// Gets all story summaries
        /// </summary>
        /// <returns>All story summaries</returns>
        Task<List<StorySummary>> GetStorySummaries();
    }
}

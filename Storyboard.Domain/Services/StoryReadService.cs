using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Domain.Services
{
    /// <summary>
    /// Composes stories
    /// </summary>
    public class StoryReadService : IStoryReadService
    {
        private IStoryRepository storyRepository;
        private INodeService nodeService;

        public StoryReadService(IStoryRepository storyRepository, INodeService nodeService)
        {
            this.storyRepository = storyRepository;
            this.nodeService = nodeService;
        }
        
        /// <summary>
        /// Gets requested story overview
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StoryOverview</returns>
        public StoryOverview GetStoryOverview(int id)
        {
            var result = new StoryOverview();
            result.Summary = GetStorySummary(id);
            result.Actors = nodeService.Get(new Node(id, StoryboardNodeTypes.Story), StoryboardNodeTypes.Actor).OfType<Actor>().ToList();
            return result;
        }

        /// <summary>
        /// Gets requested story Summary
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StorySummary</returns>
        public StorySummary GetStorySummary(int id)
        {
            return MapToOverviewSummary(storyRepository.Get(id));
        }


        /// <summary>
        /// Gets all story summaries
        /// </summary>
        /// <returns>All story summaries</returns>
        public IEnumerable<StorySummary> GetStorySummaries()
        {
            return storyRepository.Get().Select(MapToOverviewSummary);
        }

        private StorySummary MapToOverviewSummary(Story arg)
        {
            return new StorySummary
            {
                Id = arg.Id,
                Synopsis = arg.Synopsis,
                Title = arg.Title
            };
        }
    }
}

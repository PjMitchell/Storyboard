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
        private IAsyncNodeService nodeService;

        public StoryReadService(IStoryRepository storyRepository, IAsyncNodeService nodeService)
        {
            this.storyRepository = storyRepository;
            this.nodeService = nodeService;
        }
        
        /// <summary>
        /// Gets requested story overview
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StoryOverview</returns>
        public async Task<StoryOverview> GetStoryOverview(int id)
        {
            var result = new StoryOverview();
            var getSummary = GetStorySummary(id);
            var getActor = nodeService.Get(new Node(id, StoryboardNodeTypes.Story), StoryboardNodeTypes.Actor);
            result.Summary = await getSummary;
            result.Actors = await getActor;
            return result;
        }

        /// <summary>
        /// Gets requested story Summary
        /// </summary>
        /// <param name="id">Story Id</param>
        /// <returns>Requested StorySummary</returns>
        public async Task<StorySummary> GetStorySummary(int id)
        {
            var story = await storyRepository.GetAsync(id);
            return MapToOverviewSummary(story);
        }


        /// <summary>
        /// Gets all story summaries
        /// </summary>
        /// <returns>All story summaries</returns>
        public async Task<List<StorySummary>> GetStorySummaries()
        {
            var stories = await storyRepository.GetAsync();
            return stories.Select(MapToOverviewSummary).ToList();
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

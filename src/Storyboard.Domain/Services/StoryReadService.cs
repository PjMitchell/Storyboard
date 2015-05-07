using HDLink;
using Storyboard.Domain.Core;
using Storyboard.Domain.Data;
using Storyboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IStorySectionRepository storySectionRepository;

        public StoryReadService(IStoryRepository storyRepository, IAsyncNodeService nodeService, IStorySectionRepository storySectionRepository)
        {
            this.storyRepository = storyRepository;
            this.nodeService = nodeService;
            this.storySectionRepository = storySectionRepository;
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
            var getStorySections = storySectionRepository.GetTreeForStory(id);
            var getActor = nodeService.Get(new Node(id, StoryboardNodeTypes.Story), StoryboardNodeTypes.Actor);
            var tree = await getStorySections;
            
            result.Summary = await getSummary;
            result.Actors = await getActor;
            if (tree != null && tree.Hierarchies.Count != 0)
            {
                if (tree.Hierarchies.Count != 1)
                    throw new InvalidOperationException("Multiple Hierarchical levels not supported");
                result.Sections = tree.GetHierarchicalLevel(tree.Hierarchies[0]).ToList();
            }
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
